using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_diemB_QLCanBo
{
    internal class User
    {
        private string userName;
        private string passWord;
        public string Username { get => userName; set => userName = value; }
        public string Password { get => passWord; set => passWord = value; }
        public User(string userName, string passWord)
        {
            this.Username = userName;
            this.Password = passWord;

        }
    }
    

}
