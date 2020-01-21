using System;
using BusinessLogic;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminLoginManager adminManager = new AdminLoginManager();
            adminManager.CreateAdmin("admin123");
            bool loginResult = adminManager.Login("admin123");
            Console.WriteLine(loginResult);
        }
    }
}