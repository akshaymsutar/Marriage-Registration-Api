using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using MarriageRegistrationApi.Models;

namespace MarriageRegistrationApi.Services.LoginValidation
{
    public class ValidateLogin : IValidateLogin
    {
        public async Task<bool> loginValidation(LoginRequestModel loginRequestModel, LoginDetailsConfigureModel loginDetailsConfigureModel)
        {
            if (loginDetailsConfigureModel.Password != null) {
                if (loginRequestModel.Password == loginDetailsConfigureModel.Password)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
            
        }
    }
}
