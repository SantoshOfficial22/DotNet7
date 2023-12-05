using ImageCollectionGallery.Models;
using ImageCollectionGallery.Models.AppDbContext;
using Microsoft.AspNetCore.Mvc;

namespace ImageCollectionGallery.Controllers
{
	public class ImageController : Controller
	{
		private readonly AppDbContext _context;

		public ImageController(AppDbContext context)
		{
			_context = context;
		}

        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            var totalImages = _context.Images.Count();
            var images = _context.Images
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new IndexViewModel
            {
                Images = images,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = totalImages
                }
            };

            return View(model);
        }

        [HttpGet]
		public IActionResult Upload()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Upload(IFormFile file, string name)
		{
			if (file != null && file.Length > 0)
			{
				var imagePath = Path.Combine("wwwroot/images", file.FileName);
				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					file.CopyTo(stream);
				}

				var image = new Image
				{
					Name = name,
					Path = $"/images/{file.FileName}"
				};

				_context.Images.Add(image);
				_context.SaveChanges();
			}

			return RedirectToAction("Index");
		}

		public IActionResult Details(int id)
		{
			var image = _context.Images.FirstOrDefault(i => i.Id == id);
			return View(image);
		}

        public IActionResult BulkUpload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BulkUpload(List<IFormFile> images)
        {
            if (images == null || images.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No images selected for upload.");
                return View();
            }

            foreach (var file in images)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var imagePath = Path.Combine("wwwroot/images", fileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var image = new Image
                    {
                        Name = fileName,
                        Path = $"/images/{fileName}"
                    };

                    _context.Images.Add(image);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
