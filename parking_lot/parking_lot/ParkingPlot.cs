using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot
{
    public class ParkingPlot
    {
        const int ParkingSize = 6;
        List<string> Cars;
        public ParkingPlot()
        {
            Cars = new List<string>()
            {
                "KA-01-HH-1234",
                "KA-01-HH-9999",
                "KA-01-BB-0001",
                "KA-01-HH-7777",
                "KA-01-HH-2701",
                "KA-01-HH-3141"
            };
        }

        public bool IsAvailable()
        {
            return Cars.Count < (ParkingSize );
        }

        public void Leave(string CarNumber)
        {
            Cars.Remove(CarNumber.ToUpper());
        }
        public void Book(string CarNumber)
        {
            Cars.Add(CarNumber.ToUpper());
        }
        public IEnumerable<string> Status()
        {
            return Cars;
        }
    }
}
