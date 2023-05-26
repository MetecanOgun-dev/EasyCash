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
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;
        private readonly ILogger _logger;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal, ILogger logger)
        {
            _customerAccountDal = customerAccountDal;
            _logger = logger;
        }

        public ServiceResponse<CustomerAccount> TDelete(CustomerAccount t)
        {
            try
            {
                _customerAccountDal.Delete(t);
                return new ServiceResponse<CustomerAccount>
                {
                    Success = true,
                    Message = "Delete operation succeded",
                    Data = t
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Delete oepration error: " + ex.Message);
                return new ServiceResponse<CustomerAccount>() { Message = "Delete operation error" };
            }
        }

        public ServiceResponse<CustomerAccount> TGetById(int id)
        {
            try
            {
                return new ServiceResponse<CustomerAccount>
                {
                    Success = true,
                    Message = "Get operation succeded",
                    Data = _customerAccountDal.GetById(id)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Get operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccount>() { Message = "Get operation error" };
            }

        }

        public ServiceResponse<CustomerAccount> TGetList()
        {
            try
            {
                return new ServiceResponse<CustomerAccount>
                {
                    Success = true,
                    Message = "Get operation succeded",
                    DataList = _customerAccountDal.GetList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Get operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccount>() { Message = "Get operation error" };
            }
        }

        public ServiceResponse<CustomerAccount> TGetListByFilter(Expression<Func<CustomerAccount, bool>> filter)
        {
            /*
            // Fiyatı 15 TL üzerinde olan ürünleri filtreleyen bir lambda ifadesi
            Expression<Func<T, bool>> highPriceProductsFilter = p => p.Price > 15.0m;

            // Filtrelenmiş ürünleri al
            List<T> highPriceProducts = repository.GetAll(highPriceProductsFilter);
            */
            try
            {
                return new ServiceResponse<CustomerAccount>
                {
                    Success = true,
                    Message = "Get operation succeded",
                    DataList = _customerAccountDal.GetList(filter)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Get operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccount>() { Message = "Get operation error" };
            }
        }

        public ServiceResponse<CustomerAccount> TInsert(CustomerAccount t)
        {
            try
            {
                _customerAccountDal.Insert(t);
                return new ServiceResponse<CustomerAccount>
                {
                    Success = true,
                    Message = "Insert operation succeded",
                    Data = t
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Insert operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccount>() { Message = "Insert operation error" };
            }
        }

        public ServiceResponse<CustomerAccount> TUpdate(CustomerAccount t)
        {
            try
            {
                _customerAccountDal.Update(t);
                return new ServiceResponse<CustomerAccount>
                {
                    Success = true,
                    Message = "Update operation succeded",
                    Data = t
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Update operation error: " + ex.Message);
                return new ServiceResponse<CustomerAccount>() { Message = "Update operation error" };
            }
        }
    }
}
