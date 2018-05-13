using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotCore;
using ParkingLotCore.Entities;

namespace ParkingLotWebAPI.Services
{
    public class TransactionsService
    {
        //View Transactions.log (GET)
        public string GetTransactionsFile()
        {
            return CoreApp.ParkingService.FileReader.ReadTransactionFromFile();
        }

        //Last minute transactions (GET)
        public IEnumerable<Transaction> GetLastMinuteTransactions()
        {
            return CoreApp.Parking.GetLastTransactions(1);
        }

        //Transaction for the last minute on one particular machine(GET)

        //Fill the machine balance (PUT)
    }
}
