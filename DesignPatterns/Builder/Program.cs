using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Builder Tasarım Deseni-örnek Çalışma
//ortaya bir nesne örneği çıkarmayı hedefler,bu nesne örneği biribiri arkasına atılacak adımların sırasıyla işlenmesi sonucu ortaya çıkar
//genellikle iş,arayüz katmanlarında kodlarımızı if ile yazmak yerine ilgili üreticini enjekte edilmesi ve ona göre ortaya bir nesnenin çıkarılması şeklinde örneklendiririz.

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);

            Console.ReadLine();

        }
    }
    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder  //
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder  //ilk kez bizden alışveriş yapacak kullanıcı
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "İçecekler";
            model.ProductName = "Çay";
            model.UnitPrice = 20;

        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }
    class ProductDirector  //arka arkaya çalıştırılacak işlmelre karşılık geliyor
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();  
            productBuilder.ApplyDiscount();

        }
    }



}
