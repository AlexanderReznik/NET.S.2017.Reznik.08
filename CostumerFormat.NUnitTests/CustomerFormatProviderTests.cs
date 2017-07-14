using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerFormat;
using NUnit.Framework;

namespace CostumerFormat.NUnitTests
{
    class CustomerFormatProviderTests
    {
        private readonly CustomerFormatProvider provider = new CustomerFormatProvider();
        private Customer customer;

        [TestCase("Valera", "+1 (500) 866 988", 70, ExpectedResult = true)]
        public bool ToString_PositiveTest(string name, string phone, decimal revenue)
        {
            customer = new Customer(name, phone, revenue);
            bool ans = true;

            if (String.Format(provider, "{0:xml}", customer) != $"<customer><name>{customer.Name}<//name><phone>{customer.ContactPhone}<//phone><revenue>{customer.Revenue}<//revenue><//customer>") ans = false;
            if (String.Format(provider, "{0:h}", customer) != $"Hello, I am a customer. My name is {customer.Name}. Call me {customer.ContactPhone} :)") ans = false;

            return ans;
        }
    }
}
