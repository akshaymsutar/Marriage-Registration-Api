using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistrationApi.DataAccess;
using MarriageRegistrationApi.Factory;

namespace MarriageRegistrationApi.Services
{
    public class IdGenerator
    {
        private readonly IDataContext _context;

        private static string TableName = "LatestCertificateNumber";

        public IdGenerator(IDataContext context)
        {
            _context = context;
        }

        public static string GenerateApplicationId()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task<string> GenerateCertificateNumber(string Hospital)
        {
            var CerificateInitial = GenerateCertificateInitial(Hospital);

            var Number = await GetCertificateNumber(TableName);

            var CertificateNumber = CerificateInitial + "/"+ Number;


            return CertificateNumber;
                
        }

        private async Task<string> GetCertificateNumber(string TableName)
        {
            //string Number = "1";
            //await StoreCertificateNumber(Number);
            var request = RequestFactory.CreateScanItemRequest(TableName);
            var response = await _context.GetPendingRecords(request);
            var Number1 =  CreateScanResponse(response);
            //string substr1 = CertificateNumber1.Substring(0,15);
            //string substr2 = CertificateNumber1.Substring(CertificateNumber1.Length - 3);
            
            int id = int.Parse(Number1);
           
            id++;

            var Number2 = id.ToString();

            //var CertificateNumber2 = substr1 + substr2;
            var deleteRequest = CreateDeleteRequest(Number1);

            var deleteResponse = await _context.DeleteDetails(deleteRequest);

            await StoreCertificateNumber(Number2);

            return Number2;
        }

        private async Task<PutItemResponse> StoreCertificateNumber(string certificateNumber)
        {
            var request = CreatePutRequest(certificateNumber);

            var response = await _context.PutItem(request);

            return response;
        }

        public static string CreateScanResponse(ScanResponse response)
        {
            string CertificateNumber = string.Empty;
            foreach (var item in response.Items)
            {
                CertificateNumber = item["CertificateNumber"].S;
            }
           
            return CertificateNumber;
        }

        public static PutItemRequest CreatePutRequest(string id)
        {
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "CertificateNumber", new AttributeValue { S = id.ToString() }},
                }
            };

            return request;
        }

        public static DeleteItemRequest CreateDeleteRequest(string id)
        {
            var request = new DeleteItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "CertificateNumber", new AttributeValue { S = id.ToString() } } }
                
            };

            return request;
        }

        private string GenerateCertificateInitial(string Hospital)
        {
            
            string result = string.Empty;
            string[] strSplit = Hospital.Split();
            foreach (string res in strSplit)
            {

                result = result + res.Substring(0, 1).ToUpper();
            }

            return result;
        }

    }
}
