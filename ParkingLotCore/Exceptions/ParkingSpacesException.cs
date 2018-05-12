using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotCore.Exceptions
{
    [Serializable]
    class ParkingSpacesException : Exception
    {
        public ParkingSpacesException()
        {
        }

        public ParkingSpacesException(string message)
            : base(message)
        {
        }

        public ParkingSpacesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
