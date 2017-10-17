using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiApplication1.Models;
using WebApiApplication1.ViewModels;

namespace WebApiApplication1.DbContext
{
    /// <summary>
    /// 假的資料介面
    /// </summary>
    public class FakeUserContext
    {
        private readonly UsersModel _fakeUserModels;
        
        public FakeUserContext()
        {
            this._fakeUserModels = new UsersModel();

            InjectMockUserData();
        }

        /// <summary>
        /// 回傳幾筆假的資料
        /// </summary>
        /// <returns></returns>
        private void InjectMockUserData()
        {
            this._fakeUserModels.Clear();
            this._fakeUserModels.Add(new UserModel { No = 1, Name = "Neo Chang", Age = 37 });
            this._fakeUserModels.Add(new UserModel { No = 2, Name = "Tim Cooker", Age = 57 });
        }

        /// <summary>
        /// 取得所有使用者集合
        /// </summary>
        /// <returns></returns>
        public UsersModel GetUsers()
        {
            return this._fakeUserModels;
        }

        /// <summary>
        /// 依照傳入的 no 來取得指定對象的 UserModel
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public UserModel GetUserByNo(int no)
        {
            return this._fakeUserModels.FirstOrDefault(user => user.No == no);
        }

        public UserModel CreateUser(UserModel inputUserData)
        {
            int newNo = this._fakeUserModels.Max(item => item.No);

            inputUserData.No = newNo + 1;

            this._fakeUserModels.Add(inputUserData);

            return inputUserData;
        }

        public UserModel UpdateUser(int no, UserModel inputUserData)
        {
            var oldUser = this._fakeUserModels.FirstOrDefault(user => user.No == inputUserData.No);

            var newUser = FakeReplace(oldUser, inputUserData);

            return newUser;
        }

        public ErrorData DeleteUser(int no)
        {
            var deleteUser = this._fakeUserModels.FirstOrDefault(user => user.No == no);

            if (deleteUser == null)
            {
                return new ErrorData(1002, "指定的使用者不存在");
            }

            // do some delete operation

            // mock success
            return null;
        }


        private UserModel FakeReplace(UserModel oldUser, UserModel replaceUserModel)
        {
            return replaceUserModel;
        }
    }
}