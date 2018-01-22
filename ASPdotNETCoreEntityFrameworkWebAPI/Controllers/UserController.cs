using ASPdotNETCoreEntityFrameworkWebAPI.DAL;
using ASPdotNETCoreEntityFrameworkWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private UserDal userDal;

        public UserController(UserDal userDal)
        {
            this.userDal = userDal;
        }

        [HttpGet]
        [Route("~/api/users")]
        public IEnumerable<User> GetAll()
        {
            return userDal.GetAll();
        }

        [HttpGet("{id:int}")]
        public User GetById([FromRoute]int id)
        {
            return userDal.GetById(id);
        }

        [HttpPost]
        public void Create([FromBody]User user)
        {
            userDal.Create(user);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody]User user)
        {
            userDal.Update(id, user);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            userDal.Delete(id);
        }
    }
}
