using FornecedoresAPI.Data;
using FornecedoresAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly FornecedorContext _context;

        public FornecedorRepository(FornecedorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedoresAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor> GetFornecedorAsync(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<Fornecedor> AddFornecedorAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> DeleteFornecedorAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return false;
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
