using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        ILoginRepository loginRepository = new LoginRepository();
        public IEnumerable<tbUser> GetAll()
        {
            return loginRepository.GetAll();
        }

        public tbUser GetById(int userId)
        {
            return loginRepository.GetById(userId);
        }
        public bool IsUserExist(tbUser user)
        {
            return loginRepository.IsUserExist(user);
        }
        public tbUser LoginUser(LogIn objUser)
        {
            return loginRepository.LoginUser(objUser);
        }
        

    }
}
