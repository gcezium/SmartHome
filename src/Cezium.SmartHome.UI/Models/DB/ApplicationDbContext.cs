using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cezium.SmartHome.UI.Models.DB
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public ApplicationDbContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
        }

        public ApplicationDbContext()
            : base(_connectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}