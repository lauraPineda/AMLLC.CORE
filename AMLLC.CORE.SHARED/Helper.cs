using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AMLLC.CORE.SHARED
{
    public class Helper
    {
        #region [     Constants      ]

        public const int INVALID_IDENTIFIERNUMBER = 0;

        #endregion


        #region [    Application Parameters    ]


        public static int GetMaxPageSize()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["MaxPageSize"]);
        }

        #endregion


        #region [    ConnectionStrings    ]

        public static string GetBufferConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBAMLLC"].ConnectionString;
        }

        #endregion


        #region [    DataBase Types Mappers     ]

        public static byte GetByte(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Convert.ToByte(INVALID_IDENTIFIERNUMBER) : Convert.ToByte(reader[column]);
        }

        public static byte[] GetByteArray(SqlDataReader reader, string column)
        {
            //TODO: Implementar
            return new Byte[1];
        }

        public static short GetInt16(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Convert.ToInt16(INVALID_IDENTIFIERNUMBER) : reader.GetInt16(reader.GetOrdinal(column));
        }

        public static int GetInt32(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToInt32(reader[column]);
        }

        public static ushort GetUInt16(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Convert.ToUInt16(INVALID_IDENTIFIERNUMBER) : Convert.ToUInt16(reader[column]);
        }

        public static uint GetUInt32(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToUInt32((reader[column]));
        }

        public static ulong GetUInt64ReferenceIdentifier(SqlDataReader reader, string column)
        {
            var listColumns = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                listColumns.Add(reader.GetName(i));
            }
            var columnValue = listColumns.Where(x => x == column).FirstOrDefault();

            return string.IsNullOrEmpty(columnValue) ? 0 : reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToUInt64((reader[column]));
        }
        public static ulong GetUInt64(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToUInt64((reader[column]));
        }

        public static long GetInt64(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : reader.GetInt64(reader.GetOrdinal(column));
        }

        public static string GetString(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? string.Empty : reader.GetString(reader.GetOrdinal(column)).TrimEnd().TrimStart();
        }

        public static DateTime? GetNullDateTime(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal(column));
        }

        public static DateTime GetDateTime(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal(column));
        }

        public static bool GetBoolean(SqlDataReader reader, string column)
        {
            return !reader.IsDBNull(reader.GetOrdinal(column)) && reader.GetBoolean(reader.GetOrdinal(column));
        }

        public static Guid GetGuid(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal(column));
        }

        public static decimal GetDecimal(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? INVALID_IDENTIFIERNUMBER : Convert.ToDecimal(reader[column]);
        }

        public static Char GetChar(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? char.MinValue : reader.GetString(reader.GetOrdinal(column)).First();
        }

        #endregion

    }
}
