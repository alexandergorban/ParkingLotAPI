using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ParkingLotCore;
using ParkingLotCore.Entities;
using ParkingLotWebAPI.Models;

namespace ParkingLotWebAPI.Services
{
    public class TransactionsService
    {
        //View Transactions.log (GET)
        public string GetTransactionsFile()
        {
            return CoreApp.ParkingService.FileReader.ReadTransactionFromFile();
        }

        //Last n-minutes transactions (GET)
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
        public bool IncreaseCarBalance(BalanceDto balanceDto)
        {
            if (IsCarExist(balanceDto.Id))
            {
                CoreApp.Parking.IncreaseCarBalance(balanceDto.Id, balanceDto.Balance);
                return true;
            }

            return false;
        }

        public bool IsCarExist(uint carId)
        {
            return CoreApp.Parking.IsCarExist(carId);
        }
    }
}
