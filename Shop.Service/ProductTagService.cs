using Shop.Data.Repository;
using Shop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IProductTagService
    {
        ProductTag Add(ProductTag ProductTag);

        void Update(ProductTag ProductTag);

        ProductTag Delete(int id);

        IEnumerable<ProductTag> GetAll();

        IEnumerable<ProductTag> GetAll(string keyWord);

        IEnumerable<ProductTag> GetListProductTagByCategoryIdPage(int categryID, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<ProductTag> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListProductTagByName(string name);

        IEnumerable<ProductTag> GetReatedProductTag(int id, int top);

        IEnumerable<ProductTag> GetLastest(int top);

        IEnumerable<ProductTag> GetHotProductTag(int top);

        ProductTag GetById(int id);

        void Save();

        Tag getTag(string tagID);

        // lấy ra tag
        IEnumerable<Tag> GetListTagProductTagID(int id);

        // phân trang
        IEnumerable<ProductTag> GetListProductTagByTag(string tagID, int page, int pageSize, out int totalRow);

        IEnumerable<ProductTag> GetHotProductTag();
        IEnumerable<ProductTag> GetSameInforProductTag(int id);
        IEnumerable<ProductTag> GetProductTagByParentId(int id, int page, int pageSize, out int totalRow);

        IEnumerable<ProductTag> GetTagByID(int id);
    }
    public class ProductTagService : IProductTagService
    {
        private IProductTagRepository _productTagRepository;

        public ProductTagService(IProductTagRepository productTagRepository)
        {
            this._productTagRepository = productTagRepository;
        }
        public ProductTag Add(ProductTag ProductTag)
        {
            throw new NotImplementedException();
        }

        public ProductTag Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetAll()
        {
            return _productTagRepository.GetAll();
        }

        public IEnumerable<ProductTag> GetAll(string keyWord)
        {
            throw new NotImplementedException();
        }

        public ProductTag GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetHotProductTag(int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetHotProductTag()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetLastest(int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetListProductTagByCategoryIdPage(int categryID, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetListProductTagByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetListProductTagByTag(string tagID, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetListTagProductTagID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetProductTagByParentId(int id, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetReatedProductTag(int id, int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetSameInforProductTag(int id)
        {
            throw new NotImplementedException();
        }

        public Tag getTag(string tagID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> GetTagByID(int id)
        {
            return _productTagRepository.GetMulti(x => x.ProductID == id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTag> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductTag ProductTag)
        {
            throw new NotImplementedException();
        }
    }
}
