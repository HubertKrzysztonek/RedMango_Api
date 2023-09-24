using Microsoft.AspNetCore.Mvc;
using RedMango_Api.Database;
using RedMango_Api.Models;
using System.Net;

namespace RedMango_Api.Controllers
{
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemCotroller :ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private ApiResponse _response;

        public MenuItemCotroller(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            _response.Result = _dbcontext.MenuItems;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        
        [HttpGet("int:id")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            MenuItem menuItem = _dbcontext.MenuItems.FirstOrDefault(i => i.Id == id);
            if (menuItem == null)
            {
                _response.StatusCode=HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = menuItem;
            return Ok(_response);
        }
    }
}
