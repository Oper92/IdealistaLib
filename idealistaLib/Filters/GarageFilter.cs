using System;
using System.Collections.Generic;
using System.Text;

namespace IdealistaLib
{
    public class GarageFilter : IdealistaFilter
    {

        public bool BankOffer { get; set; }

        public bool AutomaticDoor { get; set; }
        public bool motorCycleParking { get; set; }
        public bool security { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var property in this.GetType().GetProperties())
            {
                var thekey = property.Name;
                var thevalue = property.GetValue(this, null);
                if (thevalue != null)
                {
                    if (property.PropertyType == typeof(bool))
                    {
                        if ((bool)thevalue == false)
                        {
                            continue;
                        }
                    }
                    if (property.PropertyType == typeof(string))
                    {
                        if ((string)thevalue == "")
                        {
                            continue;
                        }
                    }
                    if (property.PropertyType == typeof(int))
                    {
                        if ((int)thevalue == 0)
                        {
                            continue;
                        }
                    }
                    if (property.PropertyType == typeof(double))
                    {
                        if ((double)thevalue == 0)
                        {
                            continue;
                        }
                    }
                    sb.Append("&" + thekey + "=" + thevalue);
                }
            }
            return sb.ToString();
        }
    }
}
