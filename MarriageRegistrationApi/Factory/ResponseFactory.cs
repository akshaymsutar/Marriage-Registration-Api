using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistrationApi.Entities;
using MarriageRegistrationApi.Models;

namespace MarriageRegistrationApi.Factory
{
    public class ResponseFactory
    {

        public static MarriageRegistrationResponseEntity CreateResponse(PutItemResponse response, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                //Application Details
                ApplicationId = marriageRegistrationRequestEntity.ApplicationId,
                CertificateNumber = marriageRegistrationRequestEntity.CertificateNumber,
                DocumentStatus = marriageRegistrationRequestEntity.DocumentStatus,
                ApprovalDate = marriageRegistrationRequestEntity.ApprovalDate,
                ApplicantState = marriageRegistrationRequestEntity.ApplicantState,
                ApplicantDivision = marriageRegistrationRequestEntity.ApplicantDivision,
                ApplicantDistrict = marriageRegistrationRequestEntity.ApplicantDistrict,
                Hospital = marriageRegistrationRequestEntity.Hospital,
                ApplicantTaluka = marriageRegistrationRequestEntity.ApplicantTaluka,
                MarriageDate = marriageRegistrationRequestEntity.MarriageDate,
                MarriagePlace = marriageRegistrationRequestEntity.MarriagePlace,
                MarathiMarriagePlace = marriageRegistrationRequestEntity.MarathiMarriagePlace,
                LawOfMarriage = marriageRegistrationRequestEntity.LawOfMarriage,
                MarathiLawOfMarriage = marriageRegistrationRequestEntity.MarathiLawOfMarriage,
                DocumentsPresented = marriageRegistrationRequestEntity.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready,
                SubmissionDate = marriageRegistrationRequestEntity.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageRegistrationRequestEntity.HusbandFirstName,
                HusbandMiddleName = marriageRegistrationRequestEntity.HusbandMiddleName,
                HusbandLastName = marriageRegistrationRequestEntity.HusbandLastName,
                MarathiHusbandFirstName = marriageRegistrationRequestEntity.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = marriageRegistrationRequestEntity.MarathiHusbandMiddleName,
                MarathiHusbandLastName = marriageRegistrationRequestEntity.MarathiHusbandLastName,
                UidOfHusband = marriageRegistrationRequestEntity.UidOfHusband,
                OtherNameOfHusband = marriageRegistrationRequestEntity.OtherNameOfHusband,
                MarathiOtherNameOfHusband = marriageRegistrationRequestEntity.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = marriageRegistrationRequestEntity.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = marriageRegistrationRequestEntity.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(marriageRegistrationRequestEntity.AgeOfHusband),
                OccupationOfHusbandWithAddress = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageRegistrationRequestEntity.AddressOfHusband,
                MarathiAddressOfHusband = marriageRegistrationRequestEntity.MarathiAddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageRegistrationRequestEntity.WifeFirstName,
                WifeMiddleName = marriageRegistrationRequestEntity.WifeMiddleName,
                WifeLastName = marriageRegistrationRequestEntity.WifeLastName,
                MarathiWifeFirstName = marriageRegistrationRequestEntity.MarathiWifeFirstName,
                MarathiWifeMiddleName = marriageRegistrationRequestEntity.MarathiWifeMiddleName,
                MarathiWifeLastName = marriageRegistrationRequestEntity.MarathiWifeLastName,
                UidOfWife = marriageRegistrationRequestEntity.UidOfWife,
                OtherNameOfWife = marriageRegistrationRequestEntity.OtherNameOfWife,
                MarathiOtherNameOfWife = marriageRegistrationRequestEntity.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = marriageRegistrationRequestEntity.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = marriageRegistrationRequestEntity.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(marriageRegistrationRequestEntity.AgeOfWife),
                StatusOfWifeAtMarriage = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = marriageRegistrationRequestEntity.MarathiAddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = marriageRegistrationRequestEntity.NameofWitness1,
                UidOfWitness1 = marriageRegistrationRequestEntity.UidOfWitness1,
                AddressOfWitness1 = marriageRegistrationRequestEntity.AddressOfWitness1,
                OccupationOfWitness1WithAddress = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1,
                NameofWitness2 = marriageRegistrationRequestEntity.NameofWitness2,
                UidOfWitness2 = marriageRegistrationRequestEntity.UidOfWitness2,
                AddressOfWitness2 = marriageRegistrationRequestEntity.AddressOfWitness2,
                OccupationOfWitness2WithAddress = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2,
                NameOfWitness3 = marriageRegistrationRequestEntity.NameOfWitness3,
                UidOfWitness3 = marriageRegistrationRequestEntity.UidOfWitness3,
                AddressOfWitness3 = marriageRegistrationRequestEntity.AddressOfWitness3,
                OccupationOfWitness3WithAddress = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3,

                MarathiNameofWitness1 = marriageRegistrationRequestEntity.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = marriageRegistrationRequestEntity.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = marriageRegistrationRequestEntity.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = marriageRegistrationRequestEntity.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = marriageRegistrationRequestEntity.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = marriageRegistrationRequestEntity.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageRegistrationRequestEntity.PriestName,
                PriestAddress = marriageRegistrationRequestEntity.PriestAddress,
                PriestReligion = marriageRegistrationRequestEntity.PriestReligion,
                PriestAge = marriageRegistrationRequestEntity.PriestAge,
                MarathiPriestName = marriageRegistrationRequestEntity.MarathiPriestName,
                MarathiPriestAddress = marriageRegistrationRequestEntity.MarathiPriestAddress,
                MarathiPriestReligion = marriageRegistrationRequestEntity.MarathiPriestReligion,


            };

