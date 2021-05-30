using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistrationApi.Entities;
using MarriageRegistrationApi.Models;

namespace MarriageRegistrationApi.Factory
{

    public class ModelFactory
    {
        public static MarriageRegistrationRequestEntity GetPutItemRequestEntity(MarriageDetailsInput marriageDetailsInput, string ApplicationId)
        {
            var marriageRegistrationRequestEntity = new MarriageRegistrationRequestEntity
            {
                //Application Details
                ApplicationId = ApplicationId,
                DocumentStatus = "PendingForApproval",
                CertificateNumber = "Not Yet generated",
                ApprovalDate = "Not Yet Approved",
                ApplicantState = marriageDetailsInput.ApplicantState,
                ApplicantDivision = marriageDetailsInput.ApplicantDivision,
                ApplicantDistrict = marriageDetailsInput.ApplicantDistrict,
                Hospital = marriageDetailsInput.Hospital,
                ApplicantTaluka = marriageDetailsInput.ApplicantTaluka,
                MarriageDate = marriageDetailsInput.MarriageDate,
                MarriagePlace = marriageDetailsInput.MarriagePlace,
                MarathiMarriagePlace = marriageDetailsInput.MarathiMarriagePlace,
                LawOfMarriage = marriageDetailsInput.LawOfMarriage,
                MarathiLawOfMarriage = marriageDetailsInput.MarathiLawOfMarriage,
                DocumentsPresented = marriageDetailsInput.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageDetailsInput.IsMarriageRegisteredAlready,
                SubmissionDate = marriageDetailsInput.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageDetailsInput.HusbandFirstName,
                HusbandMiddleName = marriageDetailsInput.HusbandMiddleName,
                HusbandLastName = marriageDetailsInput.HusbandLastName,
                MarathiHusbandFirstName = marriageDetailsInput.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = marriageDetailsInput.MarathiHusbandMiddleName,
                MarathiHusbandLastName = marriageDetailsInput.MarathiHusbandLastName,
                UidOfHusband = marriageDetailsInput.UidOfHusband,
                OtherNameOfHusband = marriageDetailsInput.OtherNameOfHusband,
                MarathiOtherNameOfHusband = marriageDetailsInput.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = marriageDetailsInput.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = marriageDetailsInput.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageDetailsInput.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = marriageDetailsInput.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(marriageDetailsInput.AgeOfHusband),
                OccupationOfHusbandWithAddress = marriageDetailsInput.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = marriageDetailsInput.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageDetailsInput.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageDetailsInput.AddressOfHusband,
                MarathiAddressOfHusband = marriageDetailsInput.MarathiAddressOfHusband,
                

                //Wife's Details
                WifeFirstName = marriageDetailsInput.WifeFirstName,
                WifeMiddleName = marriageDetailsInput.WifeMiddleName,
                WifeLastName = marriageDetailsInput.WifeLastName,
                MarathiWifeFirstName = marriageDetailsInput.MarathiWifeFirstName,
                MarathiWifeMiddleName = marriageDetailsInput.MarathiWifeMiddleName,
                MarathiWifeLastName = marriageDetailsInput.MarathiWifeLastName,
                UidOfWife = marriageDetailsInput.UidOfWife,
                OtherNameOfWife = marriageDetailsInput.OtherNameOfWife,
                MarathiOtherNameOfWife = marriageDetailsInput.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = marriageDetailsInput.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageDetailsInput.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = marriageDetailsInput.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = marriageDetailsInput.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(marriageDetailsInput.AgeOfWife),
                StatusOfWifeAtMarriage = marriageDetailsInput.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageDetailsInput.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = marriageDetailsInput.MarathiAddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = marriageDetailsInput.NameofWitness1,
                UidOfWitness1 = marriageDetailsInput.UidOfWitness1,
                AddressOfWitness1 = marriageDetailsInput.AddressOfWitness1,
                OccupationOfWitness1WithAddress = marriageDetailsInput.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = marriageDetailsInput.RelationWithCoupleOfWitness1,
                NameofWitness2 = marriageDetailsInput.NameofWitness2,
                UidOfWitness2 = marriageDetailsInput.UidOfWitness2,
                AddressOfWitness2 = marriageDetailsInput.AddressOfWitness2,
                OccupationOfWitness2WithAddress = marriageDetailsInput.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = marriageDetailsInput.RelationWithCoupleOfWitness2,
                NameOfWitness3 = marriageDetailsInput.NameOfWitness3,
                UidOfWitness3 = marriageDetailsInput.UidOfWitness3,
                AddressOfWitness3 = marriageDetailsInput.AddressOfWitness3,
                OccupationOfWitness3WithAddress = marriageDetailsInput.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = marriageDetailsInput.RelationWithCoupleOfWitness3,

                MarathiNameofWitness1 = marriageDetailsInput.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = marriageDetailsInput.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = marriageDetailsInput.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = marriageDetailsInput.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = marriageDetailsInput.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = marriageDetailsInput.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = marriageDetailsInput.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = marriageDetailsInput.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = marriageDetailsInput.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = marriageDetailsInput.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = marriageDetailsInput.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = marriageDetailsInput.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageDetailsInput.PriestName,
                PriestAddress = marriageDetailsInput.PriestAddress,
                PriestReligion = marriageDetailsInput.PriestReligion,
                PriestAge = marriageDetailsInput.PriestAge,
                MarathiPriestName = marriageDetailsInput.MarathiPriestName,
                MarathiPriestAddress = marriageDetailsInput.MarathiPriestAddress,
                MarathiPriestReligion = marriageDetailsInput.MarathiPriestReligion,

            };

            return marriageRegistrationRequestEntity;
        }




