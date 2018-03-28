# Fat-Lama
I used .Net Framework to build the web application because it provides the means of separating the content and the programming logic and postman to test the web service created.
The framework allowed me to split the service into 3 separate parts (modular):
CONTROLLER: takes values from the URL
MANAGER: responsible for calling the database
MODEL: retains the structure of the data I wish to return

The controller was called SearchController, this is where the GET function is invoked. It gets the searchTerm, latitude and Long from the url. Checks the url for illegal characters (url encoding) to prevent sql injection. 
It calls the database layer SearchManager to perform the seacrh.
SearchManager functions as the database layer which queries the database. This is where the search wildcard and sqlite query are constructed. The serchTerm is converted to a wildcard by concatenating it "%" as a prefix and suffix and replacing any space (' ') within the phrase with "%"
SearchResult is the name of the model, a structural representation of the data to be returned.

The search web service only produces results based on the searchTerm. I was unable to get Spatialite to function, as such I was unable to order my result by geolocation.
