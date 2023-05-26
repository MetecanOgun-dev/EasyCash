using EasyCash.BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        ServiceResponse<T> TInsert(T t);
        ServiceResponse<T> TDelete(T t);
        ServiceResponse<T> TUpdate(T t);
        ServiceResponse<T> TGetById(int id);
        ServiceResponse<T> TGetList();
        ServiceResponse<T> TGetListByFilter(Expression<Func<T, bool>> filter);
    }
}
