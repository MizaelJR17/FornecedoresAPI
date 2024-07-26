using Microsoft.EntityFrameworkCore;
using FornecedoresAPI.Models;

namespace FornecedoresAPI.Data
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> options)
            : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
