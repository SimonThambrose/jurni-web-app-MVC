using JurniWebApp.Data;
using JurniWebApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JurniWebApp.Controllers {
    [Authorize(Roles = "admin")]
    public class BlogController : Controller {
        private readonly JurniWebAppDbContext _context;
        
        public BlogController(JurniWebAppDbContext context) {
            _context = context;
        }
        
        [AllowAnonymous]
        public ActionResult Index() {
            List<Blog> blogs = _context.Blogs.ToList();
            return View(blogs);
        }

        [AllowAnonymous]
        public ActionResult Details(int id) {
            Blog blog = _context.Blogs.Find(id);
            blog.Author = _context.Users.Find(blog.AuthorId);
            return View(blog);
        }

        [AllowAnonymous]
        public ActionResult Create() {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult<Blog>> Create(IFormCollection collection) {
            try {
                Blog blog = new Blog {
                    Title = collection["Title"],
                    Description = collection["Description"],
                    AuthorId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}