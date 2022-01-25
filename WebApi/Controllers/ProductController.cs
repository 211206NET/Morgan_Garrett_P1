using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IBL _bl;
        public ProductController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public List<Inventory> Get()
        {
            return _bl.GetAllInventories();
        }

        // GET api/<ProductController>/5
        [HttpGet("{storeId}")]
        public ActionResult<List<Inventory>> GetSpecific(int storeId)
        {
          //List <Inventory> showInvent = _bl.GetInventoriesById(storeId);

          //  return Ok(showInvent);
            return _bl.GetInventoriesById(storeId);


        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post(int Id, [FromBody] Inventory InventoryToAdd)
        {
            try
            {
                _bl.AddInventory(Id, InventoryToAdd);
            return Created("Successfully Added", InventoryToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id,int addI)
        {
        
            Inventory currInvent = _bl.GetInventoriesByStoreId(id);
            currInvent.Quantity = currInvent.Quantity + addI;
            _bl.ChangeInventory(id, currInvent.Quantity);
         
            return;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
