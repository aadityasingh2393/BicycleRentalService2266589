using Microsoft.EntityFrameworkCore;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;
using System.Collections.Generic;
using System.Reflection.Emit;



namespace MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data
{
    public class UserData : DbContext
    {
        public DbSet<AuthUser> Users { get; set; }



        public UserData(DbContextOptions<UserData> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            base.OnModelCreating(modelBuilder);
        }
    }



}