using System;
using System.Linq;
using DataAccess.Model;

namespace BusinessLogic
{
    public class AdminLoginManager
    {
        private QuestionnaireContext dbContext;

        public AdminLoginManager()
        {
            dbContext = new QuestionnaireContext();
        }

        public bool Login(string password)
        {
            Admin admin = dbContext.Admins.First();
            return admin.Password == password;
        }

        public void CreateAdmin(string password)
        {
            if (dbContext.Admins.Any())
            {
                throw new InvalidOperationException("Admin already exists");
            }
            dbContext.Admins.Add(new Admin { Password = password});
            dbContext.SaveChanges();           
        }
    }
}