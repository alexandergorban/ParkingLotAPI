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
        public Car AddCar(CarDto carDto)
        {
            var car = Mapper.Map<Car>(carDto);
            CoreApp.Parking.AddCar(car);

            return car;
        }

        public bool IsCarExist(uint carId)
        {
            return CoreApp.Parking.IsCarExist(carId);
        }
    }
}
