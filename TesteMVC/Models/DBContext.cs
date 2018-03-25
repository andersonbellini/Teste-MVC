using TesteMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TesteMVC.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}