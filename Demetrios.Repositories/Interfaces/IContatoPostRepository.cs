using System.Linq;
using System.Threading.Tasks;
using Demetrios.Models;

namespace Demetrios.Repositories.Interfaces
{
    public interface IContatoPostRepository
    {
        Task<bool> Create(ContatoPost contatoPost);

        Task<bool> Update(ContatoPost contatoPost);

        ContatoPost Get(string contatoPostId);

        IOrderedQueryable<ContatoPost> GetAll(int? pageNumber, int? pageSize);

        IOrderedQueryable<ContatoPost> GetAllByUserAccountId(string userAccountId);

        Task<bool> Delete(string contatoPostId);
    }
}
