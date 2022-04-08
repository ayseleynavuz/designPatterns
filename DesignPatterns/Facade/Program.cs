using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Uygulaması en basit tasarım desenlerindendir.Facade-cephe,dış görünüş demektir.
//Elimizdeki sınıflara tek tek ulaşmaktansa tek bbir cephede toplayıp,o cephe üzerinden ulaşıyoruz.

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class logging : ILogging 
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }
    internal interface ILogging
    {
        void Log();
    }
    class Caching :ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }
    interface ICaching
    {
        void Cache();
    }
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked!");
        }
    }   
    interface IAuthorize
    {
        void CheckUser();
    }
    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }
    interface IValidate
    {
        void Validate();
    }

    class CustomerManager
    {
        CrossCuttingConcernsFacade _concernsFacade;
        public CustomerManager()
        {
            _concernsFacade = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concernsFacade.Caching.Cache();
            _concernsFacade.Authorize.CheckUser();
            _concernsFacade.Logging.Log();
            _concernsFacade.Validation.Validate();
            Console.WriteLine("Saved!");
        }
    }
    
    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;
        
        public CrossCuttingConcernsFacade()
        {
            Logging = new logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();
        }

    }

}
