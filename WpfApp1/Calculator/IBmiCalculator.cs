using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Calculator
{
    internal interface IBmiCalculator
    {
        double CalculateBmi(double weight, double height);
    }
}
