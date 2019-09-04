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
    public class RoleController : ApiController
    {
        WishListDBEntities wishList = new WishListDBEntities();
        //../api/Role
        [HttpGet]
        public IQueryable<Role> GetAllRoles()
        {
            return wishList.Roles;
        }
        //../api/Role/1
        [HttpGet]
        public Role GetRoleById(int id)
        {
            Role role = wishList.Roles.Find(id);
            return role;
        }
        //api/Role/1
        [HttpPut]
        public void UpdateRole(int id, Role role)
        {
            wishList.Entry(role).State = EntityState.Modified;
            wishList.SaveChanges();
        }

        //api/Role/1
        [HttpDelete]
        public void DeleteRoleById(int id)
        {
            Role role = wishList.Roles.Find(id);
            wishList.Roles.Remove(role);
            wishList.SaveChanges();
        }
        //api/Role
        [HttpPost]
        public void CreateNewRole(Role role)
        {
            wishList.Roles.Add(role);
            wishList.SaveChanges();
        }
    }
}