            return marriageRegistrationResponseEntity;
        }

        public  static LoginResponseModel CreateLoginResponse(bool isSuccess, LoginDetailsConfigureModel loginValidationModel)
        {
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            if (isSuccess)
            {
                loginResponseModel.isSuccess = isSuccess;
                loginResponseModel.Division = loginValidationModel.Division;
                loginResponseModel.District = loginValidationModel.District;
                loginResponseModel.Hospital = loginValidationModel.Hospital;
            }
            else
            {
                loginResponseModel.isSuccess = false;
            }
            return loginResponseModel;
        }

        public static MarriageRegistrationResponseEntity CreateUpdateItemResponse(UpdateItemResponse response)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
               // marriageRegistrationResponseEntity.AddressOfHusband = response.
            };
            return marriageRegistrationResponseEntity;
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
        public static List<MarriageRegistrationResponseEntity> CreateScanResponse(ScanResponse response, GetAllRequestsRequestModel pendingRequestsRequestModel)
        {
            List<MarriageRegistrationResponseEntity> marriageRegistrationResponseEntity = new List<MarriageRegistrationResponseEntity>();
            foreach (var item in response.Items)
            {
                if (item["ApplicantDivision"].S == pendingRequestsRequestModel.Division &&
                    item["ApplicantDistrict"].S == pendingRequestsRequestModel.District &&
                    item["Hospital"].S == pendingRequestsRequestModel.Hospital)
                {
                    marriageRegistrationResponseEntity.Add(GetResult(item));
                }
                
            }
            return marriageRegistrationResponseEntity;
        }

        private static MarriageRegistrationResponseEntity GetResult(Dictionary<string, AttributeValue> Item)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity()
            {
                //Application Details
                ApplicationId = Item["ApplicationId"].S,
                CertificateNumber = Item["CertificateNumber"].S,
                DocumentStatus = Item["DocumentStatus"].S,
                ApprovalDate =Item["ApprovalDate"].S,
                ApplicantState = Item["ApplicantState"].S,
                ApplicantDivision = Item["ApplicantDivision"].S,
                ApplicantDistrict = Item["ApplicantDistrict"].S,
                Hospital = Item["Hospital"].S,
                ApplicantTaluka = Item["ApplicantTaluka"].S,
                MarriageDate = Item["MarriageDate"].S,
                MarriagePlace = Item["MarriagePlace"].S,
                LawOfMarriage = Item["LawOfMarriage"].S,
                MarathiMarriagePlace = Item["MarathiMarriagePlace"].S,
                MarathiLawOfMarriage = Item["MarathiLawOfMarriage"].S,
                DocumentsPresented = Item["DocumentsPresented"].S,
                IsMarriageRegisteredAlready = Item["IsMarriageRegisteredAlready"].BOOL,
                SubmissionDate = Item["SubmissionDate"].S,

                //Husbands's Details
                HusbandFirstName = Item["HusbandFirstName"].S,
                HusbandMiddleName = Item["HusbandMiddleName"].S,
                HusbandLastName = Item["HusbandLastName"].S,
                MarathiHusbandFirstName = Item["MarathiHusbandFirstName"].S,
                MarathiHusbandMiddleName = Item["MarathiHusbandMiddleName"].S,
                MarathiHusbandLastName = Item["MarathiHusbandLastName"].S,
                UidOfHusband = Item["UidOfHusband"].S,
                OtherNameOfHusband = Item["OtherNameOfHusband"].S,
                ReligionByBirthOfHusband = Item["ReligionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = Item["ReligionByAdoptionOfHusband"].S,
                MarathiOtherNameOfHusband = Item["MarathiOtherNameOfHusband"].S,
                MarathiReligionByBirthOfHusband = Item["MarathiReligionByBirthOfHusband"].S,
                MarathiReligionByAdoptionOfHusband = Item["MarathiReligionByAdoptionOfHusband"].S,
                AgeOfHusband = getAgeEntityResponse(Item["AgeOfHusbandYears"].S, Item["AgeOfHusbandMonths"].S),
                OccupationOfHusbandWithAddress = Item["OccupationOfHusbandWithAddress"].S,
                MarathiOccupationOfHusbandWithAddress = Item["MarathiOccupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = Item["StatusOfHusbandAtMarriage"].S,
                AddressOfHusband = Item["AddressOfHusband"].S,
                MarathiAddressOfHusband = Item["MarathiAddressOfHusband"].S,

                //Wife's Details
                WifeFirstName = Item["WifeFirstName"].S,
                WifeMiddleName = Item["WifeMiddleName"].S,
                WifeLastName = Item["WifeLastName"].S,
                MarathiWifeFirstName = Item["MarathiWifeFirstName"].S,
                MarathiWifeMiddleName = Item["MarathiWifeMiddleName"].S,
                MarathiWifeLastName = Item["MarathiWifeLastName"].S,
                UidOfWife = Item["UidOfWife"].S,
                OtherNameOfWife = Item["OtherNameOfWife"].S,
                ReligionByBirthOfWife = Item["ReligionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = Item["ReligionByAdoptionOfWife"].S,
                MarathiOtherNameOfWife = Item["MarathiOtherNameOfWife"].S,
                MarathiReligionByBirthOfWife = Item["MarathiReligionByBirthOfWife"].S,
                MarathiReligionByAdoptionOfWife = Item["MarathiReligionByAdoptionOfWife"].S,
                AgeOfWife = getAgeEntityResponse(Item["AgeOfWifeYears"].S, Item["AgeOfWifeMonths"].S),
                StatusOfWifeAtMarriage = Item["StatusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = Item["AddressOfWifeBeforeMarriage"].S,
                MarathiAddressOfWifeBeforeMarriage = Item["MarathiAddressOfWifeBeforeMarriage"].S,

                //Witness Details
                NameofWitness1 = Item["NameofWitness1"].S,
                UidOfWitness1 = Item["UidOfWitness1"].S,
                AddressOfWitness1 = Item["AddressOfWitness1"].S,
                OccupationOfWitness1WithAddress = Item["OccupationOfWitness1WithAddress"].S,
                RelationWithCoupleOfWitness1 = Item["RelationWithCoupleOfWitness1"].S,
                NameofWitness2 = Item["NameofWitness2"].S,
                UidOfWitness2 = Item["UidOfWitness2"].S,
                AddressOfWitness2 = Item["AddressOfWitness2"].S,
                OccupationOfWitness2WithAddress = Item["OccupationOfWitness2WithAddress"].S,
                RelationWithCoupleOfWitness2 = Item["RelationWithCoupleOfWitness2"].S,
                NameOfWitness3 = Item["NameOfWitness3"].S,
                UidOfWitness3 = Item["UidOfWitness3"].S,
                AddressOfWitness3 = Item["AddressOfWitness3"].S,
                OccupationOfWitness3WithAddress = Item["OccupationOfWitness3WithAddress"].S,
                RelationWithCoupleOfWitness3 = Item["RelationWithCoupleOfWitness3"].S,

                MarathiNameofWitness1 = Item["MarathiNameofWitness1"].S,

                MarathiAddressOfWitness1 = Item["MarathiAddressOfWitness1"].S,
                MarathiOccupationOfWitness1WithAddress = Item["MarathiOccupationOfWitness1WithAddress"].S,
                MarathiRelationWithCoupleOfWitness1 = Item["MarathiRelationWithCoupleOfWitness1"].S,
                MarathiNameofWitness2 = Item["MarathiNameofWitness2"].S,

                MarathiAddressOfWitness2 = Item["MarathiAddressOfWitness2"].S,
                MarathiOccupationOfWitness2WithAddress = Item["MarathiOccupationOfWitness2WithAddress"].S,
                MarathiRelationWithCoupleOfWitness2 = Item["MarathiRelationWithCoupleOfWitness2"].S,
                MarathiNameOfWitness3 = Item["MarathiNameOfWitness3"].S,

                MarathiAddressOfWitness3 = Item["MarathiAddressOfWitness3"].S,
                MarathiOccupationOfWitness3WithAddress = Item["MarathiOccupationOfWitness3WithAddress"].S,
                MarathiRelationWithCoupleOfWitness3 = Item["MarathiRelationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = Item["PriestName"].S,
                PriestAddress = Item["PriestAddress"].S,
                PriestReligion = Item["PriestReligion"].S,
                PriestAge = Item["PriestAge"].S,
                MarathiPriestName = Item["MarathiPriestName"].S,
                MarathiPriestAddress = Item["MarathiPriestAddress"].S,
                MarathiPriestReligion = Item["MarathiPriestReligion"].S,

            };

            return marriageRegistrationResponseEntity;
        }

        public static AgeEntity getAgeEntityResponse(string ageYears, string ageMonths)
        {
            var ageEntity = new AgeEntity
            {
                Years = ageYears,
                Months = ageMonths,
            };
            return ageEntity;
        }

        public static MarriageRegistrationResponseEntity CreateGetItemResponse(GetItemResponse response, string TableName)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                ApplicationId = response.Item["ApplicationId"].S,
                CertificateNumber = response.Item["CertificateNumber"].S,
                DocumentStatus = response.Item["DocumentStatus"].S,
                ApprovalDate = response.Item["ApprovalDate"].S,
                ApplicantState = response.Item["ApplicantState"].S,
                ApplicantDivision = response.Item["ApplicantDivision"].S,
                ApplicantDistrict = response.Item["ApplicantDistrict"].S,
                Hospital = response.Item["Hospital"].S,
                ApplicantTaluka = response.Item["ApplicantTaluka"].S,
                MarriageDate = response.Item["MarriageDate"].S,
                MarriagePlace = response.Item["MarriagePlace"].S,
                LawOfMarriage = response.Item["LawOfMarriage"].S,
                MarathiMarriagePlace = response.Item["MarathiMarriagePlace"].S,
                MarathiLawOfMarriage = response.Item["MarathiLawOfMarriage"].S,
                DocumentsPresented = response.Item["DocumentsPresented"].S,
                IsMarriageRegisteredAlready = response.Item["IsMarriageRegisteredAlready"].BOOL,
                SubmissionDate = response.Item["SubmissionDate"].S,

                //Husbands's Details
                HusbandFirstName = response.Item["HusbandFirstName"].S,
                HusbandMiddleName = response.Item["HusbandMiddleName"].S,
                HusbandLastName = response.Item["HusbandLastName"].S,
                MarathiHusbandFirstName = response.Item["MarathiHusbandFirstName"].S,
                MarathiHusbandMiddleName = response.Item["MarathiHusbandMiddleName"].S,
                MarathiHusbandLastName = response.Item["MarathiHusbandLastName"].S,
                UidOfHusband = response.Item["UidOfHusband"].S,
                OtherNameOfHusband = response.Item["OtherNameOfHusband"].S,
                ReligionByBirthOfHusband = response.Item["ReligionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = response.Item["ReligionByAdoptionOfHusband"].S,
                MarathiOtherNameOfHusband = response.Item["MarathiOtherNameOfHusband"].S,
                MarathiReligionByBirthOfHusband = response.Item["MarathiReligionByBirthOfHusband"].S,
                MarathiReligionByAdoptionOfHusband = response.Item["MarathiReligionByAdoptionOfHusband"].S,
                AgeOfHusband = getAgeEntityResponse(response.Item["AgeOfHusbandYears"].S, response.Item["AgeOfHusbandMonths"].S),
                OccupationOfHusbandWithAddress = response.Item["OccupationOfHusbandWithAddress"].S,
                MarathiOccupationOfHusbandWithAddress = response.Item["MarathiOccupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = response.Item["StatusOfHusbandAtMarriage"].S,
                AddressOfHusband = response.Item["AddressOfHusband"].S,
                MarathiAddressOfHusband = response.Item["MarathiAddressOfHusband"].S,

                //Wife's Details
                WifeFirstName = response.Item["WifeFirstName"].S,
                WifeMiddleName = response.Item["WifeMiddleName"].S,
                WifeLastName = response.Item["WifeLastName"].S,
                MarathiWifeFirstName = response.Item["MarathiWifeFirstName"].S,
                MarathiWifeMiddleName = response.Item["MarathiWifeMiddleName"].S,
                MarathiWifeLastName = response.Item["MarathiWifeLastName"].S,
                UidOfWife = response.Item["UidOfWife"].S,
                OtherNameOfWife = response.Item["OtherNameOfWife"].S,
                ReligionByBirthOfWife = response.Item["ReligionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = response.Item["ReligionByAdoptionOfWife"].S,
                MarathiOtherNameOfWife = response.Item["MarathiOtherNameOfWife"].S,
                MarathiReligionByBirthOfWife = response.Item["MarathiReligionByBirthOfWife"].S,
                MarathiReligionByAdoptionOfWife = response.Item["MarathiReligionByAdoptionOfWife"].S,
                AgeOfWife = getAgeEntityResponse(response.Item["AgeOfWifeYears"].S, response.Item["AgeOfWifeMonths"].S),
                StatusOfWifeAtMarriage = response.Item["StatusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = response.Item["AddressOfWifeBeforeMarriage"].S,
                MarathiAddressOfWifeBeforeMarriage = response.Item["MarathiAddressOfWifeBeforeMarriage"].S,

                //Witness Details
                NameofWitness1 = response.Item["NameofWitness1"].S,
                UidOfWitness1 = response.Item["UidOfWitness1"].S,
                AddressOfWitness1 = response.Item["AddressOfWitness1"].S,
                OccupationOfWitness1WithAddress = response.Item["OccupationOfWitness1WithAddress"].S,
                RelationWithCoupleOfWitness1 = response.Item["RelationWithCoupleOfWitness1"].S,
                NameofWitness2 = response.Item["NameofWitness2"].S,
                UidOfWitness2 = response.Item["UidOfWitness2"].S,
                AddressOfWitness2 = response.Item["AddressOfWitness2"].S,
                OccupationOfWitness2WithAddress = response.Item["OccupationOfWitness2WithAddress"].S,
                RelationWithCoupleOfWitness2 = response.Item["RelationWithCoupleOfWitness2"].S,
                NameOfWitness3 = response.Item["NameOfWitness3"].S,
                UidOfWitness3 = response.Item["UidOfWitness3"].S,
                AddressOfWitness3 = response.Item["AddressOfWitness3"].S,
                OccupationOfWitness3WithAddress = response.Item["OccupationOfWitness3WithAddress"].S,
                RelationWithCoupleOfWitness3 = response.Item["RelationWithCoupleOfWitness3"].S,

                MarathiNameofWitness1 = response.Item["MarathiNameofWitness1"].S,

                MarathiAddressOfWitness1 = response.Item["MarathiAddressOfWitness1"].S,
                MarathiOccupationOfWitness1WithAddress = response.Item["MarathiOccupationOfWitness1WithAddress"].S,
                MarathiRelationWithCoupleOfWitness1 = response.Item["MarathiRelationWithCoupleOfWitness1"].S,
                MarathiNameofWitness2 = response.Item["MarathiNameofWitness2"].S,

                MarathiAddressOfWitness2 = response.Item["MarathiAddressOfWitness2"].S,
                MarathiOccupationOfWitness2WithAddress = response.Item["MarathiOccupationOfWitness2WithAddress"].S,
                MarathiRelationWithCoupleOfWitness2 = response.Item["MarathiRelationWithCoupleOfWitness2"].S,
                MarathiNameOfWitness3 = response.Item["MarathiNameOfWitness3"].S,

                MarathiAddressOfWitness3 = response.Item["MarathiAddressOfWitness3"].S,
                MarathiOccupationOfWitness3WithAddress = response.Item["MarathiOccupationOfWitness3WithAddress"].S,
                MarathiRelationWithCoupleOfWitness3 = response.Item["MarathiRelationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = response.Item["PriestName"].S,
                PriestAddress = response.Item["PriestAddress"].S,
                PriestReligion = response.Item["PriestReligion"].S,
                PriestAge = response.Item["PriestAge"].S,
                MarathiPriestName = response.Item["MarathiPriestName"].S,
                MarathiPriestAddress = response.Item["MarathiPriestAddress"].S,
                MarathiPriestReligion = response.Item["MarathiPriestReligion"].S,


            };

            return marriageRegistrationResponseEntity;
        }

    }
}
