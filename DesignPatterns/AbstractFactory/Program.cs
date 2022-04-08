using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//cross cutting concerns:log,cache,...
//desing patternler çok kullanılır
namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new FactoryName1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);

    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("logged with Log4Net");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }
    public abstract class CrossCuttingConcernsFactory //bir fabrika oluşturduk,artabilir..
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
        //
        //
    }
    public class FactoryName1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();

        }
    }
    public class ProductManager//:IProductService olmalı   //iş katmanı yazıyouz
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("product listed.");
        }


    }



}
