using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{

    public class LoginRepository : ILoginRepository
    {
        private readonly Inventory_Management_systeamEntities _context;
        public LoginRepository()
        {
            _context = new Inventory_Management_systeamEntities();
        }
        public LoginRepository(Inventory_Management_systeamEntities context)
        {
            _context = context;
        }
        public IEnumerable<tbUser> GetAll()
        {
            return _context.tbUsers.ToList();
        }
        public tbUser GetById(int tbUserID)
        {
            return _context.tbUsers.Find(tbUserID);
        }
        public void Insert(tbUser tbUser)
        {
            _context.tbUsers.Add(tbUser);
        }
        public void Update(tbUser tbUser)
        {
            _context.Entry(tbUser).State = EntityState.Modified;
        }
        public void Delete(int tbUserID)
        {
            tbUser tbUser = _context.tbUsers.Find(tbUserID);
            _context.tbUsers.Remove(tbUser);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsUserExist(tbUser user)
        {
            return _context.tbUsers.Any(m => m.Email == user.Email && m.Password == user.Password);
        }
        public tbUser LoginUser(LogIn objUser)
        {

            var obj = _context.tbUsers.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
            return obj;

        }
    }

}
