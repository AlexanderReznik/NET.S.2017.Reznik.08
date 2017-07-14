using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    /// <summary>
    /// Class for formatting class Customer
    /// </summary>
    public class CustomerFormatProvider : ICustomFormatter, IFormatProvider
    {
        /// <summary>
        /// Method is used to get a string representation of Customer
        /// </summary>
        /// <param name="format">"XML" for xml string, "H" for hello string</param>
        /// <param name="arg">Customer, I hope</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>(String)Customer</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null)) throw new ArgumentNullException();
            if (arg.GetType() != typeof(Customer))
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }

            format = format.ToUpper(CultureInfo.InvariantCulture);
            if (!(format == "XML" || format == "H"))
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }

            Customer c = arg as Customer;

            switch (format)
            {
                case "XML":
                    return
                        $"<customer><name>{c.Name}<//name><phone>{c.ContactPhone}<//phone><revenue>{c.Revenue}<//revenue><//customer>";
                case "H":
                    return $"Hello, I am a customer. My name is {c.Name}. Call me {c.ContactPhone} :)";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// returns formatter
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns>formatter</returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
