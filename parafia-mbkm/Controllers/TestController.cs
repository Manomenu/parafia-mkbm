using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parafia_mbkm.data.DataContexts;
using parafia_mbkm.ViewModels;

namespace parafia_mbkm.Controllers
{
    public class TestController : Controller
    {
        private readonly MovieActorDataContext context;

        public TestController(MovieActorDataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var movies = this.context.Movies.Include(m => m.Actors).Select(m => new MovieViewModel
            {
                Title = m.Title,
                Actors = string.Join(",", m.Actors.Select(a => a.Name))
            });
            return View(movies);
        }
    }
}
