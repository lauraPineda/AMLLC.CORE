﻿using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AMLLC.CORE.SHARED.CatalogEnum;

namespace AMLLC.CORE.DATAMANAGER
{
    public class CatalogDataManager
    {
        public ResponseDTO<List<ResponseCatalogDTO>> GetListCatalog(RequestCatalogDTO request, string uspName)
        {
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            MapperListCatalogDTO mapperListCatalogDTO = new MapperListCatalogDTO();

            database = DatabaseFactory.CreateDataBase(databaseType, uspName, request.IncludeDisabled, request.Id);

            ResponseDTO<List<ResponseCatalogDTO>> response = mapperListCatalogDTO.Mapper(database.DataReader);

            database.Connection.Close();

            return response;
        }


       
    }
}