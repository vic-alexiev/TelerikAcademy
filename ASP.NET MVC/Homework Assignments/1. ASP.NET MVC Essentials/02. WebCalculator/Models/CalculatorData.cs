using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalculator.Models
{
    public class CalculatorData
    {
        private Dictionary<string, double> decimalQuotients;

        private Dictionary<string, double> binaryQuotients;

        private IEnumerable<SelectListItem> units;

        private IEnumerable<SelectListItem> kilos;

        public CalculatorData()
        {
            this.LoadBinaryQuotients();
            this.LoadDecimalQuotients();
            this.units = this.PopulateUnits();
            this.kilos = this.PopulateKilos();
        }

        public IEnumerable<SelectListItem> Units
        {
            get
            {
                return this.units;
            }
        }

        public IEnumerable<SelectListItem> Kilos
        {
            get
            {
                return this.kilos;
            }
        }

        public string SelectedUnit { get; set; }

        public int SelectedKilo { get; set; }

        public double Quantity { get; set; }

        public Dictionary<string, double> Conversions { get; set; }

        public void ConvertUnits()
        {
            this.Conversions = new Dictionary<string, double>();
            double commonQuotient = 0;

            if (this.SelectedKilo == 1000)
            {
                commonQuotient = this.Quantity / this.decimalQuotients[this.SelectedUnit];

                this.Conversions.Add("Bit", commonQuotient * this.decimalQuotients["Bit"]);
                this.Conversions.Add("Byte", commonQuotient * this.decimalQuotients["Byte"]);
                this.Conversions.Add("Kilobit", commonQuotient * this.decimalQuotients["Kilobit"]);
                this.Conversions.Add("Kilobyte", commonQuotient * this.decimalQuotients["Kilobyte"]);
                this.Conversions.Add("Megabit", commonQuotient * this.decimalQuotients["Megabit"]);
                this.Conversions.Add("Megabyte", commonQuotient * this.decimalQuotients["Megabyte"]);
                this.Conversions.Add("Gigabit", commonQuotient * this.decimalQuotients["Gigabit"]);
                this.Conversions.Add("Gigabyte", commonQuotient * this.decimalQuotients["Gigabyte"]);
                this.Conversions.Add("Terabit", commonQuotient * this.decimalQuotients["Terabit"]);
                this.Conversions.Add("Terabyte", commonQuotient * this.decimalQuotients["Terabyte"]);
                this.Conversions.Add("Petabit", commonQuotient * this.decimalQuotients["Petabit"]);
                this.Conversions.Add("Petabyte", commonQuotient * this.decimalQuotients["Petabyte"]);
                this.Conversions.Add("Exabit", commonQuotient * this.decimalQuotients["Exabit"]);
                this.Conversions.Add("Exabyte", commonQuotient * this.decimalQuotients["Exabyte"]);
                this.Conversions.Add("Zettabit", commonQuotient * this.decimalQuotients["Zettabit"]);
                this.Conversions.Add("Zettabyte", commonQuotient * this.decimalQuotients["Zettabyte"]);
                this.Conversions.Add("Yottabit", commonQuotient * this.decimalQuotients["Yottabit"]);
                this.Conversions.Add("Yottabyte", commonQuotient * this.decimalQuotients["Yottabyte"]);
            }
            else
            {
                commonQuotient = this.Quantity / this.binaryQuotients[this.SelectedUnit];

                this.Conversions.Add("Bit", commonQuotient * this.binaryQuotients["Bit"]);
                this.Conversions.Add("Byte", commonQuotient * this.binaryQuotients["Byte"]);
                this.Conversions.Add("Kilobit", commonQuotient * this.binaryQuotients["Kilobit"]);
                this.Conversions.Add("Kilobyte", commonQuotient * this.binaryQuotients["Kilobyte"]);
                this.Conversions.Add("Megabit", commonQuotient * this.binaryQuotients["Megabit"]);
                this.Conversions.Add("Megabyte", commonQuotient * this.binaryQuotients["Megabyte"]);
                this.Conversions.Add("Gigabit", commonQuotient * this.binaryQuotients["Gigabit"]);
                this.Conversions.Add("Gigabyte", commonQuotient * this.binaryQuotients["Gigabyte"]);
                this.Conversions.Add("Terabit", commonQuotient * this.binaryQuotients["Terabit"]);
                this.Conversions.Add("Terabyte", commonQuotient * this.binaryQuotients["Terabyte"]);
                this.Conversions.Add("Petabit", commonQuotient * this.binaryQuotients["Petabit"]);
                this.Conversions.Add("Petabyte", commonQuotient * this.binaryQuotients["Petabyte"]);
                this.Conversions.Add("Exabit", commonQuotient * this.binaryQuotients["Exabit"]);
                this.Conversions.Add("Exabyte", commonQuotient * this.binaryQuotients["Exabyte"]);
                this.Conversions.Add("Zettabit", commonQuotient * this.binaryQuotients["Zettabit"]);
                this.Conversions.Add("Zettabyte", commonQuotient * this.binaryQuotients["Zettabyte"]);
                this.Conversions.Add("Yottabit", commonQuotient * this.binaryQuotients["Yottabit"]);
                this.Conversions.Add("Yottabyte", commonQuotient * this.binaryQuotients["Yottabyte"]);
            }
        }

        private IEnumerable<SelectListItem> PopulateUnits()
        {
            List<Unit> units = new List<Unit>();
            units.Add(new Unit
            {
                Code = "b",
                Name = "Bit"
            });
            units.Add(new Unit
            {
                Code = "B",
                Name = "Byte"
            });
            units.Add(new Unit
            {
                Code = "Kb",
                Name = "Kilobit"
            });
            units.Add(new Unit
            {
                Code = "KB",
                Name = "Kilobyte"
            });
            units.Add(new Unit
            {
                Code = "Mb",
                Name = "Megabit"
            });
            units.Add(new Unit
            {
                Code = "MB",
                Name = "Megabyte"
            });
            units.Add(new Unit
            {
                Code = "Gb",
                Name = "Gigabit"
            });
            units.Add(new Unit
            {
                Code = "GB",
                Name = "Gigabyte"
            });
            units.Add(new Unit
            {
                Code = "Tb",
                Name = "Terabit"
            });
            units.Add(new Unit
            {
                Code = "TB",
                Name = "Terabyte"
            });
            units.Add(new Unit
            {
                Code = "Pb",
                Name = "Petabit"
            });
            units.Add(new Unit
            {
                Code = "PB",
                Name = "Petabyte"
            });
            units.Add(new Unit
            {
                Code = "Eb",
                Name = "Exabit"
            });
            units.Add(new Unit
            {
                Code = "EB",
                Name = "Exabyte"
            });
            units.Add(new Unit
            {
                Code = "Zb",
                Name = "Zettabit"
            });
            units.Add(new Unit
            {
                Code = "ZB",
                Name = "Zettabyte"
            });
            units.Add(new Unit
            {
                Code = "Yb",
                Name = "Yottabit"
            });
            units.Add(new Unit
            {
                Code = "YB",
                Name = "Yottabyte"
            });

            var listUnits =
                from unit in units
                select new SelectListItem
                {
                    Value = unit.Name,
                    Text = unit.Name + " - " + unit.Code
                };

            return listUnits;
        }

        private IEnumerable<SelectListItem> PopulateKilos()
        {
            List<SelectListItem> kilos = new List<SelectListItem>();
            kilos.Add(new SelectListItem
            {
                Value = "1024",
                Text = "1024"
            });

            kilos.Add(new SelectListItem
            {
                Value = "1000",
                Text = "1000"
            });

            return kilos;
        }

        private void LoadBinaryQuotients()
        {
            this.binaryQuotients = new Dictionary<string, double>();

            this.binaryQuotients.Add("Bit", 9.671406556917E+24);
            this.binaryQuotients.Add("Byte", 1.2089258196146E+24);
            this.binaryQuotients.Add("Kilobit", 9.4447329657393E+21);
            this.binaryQuotients.Add("Kilobyte", 1.1805916207174E+21);
            this.binaryQuotients.Add("Megabit", 9.2233720368548E+18);
            this.binaryQuotients.Add("Megabyte", 1.1529215046068E+18);
            this.binaryQuotients.Add("Gigabit", 9.007199254741E+15);
            this.binaryQuotients.Add("Gigabyte", 1.1258999068426E+15);
            this.binaryQuotients.Add("Terabit", 8796093022208);
            this.binaryQuotients.Add("Terabyte", 1099511627776);
            this.binaryQuotients.Add("Petabit", 8589934592);
            this.binaryQuotients.Add("Petabyte", 1073741824);
            this.binaryQuotients.Add("Exabit", 8388608);
            this.binaryQuotients.Add("Exabyte", 1048576);
            this.binaryQuotients.Add("Zettabit", 8192);
            this.binaryQuotients.Add("Zettabyte", 1024);
            this.binaryQuotients.Add("Yottabit", 8);
            this.binaryQuotients.Add("Yottabyte", 1);
        }

        private void LoadDecimalQuotients()
        {
            this.decimalQuotients = new Dictionary<string, double>();

            this.decimalQuotients.Add("Bit", 8.0E+24);
            this.decimalQuotients.Add("Byte", 1.0E+24);
            this.decimalQuotients.Add("Kilobit", 8.0E+21);
            this.decimalQuotients.Add("Kilobyte", 1.0E+21);
            this.decimalQuotients.Add("Megabit", 8.0E+18);
            this.decimalQuotients.Add("Megabyte", 1.0E+18);
            this.decimalQuotients.Add("Gigabit", 8.0E+15);
            this.decimalQuotients.Add("Gigabyte", 1.0E+15);
            this.decimalQuotients.Add("Terabit", 8000000000000);
            this.decimalQuotients.Add("Terabyte", 1000000000000);
            this.decimalQuotients.Add("Petabit", 8000000000);
            this.decimalQuotients.Add("Petabyte", 1000000000);
            this.decimalQuotients.Add("Exabit", 8000000);
            this.decimalQuotients.Add("Exabyte", 1000000);
            this.decimalQuotients.Add("Zettabit", 8000);
            this.decimalQuotients.Add("Zettabyte", 1000);
            this.decimalQuotients.Add("Yottabit", 8);
            this.decimalQuotients.Add("Yottabyte", 1);
        }
    }
}