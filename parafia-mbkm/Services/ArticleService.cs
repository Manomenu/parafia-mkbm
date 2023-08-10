using parafia_mbkm.View;
using parafia_mbkm.data.Models;
using parafia_mbkm.data;

namespace parafia_mbkm.Services
{
    public static class ArticleService
    {
        public static async Task<int> AddArticleAsync(ArticleView articleModel, ParafiaDbDataContext context)
        {
            Article article = new Article
            {
                Header = articleModel.Header,
                Content = articleModel.Content
            };
            await context.Articles.AddAsync(article);
            await context.SaveChangesAsync();

            return article.Id;
        }

        public static async Task<Article?> GetArticleByIdAsync(int id, ParafiaDbDataContext context)
        {
            return await context.Articles.FindAsync(id);
        }
    }
}
