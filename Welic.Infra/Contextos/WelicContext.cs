using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Welic.Api.Contexts
{
    public class WelicContext : DbContext
    {
        public WelicContext()
            :base("WelicConectionString")
        {

        }       
        //public DbSet<Autor> Autores { get; set; }      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new AutorMap());
            

        }
    }
}