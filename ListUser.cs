using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_diemB_QLCanBo
{
    internal class ListUser
    {
        private static ListUser instance; 
        private List<User> listAccountUser;
        private List<User> ListAccountUser { get => ListAccountUser; set => ListAccountUser = value; }
        public static ListUser Instance 
        {
            get 
            { 
                if (instance == null)
                    instance = new ListUser();
                return instance; 
            } 
            set => instance = value; 
        }
        private ListUser()
        {
            listAccountUser = new List<User>();
            listAccountUser.Add(new User("admin01", "12345678"));
            listAccountUser.Add(new User("NV01", "12345"));

        }
    }
    
}
