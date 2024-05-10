using Shop.Data.Repository;
using Shop.Models.Models;
using System;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IOrderDetailsService
    {
        OrderDetails Add(OrderDetails OrderDetails);

        void Update(OrderDetails OrderDetails);

        OrderDetails Delete(int id);

        IEnumerable<OrderDetails> GetAll();

        IEnumerable<OrderDetails> GetAll(string keyWord);

        IEnumerable<OrderDetails> GetAllByParentId(int parentId);

        OrderDetails GetById(int id);

        IEnumerable<OrderDetails> GetDetailByID(int id);
        void Save();
    }

    public class OrderDetailsService : IOrderDetailsService
    {
        private IOrderDetalRepository _orderDetalRepository;

        public OrderDetailsService(IOrderDetalRepository orderDetalRepository)
        {
            this._orderDetalRepository = orderDetalRepository;
        }

        public OrderDetails Add(OrderDetails OrderDetails)
        {
            return _orderDetalRepository.Add(OrderDetails);
        }

        public OrderDetails Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAll(string keyWord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetDetailByID(int id)
        {
            return _orderDetalRepository.GetMulti(x => x.OrderID == id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetails OrderDetails)
        {
            throw new NotImplementedException();
        }
    }
}