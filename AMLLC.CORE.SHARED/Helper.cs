using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace AMLLC.CORE.SHARED
{
    public class Helper
    {
        #region [     Constants      ]

        public const int INVALID_IDENTIFIERNUMBER = 0;

        public static string GetLogNameTxt() { return ConfigurationManager.AppSettings["LogNameTxt"].ToString(); }

        #endregion



        #region [    DataBase Types Mappers     ]

        public static byte GetByte(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Convert.ToByte(INVALID_IDENTIFIERNUMBER) : Convert.ToByte(reader[column]);
        }
        

        public static byte[] GetByteArray(DbDataReader reader, string column)
        {
            //TODO: Implementar
            return new Byte[1];
        }

        public static short GetInt16(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Convert.ToInt16(INVALID_IDENTIFIERNUMBER) : reader.GetInt16(reader.GetOrdinal(column));
        }

        public static int GetInt32(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToInt32(reader[column]);
        }

        public static ushort GetUInt16(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Convert.ToUInt16(INVALID_IDENTIFIERNUMBER) : Convert.ToUInt16(reader[column]);
        }

        public static uint GetUInt32(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToUInt32((reader[column]));
        }

         public static Double GetDouble(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToDouble((reader[column]));
        }


        public static ulong GetUInt64ReferenceIdentifier(DbDataReader reader, string column)
        {
            var listColumns = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                listColumns.Add(reader.GetName(i));
            }
            var columnValue = listColumns.Where(x => x == column).FirstOrDefault();

            return string.IsNullOrEmpty(columnValue) ? 0 : reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToUInt64((reader[column]));
        }
        public static ulong GetUInt64(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToUInt64((reader[column]));
        }

        public static long GetInt64(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : reader.GetInt64(reader.GetOrdinal(column));
        }

        public static string GetString(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? string.Empty : reader.GetString(reader.GetOrdinal(column)).TrimEnd().TrimStart();
        }

        public static DateTime? GetNullDateTime(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal(column));
        }

        public static DateTime GetDateTime(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal(column));
        }

        public static bool GetBoolean(DbDataReader reader, string column)
        {
            return !reader.IsDBNull(reader.GetOrdinal(column)) && reader.GetBoolean(reader.GetOrdinal(column));
        }

        public static Guid GetGuid(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal(column));
        }

        public static decimal GetDecimal(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToDecimal(reader[column]);
        }

        public static Char GetChar(DbDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? char.MinValue : reader.GetString(reader.GetOrdinal(column)).First();
        }

        #endregion

    }
}
