using APIshka.DbContexts;
using APIshka.Entities;
using APIshka.Request;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace APIshka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateNews : Controller
    {

        // Для добавления новостей. Фотографию в массив байтов не переводит
        [HttpPost("add_news")]
        public async Task<IActionResult> AddNewsAsync([FromForm] CreateNewsRequest request)
        {
            string? imagesName = null;
            AppDbContext dbContext = new AppDbContext();

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Название не может быть нулловым");
            }

            if (request.Image != null)
            {
                if (request.Image.Length > 0)
                {
                    var fileExtension = Path.GetExtension(request.Image.FileName);
                    var fileName = Guid.NewGuid().ToString() + fileExtension;
                    imagesName = fileName;

                    string filePath = Path.Combine("static/files/images", fileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(fileStream);
                    }

                }
            }
            dbContext.News.Add(new New(request.Title, request.Description, imagesName, Memmory.UserId));
            dbContext.SaveChanges();


            return Created();
        }

        // возвращает данные о новости и ссылку на изображение
        [HttpGet]
        public async Task<IActionResult> GetAllNewsAsync()
        {
            AppDbContext dbContext = new AppDbContext();
            var columns = dbContext.News
                .Select(n => new { n.NewsId,
                    n.Title,
                    n.Description,
                    image = n.ImagesName != null ? $"http://localhost:5155/static/files/images/{n.ImagesName}" : null })
                .ToList();


            return Ok(columns);
        }

        // Возвращает ссылку на изображение
        [HttpGet("{name}")]
        public async Task<IActionResult> GetNewsImageAsync(string name)
        {

            var filePath = $"http://localhost:5155/static/files/images/{name}";

            return Ok(filePath);
        }

        // возвращает имена всех изображение
        // п.с. я пока хз зачем это сделал
        [Route("images_name")]
        [HttpGet]
        public async Task<IActionResult> GetNewImageNameAsync()
        {
            AppDbContext dbContext= new AppDbContext();
            var imagesName = dbContext.News.Select(n => n.ImagesName).ToList();

            return Ok(imagesName);
        }

    }
}
