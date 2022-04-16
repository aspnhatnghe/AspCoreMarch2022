using Buoi09_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi09_Validation.Services
{
    public interface ICategory
    {
        public List<Category> GetAll();
        public List<Category> Search(string filter);
        public Category GetById(int id);
        public Category Create(string name);
    }
}
