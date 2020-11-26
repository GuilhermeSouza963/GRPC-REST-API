using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TccDev.Domain.Interfaces.Services;
using TccDev.gRPC.Protos;

namespace TccDev.gRPC.Services
{
    public class ProdutogRPCService : ProdutogRPC.ProdutogRPCBase
    {
        private readonly ILogger<ProdutogRPCService> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutogRPCService(
            ILogger<ProdutogRPCService> logger,
            IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        public override async Task Listar(
            ListarProdutosRequest request, 
            IServerStreamWriter<ListarProdutosResponse> responseStream, 
            ServerCallContext context)
        {
            _logger.LogInformation("Listando Produtos...");
            var produtos = _produtoService.GetAll();

            foreach (var produto in produtos)
            {
                await responseStream.WriteAsync(new ListarProdutosResponse { Produto = new DadosProduto { ProdutoId = produto.ProdutoId, Descricao = produto.Descricao } });
            }
        }
    }
}