        public static MarriageRegistrationRequestEntity GetApproveRequestEntity(string CertificateNumber, MarriageRegistrationResponseEntity marriageRegistrationResponseEntity)
        {
            var marriageRegistrationRequestEntity = new MarriageRegistrationRequestEntity
            {
                //Application Details
                ApplicationId = marriageRegistrationResponseEntity.ApplicationId,
                DocumentStatus = marriageRegistrationResponseEntity.DocumentStatus,
                CertificateNumber = CertificateNumber,
                ApplicantState = marriageRegistrationResponseEntity.ApplicantState,
                ApplicantDivision = marriageRegistrationResponseEntity.ApplicantDivision,
                ApplicantDistrict = marriageRegistrationResponseEntity.ApplicantDistrict,
                Hospital = marriageRegistrationResponseEntity.Hospital,
                ApplicantTaluka = marriageRegistrationResponseEntity.ApplicantTaluka,
                MarriageDate = marriageRegistrationResponseEntity.MarriageDate,
                MarriagePlace = marriageRegistrationResponseEntity.MarriagePlace,
                MarathiMarriagePlace = marriageRegistrationResponseEntity.MarathiMarriagePlace,
                LawOfMarriage = marriageRegistrationResponseEntity.LawOfMarriage,
                MarathiLawOfMarriage = marriageRegistrationResponseEntity.MarathiLawOfMarriage,
                DocumentsPresented = marriageRegistrationResponseEntity.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageRegistrationResponseEntity.IsMarriageRegisteredAlready,
                SubmissionDate = marriageRegistrationResponseEntity.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageRegistrationResponseEntity.HusbandFirstName,
                HusbandMiddleName = marriageRegistrationResponseEntity.HusbandMiddleName,
                HusbandLastName = marriageRegistrationResponseEntity.HusbandLastName,
                MarathiHusbandFirstName = marriageRegistrationResponseEntity.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = marriageRegistrationResponseEntity.MarathiHusbandMiddleName,
                MarathiHusbandLastName = marriageRegistrationResponseEntity.MarathiHusbandLastName,
                UidOfHusband = marriageRegistrationResponseEntity.UidOfHusband,
                OtherNameOfHusband = marriageRegistrationResponseEntity.OtherNameOfHusband,
                MarathiOtherNameOfHusband = marriageRegistrationResponseEntity.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = marriageRegistrationResponseEntity.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = marriageRegistrationResponseEntity.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageRegistrationResponseEntity.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = marriageRegistrationResponseEntity.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(marriageRegistrationResponseEntity.AgeOfHusband),
                OccupationOfHusbandWithAddress = marriageRegistrationResponseEntity.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageRegistrationResponseEntity.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageRegistrationResponseEntity.AddressOfHusband,
                MarathiAddressOfHusband = marriageRegistrationResponseEntity.MarathiAddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageRegistrationResponseEntity.WifeFirstName,
                WifeMiddleName = marriageRegistrationResponseEntity.WifeMiddleName,
                WifeLastName = marriageRegistrationResponseEntity.WifeLastName,
                MarathiWifeFirstName = marriageRegistrationResponseEntity.MarathiWifeFirstName,
                MarathiWifeMiddleName = marriageRegistrationResponseEntity.MarathiWifeMiddleName,
                MarathiWifeLastName = marriageRegistrationResponseEntity.MarathiWifeLastName,
                UidOfWife = marriageRegistrationResponseEntity.UidOfWife,
                OtherNameOfWife = marriageRegistrationResponseEntity.OtherNameOfWife,
                MarathiOtherNameOfWife = marriageRegistrationResponseEntity.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = marriageRegistrationResponseEntity.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageRegistrationResponseEntity.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = marriageRegistrationResponseEntity.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = marriageRegistrationResponseEntity.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(marriageRegistrationResponseEntity.AgeOfWife),
                StatusOfWifeAtMarriage = marriageRegistrationResponseEntity.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageRegistrationResponseEntity.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = marriageRegistrationResponseEntity.MarathiAddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = marriageRegistrationResponseEntity.NameofWitness1,
                UidOfWitness1 = marriageRegistrationResponseEntity.UidOfWitness1,
                AddressOfWitness1 = marriageRegistrationResponseEntity.AddressOfWitness1,
                OccupationOfWitness1WithAddress = marriageRegistrationResponseEntity.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = marriageRegistrationResponseEntity.RelationWithCoupleOfWitness1,
                NameofWitness2 = marriageRegistrationResponseEntity.NameofWitness2,
                UidOfWitness2 = marriageRegistrationResponseEntity.UidOfWitness2,
                AddressOfWitness2 = marriageRegistrationResponseEntity.AddressOfWitness2,
                OccupationOfWitness2WithAddress = marriageRegistrationResponseEntity.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = marriageRegistrationResponseEntity.RelationWithCoupleOfWitness2,
                NameOfWitness3 = marriageRegistrationResponseEntity.NameOfWitness3,
                UidOfWitness3 = marriageRegistrationResponseEntity.UidOfWitness3,
                AddressOfWitness3 = marriageRegistrationResponseEntity.AddressOfWitness3,
                OccupationOfWitness3WithAddress = marriageRegistrationResponseEntity.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = marriageRegistrationResponseEntity.RelationWithCoupleOfWitness3,

                MarathiNameofWitness1 = marriageRegistrationResponseEntity.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = marriageRegistrationResponseEntity.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = marriageRegistrationResponseEntity.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = marriageRegistrationResponseEntity.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = marriageRegistrationResponseEntity.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = marriageRegistrationResponseEntity.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = marriageRegistrationResponseEntity.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = marriageRegistrationResponseEntity.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = marriageRegistrationResponseEntity.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageRegistrationResponseEntity.PriestName,
                PriestAddress = marriageRegistrationResponseEntity.PriestAddress,
                PriestReligion = marriageRegistrationResponseEntity.PriestReligion,
                PriestAge = marriageRegistrationResponseEntity.PriestAge,
                MarathiPriestName = marriageRegistrationResponseEntity.MarathiPriestName,
                MarathiPriestAddress = marriageRegistrationResponseEntity.MarathiPriestAddress,
                MarathiPriestReligion = marriageRegistrationResponseEntity.MarathiPriestReligion,

            };
            return marriageRegistrationRequestEntity;
        }

