using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistrationApi.Entities;

namespace MarriageRegistrationApi.DataAccess
{
    public interface IDataContext
    {
        public Task<PutItemResponse> SaveDetails(PutItemRequest request, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity);

        public Task<GetItemResponse> GetItemDetails(GetItemRequest request);

        public Task<DeleteItemResponse> DeleteDetails(DeleteItemRequest request);

        public Task<ScanResponse> GetPendingRecords(ScanRequest request);

        public Task<PutItemResponse> PutItem(PutItemRequest request);

        public Task<ScanResponse> GetApprovedRecords(ScanRequest request);

        public Task<UpdateItemResponse> UpdateRecord(UpdateItemRequest request);

        
    }
}
