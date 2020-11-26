using System;
using Microsoft.AspNetCore.Mvc;
using TccDev.Domain.Interfaces.Services;

namespace TccDev.Api.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("api/Produto/Listar")]
        public IActionResult Listar()        
        {
            try
            {
                var response = _produtoService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
            }
        }
    }
}