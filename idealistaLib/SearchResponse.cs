using System;
using System.Collections.Generic;
using System.Text;

namespace IdealistaLib
{
    public class SearchResponse
    {
        public int actualPage { get; set; }
        public int itemsPerPage { get; set; }
        public int lowerRangePosition { get; set; }
        public bool paginable { get; set; }
        public string[] summary { get; set; }
        public int total { get; set; }
        public int totalPages { get; set; }
        public int upperRangePosition { get; set; }
        public List<elementList> elementList { get; set; }
    }


    public class elementList
    {
        public string address { get; set; }
        public int bathrooms { get; set; }
        public string country { get; set; }
        public string distance { get; set; }
        public string district { get; set; }
        public bool exterior { get; set; }
        public string floor { get; set; }
        public bool hasVideo { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string municipality { get; set; }
        public string neighborhood { get; set; }
        public int numPhotos { get; set; }
        public string operation { get; set; }
        public double price { get; set; }
        public string propertyCode { get; set; }
        public string province { get; set; }
        public string region { get; set; }
        public int rooms { get; set; }
        public bool showAddress { get; set; }
        public double size { get; set; }
        public string subregion { get; set; }
        public string thumbnail { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public bool newDevelopment { get; set; }
        public string tenantGender { get; set; }
        public string garageType { get; set; }
        public ParkingSpace parkingSpace { get; set; }
        public bool hasLift { get; set; }
        public bool newDevelopmentFinished { get; set; }
        public bool isSmokingAllowed { get; set; }
        public double priceByArea { get; set; }
        public DetailedType detailedType { get; set; }
        public string externalReference { get; set; }

    }

    public class ParkingSpace { 
        public bool hasParkingSpace { get; set; }
        public bool isParkingSpaceIncludedInPrice { get; set; }
        public double parkingSpacePrice { get; set; }


    }
    public class DetailedType
    {
        public string typology { get; set; }
        public string subtypology { get; set; }
    }

}
