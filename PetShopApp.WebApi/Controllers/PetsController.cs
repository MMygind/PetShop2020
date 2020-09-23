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
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            try
            {
                return _petService.GetAllPets();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }

        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petService.FindPetById(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find Pet with ID " + id);
            }

            try
            {
                return _petService.FindPetById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }

        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return StatusCode(500, "Name is required for Creating Pet");
            }

            return _petService.CreatePet(pet);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return StatusCode(404, "Parameter Id and Pet Id must be the same");
            }

            try
            {
                return _petService.UpdatePet(pet);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }

        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find Pet with ID " + id);
            }

            try
            {
                return pet;
            }
            catch (Exception)
            {
                return StatusCode(500, "Task failed successfully");
            }

        }

        // GET api/<PetsController>/5
        [HttpGet("{type}")]
        [Route("[action]/{type}")]
        public ActionResult<List<Pet>> GetFiltered(string type)
        {
            try
            {
                return _petService.GetAllByType(type);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Task failed successfully");
            }
            
        }
    }
}
