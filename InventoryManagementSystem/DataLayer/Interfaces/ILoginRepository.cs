using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ILoginRepository
    {
        IEnumerable<tbUser> GetAll();
        tbUser GetById(int UserID);
        void Insert(tbUser user);
        void Update(tbUser user);
        void Delete(int userID);
        void Save();
        bool IsUserExist(tbUser user);
        tbUser LoginUser(LogIn objUser);


    }
}
