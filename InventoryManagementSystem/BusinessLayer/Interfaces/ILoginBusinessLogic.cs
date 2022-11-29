using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ILoginBusinessLogic
    {
        IEnumerable<tbUser> GetAll();
        tbUser GetById(int UserID);
        bool IsUserExist(tbUser user);
        tbUser LoginUser(LogIn objUser);
    }

}
