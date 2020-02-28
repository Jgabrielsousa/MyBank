using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IRepository;
using MyBank.Shared.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public User Add(User entidade)
        {
            return _repo.Add(entidade);
        }



        public User Find(long id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll();
        }

        public void Remove(User entidade)
        {
            _repo.Remove(entidade);
        }

        public void Update(User entidade)
        {
            _repo.Update(entidade);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
