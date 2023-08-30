using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace InvoiceGenAppAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("GetItem")]
        public async Task<IActionResult> GetItem()
        {
            var items = await _itemService.GetItemsAsync();
            return Ok(items);
        }

        [HttpPost("Add")]

        public async Task<IActionResult> Add(ItemDTO itemdto)
        {
            var result = await _itemService.AddItem(itemdto);

            return Ok(result);
        }
    }
}
