using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new AyLogger());
            productManager.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved!");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class AyLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged,{0}", message);
        }
    }
    //Bu kısmı Nuget den indirildiğini varsayalım, burası dll diyelim
    class Log4Net 
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net,{0}", message);
        }
    }

    //yukarıdakini değilde bu adapter kullanılır
    //gerekli servis için bu şekilde adapter yazılıyor,interface varsa implemente edilir ve kullanılır
    class log4netAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }


}
