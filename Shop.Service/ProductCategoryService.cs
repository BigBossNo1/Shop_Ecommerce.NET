using Shop.Data.Infastructure;
using Shop.Data.Repository;
using Shop.Models.Models;
using System;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IProductCategoryService
    {
        ProductCategorye Add(ProductCategorye ProductCategory);

        void Update(ProductCategorye ProductCategory);

        ProductCategorye Delete(int id);

        IEnumerable<ProductCategorye> GetAll();

        IEnumerable<ProductCategorye> GetAll(string keyWord);

        IEnumerable<ProductCategorye> GetAllByParentId(int parentId);

        ProductCategorye GetById(int id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategorye Add(ProductCategorye ProductCategory)
        {
            ProductCategory.Createdate = DateTime.Now;
            return _productCategoryRepository.Add(ProductCategory);
        }

        public ProductCategorye Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategorye> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategorye> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            }
            else
            {
                return _productCategoryRepository.GetAll();
            }
        }

        public IEnumerable<ProductCategorye> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public ProductCategorye GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategorye ProductCategory)
        {
            _productCategoryRepository.Update(ProductCategory);
        }
    }
}