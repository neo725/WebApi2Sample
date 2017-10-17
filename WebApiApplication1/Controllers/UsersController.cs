using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Newtonsoft.Json;
using WebApiApplication1.DbContext;
using WebApiApplication1.Models;
using WebApiApplication1.ViewModels;

namespace WebApiApplication1.Controllers
{
    [EnableCors("*", "*", "GET, POST, PUT, DELETE, OPTIONS")]
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        FakeUserContext userContext = new FakeUserContext();

        [HttpGet]
        [Route("")]
        public IQueryable<UserModel> GetUsers()
        {
            return userContext.GetUsers().AsQueryable();
        }

        [HttpGet]
        [Route("{no:int}")]
        public IHttpActionResult GetUser(int no)
        {
            var user = userContext.GetUserByNo(no);

            if (user == null)
            {
                return Content(HttpStatusCode.NotFound, new ErrorData (1001, "錯誤的使用者代碼"));
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(UserModel user)
        {
            // 新增資料
            var newUser = userContext.CreateUser(user);

            return Content(HttpStatusCode.Created, newUser);
        }

        [HttpPut]
        [Route("{no:int}")]
        public IHttpActionResult Update(int no, UserModel user)
        {
            // 確認使用者資料是否存在
            var result = GetUser(no);

            if (result is NegotiatedContentResult<ErrorData>)
            {
                return result;
            }

            // 更新資料
            var resultWithData = result as OkNegotiatedContentResult<UserModel>;

            var oldUser = resultWithData.Content;

            var updatedUser = userContext.UpdateUser(oldUser.No, user);

            return Content(HttpStatusCode.Created, updatedUser);
        }

        [HttpDelete]
        [Route("{no:int}")]
        public IHttpActionResult Delete(int no)
        {
            var result = GetUser(no);

            if (result is NegotiatedContentResult<ErrorData>)
            {
                return result;
            }

            var errorData = userContext.DeleteUser(no);

            if (errorData != null)
            {
                return Content(HttpStatusCode.NotFound, result);
            }

            return Content<UserModel>(HttpStatusCode.NoContent, null);
        }
    }
    
}
