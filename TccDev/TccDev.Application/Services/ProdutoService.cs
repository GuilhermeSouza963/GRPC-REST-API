using System;
using System.Collections.Generic;
using TccDev.Domain.Entities;
using TccDev.Domain.Interfaces.Repositories;
using TccDev.Domain.Interfaces.Services;

namespace TccDev.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }
    }
}
