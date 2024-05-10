using AutoMapper;
using Shop.Data.Infastructure;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Infrastructure.Extensions;
using ShopEcommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private IContactService _contactService;
        private IUnitOfWork _unitOfWork;

        public ContactController(IContactService contactService, IUnitOfWork unitOfWork)
        {
            this._contactService = contactService;
            this._unitOfWork = unitOfWork;
        }

        [Route("getTrue")]
        [HttpGet]
        public HttpResponseMessage GetTrue(HttpRequestMessage reques)
        {
            var model = _contactService.GetContactTrue();
            var listContactViewModel = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listContactViewModel);
            return respose;
        }

        [Route("getFalse")]
        [HttpGet]
        public HttpResponseMessage GetFalse(HttpRequestMessage reques)
        {
            var model = _contactService.GetContactFalse();
            var listContactViewModel = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listContactViewModel);
            return respose;
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage reques, ContactViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                var contactDB = _contactService.GetById(model.ID);
                contactDB.UpdateContact(model);
                contactDB.Status = true;
                contactDB.ConfirmDate = DateTime.Now;
                _contactService.Update(contactDB);
                _contactService.Save();
                return reques.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("detail")]
        [HttpGet]
        public HttpResponseMessage Detail(HttpRequestMessage reques, int id)
        {
            try
            {
                var model = _contactService.GetById(id);
                var contactViewModel = Mapper.Map<Contact, ContactViewModel>(model);
                return reques.CreateResponse(HttpStatusCode.OK, contactViewModel);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage reques, int id)
        {
            try
            {
                var oldContact = _contactService.Delete(id);
                _unitOfWork.Commit();
                var contactViewModel = Mapper.Map<Contact, ContactViewModel>(oldContact);
                return reques.CreateResponse(HttpStatusCode.OK, contactViewModel);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}