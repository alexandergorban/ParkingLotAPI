using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotCore;
using ParkingLotWebAPI.Services;

namespace ParkingLotWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/parking")]
    public class ParkingController : Controller
    {
        private readonly ParkingService _parkingService;

        public ParkingController(ParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        // GET: api/parking
        [HttpGet]
        //public IEnumerable<string> Get()
        public IActionResult Get()
        {
            return Ok();
        }

        // GET: api/parking/freeplaces
        [HttpGet("freeplaces")]
        public IActionResult GetFreePlaces()
        {
            var freePlaces = _parkingService.GetNumberFreePlaces();
            if (freePlaces == null)
            {
                return NotFound();
            }

            return Ok(freePlaces);
        }

        // GET: api/parking/occupiedplaces
        [HttpGet("occupiedplaces")]
        public IActionResult GetOccupiedPlaces()
        {
            var freePlaces = _parkingService.GetNumberOccupiedPlaces();
            if (freePlaces == null)
            {
                return NotFound();
            }

            return Ok(freePlaces);
        }

        // GET: api/parking/generalincome
        [HttpGet("generalincome")]
        public IActionResult GetGeneralIncome()
        {
            var freePlaces = _parkingService.GetGeneralIncome();
            if (freePlaces == null)
            {
                return NotFound();
            }

            return Ok(freePlaces);
        }
    }
}
