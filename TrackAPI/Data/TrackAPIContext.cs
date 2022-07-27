using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackAPI.Models;

namespace TrackAPI.Data
{
    public class TrackAPIContext : DbContext
    {
        public TrackAPIContext (DbContextOptions<TrackAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TrackAPI.Models.Item> Item { get; set; }

        public DbSet<TrackAPI.Models.Status> Status { get; set; }
    }
}
