using FornecedoresAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Repositories
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> GetFornecedoresAsync();
        Task<Fornecedor> GetFornecedorAsync(int id);
        Task<Fornecedor> AddFornecedorAsync(Fornecedor fornecedor);
        Task<Fornecedor> UpdateFornecedorAsync(Fornecedor fornecedor);
        Task<bool> DeleteFornecedorAsync(int id);
    }
}
