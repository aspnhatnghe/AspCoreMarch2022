using Buoi09_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi09_Validation.Services
{
    public class MockCategory : ICategory
    {
        static List<Category> categories = new List<Category>()
        {
            new Category{Id = 1, Name="Phone"},
            new Category{Id = 2, Name="Laptop"},
            new Category{Id = 3, Name="Tablet"},
            new Category{Id = 4, Name="Air Condition"}
        };
        public Category Create(string name)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
