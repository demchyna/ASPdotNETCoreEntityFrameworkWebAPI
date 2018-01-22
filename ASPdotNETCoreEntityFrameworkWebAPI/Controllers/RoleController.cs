using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPdotNETCoreEntityFrameworkWebAPI.DAL;
using ASPdotNETCoreEntityFrameworkWebAPI.Entities;

namespace ASPdotNETCoreEntityFrameworkWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/role")]
    public class RoleController : Controller
    {
        RoleDal roleDal;

        public RoleController(RoleDal roleDal)
        {
            this.roleDal = roleDal;
        }

        [HttpGet]
        [Route("~/api/roles")]
        public IEnumerable<Role> GetAll()
        {
            return roleDal.GetAll();
        }

        [HttpGet("{id:int}")]
        public Role GetById([FromRoute]int id)
        {
            return roleDal.GetById(id);
        }

        [HttpPost]
        public void Create([FromBody]Role role)
        {
            roleDal.Create(role);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody]Role role)
        {
            roleDal.Update(id, role);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            roleDal.Delete(id);
        }
    }
}
