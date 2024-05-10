using Shop.Data.Infastructure;
using Shop.Data.Repository;
using Shop.Models.Models;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IApplicationUserService
    {
        ApplicationUser Add(ApplicationUser user);

        void Update(ApplicationUser user);

        ApplicationUser Delete(int id);

        IEnumerable<ApplicationUser> GetAll();

        IEnumerable<ApplicationUser> GetAll(string keyWord);

        IEnumerable<ApplicationUser> GetContactTrue();

        IEnumerable<ApplicationUser> GetContactFalse();

        IEnumerable<ApplicationUser> GetAllByUserID(int Id);

        ApplicationUser GetById(int id);

        void Save();
    }

    internal class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            this._applicationUserRepository = applicationUserRepository;
        }

        public ApplicationUser Add(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public ApplicationUser Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _applicationUserRepository.GetAll();
        }

        public IEnumerable<ApplicationUser> GetAll(string keyWord)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllByUserID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetContactFalse()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetContactTrue()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}