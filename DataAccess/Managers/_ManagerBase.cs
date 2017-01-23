using Global;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public abstract class _ManagerBase
    {
        protected MethodBase _methodBase;
        protected SqlConnection _sqlConnection;

        public _ManagerBase()
        {
            _methodBase = MethodInfo.GetCurrentMethod();
            _sqlConnection = new SqlConnection(new Configurator().databaseConnectionString);
        }
    }
}
