using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Buoi09_Validation.Models
{
    public class Demo
    {
        public async Task<string> Test01Async()
        {
            await Task.Delay(2000);
            return "Test01 - 2s";
        }

        public async Task<int> Test02Async()
        {
            await Task.Delay(5000);
            return 123;
        }
        public async Task Test03Async()
        {
            await Task.Delay(3000);
        }

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
