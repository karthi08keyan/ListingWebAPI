
using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Model.DataContract.Response;
using ListingScreenAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListingScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
       
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
           
            _itemService = itemService;
        }
        CommonResponse response = new CommonResponse();

        [HttpGet]
        public async Task<ActionResult> Get(int ItemId)
        {
          
            try
            {
                response.SetSuccessStatus( await _itemService.GetItems(ItemId));
                return Ok(response);
            }
            catch (Exception ex)
            {
               
                response.SetStatus(System.Net.HttpStatusCode.InternalServerError, null, "Internel server error,Error Geting Data");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpDelete]
        
        public async Task<ActionResult> Delete(int ItemId)
        {
          
            try
            {
                bool delete = await _itemService.DeleteItem(ItemId);
                if (delete)
                {
                    response.SetSuccessStatus(null, "Customer Deleted Succusfull!");

                    return Ok(response);
                }
                else
                {
                    response.SetSuccessStatus(null, "No Data Found!");

                    return Ok(response);

                }

               
            }
            catch (Exception ex)
            {
              
                response.SetStatus(System.Net.HttpStatusCode.InternalServerError, null, "Internel server error, Deleting Failed");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            
        }

        [HttpPost]
        

        public async Task<ActionResult> Post(ItemRequest item)
        {
          
            try
            {
                if(item.ItemId == 0)
                {
                    response.SetSuccessStatus(await _itemService.AddItem(item), "Saved successfully!");
                    return Ok(response);

                }
                else
                {
                    response.SetSuccessStatus(await _itemService.AddItem(item), "Updated successfully!");
                    return Ok(response);

                }
               
            }
            catch (Exception ex)
            {
               
                response.SetStatus(System.Net.HttpStatusCode.InternalServerError, null, "Internel server error,Saving Or Updating Is failed");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }
    }
}
