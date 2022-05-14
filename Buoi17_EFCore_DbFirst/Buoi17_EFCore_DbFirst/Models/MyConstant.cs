using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_EFCore_DbFirst.Models
{
    public enum Role
    {
        Guest = 1,
        Customer = 2,
        Accountant = 3,
        Administrator = 4
    }

    public class Roles
    {
        public const string Administrator = "4";
        public const string Accountant = "3";
        public const string Customer = "2";
        public const string Guest = "1";
    }
    
    public class MyConstant
    {
    }
}
