﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadJson
{
    public class Test
    {
        private readonly IConfiguration configuration;

        public Test(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string fromAddressMethod()
        {
            var dataFromJsonFile = configuration.GetSection("fromAddress").Value;
            Console.WriteLine(dataFromJsonFile);
            return dataFromJsonFile;
        }
        public string toEmail()
        {
            var dataFromJsonFile = configuration.GetSection("toAddress").Value;
            Console.WriteLine(dataFromJsonFile);
            return dataFromJsonFile;
        }
        public string password()
        {
            var dataFromJsonFile = configuration.GetSection("password").Value;
            Console.WriteLine(dataFromJsonFile);
            return dataFromJsonFile;
        }
    }
}
