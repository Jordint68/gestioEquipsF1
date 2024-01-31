using System;
using System.Data.Common;

namespace DBLib
{
    internal class DBUtils
    {
        public static void createParam(DbCommand consulta, String paramName, Object val, System.Data.DbType type)
        {
            DbParameter paramDataAlta = consulta.CreateParameter();
            paramDataAlta.ParameterName = paramName;
            paramDataAlta.Value = val;
            paramDataAlta.DbType = type;
            consulta.Parameters.Add(paramDataAlta);
        }
    }
}
