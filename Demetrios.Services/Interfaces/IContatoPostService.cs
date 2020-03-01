using System.Linq;
using System.Threading.Tasks;
using Demetrios.Models;

namespace Demetrios.Services.Interfaces
{
    public interface IContatoPostService
    {
        Task<ContatoPost> Create(ContatoPost contatoPost);
   
        Task<ContatoPost> Update(ContatoPost contatoPost);

        ContatoPost Get(string contatoPostId);

        IOrderedQueryable<ContatoPost> GetAll(int? pageNumber, int? pageSize);

        IOrderedQueryable<ContatoPost> GetAllByUserAccountId(string userAccountId);

        Task<bool> Delete(string contatoPostId);
    }
}
