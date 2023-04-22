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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IFileService fileService;

        public ProductsController(IProductRepository productRepository, IFileService fileService)
        {
            this.productRepository = productRepository;
            this.fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = productRepository.GetAll();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Add([FromForm] ProductDTO productDTO)
        {
            // DTO => Domain
            var product = new Product()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                ImageFile = productDTO.ImageFile,
                CategoryId = productDTO.CategoryId,
            };


            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (product.ImageFile != null)
            {
                var fileResult = fileService.SaveImage(product.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    product.Image = fileResult.Item2; // getting name of image
                }
                var productResult = productRepository.Add(product);
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

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
