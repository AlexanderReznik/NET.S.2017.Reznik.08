using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    /// <summary>
    /// Class customer
    /// </summary>
    public class Customer : IFormattable
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        private string _contactPhone;

        /// <summary>
        /// Contact phone in any format
        /// </summary>
        public string ContactPhone
        {
            get { return _contactPhone; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException();
                _contactPhone = value;
            }
        }

        /// <summary>
        /// Money:)
        /// </summary>
        public decimal Revenue { get; set; }

        public Customer(string name, string phone, decimal revenue)
        {
            ContactPhone = phone;
            Name = name;
            Revenue = revenue;
        }

        /// <summary>
        /// gets string representation of customer
        /// </summary>
        /// <returns>String representation of customer</returns>
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// gets string representation of customer in special format
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="formatProvider">format provider. For example culture or your provider</param>
        /// <returns>String representation of customer</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            if (ReferenceEquals(formatProvider, null)) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G": return $"Customer record: {Name}, Phone: {ContactPhone}";
                case "F": return $"Customer record: {Name}, Phone: {ContactPhone}, Revenue:{Revenue.ToString("C", formatProvider)}";//$"{Name}, Phone: {ContactPhone}, {Revenue:C}"
                case "S": return "Customer record: " + Name;
                case "P": return "Customer record: " + ContactPhone;
                case "R": return "Customer record: " + Revenue.ToString("C", formatProvider);
                default: return "Customer record.";
            }
        }
    }
}
