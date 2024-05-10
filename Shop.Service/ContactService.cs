using Shop.Data.Infastructure;
using Shop.Data.Repository;
using Shop.Models.Models;
using System;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IContactService
    {
        Contact Add(Contact contact);

        void Update(Contact contact);

        Contact Delete(int id);

        IEnumerable<Contact> GetAll();

        IEnumerable<Contact> GetAll(string keyWord);
        IEnumerable<Contact> GetContactTrue();
        IEnumerable<Contact> GetContactFalse();

        IEnumerable<Contact> GetAllByParentId(int parentId);

        Contact GetById(int id);

        void Save();
    }

    public class ContactService : IContactService
    {
        private IContactRepository _contacRepository;
        private IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            this._contacRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public Contact Add(Contact contact)
        {
            return _contacRepository.Add(contact);
        }

        public Contact Delete(int id)
        {
            return _contacRepository.Delete(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacRepository.GetAll();
        }

        public IEnumerable<Contact> GetAll(string keyWord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            return _contacRepository.GetSingleById(id);
        }

        public IEnumerable<Contact> GetContactFalse()
        {
            return _contacRepository.GetMulti(x => x.Status == false);
        }

        public IEnumerable<Contact> GetContactTrue()
        {
            return _contacRepository.GetMulti(x => x.Status == true);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Contact contact)
        {
            _contacRepository.Update(contact);
        }
    }
}