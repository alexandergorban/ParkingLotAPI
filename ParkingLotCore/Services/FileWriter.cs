﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotCore.Entities;

namespace ParkingLotCore.Services
{
    public class FileWriter
    {
        // Set interval for logging (1 min)
        private TimeSpan interval = new TimeSpan(0, 1, 0);

        public void LogTransactionToFile(object obj)
        {
            var lastTransactionsForWrite =
                CoreApp.Parking.Transactions.Where<Transaction>(t => DateTime.Now - t.Time < interval);

            using (StreamWriter sw = new StreamWriter("Transactions.log", true, System.Text.Encoding.Default))
            {
                decimal accumulator = 0;
                foreach (var transaction in lastTransactionsForWrite)
                {
                    accumulator += transaction.WithdrawMoney;
                }

                sw.WriteLine("DateTime: {0} Transaction Amount: {1}", DateTime.Now, accumulator);
            }

        }
    }
}
