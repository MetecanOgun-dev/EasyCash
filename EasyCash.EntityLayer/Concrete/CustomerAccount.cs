using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountId { get; set; }
        public string CustomerAccountNumber { get; set; } = string.Empty;
        public string CustomerAccountCurrency { get; set;} = string.Empty;
        public decimal CustomerAccountBalacne { get; set; }
        public string BankBranch { get; set; } = string.Empty;
        public int AppUserId { get; set; }
        public  AppUser AppUser { get; set; }
    }
}
