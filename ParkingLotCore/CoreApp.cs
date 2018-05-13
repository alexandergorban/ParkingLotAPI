using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParkingLotCore.Entities;
using ParkingLotCore.Services;

namespace ParkingLotCore
{
    public class CoreApp
    {
        private static readonly Lazy<CoreApp> LazyParking = new Lazy<CoreApp>(() => new CoreApp());
        public static CoreApp Instance => LazyParking.Value;

        public static uint intervalForLoggingToFile = 60000; // 60 sec
        public static uint intervalForWithdrawMoney = 5000; // 5 sec

        //Initialize prices for Parking Lot by Car Type
        public static Dictionary<CarType, decimal> Dictionary { get; set; } = new Dictionary<CarType, decimal>()
        {
            { CarType.Motorcycle, 2 },
            { CarType.Passenger, 5},
            { CarType.Truck, 10},
            { CarType.Bus, 12}
        };

        //Initialize Parking Size
        public static UInt16 ParkingSpace { get; set; } = 100;

        //Coefficient of Penalty
        public static double Fine { get; set; } = 0.20;


        //Parking Instance
        public static Parking Parking { get; private set; }

        //Services
        public static ParkingService ParkingService { get; private set; }

        static CoreApp()
        {
            Parking = Parking.Instance;
            ParkingService = new ParkingService();

            AddMockData();
        }

        // Adding mock data
        private static void AddMockData()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car(1, CarType.Motorcycle, 50));
            cars.Add(new Car(2, CarType.Passenger, 90));
            cars.Add(new Car(3, CarType.Bus, 200));
            cars.Add(new Car(4, CarType.Truck, 300));
            cars.Add(new Car(5, CarType.Motorcycle, 100));
            cars.Add(new Car(6, CarType.Passenger, 200));
            cars.Add(new Car(7, CarType.Passenger, 150));

            foreach (Car car in cars)
            {
                Parking.AddCar(car);
            }
        }
    }
}
