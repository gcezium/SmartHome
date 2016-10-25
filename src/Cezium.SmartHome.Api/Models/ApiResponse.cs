using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cezium.SmartHome.Api.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Esception { get; set; }

        public ApiResponse(bool success)
        {
            Success = success;
        }
    }
}