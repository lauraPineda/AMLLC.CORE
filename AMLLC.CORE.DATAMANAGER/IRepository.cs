using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public interface IRepository<Tkey, TEntity,TFilter>
    {
        ResponseDTO<Tkey> Add(TEntity entity);
        ResponseDTO<Tkey> Update(TEntity entity);
        ResponseDTO<IEnumerable<TEntity>> GetAll(TFilter filter);
        ResponseDTO<TEntity> GetById(Tkey id);
    }

}
