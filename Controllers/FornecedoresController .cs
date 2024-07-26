using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FornecedoresAPI.Models;
using FornecedoresAPI.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FornecedoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _repository;

        public FornecedoresController(IFornecedorRepository repository)
        {
            _repository = repository;
        }
        
    
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Obtém uma lista de todos os fornecedores", Description = "Obtém uma lista de todos os fornecedores registrados no sistema.")]
        [SwaggerResponse(200, "Retorna a lista de fornecedores.", typeof(IEnumerable<Fornecedor>))]
        [SwaggerResponse(404, "Nenhum fornecedor encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            try
            {
                var fornecedores = await _repository.GetFornecedoresAsync();
    
                if (fornecedores == null || !fornecedores.Any())
                {
                    return NotFound(new ApiErrorResponse("Nenhum fornecedor encontrado", "Certifique-se de que os fornecedores foram adicionados ao sistema."));
                }

                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiErrorResponse("Erro interno do servidor", $"Ocorreu um erro: {ex.Message}"));
            }
        }

        
        [HttpGet("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Obtém um fornecedor específico pelo ID", Description = "Obtém os detalhes do fornecedor com o ID especificado.")]
        [SwaggerResponse(200, "Retorna o fornecedor com o ID especificado.", typeof(Fornecedor))]
        [SwaggerResponse(404, "Fornecedor não encontrado com o ID especificado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            try
            {
                var fornecedor = await _repository.GetFornecedorAsync(id);
                if (fornecedor == null)
                {
                    return NotFound(new ApiErrorResponse("Fornecedor não encontrado", $"Não há fornecedor com o ID {id}."));
                }
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiErrorResponse("Erro interno do servidor", $"Ocorreu um erro: {ex.Message}"));
            }
        }

     
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Adiciona um novo fornecedor", Description = "Adiciona um novo fornecedor ao sistema.")]
        [SwaggerResponse(201, "Fornecedor criado com sucesso.", typeof(Fornecedor))]
        [SwaggerResponse(400, "Dados do fornecedor inválidos.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            try
            {
                if (fornecedor == null)
                {
                    return BadRequest(new ApiErrorResponse("Dados do fornecedor inválidos", "Os dados do fornecedor fornecidos não são válidos."));
                }

                var novoFornecedor = await _repository.AddFornecedorAsync(fornecedor);
                return CreatedAtAction(nameof(GetFornecedor), new { id = novoFornecedor.Id }, novoFornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiErrorResponse("Erro interno do servidor", $"Ocorreu um erro: {ex.Message}"));
            }
        }

        
        [HttpPut("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Atualiza um fornecedor existente", Description = "Atualiza os dados de um fornecedor existente no sistema.")]
        [SwaggerResponse(204, "Fornecedor atualizado com sucesso.")]
        [SwaggerResponse(400, "Incompatibilidade entre ID na URL e no corpo.")]
        [SwaggerResponse(404, "Fornecedor não encontrado com o ID especificado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            try
            {
                if (id != fornecedor.Id)
                {
                    return BadRequest(new ApiErrorResponse("Incompatibilidade entre ID na URL e no corpo", $"ID esperado: {id}, mas recebido: {fornecedor.Id}."));
                }

                var fornecedorAtualizado = await _repository.UpdateFornecedorAsync(fornecedor);
                if (fornecedorAtualizado == null)
                {
                    return NotFound(new ApiErrorResponse("Fornecedor não encontrado", $"Não há fornecedor com o ID {id}."));
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiErrorResponse("Erro interno do servidor", $"Ocorreu um erro: {ex.Message}"));
            }
        }

    

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Remove um fornecedor existente", Description = "Remove um fornecedor do sistema com base no ID especificado.")]
        [SwaggerResponse(204, "Fornecedor removido com sucesso.")]
        [SwaggerResponse(404, "Fornecedor não encontrado com o ID especificado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            try
            {
                var sucesso = await _repository.DeleteFornecedorAsync(id);
                if (!sucesso)
                {
                    return NotFound(new ApiErrorResponse("Fornecedor não encontrado", $"Não há fornecedor com o ID {id}."));
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiErrorResponse("Erro interno do servidor", $"Ocorreu um erro: {ex.Message}"));
            }
        }
    }
}
