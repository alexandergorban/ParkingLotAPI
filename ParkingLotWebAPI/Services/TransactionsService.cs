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
        public IEnumerable<Transaction> GetLastTransactions(int minutes)
        {
            return CoreApp.Parking.GetLastTransactions(minutes);
        }

        //Transaction for the last n-minute on one particular machine(GET)
        public IEnumerable<Transaction> GetLastTransactionsForCar(uint carId, int minutes)
        {
            return CoreApp.Parking.GetLastTransactionsForCar(carId, minutes);
        }


        //Fill the machine balance (PUT)
    }
}
