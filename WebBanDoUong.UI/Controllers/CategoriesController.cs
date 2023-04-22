using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanDoUong.UI.Models.Domain;
using WebBanDoUong.UI.Models.DTO;
using WebBanDoUong.UI.Repository.Abstract;
using WebBanDoUong.UI.Repository.Implementation;

namespace WebBanDoUong.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IFileService fileService;

        public CategoriesController(ICategoryRepository categoryRepository, IFileService fileService)
        {
            this.categoryRepository = categoryRepository;
            this.fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = categoryRepository.GetAll();
            return Ok(categories);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (category.ImageFile != null)
            {
                var fileResult = fileService.SaveImage(category.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    category.Image = fileResult.Item2; // getting name of image
                }
                var productResult = categoryRepository.Add(category);
                if (productResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error on adding product";

                }
            }
            return Ok(status);
        }
    }
}
