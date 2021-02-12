using System.Collections.Generic;
using AdvModelBinding.Models.CategoryModels;

namespace AdvModelBinding.Models
{
    public class CategoryRepoStub
    {
        public static List<Category> GetAll()
        {
            return new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "Action"},
                new Category {CategoryId = 2, CategoryName = "Adventure"},
                new Category {CategoryId = 3, CategoryName = "Horror"},
                new Category {CategoryId = 4, CategoryName = "Mystery"},
                new Category {CategoryId = 5, CategoryName = "Sci-Fi"},
            };
        }
    }
}