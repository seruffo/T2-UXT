using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions
{
    public static class SQLProcedures
    {
        public static int ExecuteStoredProcedure(string storedProcedureName, DbContext contexto, params SqlParameter[] parameters)
        {
            var spSignature = new StringBuilder();
            object[] spParameters;
            bool hasTableVariables = parameters.Any(p => p.SqlDbType == SqlDbType.Structured);

            spSignature.AppendFormat("EXECUTE {0}", storedProcedureName);
            var length = parameters.Count() - 1;

            if (hasTableVariables)
            {
                var tableValueParameters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Count(); i++)
                {
                    switch (parameters[i].SqlDbType)
                    {
                        case SqlDbType.Structured:
                            spSignature.AppendFormat("@{0}", parameters[i].ParameterName);
                            tableValueParameters.Add(parameters[i]);
                            break;
                        case SqlDbType.VarChar:
                        case SqlDbType.Char:
                        case SqlDbType.Text:
                        case SqlDbType.NVarChar:
                        case SqlDbType.NChar:
                        case SqlDbType.NText:
                        case SqlDbType.Xml:
                        case SqlDbType.UniqueIdentifier:
                        case SqlDbType.Time:
                        case SqlDbType.Date:
                        case SqlDbType.DateTime:
                        case SqlDbType.DateTime2:
                        case SqlDbType.DateTimeOffset:
                        case SqlDbType.SmallDateTime:
                            spSignature.AppendFormat("'{0}'", parameters[i].Value.ToString());
                            break;
                        default:
                            spSignature.AppendFormat("{0}", parameters[i].Value.ToString());
                            break;
                    }

                    if (i != length) spSignature.Append(",");
                }
                spParameters = tableValueParameters.Cast<object>().ToArray();
            }
            else
            {
                for (int i = 0; i < parameters.Count(); i++)
                {
                    spSignature.AppendFormat("@{0}", parameters[i].ParameterName);
                    if (i != length) spSignature.Append(",");
                }
                spParameters = parameters.Cast<object>().ToArray();
            }

            var result = contexto.Database.ExecuteSqlCommand(spSignature.ToString(), spParameters);

            return result;
        }
    }
}
