using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IBL _bl;

        public CustomerController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> Get()
        {
            return _bl.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer CustoToAdd)
        {
            try 
            {
                _bl.AddCustomer(CustoToAdd);
                return Created("Successfully Added", CustoToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
