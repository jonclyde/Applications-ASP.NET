using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _3D_Printing_Service.Data;
using _3D_Printing_Service.Models.ViewModels;
using _3D_Printing_Service.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3D_Printing_Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }

        public ProductController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            ProductVM = new ProductViewModel()
            {
                Category = _db.Category,
                Product = new Models.Product()
            };
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Product.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View(products);
        }

        //GET - CREATE

        public IActionResult Create()
        {
            return View(ProductVM);
        }

        //POST - CREATE
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            ProductVM.Product.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if(!ModelState.IsValid)
            {
                return View(ProductVM);
            }

            _db.Product.Add(ProductVM.Product);
            await _db.SaveChangesAsync();

            //Work on the image saving section
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productFromDb = await _db.Product.FindAsync(ProductVM.Product.Id);

            if(files.Count>0)
            {
                //files has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, ProductVM.Product.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                productFromDb.Image = @"\images\" + ProductVM.Product.Id + extension;
            }
            else
            {
                //no files was uploaded, so use default
                var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + ProductVM.Product.Id + ".png");
                productFromDb.Image = @"\images\" + ProductVM.Product.Id + ".png";
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}