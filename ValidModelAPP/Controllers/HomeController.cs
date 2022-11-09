using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ValidModelAPP.Context;
using ValidModelAPP.Models;
 
namespace ValidModelAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            this.context = context;
            _logger = logger;
            Publishing press = new Publishing { Name = "Press" };
            Publishing springer = new Publishing { Name = "Springer" };
            Book book1 = new Book { Title = "History", Price = 324, Publishing = press };
            Book book2 = new Book { Title = "Garry", Price = 34, Publishing = springer };
            context.Publishings.AddRange(press, springer);
            context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> List(string? name, Guid? publishingId, int page=1,
            SortState sortState=SortState.NameAsc) 
        {
            int pageSize = 3;

            IQueryable<Book>? books = context.Books.Include(p => p.Publishing);
            if (publishingId != null) 
            {
                books = books.Where(b => b.PublishingId == publishingId);
            }
            if (!string.IsNullOrEmpty(name)) 
            {
                books = books.Where(b=>b.Title!.Contains(name));
            }
            switch (sortState) 
            {
                case SortState.NameDesc:
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case SortState.PriceAsc:
                    books = books.OrderBy(b => b.Price);
                    break;
                case SortState.PriceDesc:
                    books = books.OrderByDescending(b => b.Price);
                    break;
                case SortState.PublishingAsc:
                    books=books.OrderBy(b => b.Publishing!.Name);
                    break;
                case SortState.PublishingDesc:
                    books = books.OrderByDescending(b => b.Publishing!.Name);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }
            var count = await books.CountAsync();
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            ListViewModel listViewModel = new ListViewModel(items, new PageViewModel(count, page, pageSize),
                new FilterListViewModel(context.Publishings.ToList(), publishingId, name), new SortViewModel(sortState));
            return View(listViewModel);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (book.Price < 0)
            {
                ModelState.AddModelError("Price", "Price must be over 0");
            }
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return StatusCode(403);
        }

        [HttpGet]
        public IActionResult Edit(Guid? id) 
        {
            if (id != null) 
            {
                var book = context.Books.FirstOrDefault(x => x.Id == id);
                if (book != null) return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book) 
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id) 
        {
            if (id != null)
            {
                var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book != null)
                {
                    context.Books.Remove(book);
                    await context.SaveChangesAsync();
                    return RedirectToAction("List");
                }
            }
            return NotFound();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}