using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAPI.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string TrackID { get; set; }

        public string Stats { get; set; }
        public DateTime Progressdate { get; set; }



    }
} 
