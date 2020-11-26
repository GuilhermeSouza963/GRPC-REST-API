using System.Collections.Generic;
using TccDev.Domain.Entities;

namespace TccDev.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
    }
}
