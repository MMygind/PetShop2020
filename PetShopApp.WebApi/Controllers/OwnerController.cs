using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<List<Owner>> Get()
        {
            try
            {
                return _ownerService.GetAllOwners();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var owner = _ownerService.FindOwnerById(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Owner with ID " + id);
            }

            try
            {
                return _ownerService.FindOwnerById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.Name))
            {
                return StatusCode(500, "Name is required for Creating Owner");
            }
            return _ownerService.CreateOwner(owner);
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return StatusCode(404, "Parameter Id and Owner Id must be the same");
            }

            try
            {
                return _ownerService.UpdateOwner(owner);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Owner with ID " + id);
            }

            try
            {
                return _ownerService.DeleteOwner(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }
    }
}
