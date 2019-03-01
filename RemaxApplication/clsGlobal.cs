using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace RemaxApplication
{
    static class clsGlobal
    {
        public static OleDbConnection myCon;
        public static DataSet mySet;
        public static OleDbDataAdapter adpClients, adpEmployees, adpProperties;
    }
}
