using System;
using System.Collections.Generic;
using System.Text;

namespace IdealistaLib
{
    class PremiseFilter : IdealistaFilter
    {
        public double minSize { get; set; }

        public double maxSize { get; set; }

        public bool virtualTour { get; set; }
        public enum location
        {
            shoppingcenter,
            street,
            mezzanine,
            underground,
            others
        }
        public bool corner { get; set; }
        public bool airConditioning { get; set; }
        public bool smokeVentilation { get; set; }
        public bool heating { get; set; }
        public bool transfer { get; set; }
        public enum buildingTypes
        {
            premises,
            industrialBuilding

        }
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