        private static AgeEntity GetAge(Age age)
        {
            var ageEntity = new AgeEntity();
            if (age != null)
            {
                ageEntity.Years = age.Years;
                ageEntity.Months = age.Months;
                
            }
            return ageEntity;
        }

        private static AgeEntity GetAge(AgeEntity age)
        {
            var ageEntity = new AgeEntity();
            if(age != null)
            {
                ageEntity.Years = age.Years;
                ageEntity.Months = age.Months;
            };
            return ageEntity;
        }

        public static MarriageRegistrationRequestEntity GetUpdateItemRequestEntity(UpdateDetailsInputModel updateDetailsInputModel)
        {
            var marriageRegistrationRequestEntity = new MarriageRegistrationRequestEntity
            {
                //Application Details
                ApplicationId = updateDetailsInputModel.ApplicationId,
                DocumentStatus = "PendingForApproval",
                CertificateNumber = "Not Yet generated",
                ApplicantDistrict = updateDetailsInputModel.ApplicantDistrict,

                ApplicantTaluka = updateDetailsInputModel.ApplicantTaluka,
                MarriageDate = updateDetailsInputModel.MarriageDate,
                MarriagePlace = updateDetailsInputModel.MarriagePlace,
                MarathiMarriagePlace = updateDetailsInputModel.MarathiMarriagePlace,
                LawOfMarriage = updateDetailsInputModel.LawOfMarriage,
                MarathiLawOfMarriage = updateDetailsInputModel.MarathiLawOfMarriage,
                DocumentsPresented = updateDetailsInputModel.DocumentsPresented,
                IsMarriageRegisteredAlready = updateDetailsInputModel.IsMarriageRegisteredAlready,
                SubmissionDate = updateDetailsInputModel.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = updateDetailsInputModel.HusbandFirstName,
                HusbandMiddleName = updateDetailsInputModel.HusbandMiddleName,
                HusbandLastName = updateDetailsInputModel.HusbandLastName,
                MarathiHusbandFirstName = updateDetailsInputModel.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = updateDetailsInputModel.MarathiHusbandMiddleName,
                MarathiHusbandLastName = updateDetailsInputModel.MarathiHusbandLastName,
                UidOfHusband = updateDetailsInputModel.UidOfHusband,
                OtherNameOfHusband = updateDetailsInputModel.OtherNameOfHusband,
                MarathiOtherNameOfHusband = updateDetailsInputModel.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = updateDetailsInputModel.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = updateDetailsInputModel.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = updateDetailsInputModel.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = updateDetailsInputModel.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(updateDetailsInputModel.AgeOfHusband),
                OccupationOfHusbandWithAddress = updateDetailsInputModel.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = updateDetailsInputModel.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = updateDetailsInputModel.StatusOfHusbandAtMarriage,
                AddressOfHusband = updateDetailsInputModel.AddressOfHusband,
                MarathiAddressOfHusband = updateDetailsInputModel.MarathiAddressOfHusband,

                //Wife's Details
                WifeFirstName = updateDetailsInputModel.WifeFirstName,
                WifeMiddleName = updateDetailsInputModel.WifeMiddleName,
                WifeLastName = updateDetailsInputModel.WifeLastName,
                MarathiWifeFirstName = updateDetailsInputModel.MarathiWifeFirstName,
                MarathiWifeMiddleName = updateDetailsInputModel.MarathiWifeMiddleName,
                MarathiWifeLastName = updateDetailsInputModel.MarathiWifeLastName,
                UidOfWife = updateDetailsInputModel.UidOfWife,
                OtherNameOfWife = updateDetailsInputModel.OtherNameOfWife,
                MarathiOtherNameOfWife = updateDetailsInputModel.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = updateDetailsInputModel.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = updateDetailsInputModel.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = updateDetailsInputModel.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = updateDetailsInputModel.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(updateDetailsInputModel.AgeOfWife),
                StatusOfWifeAtMarriage = updateDetailsInputModel.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = updateDetailsInputModel.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = updateDetailsInputModel.MarathiAddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = updateDetailsInputModel.NameofWitness1,
                UidOfWitness1 = updateDetailsInputModel.UidOfWitness1,
                AddressOfWitness1 = updateDetailsInputModel.AddressOfWitness1,
                OccupationOfWitness1WithAddress = updateDetailsInputModel.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = updateDetailsInputModel.RelationWithCoupleOfWitness1,
                NameofWitness2 = updateDetailsInputModel.NameofWitness2,
                UidOfWitness2 = updateDetailsInputModel.UidOfWitness2,
                AddressOfWitness2 = updateDetailsInputModel.AddressOfWitness2,
                OccupationOfWitness2WithAddress = updateDetailsInputModel.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = updateDetailsInputModel.RelationWithCoupleOfWitness2,
                NameOfWitness3 = updateDetailsInputModel.NameOfWitness3,
                UidOfWitness3 = updateDetailsInputModel.UidOfWitness3,
                AddressOfWitness3 = updateDetailsInputModel.AddressOfWitness3,
                OccupationOfWitness3WithAddress = updateDetailsInputModel.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = updateDetailsInputModel.RelationWithCoupleOfWitness3,

                MarathiNameofWitness1 = updateDetailsInputModel.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = updateDetailsInputModel.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = updateDetailsInputModel.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = updateDetailsInputModel.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = updateDetailsInputModel.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = updateDetailsInputModel.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = updateDetailsInputModel.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = updateDetailsInputModel.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = updateDetailsInputModel.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = updateDetailsInputModel.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = updateDetailsInputModel.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = updateDetailsInputModel.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = updateDetailsInputModel.PriestName,
                PriestAddress = updateDetailsInputModel.PriestAddress,
                PriestReligion = updateDetailsInputModel.PriestReligion,
                PriestAge = updateDetailsInputModel.PriestAge,
                MarathiPriestName = updateDetailsInputModel.MarathiPriestName,
                MarathiPriestAddress = updateDetailsInputModel.MarathiPriestAddress,
                MarathiPriestReligion = updateDetailsInputModel.MarathiPriestReligion,

            };

            return marriageRegistrationRequestEntity;
        }



    }
}
