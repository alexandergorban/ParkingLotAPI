using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotCore;

namespace ParkingLotWebAPI.Services
{
    public class ParkingService
    {
        //Number of free places (GET)
        public string GetNumberFreePlaces()
        {
            return CoreApp.Parking.GetNumberAvailableParkingSpaces().ToString();
        }

        //Number of occupied places (GET)
        public string GetNumberOccupiedPlaces()
        {
            return CoreApp.Parking.GetNumberBusyParkingSpaces().ToString();
        }

        //General Income (GET)
        public string GetGeneralIncome()
        {
            return CoreApp.Parking.GetEarnedMoney().ToString();
        }
    }
}
