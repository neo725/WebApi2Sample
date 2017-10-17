using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiApplication1.Controllers;

namespace WebApiApplication1.Models
{
    public class UsersModel : IList<UserModel>
    {
        public UsersModel()
        {
            this.Users = new List<UserModel>();
        }

        public List<UserModel> Users { get; set; }

        public void Add(UserModel item)
        {
            if (item.No == 0)
            {
                var maxNo = this.Users.Max(user => user.No);
                item.No = maxNo + 1;
            }

            this.Users.Add(item);
        }

        public void Clear()
        {
            this.Users.Clear();
        }

        public bool Contains(UserModel item)
        {
            return this.Users.Count(user => user.No == item.No) > 0;
        }

        public void CopyTo(UserModel[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(UserModel item)
        {
            return this.Users.Remove(item);
        }

        public int Count => this.Users.Count;

        public bool IsReadOnly => false;

        public int IndexOf(UserModel item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, UserModel item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public UserModel this[int index]
        {
            get { return this.Users[index]; }
            set { this.Users[index] = value; }
        }

        public IEnumerator<UserModel> GetEnumerator()
        {
            return this.Users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}