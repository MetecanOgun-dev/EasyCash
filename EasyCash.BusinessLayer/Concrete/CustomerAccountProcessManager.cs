using EasyCash.BusinessLayer.Abstract;
using EasyCash.DataAccessLayer.Abstract;
using EasyCash.EntityLayer.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.Concrete
{
    internal class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;
        private readonly ILogger _logger;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerProcessAccountDal, ILogger logger)
        {
            _customerAccountProcessDal = customerProcessAccountDal;
            _logger = logger;
        }

        public ServiceResponse<CustomerAccountProcess> TDelete(CustomerAccountProcess t)
        {
            try
            {
                _customerAccountProcessDal.Delete(t);
                return new ServiceResponse<CustomerAccountProcess>
                {
                    Success = true,
                    Message = "Delete operation succeded",
                    Data = t
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete oepration error: " + ex.Message);
                return new ServiceResponse<CustomerAccountProcess>() { Message = "Delete operation error" };
            }
        }

        public ServiceResponse<CustomerAccountProcess> TGetById(int id)
        {
            try
            {
                return new ServiceResponse<CustomerAccountProcess>
                {
                    Success = true,
                    Message = "Get operation succeded",
                    Data = _customerAccountProcessDal.GetById(id)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Get operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccountProcess>() { Message = "Get operation error" };
            }

        }

        public ServiceResponse<CustomerAccountProcess> TGetList()
        {
            try
            {
                return new ServiceResponse<CustomerAccountProcess>
                {
                    Success = true,
                    Message = "Get operation succeded",
                    DataList = _customerAccountProcessDal.GetList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Get operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccountProcess>() { Message = "Get operation error" };
            }
        }

        public ServiceResponse<CustomerAccountProcess> TGetListByFilter(Expression<Func<CustomerAccountProcess, bool>> filter)
        {
            /*
            // Fiyatı 15 TL üzerinde olan ürünleri filtreleyen bir lambda ifadesi
            Expression<Func<T, bool>> highPriceProductsFilter = p => p.Price > 15.0m;

            // Filtrelenmiş ürünleri al
            List<T> highPriceProducts = repository.GetAll(highPriceProductsFilter);
            */
            try
            {
                return new ServiceResponse<CustomerAccountProcess>
                {
                    Success = true,
                    Message = "Get operation succeded",
                    DataList = _customerAccountProcessDal.GetList(filter)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Get operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccountProcess>() { Message = "Get operation error" };
            }
        }

        public ServiceResponse<CustomerAccountProcess> TInsert(CustomerAccountProcess t)
        {
            try
            {
                _customerAccountProcessDal.Insert(t);
                return new ServiceResponse<CustomerAccountProcess>
                {
                    Success = true,
                    Message = "Insert operation succeded",
                    Data = t
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Insert operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccountProcess>() { Message = "Insert operation error" };
            }
        }

        public ServiceResponse<CustomerAccountProcess> TUpdate(CustomerAccountProcess t)
        {
            try
            {
                _customerAccountProcessDal.Update(t);
                return new ServiceResponse<CustomerAccountProcess>
                {
                    Success = true,
                    Message = "Update operation succeded",
                    Data = t
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Update operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccountProcess>() { Message = "Update operation error" };
            }
        }
    }
}
