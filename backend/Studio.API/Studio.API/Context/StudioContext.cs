using Studio.API.Entities;
using System.Data.Entity;

namespace Studio.API.Context
{
    /// <summary>
    /// Classe PessoaContext
    /// </summary>
    public class StudioContext : DbContext
    {
        /// <summary>
        /// Método Contrutor da Classe StudioContext
        /// </summary>
        public StudioContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;
         Encrypt = False; TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") { }

        /// <summary>
        /// Propriedade Pessoas
        /// </summary>
        public DbSet<Pessoa> Pessoas { get; set; }
        /// <summary>
        /// Propriedade Ferias
        /// </summary>
        public DbSet<Ferias> Ferias { get; set; }
        /// <summary>
        /// Propriedade Aula
        /// </summary>
        public DbSet<Aula> Aula { get; set; }
    }
}