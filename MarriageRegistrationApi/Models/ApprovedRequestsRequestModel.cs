﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistrationApi.Models
{
    public class ApprovedRequestsRequestModel
    {
        public string Division { get; set; }
        public string District { get; set; }
        public string Hospital { get; set; }
    }
}
