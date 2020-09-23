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
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        // GET: api/<PetTypeController>
        [HttpGet]
        public ActionResult<List<PetType>> Get()
        {
            try
            {
                return _petTypeService.GetAllPetTypes();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public ActionResult<PetType> Get(int id)
        {
            var petType = _petTypeService.FindPetTypeById(id);
            if (petType == null)
            {
                return StatusCode(404, "Did not find PetType with ID " + id);
            }

            try
            {
                return _petTypeService.FindPetTypeById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }

        }

        // POST api/<PetTypeController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.Name))
            {
                return StatusCode(500, "Name is required for Creating PetType");
            }


            return _petTypeService.CreatePetType(petType);
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            if (id < 1 || id != petType.Id)
            {
                return StatusCode(404, "Parameter Id and PetType Id must be the same");
            }

            try
            {
                return _petTypeService.UpdatePetType(petType);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            var petType = _petTypeService.DeletePetType(id);
            if (petType == null)
            {
                return StatusCode(404, "Did not find PetType with ID " + id);
            }

            try
            {
                return _petTypeService.DeletePetType(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }

        // GET api/<OwnerController>/5
        [HttpGet("{name}")]
        [Route("[action]/{name}")]
        public ActionResult<List<PetType>> GetFiltered(string name)
        {
            try
            {
                return _petTypeService.GetAllByName(name);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }
    }
}
