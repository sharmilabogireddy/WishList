using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WishListWebAPI.Models;
using System.Data.Entity;

namespace WishListWebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        WishListCategoryDBEntities wishList = new WishListCategoryDBEntities();
        //api/Category
        [HttpGet]
        public IQueryable<Category> GetAllCategories()
        {
            return wishList.Categories;
        }
        //api/Category/1
        [HttpGet]
        public Category GetCategoryById(int id)
        {
            Category category = wishList.Categories.Find(id);
            return category;
        }
        //api/Category/1
        [HttpPut]
        public void UpdateCategory(int id, Category category)
        {
            wishList.Entry(category).State = EntityState.Modified;
            wishList.SaveChanges();
        }

        //api/Category/1
        [HttpDelete]
        public void DeleteCategoryById(int id)
        {
            Category category = wishList.Categories.Find(id);
            wishList.Categories.Remove(category);
            wishList.SaveChanges();
        }
        //api/Category
        [HttpPost]
        public void CreateNewCategory(Category category)
        {
            wishList.Categories.Add(category);
            wishList.SaveChanges();
        }
    }
}
