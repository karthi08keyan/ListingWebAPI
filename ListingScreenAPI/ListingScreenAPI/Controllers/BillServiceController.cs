using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Model.DataContract.Response;
using ListingScreenAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListingScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillServiceController : ControllerBase
    {
        private IBillService billService;

        public BillServiceController(IBillService ibillservice)
        {
            billService = ibillservice;
        }

        CommonResponse response = new CommonResponse();
        [HttpGet]
        public async Task<IActionResult> Get(string billNo)
        {
            response.SetSuccessStatus(await billService.GetBillNumber(billNo));
            return Ok( response);
        }

       
        [HttpPost]
        public async Task<IActionResult> POST(CustomerBillRequest customerBill)
        {
            response.SetSuccessStatus(await billService.PostCustomer(customerBill));
            return Ok( response );
        }
        [Route("ItemBill")]
        [HttpPost]
        public async Task<IActionResult> POST (ItemRequest customerItemBill)
                {
           response.SetSuccessStatus(await billService.PostCustomerItemBill(customerItemBill));
          return Ok( response );
       }

        [Route("ItemBill")]
        [HttpGet]
        public async Task<IActionResult> GET(int billNo)
        {
            response.SetSuccessStatus(await billService.GetCustomerItemBill(billNo));
            return Ok(response);
        }
        [Route("ItemBill")]
        [HttpDelete]
        public async Task<IActionResult> DELETE(int billNo)
        {
            response.SetSuccessStatus(await billService.DELETECustomerItemBill(billNo));
            return Ok(response);
        }
    }
}
