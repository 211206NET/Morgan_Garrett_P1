using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IBL _bl;
        public OrdersController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Orders>> Get(int Cid, int Sid)
        {
            List<Orders> orders = _bl.GetAllOrdersforCustomers(Cid,Sid);

                return Ok(orders);
            
          //  return _bl.GetAllOrders();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{CustomerId}")]
        public ActionResult<Orders> GetOrders(int CustomerId)
        {
            Orders showInvent = _bl.GetCustomerOrders(CustomerId);

            return Ok(showInvent);

        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post(int storeId,int custId, int subI, [FromBody] Orders OrdersToAdd)
        {
            string Date = DateTime.Now.ToString();

            try
            {
                _bl.AddOrders(Date,OrdersToAdd);
               //  Orders currOrd = _bl.GetCustomerOrders(custId);
                //  Inventory currInvent = _bl.GetInventoriesByStoreId(storeId);
                 Inventory currInvent = _bl.GetInventoriesByStoreId(storeId);
                currInvent.Quantity = currInvent.Quantity - subI;
                _bl.ChangeInventory(storeId, currInvent.Quantity);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
            return Created("Successfully Added", OrdersToAdd);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
