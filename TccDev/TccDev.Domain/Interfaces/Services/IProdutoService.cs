using System.Collections.Generic;
using TccDev.Domain.Entities;

namespace TccDev.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetAll();
    }
}
