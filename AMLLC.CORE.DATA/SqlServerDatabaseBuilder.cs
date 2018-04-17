using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATA
{
    public class SqlServerDatabaseBuilder : IDatabaseBuilder
    {
        private Database _Database;

        public SqlServerDatabaseBuilder()
        {
            _Database = new SQLServerDatabase();
        }

        public void BuildConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
            _Database.Connection = new SqlConnection(connectionString);
        }

        public void BuildCommand(string sStoredProcedure)
        {
            _Database.Command = new SqlCommand(sStoredProcedure);
            _Database.Command.Connection = _Database.Connection;
        }

        public void SetSettings()
        {
            _Database.Command.CommandTimeout = 360;
            _Database.Command.CommandType = CommandType.StoredProcedure;
        }

        public void AddParameters(params object[] arrobjParameters)
        {
            _Database.Connection.Open();
            int intIndexParam = 0;
            SqlCommandBuilder.DeriveParameters((SqlCommand)_Database.Command);
            foreach (SqlParameter sqlParameter in _Database.Command.Parameters)
            {
                if (sqlParameter.Direction == ParameterDirection.Input)
                {
                    if (arrobjParameters[intIndexParam] != null)
                    {
                        if (arrobjParameters[intIndexParam].GetType() == typeof(DataTable))
                        {
                            sqlParameter.TypeName = sqlParameter.TypeName.Split('.').Last();
                            sqlParameter.SqlDbType = SqlDbType.Structured;
                        }
                    }
                    else
                    {
                        arrobjParameters[intIndexParam] = "";
                    }
                    sqlParameter.SqlValue = arrobjParameters[intIndexParam];
                    intIndexParam += 1;
                }
            }
        }

        public void GetDataReader()
        {
            _Database.DataReader = _Database.Command.ExecuteReader();
        }



        public Database Database
        {
            get { return _Database; }
        }
    }
}

