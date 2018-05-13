using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotCore.Entities;

namespace ParkingLotWebAPI.Models
{
    public class CarDto
    {
        public uint Id { get; set; }
        public CarType Type { get; set; }
        public decimal Balance { get; set; }
    }
}
