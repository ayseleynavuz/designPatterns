using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod  //en sık kullanılanlardan birisidir Amaç yazılımda değişimi kontrol altında tutmaktır.
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class LoggerFactory : ILoggerFactory       //bir class çıplak kalmamalı!
    {
        public ILogger CreateLogger()
        {
            //business to decide factory
            return new AleynaLogger();   //nereye loglamak isteniyor veritabanı,metin dosyası mı?
        }
    }
    public class LoggerFactory2 : ILoggerFactory  //yeni bir fabrika eklenirse    
    {
        public ILogger CreateLogger()
        {
            //business to decide factory
            return new Log4NetLogger();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public interface ILogger
    {
        void Log();
    }
    public class AleynaLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AleynaLogger");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            /*
            Console.WriteLine( "Saved!");
            //ILogger logger = new AleynaLogger(); //new yapınca tamamen AleynaLogger'a bağlı olur.Newlenmeden önce düşünmeli
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
            */

            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();

        }
    }


}
