using Shop.Data.Infastructure;
using Shop.Data.Repository;
using Shop.Models.Models;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IOrderService
    {
        Order Add(Order Order);

        void Update(Order Order);

        Order Delete(int id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAll(string keyWord);

        IEnumerable<Order> GetAllByStatus(bool status);

        IEnumerable<Order> GetAllByParentId(int parentId);

        Order GetById(int id);

        void Save();
    }

    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IUnitOfWork _unirOFWork;

        public OrderService(IOrderRepository orderRepository , IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._unirOFWork = unitOfWork;
        }

        public Order Add(Order Order)
        {
            return _orderRepository.Add(Order);
        }

        public Order Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _orderRepository.GetAll();
            }
            else
            {
                return _orderRepository.GetMulti(x => x.CustomerName == keyWord);
            }
        }

        public IEnumerable<Order> GetAllByParentId(int parentId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllByStatus(bool status)
        {
            return _orderRepository.GetMulti(x => x.Statuss == status);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order Order)
        {
            _orderRepository.Update(Order);
            _unirOFWork.Commit();
        }
    }
}