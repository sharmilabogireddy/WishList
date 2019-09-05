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
    public class WishListController : ApiController
    {
        WishListDBEntities2 wishList = new WishListDBEntities2();
        //api/WishLists
        [HttpGet]
        public IQueryable<WishList> GetAllWishLists()
        {
            return wishList.WishLists;
        }
        //Get WishListsById
        //api/WishList/1
        [HttpGet]
        public WishList GetWishListsById(int id)
        {
            WishList wishlist = wishList.WishLists.Find(id);
            return wishlist;
        }

        //Update UserDetails
        //api/UserDetails/1
        [HttpPut]
        public void UpdateWishList(int id, WishList wishlist)
        {
            wishList.Entry(wishlist).State = EntityState.Modified;
            wishList.SaveChanges();
        }

        //Delete WishLists
        //api/UserDetails/1
        [HttpDelete]

        public void DeleteWishLists(int id)
        {
            WishList wishlist = wishList.WishLists.Find(id);
            wishList.WishLists.Remove(wishlist);
            wishList.SaveChanges();
        }

        //Create New UserDetails
        //api/UserDetails
        [HttpPost]
        public void CreateNewUserDetails(WishList wishlist)
        {
            wishList.WishLists.Add(wishlist);
            wishList.SaveChanges();
        }
    }
}
