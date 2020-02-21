using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot
{



    public class ParkingPlot
    {
        const int AvailablePlotSize = 6;
        List<string> Park;
        public ParkingPlot()
        {
            var Park = new List<string>()
            {
                "KA-01-HH-1234",
                "KA-01-HH-9999",
                "KA-01-BB-0001",
                "KA-01-HH-7777",
                "KA-01-HH-2701",
                "KA-01-HH-3141"
            };
        }

        public bool CheckParkingIsAvailable()
        {
            return Park.Count < (AvailablePlotSize - 1);
        }

        public void Leave(string CarNumber)
        {
            Park.Remove(CarNumber);
        }
        public void Book(string CarNumber)
        {
            Park.Add(CarNumber);
        }
        public IEnumerable<string> Status()
        {
            return Park;
        }


    }
}
