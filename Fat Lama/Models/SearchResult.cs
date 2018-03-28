using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fat_Lama.Models
{
    //Structure of the data to be returned
    public class SearchResult
    {
        //name of the item
        public string ItemName { get; set; }

        // Url of the item
        public string ItemUrl { get; set; }

        //Url of the image of the item
        public string ImageUrl { get; set; }

        //Latitudinal Location of the item
        public double Lat { get; set; }

        //Longitudinal Location of the item
        public double Lng { get; set; }

    }
}