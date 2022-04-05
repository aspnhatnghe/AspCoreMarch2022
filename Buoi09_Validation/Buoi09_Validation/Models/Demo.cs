using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Buoi09_Validation.Models
{
    public class Demo
    {
        public string Test01()
        {
            Thread.Sleep(2000);
            return "Test01 - 2s";
        }

        public int Test02()
        {
            Thread.Sleep(5000);
            return 123;
        }
        public void Test03()
        {
            Thread.Sleep(3000);
        }
    }
}
