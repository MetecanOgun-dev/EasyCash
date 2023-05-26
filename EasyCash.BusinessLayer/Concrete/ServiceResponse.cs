using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.Concrete
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<T>? DataList { get; set; }

        public ServiceResponse()
        {
            Success = false;
            Message = "Operation failed";
            Data = default(T);
            DataList = default(List<T>);
        }
    }
}
