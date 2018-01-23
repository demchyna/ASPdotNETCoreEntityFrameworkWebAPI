using ASPdotNETCoreEntityFrameworkWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.DAL
{
    public class UserDal : GenericDal<User>
    {
        public UserDal(EJournalContext dbContext) : base(dbContext)
        {
        }

        public User GetByUsername(string username)
        {
            User user = dbContext.Users.Where(u => u.Username.Equals(username)).First();
            return user;
        }
    }
}
