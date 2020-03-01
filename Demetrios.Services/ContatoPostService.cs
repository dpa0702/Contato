using System;
using System.Linq;
using System.Threading.Tasks;
using Demetrios.Models;
using Demetrios.Repositories.Interfaces;
using Demetrios.Services.Interfaces;

namespace Demetrios.Services
{
    public class ContatoPostService : IContatoPostService
    {
        private readonly IContatoPostRepository _repository;

        public ContatoPostService(IContatoPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContatoPost> Create(ContatoPost contatoPost)
        {
            contatoPost.DataAlteracao = DateTime.UtcNow;

            var success = await _repository.Create(contatoPost);

            if (success)
                return contatoPost;
            else
                return null;
        }

        public async Task<ContatoPost> Update(ContatoPost contatoPost)
        {
            contatoPost.DataAlteracao = DateTime.UtcNow;

            var success = await _repository.Update(contatoPost);

            if (success)
                return contatoPost;
            else
                return null;
        }

        public ContatoPost Get(string contatoPostId)
        {
            var result = _repository.Get(contatoPostId);

            return result;
        }

        public IOrderedQueryable<ContatoPost> GetAll(int? pageNumber, int? pageSize)
        {
            var result = _repository.GetAll(pageNumber, pageSize);

            return result;
        }

        public IOrderedQueryable<ContatoPost> GetAllByUserAccountId(string userAccountId)
        {
            var result = _repository.GetAllByUserAccountId(userAccountId);

            return result;
        }

        public async Task<bool> Delete(string contatoPostId)
        {
            var success = await _repository.Delete(contatoPostId);

            return success;
        }
    }
}
