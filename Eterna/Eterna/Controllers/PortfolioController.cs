using Eterna.Data;
using Eterna.Models;
using Eterna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eterna.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PortfolioViewModel vm = new PortfolioViewModel
            {
                Categories = _context.Categories.ToList(),
                Projects = _context.Projects.Include(x=>x.Category).Include(x=>x.ProjectImages.Where(x=>x.IsPoster)).ToList(),
            };

            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            Project project = _context.Projects.Include(x=>x.Category).Include(x=>x.ProjectImages).FirstOrDefault(x => x.Id == id);

            return View(project);
        }
    }
}
