using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();     //bu şekilde yapılacak işlemler yapılır
        }
    }


    //Singleton design pattern genellikle factory design pattern ile ortak çalışma yapılarak nesne üretilir
    //bir nesneyi aynı anda iki kullanıcı isterse ve o nesne üretilmemişse o nesneden ister istemez 2 tane oluşur
    //
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();  //dummy nesne
        private CustomerManager()  //constructorı olan ama dışarıdan erişilemeyen nesne gibi
        {

        }
        public static CustomerManager CreateAsSingleton() //CustomerManagerden daah önce oluşturulmuşşsa o verilecek
        {
            /*
            if (_customerManager == null) //oluşturulmamışsa yenisini oluştur
            {
                _customerManager = new CustomerManager();
            }
            return _customerManager;
            */
            //return _customerManager ?? ( _customerManager = new CustomerManager());
            //sadece bu şekilde de yazılabilir tek satırda,temiz bir implementasyon yapmış oluruz.

            lock (_lockObject)  //kodun yenilenmiş halidir
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;

        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}