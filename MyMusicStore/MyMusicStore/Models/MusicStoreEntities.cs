using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMusicStore.Models
{
    public class MusicStoreEntities : DbContext
    {
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<ActionLog> ActionLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Album>().ToTable("Albums");
            modelBuilder.Entity<Artist>().ToTable("Artists");

            base.OnModelCreating(modelBuilder);
        }
    }
}