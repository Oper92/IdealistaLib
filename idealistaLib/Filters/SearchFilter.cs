using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IdealistaLib.Filters
{
    public enum operation
    {
        sale,
        rent
    }
  
    public enum propertyType
    {
        homes,
        offices,
        premises,
        garages,
        bedrooms
    }

    public enum locale
    {
        es,
        it,
        pt,
        en,
        ca
    }
    public class SearchFilter
    { 
        public string operation { get; set; }
        public string propertyType { get; set; }
        public string locale { get; set;}

        public string center { get; set; }

        public double distance { get; set; }
        public string locationid { get; set; }

        public int maxitems { get; set; }
        public int numpage { get; set; }
        public string maxPrice { get; set; }

        public string minPrice { get; set; }


        public string sinceDate { get; set; }
        public string order { get; set; }

        public int[] adIds { get; set; }
        public bool hasMultimedia { get; set; }

        public IdealistaFilter SpecificFilter { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int added = 0;
            foreach (var property in this.GetType().GetProperties())
            {
                var thekey = property.Name;
                var thevalue = property.GetValue(this, null);
                if (thevalue != null)
                {
                    if (property.PropertyType == typeof(bool)) { 
                        if((bool)thevalue == false)
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
                    
                    if (added == 0)
                    {
                        sb.Append(thekey + "=" + thevalue);
                    }
                    else
                    {
                        if (thekey == "SpecificFilter")
                        {
                            sb.Append(thevalue);
                        }else  sb.Append("&" + thekey + "=" + thevalue);
                    }
                    added = added + 1;
                }
            }
            return sb.ToString();
        }

    }
}
