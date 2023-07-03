
using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Model.DataContract.Response;
using ListingScreenAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListingScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      
        private readonly ICustomerService _customerService;
        

        public CustomerController(ICustomerService customerService)
        {
          
            _customerService = customerService;

          
        }

        CommonResponse response = new CommonResponse();
        


        [HttpGet]

        public async Task<IActionResult> Get(int customerId)
        {
           
            try
            {
                response.SetSuccessStatus(await _customerService.GetCustomer(customerId));
                return Ok(response);
            }
            catch (Exception ex)
            {
                
                response.SetStatus(System.Net.HttpStatusCode.InternalServerError, null, "Internel server error,Error Geting Data");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
           
        }


        [HttpDelete]
      
        public async Task<IActionResult> Delete(int customerId)
        {

           
            try
            {
                bool delete = await _customerService.DeleteCustomer(customerId);
                if (delete)
                {
                    response.SetSuccessStatus(null,"Customer Deleted Succusfull!");

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
       
        public async Task<IActionResult> Post(CustomerRequest customer)
                {
            try
            { 

                if (customer.CustomerId == 0)
                {
                    response.SetSuccessStatus(await _customerService.AddCustomer(customer), "Saved successfully!");
                    return Ok(response);

                }
                else
                {
                    response.SetSuccessStatus(await _customerService.AddCustomer(customer), "Updated successfully!");
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
