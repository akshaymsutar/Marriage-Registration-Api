using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistrationApi.Entities;

namespace MarriageRegistrationApi.Factory
{
    public class RequestFactory
    {
        public static GetItemRequest CreateScanItemRequest(string id, string TableName)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "ApplicationId", new AttributeValue { S = id } } }
            };

            return request;
        }

        public static DeleteItemRequest CreateDeleteRequest(string id, string TableName)
        {
            var request = new DeleteItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "ApplicationId", new AttributeValue { S = id.ToString() } } }
            };

            return request;
        }

        public static ScanRequest CreateScanItemRequest(string TableName)
        {
            var request = new ScanRequest
            {
                TableName = TableName,
            };

            return request;
        }

        
        public static PutItemRequest CreatePutItemRequest(string approvedRequestsTableName, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            string ApprovalDate = DateTime.UtcNow.ToString("dd/MM/yyyy");
            var request = new PutItemRequest
            {
                TableName = approvedRequestsTableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "ApplicationId", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicationId.ToString() }},
                    { "DocumentStatus", new AttributeValue { S = "Approved" }},
                    { "CertificateNumber", new AttributeValue { S = marriageRegistrationRequestEntity.CertificateNumber }},
                    { "ApprovalDate" , new AttributeValue { S =  ApprovalDate }},
                    { "ApplicantState", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantState }},
                    { "ApplicantDivision", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDivision }},
                    { "ApplicantDistrict", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDistrict }},
                    { "Hospital", new AttributeValue { S = marriageRegistrationRequestEntity.Hospital }},
                    { "ApplicantTaluka", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantTaluka }},
                    { "MarriageDate", new AttributeValue { S = marriageRegistrationRequestEntity.MarriageDate.ToString() }},
                    { "MarriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarriagePlace }},
                    { "MarathiMarriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiMarriagePlace }},
                    { "LawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.LawOfMarriage }},
                    { "MarathiLawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiLawOfMarriage }},
                    { "DocumentsPresented", new AttributeValue { S = marriageRegistrationRequestEntity.DocumentsPresented }},
                    { "IsMarriageRegisteredAlready", new AttributeValue { BOOL = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready }},
                    { "SubmissionDate", new AttributeValue { S = marriageRegistrationRequestEntity.SubmissionDate.ToString() }},

                    { "HusbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandFirstName }},
                    { "HusbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandMiddleName }},
                    { "HusbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandLastName }},
                    { "MarathiHusbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandFirstName }},
                    { "MarathiHusbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandMiddleName } },
                    { "MarathiHusbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandLastName } },
                    { "UidOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfHusband }},
                    { "OtherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfHusband }},
                    { "MarathiOtherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfHusband }},
                    { "ReligionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfHusband }},
                    { "ReligionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband }},
                    { "MarathiReligionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfHusband }},
                    { "MarathiReligionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfHusband }},
                    { "AgeOfHusbandYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Years }},
                    { "AgeOfHusbandMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Months }},
                    { "OccupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress }},
                    { "MarathiOccupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfHusbandWithAddress }},
                    { "StatusOfHusbandAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage }},
                    { "AddressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfHusband }},
                    { "MarathiAddressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfHusband }},

                    { "WifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeFirstName }},
                    { "WifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeMiddleName }},
                    { "WifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeLastName }},
                    { "MarathiWifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeFirstName }},
                    { "MarathiWifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeMiddleName }},
                    { "MarathiWifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeLastName }},
                    { "UidOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWife }},
                    { "OtherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfWife }},
                    { "MarathiOtherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfWife }},
                    { "ReligionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfWife }},
                    { "ReligionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife }},
                    { "MarathiReligionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfWife }},
                    { "MarathiReligionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfWife }},
                    { "AgeOfWifeYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Years}},
                    { "AgeOfWifeMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Months}},
                    { "StatusOfWifeAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage }},
                    { "AddressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage }},
                    { "MarathiAddressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWifeBeforeMarriage }},

                    { "NameofWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness1 }},
                    { "UidOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness1 }},
                    { "AddressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness1 }},
                    { "OccupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress }},
                    { "RelationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1 }},
                    { "MarathiNameofWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness1 }},
                    { "MarathiAddressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness1 }},
                    { "MarathiOccupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness1WithAddress }},
                    { "MarathiRelationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness1 }},
                    { "NameofWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness2 }},
                    { "UidOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness2 }},
                    { "AddressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness2 }},
                    { "OccupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress }},
                    { "RelationWithCoupleOfWitness2", new AttributeValue { S =marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2 }},
                    { "MarathiNameofWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness2 }},
                    { "MarathiAddressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness2 }},
                    { "MarathiOccupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness2WithAddress }},
                    { "MarathiRelationWithCoupleOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness2 }},
                    { "NameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.NameOfWitness3 }},
                    { "UidOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness3 }},
                    { "AddressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness3 }},
                    { "OccupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress }},
                    { "RelationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3 }},
                    { "MarathiNameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameOfWitness3 }},
                    { "MarathiAddressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness3 }},
                    { "MarathiOccupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness3WithAddress }},
                    { "MarathiRelationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness3 }},

                    { "PriestName", new AttributeValue { S = marriageRegistrationRequestEntity.PriestName }},
                    { "PriestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAddress }},
                    { "PriestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.PriestReligion }},
                    { "MarathiPriestName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestName }},
                    { "MarathiPriestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestAddress }},
                    { "MarathiPriestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestReligion }},
                    { "PriestAge", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAge }},

                }
            };

            return request;
        }

       

        public static PutItemRequest CreatePutItemRequest(MarriageRegistrationRequestEntity marriageRegistrationRequestEntity, string TableName)
        {
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "ApplicationId", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicationId.ToString() }},
                    { "CertificateNumber", new AttributeValue { S = marriageRegistrationRequestEntity.CertificateNumber }},
                    { "DocumentStatus", new AttributeValue { S = marriageRegistrationRequestEntity.DocumentStatus }},
                    { "ApprovalDate", new AttributeValue { S = marriageRegistrationRequestEntity.ApprovalDate }},
                    { "ApplicantState", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantState }},
                    { "ApplicantDivision", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDivision }},
                    { "ApplicantDistrict", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDistrict }},
                    { "Hospital", new AttributeValue { S = marriageRegistrationRequestEntity.Hospital }},
                    { "ApplicantTaluka", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantTaluka }},
                    { "MarriageDate", new AttributeValue { S = marriageRegistrationRequestEntity.MarriageDate.ToString() }},
                    { "MarriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarriagePlace }},
                    { "MarathiMarriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiMarriagePlace }},
                    { "LawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.LawOfMarriage }},
                    { "MarathiLawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiLawOfMarriage }},
                    { "DocumentsPresented", new AttributeValue { S = marriageRegistrationRequestEntity.DocumentsPresented }},
                    { "IsMarriageRegisteredAlready", new AttributeValue { BOOL = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready }},
                    { "SubmissionDate", new AttributeValue { S = marriageRegistrationRequestEntity.SubmissionDate.ToString() }},

                    { "HusbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandFirstName }},
                    { "HusbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandMiddleName }},
                    { "HusbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandLastName }},
                    { "MarathiHusbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandFirstName }},
                    { "MarathiHusbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandMiddleName } },
                    { "MarathiHusbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandLastName } },
                    { "UidOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfHusband }},
                    { "OtherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfHusband }},
                    { "MarathiOtherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfHusband }},
                    { "ReligionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfHusband }},
                    { "ReligionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband }},
                    { "MarathiReligionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfHusband }},
                    { "MarathiReligionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfHusband }},
                    { "AgeOfHusbandYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Years }},
                    { "AgeOfHusbandMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Months }},
                    { "OccupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress }},
                    { "MarathiOccupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfHusbandWithAddress }},
                    { "StatusOfHusbandAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage }},
                    { "AddressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfHusband }},
                    { "MarathiAddressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfHusband }},

                    { "WifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeFirstName }},
                    { "WifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeMiddleName }},
                    { "WifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeLastName }},
                    { "MarathiWifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeFirstName }},
                    { "MarathiWifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeMiddleName }},
                    { "MarathiWifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeLastName }},
                    { "UidOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWife }},
                    { "OtherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfWife }},
                    { "MarathiOtherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfWife }},
                    { "ReligionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfWife }},
                    { "ReligionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife }},
                    { "MarathiReligionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfWife }},
                    { "MarathiReligionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfWife }},
                    { "AgeOfWifeYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Years}},
                    { "AgeOfWifeMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Months }},
                    { "StatusOfWifeAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage }},
                    { "AddressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage }},
                    { "MarathiAddressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWifeBeforeMarriage }},

                    { "NameofWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness1 }},
                    { "UidOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness1 }},
                    { "AddressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness1 }},
                    { "OccupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress }},
                    { "RelationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1 }},
                    { "MarathiNameofWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness1 }},
                    { "MarathiAddressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness1 }},
                    { "MarathiOccupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness1WithAddress }},
                    { "MarathiRelationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness1 }},
                    { "NameofWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness2 }},
                    { "UidOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness2 }},
                    { "AddressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness2 }},
                    { "OccupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress }},
                    { "RelationWithCoupleOfWitness2", new AttributeValue { S =marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2 }},
                    { "MarathiNameofWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness2 }},
                    { "MarathiAddressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness2 }},
                    { "MarathiOccupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness2WithAddress }},
                    { "MarathiRelationWithCoupleOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness2 }},
                    { "NameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.NameOfWitness3 }},
                    { "UidOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness3 }},
                    { "AddressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness3 }},
                    { "OccupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress }},
                    { "RelationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3 }},
                    { "MarathiNameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameOfWitness3 }},
                    { "MarathiAddressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness3 }},
                    { "MarathiOccupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness3WithAddress }},
                    { "MarathiRelationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness3 }},

                    { "PriestName", new AttributeValue { S = marriageRegistrationRequestEntity.PriestName }},
                    { "PriestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAddress }},
                    { "PriestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.PriestReligion }},
                    { "MarathiPriestName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestName }},
                    { "MarathiPriestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestAddress }},
                    { "MarathiPriestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestReligion }},
                    { "PriestAge", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAge }},

                }
            };

            return request;
        }






        public static GetItemRequest CreateApprovedRequest(string id, string TableName)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "CertificateNumber", new AttributeValue { S = id } } }
            };

            return request;
        }
        private static AgeEntity GetAge(AgeEntity age)
        {
            var ageEntity = new AgeEntity
            {
                Years = age.Years,
                Months = age.Months
            };
            return ageEntity;
        }


        public static UpdateItemRequest CreateUpdateItemRequest(MarriageRegistrationRequestEntity marriageRegistrationRequestEntity, string TableName)
        {
            
            var request = new UpdateItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "ApplicationId", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicationId.ToString() }},

                },
                AttributeUpdates = new Dictionary<string, AttributeValueUpdate>() 
                {
                    
                    {"UidOfHusband",new AttributeValueUpdate{Action="PUT",Value=new AttributeValue{S = marriageRegistrationRequestEntity.UidOfHusband}} }

                }

            };

            return request;
        }


    }
}
