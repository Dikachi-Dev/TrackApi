using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Helper;

namespace TrackAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        //public string  TrackID { get; set; }

        public string TrackID { get; set; }
       
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string DeliveryDate { get; set; }
        public string Status { get; set; }
        public string  Discription { get; set; }
        public string CountryofOrigin { get; set; }
        public string DeliveryLocation { get; set; }
        public int Wieght { get; set; }

    }
}
