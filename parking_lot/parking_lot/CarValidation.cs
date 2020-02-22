using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace parking_lot
{
    public interface IValidate
    {
        bool ValidateNumber(string number);
    }

    class CarValidation : IValidate
    {
        public bool ValidateNumber(string number)
        {
            return Regex.IsMatch(number, "^[A-Za-z]{2,2}-[0-9]{0,2}-[A-Za-z]{0,2}-[0-9]{0,4}$");
        }
    }
}
