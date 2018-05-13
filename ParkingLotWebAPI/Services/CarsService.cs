using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotCore;
using ParkingLotCore.Entities;

namespace ParkingLotWebAPI.Services
{
    public class CarsService
    {
        public IEnumerable<Car> GetParkedCars()
        {
            return CoreApp.Parking.Cars;
        }

        //Details on one machine (GET)
        public Car GetCar(uint carId)
        {
            return CoreApp.Parking.GetCar(carId);
        }

        //Delete machine (DELETE)
        public bool DeleteCar(uint carId)
        {
            return CoreApp.Parking.RemoveCar(carId);
        }

        //Add a car (POST)
        public Car AddCar(Guid carId)
        {

            return null;
        }

        public bool IsCarExist(uint carId)
        {
            return CoreApp.Parking.IsCarExist(carId);
        }
    }
}
