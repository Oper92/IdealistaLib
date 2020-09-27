using System;
using System.Collections.Generic;
using System.Text;

namespace IdealistaLib
{
    class OfficeFilter :IdealistaFilter
    {
        public double minSize { get; set; }
        public double maxSize { get; set; }
        public string layout { get; set; }
        public double buildingType { get; set; }
        public bool garage { get; set; }
        public bool hotWater { get; set; }
        public bool heating { get; set; }

        public bool elevator { get; set; }
        public bool airConditioning { get; set; }

        public bool security { get; set; }
        public bool exterior { get; set; }
        public bool bankOffer { get; set; }
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
