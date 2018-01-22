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
    [Route("api/article")]
    public class ArticleController : Controller
    {
        ArticleDal articleDal;

        public ArticleController(ArticleDal articleDal)
        {
            this.articleDal = articleDal;
        }

        [HttpGet]
        [Route("~/api/articles")]
        public IEnumerable<Article> GetAll()
        {
            return articleDal.GetAll();
        }

        [HttpGet("{id:int}")]
        public Article GetById([FromRoute]int id)
        {
            return articleDal.GetById(id);
        }

        [HttpPost]
        public void Create([FromBody]Article article)
        {
            articleDal.Create(article);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody]Article article)
        {
            articleDal.Update(id, article);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            articleDal.Delete(id);
        }
    }
}