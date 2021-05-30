using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MarriageRegistrationApi.DataAccess;
using MarriageRegistrationApi.Entities;
using MarriageRegistrationApi.Factory;
using MarriageRegistrationApi.Services;
using MarriageRegistrationApi.Models;
using Microsoft.AspNetCore.Mvc;
using MarriageRegistrationApi.Services.LoginValidation;
using MarriageRegistrationApi.Configure;

namespace MarriageRegistration.WebApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IDataContext _context;

        private readonly IdGenerator _idGenerator;

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        private readonly IValidateLogin _validateLogin;

        private const string PendingRequestsTableName = "PendingRequests";

        private const string ApprovedRequestsTableName = "ApprovedRequests";

        public AdminController(IDataContext context, IAmazonDynamoDB amazonDynamoDb, IdGenerator idGenerator, IValidateLogin validateLogin)
        {
            _context = context;
            _amazonDynamoDb = amazonDynamoDb;
            _idGenerator = idGenerator;
            _validateLogin = validateLogin;
        }

        // GET api/Admin/init
        [HttpGet]
        [Route("init")]
        public async Task Initialise()
        {
            var request = new ListTablesRequest
            {
                Limit = 10
            };

            var response = await _amazonDynamoDb.ListTablesAsync(request);

            var results = response.TableNames;

            if (!results.Contains(ApprovedRequestsTableName))
            {
                var createRequest = new CreateTableRequest
                {
                    TableName = ApprovedRequestsTableName,
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition
                        {
                            AttributeName = "CertificateNumber",
                            AttributeType = "S"
                        }
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "CertificateNumber",
                            KeyType = "HASH"  //Partition key
                        }
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 2,
                        WriteCapacityUnits = 2
                    }
                };

                await _amazonDynamoDb.CreateTableAsync(createRequest);
            }
        }

        // GET api/Admin/getallpendingrecords
        [HttpPost]
        [Route("getallpendingrecords")]
        public async Task<List<MarriageRegistrationResponseEntity>> GetPendingRequests(GetAllRequestsRequestModel getAllRequestsRequestModel)
        {
            var request = RequestFactory.CreateScanItemRequest(PendingRequestsTableName);

            var response = await _context.GetPendingRecords(request);

            return ResponseFactory.CreateScanResponse(response, getAllRequestsRequestModel);
        }

        // GET api/Admin/getallapprovedrecords
        [HttpPost]
        [Route("getallapprovedrecords")]
        public async Task<List<MarriageRegistrationResponseEntity>> GetApprovedRecords(GetAllRequestsRequestModel getAllRequestsRequestModel)
        {
            var request = RequestFactory.CreateScanItemRequest(ApprovedRequestsTableName);

            var response = await _context.GetApprovedRecords(request);

            return ResponseFactory.CreateScanResponse(response, getAllRequestsRequestModel);
        }

        // GET api/Admin/pendingrecords/{id}
        [HttpGet]
        [Route("pendingrecords/{ApplicationId}")]
        public async Task<MarriageRegistrationResponseEntity> GetPendingRequestDetails(string ApplicationId)
        {
            var request = RequestFactory.CreateScanItemRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetItemDetails(request);

            return ResponseFactory.CreateGetItemResponse(response, PendingRequestsTableName);
        }

        // GET api/admin/approvedrecords/{CertificateId}
        [HttpGet]
        [Route("approvedrecords")]
        public async Task<MarriageRegistrationResponseEntity> GetApprovedRequestDetails([FromQuery] string CertificateId)
        {
            
            var request = RequestFactory.CreateApprovedRequest(CertificateId, ApprovedRequestsTableName);

            var response = await _context.GetItemDetails(request);

            return ResponseFactory.CreateGetItemResponse(response, ApprovedRequestsTableName);
        }

        // DELETE api/admin/reject/{ApplicationId}
        [HttpDelete]
        [Route("reject/{ApplicationId}")]
        public async Task<IActionResult> DeletePendingRequest(string ApplicationId)
        {

            var request = RequestFactory.CreateDeleteRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.DeleteDetails(request);

            return StatusCode((int)response.HttpStatusCode);
        }

        // DELETE api/admin/approve/{ApplicationId}
        [HttpPost]
        [Route("approve/{ApplicationId}")]
        public async Task<string> ApproveRequest(string ApplicationId)
        {
            var request = RequestFactory.CreateScanItemRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetItemDetails(request);

            var recordToApprove = ResponseFactory.CreateGetItemResponse(response, PendingRequestsTableName);

            var CertificateNumber = await _idGenerator.GenerateCertificateNumber(recordToApprove.Hospital);
            
            var marriageRegistrationRequestEntity = ModelFactory.GetApproveRequestEntity(CertificateNumber, recordToApprove);

            var requestToApprove = RequestFactory.CreatePutItemRequest(ApprovedRequestsTableName,marriageRegistrationRequestEntity);

            var responseOfApprove = await _context.SaveDetails(requestToApprove, marriageRegistrationRequestEntity);

            var deleteRequest = RequestFactory.CreateDeleteRequest(ApplicationId, PendingRequestsTableName);

            var deleteResponse = await _context.DeleteDetails(deleteRequest);

            //return ModelFactory.CreateResponse(requestOfApprove, marriageRegistrationRequestEntity);

            return CertificateNumber;
        }

        // POST api/admin/postupdatedetails
        [HttpPost]
        [Route("postupdatedetails")]
        public async Task<UpdateItemResponse> PostUpdateDetails(UpdateDetailsInputModel updateDetailsInputModel)
        {
           //string ApplicationId = IdGenerator.GenerateApplicationId();

            var marriageRegistrationRequestEntity = ModelFactory.GetUpdateItemRequestEntity(updateDetailsInputModel);

            var request = RequestFactory.CreateUpdateItemRequest(marriageRegistrationRequestEntity, PendingRequestsTableName);

            var response = await _context.UpdateRecord(request);

            //return ResponseFactory.CreateUpdateItemResponse(response);
            return response;
        }

        // POST api/admin/login
        [HttpPost]
        [Route("login")]
        public async Task<LoginResponseModel> ValidateLogin(LoginRequestModel loginRequestModel)
        {
            ConfigureValues configureValues = new ConfigureValues();

            var loginValidationModel = configureValues.LoadLoginDetails(loginRequestModel.UserName);
            
            bool isSuccess = await _validateLogin.loginValidation(loginRequestModel, loginValidationModel);

            return ResponseFactory.CreateLoginResponse(isSuccess, loginValidationModel);
       
        }



    }
}
