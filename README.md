# IdealistaLib
This is a  .NET Core 3.0 library written in C# that can be used in order to query Idealista APIs (Please check the other branch for the .Net Core 2.0 version).

Please remember that according to Idealista current Policy (27/09/2020) access to their APIs has the following constraints:

>  Access is free to a maximum of 100 req/month and it's limited by 1 req/sec. 

If you don't already have APIKey and APISecret you can request them using their website.

Thank you Idealista team!
Marco Della Valle - marco.della.valle@hotmail.it 

# How can I use it?
1. Add the dll to your project 
1. Autenticate 
```csharp
IdealistaAPI API = new IdealistaAPI("APIKEY", "APISECRET");
var autentication = await API.Authenticate();
```
1. Build your request
```csharp
  SearchFilter request = new SearchFilter();
            request.operation = operation.sale.ToString();
            request.propertyType = propertyType.homes.ToString();
            request.locale = locale.it.ToString();
            request.center = "45.53,9.307"; //WGS84 use google or
            request.distance = 8000; 
            request.maxPrice = "200000";
            request.maxitems = 50;
            request.sinceDate = "M";
            HomeFilters homefilter = new HomeFilters();
            homefilter.minSize = 100;
            homefilter.maxSize = 300;
            homefilter.bathrooms = "2";
            homefilter.bedrooms = "3";
            request.SpecificFilter = homefilter;
```
1. Send it!  
```csharp
var response = await API.SearchRequest(request, "it");
```
## Complete example:
```csharp
  //Autenticate with the server usign APIKey and APISecret.
            IdealistaAPI API = new IdealistaAPI("APIKEY", "APISECRET");
            var autentication = await API.Authenticate();
            if (autentication == null) {
                return; //In case we are not autenticated we exit.
            } 
            
            // Here we build our request
            SearchFilter request = new SearchFilter();
            request.operation = operation.sale.ToString();
            request.propertyType = propertyType.homes.ToString();
            request.locale = locale.it.ToString();
            request.center = "45.53,9.307"; //WGS84 
            request.distance = 8000; 
            request.maxPrice = "200000";
            request.maxitems = 50;
            request.sinceDate = "M";
            HomeFilters homefilter = new HomeFilters();
            homefilter.minSize = 100;
            homefilter.maxSize = 300;
            homefilter.bathrooms = "2";
            homefilter.bedrooms = "3";
            request.SpecificFilter = homefilter;
            var response = await API.SearchRequest(request, "it");
            foreach(var house in response.elementList)
            {
                //Do stuff here.
                Console.Out.WriteLine(house.address + " " + house.price + " " + house.url);
            }
            //
```
