﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotCore.Entities;

namespace ParkingLotCore.Services
{
    public class FileReader
    {
        public string ReadTransactionFromFile()
        {
            using (StreamReader sr = new StreamReader("Transactions.log", System.Text.Encoding.Default))
            {
                StringBuilder accumulator = new StringBuilder();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    accumulator.Append(line + "\n");
                }

                return accumulator.ToString();
            }
        }
    }
}
