using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarriageRegistrationApi.Models;

namespace MarriageRegistrationApi.Services.LoginValidation
{
    public interface IValidateLogin
    {
        Task<bool> loginValidation(LoginRequestModel loginRequestModel, LoginDetailsConfigureModel loginDetailsConfigureModel);
    }
}
