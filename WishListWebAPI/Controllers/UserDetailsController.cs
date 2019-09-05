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
    public class UserDetailsController : ApiController
    {
        WishListDBEntities1 wishList = new WishListDBEntities1();
        //api/UserDetails
        [HttpGet]
        public IQueryable<UserDetail> GetAllUserDetails()
        {
            return wishList.UserDetails;
        }
        //Get UserDetailsById
        //api/UserDetails/1
        [HttpGet]
        public UserDetail GetUserDetailsById(int id)
        {
            UserDetail userDetail = wishList.UserDetails.Find(id);
            return userDetail;
        }

        //Update UserDetails
        //api/UserDetails/1
        [HttpPut]
        public void UpdateUserDetails(int id, UserDetail userDetail)
        {
            wishList.Entry(userDetail).State = EntityState.Modified;
            wishList.SaveChanges();
        }

        //Delete UserDetails
        //api/UserDetails/1
        [HttpDelete]

        public void DeleteUserDetails(int id) {
            UserDetail userDetail = wishList.UserDetails.Find(id);
            wishList.UserDetails.Remove(userDetail);
            wishList.SaveChanges();
        }

        //Create New UserDetails
        //api/UserDetails
        [HttpPost]
        public void CreateNewUserDetails(UserDetail userDetail)
        {
            wishList.UserDetails.Add(userDetail);
            wishList.SaveChanges();
        }
    }
}
