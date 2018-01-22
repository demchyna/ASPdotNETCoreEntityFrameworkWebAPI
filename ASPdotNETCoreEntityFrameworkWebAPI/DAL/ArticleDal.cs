using ASPdotNETCoreEntityFrameworkWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.DAL
{
    public class ArticleDal : GenericDal<Article>
    {
        public ArticleDal(EJournalContext dbContext) : base(dbContext)
        {
        }
    }
}
