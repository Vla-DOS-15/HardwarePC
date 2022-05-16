using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwarePC.Models;
using System.Windows;

namespace HardwarePC
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PcTb> Pc { get; set; }
        public DbSet<ProcessorTb> Processors { get; set; }
        public DbSet<MotherboardTb> Motherboards { get; set; }
        public DbSet<RAMTb> RAMS { get; set; }
        public DbSet<VideoCardTb> VideoCards { get; set; }
        public DbSet<HardDriveTb> HardDrives { get; set; }
        public DbSet<PowerSupplyTb> PowerSupplys { get; set; }

        public ApplicationContext()
        {
            try
            {
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=HardwarePCDB;Trusted_Connection=True;");
        }
    }
}
