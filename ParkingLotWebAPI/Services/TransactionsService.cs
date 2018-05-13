using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotCore;

namespace ParkingLotWebAPI.Services
{
    public class TransactionsService
    {
        public CoreApp CoreApp { get; private set; }

        public TransactionsService()
        {
            CoreApp = CoreApp.Instance;
        }

        //View Transactions.log (GET)

        //Last minute transaction (GET)

        //Transaction for the last minute on one particular machine(GET)

        //Fill the machine balance (PUT)
    }
}
