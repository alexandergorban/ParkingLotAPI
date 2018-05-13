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
        private TransactionsService _transactionsService;

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

        // GET: api/transactions/lastmin
        [HttpGet("lastmin")]
        public IActionResult GetLastMin()
        {
            var transactions = _transactionsService.GetLastMinuteTransactions();
            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
