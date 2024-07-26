using FornecedoresAPI.Models;
using FornecedoresAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FornecedoresAPI.Data;

namespace FornecedoresAPI.Tests
{
    public class FornecedorRepositoryTests
    {
        private readonly FornecedorContext _context;
        private readonly FornecedorRepository _repository;

        public FornecedorRepositoryTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<FornecedorContext>()
                .UseNpgsql(connectionString)
                .Options;

            _context = new FornecedorContext(options);
            _repository = new FornecedorRepository(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _context.Fornecedores.Add(new Fornecedor { Nome = "Fornecedor1", Email = "fornecedor1@example.com" });
            _context.Fornecedores.Add(new Fornecedor { Nome = "Fornecedor2", Email = "fornecedor2@example.com" });
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetFornecedoresAsync_ReturnsAllFornecedores()
        {
            var fornecedores = await _repository.GetFornecedoresAsync();
            Assert.Equal(2, fornecedores.Count());
        }

        [Fact]
        public async Task GetFornecedorAsync_ReturnsFornecedorById()
        {
            var fornecedor = await _repository.GetFornecedorAsync(1);
            Assert.NotNull(fornecedor);
            Assert.Equal("Fornecedor1", fornecedor.Nome);
        }
    }
}
