using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomerFormat;

namespace CostumerFormat.NUnitTests
{
    public class CustomerTests
    {
        [TestCase("Sir Alex","+375 29 858 63 74", 7500, ExpectedResult = true)]
        [TestCase("Valera", "+1 (500) 866 988", 70, ExpectedResult = true)]
        public bool ToString_PositiveTest(string name, string phone, decimal revenue)
        {
            Customer customer = new Customer(name, phone, revenue);
            bool ans = true;
            if (customer.ToString("G", CultureInfo.CurrentCulture) !=
                $"Customer record: {name}, Phone: {phone}") ans = false;
            if (customer.ToString("f", CultureInfo.CurrentCulture) !=
                $"Customer record: {name}, Phone: {phone}, Revenue:{revenue.ToString("C", CultureInfo.CurrentCulture)}") ans = false;
            if (customer.ToString("S", CultureInfo.CurrentCulture) !=
                $"Customer record: {name}") ans = false;
            if (customer.ToString("P", CultureInfo.CurrentCulture) !=
                $"Customer record: {phone}") ans = false;
            if (customer.ToString("R", CultureInfo.CurrentCulture) !=
                $"Customer record: {revenue.ToString("C", CultureInfo.CurrentCulture)}") ans = false;
            return ans;
        }
    }
}