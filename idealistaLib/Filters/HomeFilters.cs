using System;
using System.Collections.Generic;
using System.Text;

namespace IdealistaLib
{
    public class HomeFilters: IdealistaFilter
    {
        public double minSize { get; set; }
        public double maxSize { get; set; }
        public bool virtualTour { get; set; }
        public bool flat { get; set; }
        public bool penthouse { get; set; }
        public bool duplex { get; set; }
        public bool studio { get; set; }
        public bool chalet { get; set; }
        public bool countryhouse { get; set; }
        public string bedrooms { get; set; }

        public string bathrooms { get; set; }
        public enum preservation { good, renew }
        public bool newdevelopment { get; set; }

        public enum furnished { furnished, furnishedKitchen }
        public bool bankoffer { get; set; }
        public bool garage { get; set; }
        public bool terrace { get; set; }
        public bool exterior { get; set; }
        public bool elevator { get; set; }
        public bool swimmingPool { get; set; }
        public bool airConditioning { get; set; }
        public bool storeRoom { get; set; }
        public bool clotheslineSpace { get; set; }
        public bool builtinWardrobes { get; set; }
        public enum subTypology { independantHouse, semidetachedHouse, terracedHouse }


        public override string ToString() {
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
