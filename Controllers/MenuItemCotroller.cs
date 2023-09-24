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
    }
}
