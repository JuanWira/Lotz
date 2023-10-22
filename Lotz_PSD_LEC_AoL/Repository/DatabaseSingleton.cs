using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Repository
{
    public class DatabaseSingleton
    {
        private static LotzDatabaseEntities db = null;
        private DatabaseSingleton()
        {

        }

        public static LotzDatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new LotzDatabaseEntities();
            }
            return db;
        }
    }
}