using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public interface IRepository<Tkey, TEntity>
    {
        ResponseDTO<Tkey> Add(RequestDTO<TEntity> entity);
        ResponseDTO<Tkey> Update(RequestDTO<TEntity> entity);
        ResponseDTO<IEnumerable<TEntity>> GetAll(RequestDTO<Boolean> IncludeDisabled);
        ResponseDTO<TEntity> GetById(RequestDTO<Tkey> id);
    }

}
