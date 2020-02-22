using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parking_lot
{
    enum ParkingOption
    {
        Book,
        Leave,
        Status
    }


    public abstract class Parking
    {
        protected int ParkingSize = 0;
        public abstract int IsAvailable();
        public abstract int Leave(string CarNumber);
        public abstract int Book(string CarNumber);
        public abstract string[] Status();
    }

    public class Car : Parking
    {
        string[] Cars;
        IValidate validate;
        public Car(int size, IValidate validate)
        {
            ParkingSize = size;
            this.validate = validate;
            Cars = new string[size];
        }

        public override int IsAvailable()
        {
            for (int index = 0; index < Cars.Length; index++)
            {
                var car = Cars[index];
                if (car == string.Empty)
                {
                    return index + 1;
                }
            }
            return -1;
        }

        public override int Leave(string CarNumber)
        {
            if (!validate.ValidateNumber(CarNumber))
            {
                throw new Exception(CarNumber + " is not valid");
            }
            for (int index = 0; index < Cars.Length; index++)
            {
                var car = Cars[index];
                if (car == CarNumber.ToUpper())
                {
                    Cars[index] = string.Empty;
                    return index + 1;
                }
            }
            return -1;
        }
        public override int Book(string CarNumber)
        {
            if (!validate.ValidateNumber(CarNumber))
            {
                throw new Exception(CarNumber + " is not valid");
            }
            var available = IsAvailable();
            Cars[available - 1] = CarNumber.ToUpper();
            return available;
        }
        public override string[] Status()
        {
            return Cars.Where(car => !string.IsNullOrEmpty(car)).ToArray();
        }

    }
}
