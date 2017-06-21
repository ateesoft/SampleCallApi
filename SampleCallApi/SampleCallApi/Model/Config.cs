using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SampleCallApi.Model
{
    public static class Config
    {
        public static string CustomerCode => ConfigurationManager.AppSettings["SKYFROG_BPCODE"];
        public static string ApiUrl => ConfigurationManager.AppSettings["SKYFROG_API_URL"];
        public static string Username => ConfigurationManager.AppSettings["SKYFROG_API_USER"];
        public static string Password => ConfigurationManager.AppSettings["SKYFROG_API_PASS"];

    }
}