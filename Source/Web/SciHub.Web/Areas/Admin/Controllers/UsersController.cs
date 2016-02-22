using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SciHub.Services.Data.Contracts;
using SciHub.Services.Data.Contracts.Movies;
using SciHub.Web.Areas.Admin.ViewModels;
using SciHub.Web.Infrastructure.Mapping;

namespace SciHub.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Data.Models;

    public class UsersController : BaseAdminController
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {

            var result = this.users.GetAll().To<UserAdminViewModel>().ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, UserAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                //var movie = Mapper.Map<Movie>(model);

                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Avatar = model.Avatar,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender,
                    About = model.About,
                    CreatedOn = model.CreatedOn,
                    PreserveCreatedOn = model.PreserveCreatedOn,
                    IsHidden = model.IsHidden,
                    ModifiedOn = model.ModifiedOn,
                    IsDeleted = model.IsDeleted,
                    DeletedOn = model.DeletedOn

                };

                var result = this.users.Add(user);
                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var user = new User()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Avatar = model.Avatar,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender,
                    About = model.About,
                    CreatedOn = model.CreatedOn,
                    PreserveCreatedOn = model.PreserveCreatedOn,
                    IsHidden = model.IsHidden,
                    ModifiedOn = model.ModifiedOn,
                    IsDeleted = model.IsDeleted,
                    DeletedOn = model.DeletedOn

                };

                var result = this.users.Update(user).To<UserAdminViewModel>().FirstOrDefault();
                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserAdminViewModel model)
        {
            var user = this.users.GetById(model.Id);
            this.users.Delete(user);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    }
}
