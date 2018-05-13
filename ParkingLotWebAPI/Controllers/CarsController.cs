using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotWebAPI.Services;

namespace ParkingLotWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/cars")]
    public class CarsController : Controller
    {
        private CarsService _carsService;

        public CarsController(CarsService carsService)
        {
            _carsService = carsService;
        }

        // GET: api/cars
        [HttpGet]
        public IActionResult Get()
        {
            var cars = _carsService.GetParkedCars();
            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        // GET: api/cars/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(uint id)
        {
            if (!_carsService.IsCarExist(id))
            {
                return NotFound();
            }

            var car = _carsService.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // POST: api/cars
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(uint id)
        {
            if (!_carsService.IsCarExist(id))
            {
                return NotFound();
            }

            if (!_carsService.DeleteCar(id))
            {
                return StatusCode(403, "The car can not be removed from the parking lot, you have a debt for parking.");
            }
            return NoContent();
        }
    }
}
