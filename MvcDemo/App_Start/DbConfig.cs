using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo
{
    public static class DbConfig
    {
        public static void InitializeDb()
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MvcDemo.Models.MvcDemoContext>());
        }
    }
}