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
    [Route("api/transactions")]
    public class TransactionsController : Controller
    {
        private readonly TransactionsService _transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        // GET: api/transactions/file
        [HttpGet("file")]
        public IActionResult Get()
        {
            string transactionFile = _transactionsService.GetTransactionsFile();
            if (transactionFile == null)
            {
                return NotFound();
            }

            return Ok(transactionFile);
        }

        // GET: api/transactions/time/1
        [HttpGet("time/{minutes}")]
        public IActionResult GetTransactionTime(int minute)
        {
            var transactions = _transactionsService.GetLastTransactions(minute);
            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        // GET: api/transactions/car/5/time/1
        [HttpGet("car/{carId}/time/{minutes}/")]
        public IActionResult GetTransactionCarTime(uint carId, int minutes)
        {
            var transactions = _transactionsService.GetLastTransactionsForCar(carId, minutes);
            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        //// PUT: api/Transactions/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

    }
}
