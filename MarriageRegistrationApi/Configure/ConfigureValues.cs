using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using MarriageRegistrationApi.Models;
using Microsoft.Extensions.Configuration;

namespace MarriageRegistrationApi.Configure
{
    public class ConfigureValues
    {
        private readonly IConfiguration _config;
        public ConfigureValues()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public LoginDetailsConfigureModel LoadLoginDetails(string userName)
        {
            LoginDetailsConfigureModel loginDetailsConfigureModel = new LoginDetailsConfigureModel();
            loginDetailsConfigureModel.Division = _config.GetSection("LoginDetails").GetSection(userName).GetSection("Division").Value;
            loginDetailsConfigureModel.District = _config.GetSection("LoginDetails").GetSection(userName).GetSection("District").Value;
            loginDetailsConfigureModel.Hospital = _config.GetSection("LoginDetails").GetSection(userName).GetSection("Hospital").Value;
            loginDetailsConfigureModel.Password = _config.GetSection("LoginDetails").GetSection(userName).GetSection("Password").Value;


            return loginDetailsConfigureModel;
        }
    }
}
