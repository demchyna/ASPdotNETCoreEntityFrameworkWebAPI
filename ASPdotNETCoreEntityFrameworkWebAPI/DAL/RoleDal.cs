using ASPdotNETCoreEntityFrameworkWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.DAL
{
    public class RoleDal : GenericDal<Role>
    {
        public RoleDal(EJournalContext dbContext) : base(dbContext)
        {
        }
    }
}
