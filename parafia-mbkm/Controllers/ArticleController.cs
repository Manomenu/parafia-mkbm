using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.data;
using parafia_mbkm.data.Models;
using parafia_mbkm.Services;
using parafia_mbkm.ModelViews;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace parafia_mbkm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ParafiaDbDataContext context;

        public ArticleController(ParafiaDbDataContext context)
        {
            this.context = context;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IEnumerable<Article>> GetAll()
        {
            return await context.Articles.ToArrayAsync();
        }

        //GET api/<ArticleController>/5
        // Returns Article, not ArticleModel and we shall keep our API in that manner
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById([FromRoute] int id)
        {
            Article? article = await ArticleService.GetArticleByIdAsync(id, context);
            if (article == null)
                return NotFound();
            return Ok(article);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] ArticleView article)
        {
            var articleId = await ArticleService.AddArticleAsync(article, context);
            return CreatedAtAction(nameof(GetArticleById), "article", new 
            {
                Id = articleId,
            }, new 
            { 
                Header = article.Header, 
                Content = article.Content 
            });
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
