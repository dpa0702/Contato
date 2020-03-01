using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Demetrios.Context;
using Demetrios.Models;
using Demetrios.Repositories.Interfaces;

namespace Demetrios.Repositories
{
    public class ContatoPostRepository : IContatoPostRepository
    {
        private readonly IServiceScope _scope;
        private readonly ContatoPostDatabaseContext _databaseContext;

        public ContatoPostRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _databaseContext = _scope.ServiceProvider.GetRequiredService<ContatoPostDatabaseContext>();
        }

        public async Task<bool> Create(ContatoPost contatoPost)
        {
            var success = false;

            _databaseContext.ContatoPosts.Add(contatoPost);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Update(ContatoPost contatoPost)
        {
            var success = false;

            var existingcontatoPost = Get(contatoPost.Id);

            if (existingcontatoPost != null)
            {
                existingcontatoPost.Nome = contatoPost.Nome;
                existingcontatoPost.Canal = contatoPost.Canal;
                existingcontatoPost.Valor = contatoPost.Valor;
                existingcontatoPost.Obs = contatoPost.Obs;
                existingcontatoPost.DataAlteracao = contatoPost.DataAlteracao;

                _databaseContext.ContatoPosts.Attach(existingcontatoPost);

                var numberOfItemsUpdated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public ContatoPost Get(string contatoPostId)
        {
            var result = _databaseContext.ContatoPosts
                                .Where(x => x.Id == contatoPostId)
                                .FirstOrDefault();

            return result;
        }

        public IOrderedQueryable<ContatoPost> GetAll(int? pageNumber, int? pageSize)
        {
            var result = _databaseContext.ContatoPosts
                                .Skip(pageNumber ?? 0)
                                .Take(pageSize ?? 10)
                                .OrderByDescending(x => x.DataAlteracao);

            return result;
        }

        public IOrderedQueryable<ContatoPost> GetAllByUserAccountId(string userAccountId)
        {
            var result = _databaseContext.ContatoPosts
                                .Where(x => x.Id == userAccountId)
                                .OrderByDescending(x => x.DataAlteracao);

            return result;
        }

        public async Task<bool> Delete(string contatoPostId)
        {
            var success = false;

            var existingcontatoPost = Get(contatoPostId);

            if (existingcontatoPost != null)
            {
                _databaseContext.ContatoPosts.Remove(existingcontatoPost);

                var numberOfItemsDeleted = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
