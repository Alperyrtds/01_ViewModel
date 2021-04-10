using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_ViewModel.Data
{
    public class FakeDatabaseOperation
    {

        public static List<Patlangac> patlangacs = new List<Patlangac>
        {
            new Patlangac
            {
               Id = 1,
               Name = "Yeni Ürün",
               Description = ""
            },
            new Patlangac
            {
               Id = 2,
               Name = "Şok Fiyat",
               Description = ""
            },
            new Patlangac
            {
               Id = 3,
               Name = "En iyi fiyat",
               Description = ""
            }
        };

        public static List<Category> categories = new List<Category>
        {
            new Category
            {
                Id =1,
                Name = "Bilgisayar"
            },
            new Category
            {
                Id =2,
                Name = "Beyaz Eşya"
            }
        };

        public static List<Product> products = new List<Product>
        {
            new Product
            {
                Id=1,
                Name="Iphonex",
                Description="Telefon",
                Patlangacs=new List<Patlangac>(),
                Price=2800,
                CategoryId=1,
                Category=categories.First(t=>t.Id==1)


            },
            new Product
            {
                Id=2,
                Name="Sansung",
                Description="Telefon",
                Patlangacs=new List<Patlangac>(),
                Price=3800,
                CategoryId=2,
                Category=categories.First(t=>t.Id==2)


            },
            new Product
            {
                Id = 3,
                Name = "Playstation 5",
                Description = "Konsol",
                Patlangacs=new List<Patlangac>(),
                Price = 3408,
                
                CategoryId=2,
                Category = categories.First(t=>t.Id ==1)

            }


        };

        public static BannerProduct productsBannerArea = new BannerProduct
        {

            Id = 1,
            BanProducts = new List<Product>
            {
                new Product
                {
                    Id = 3,
                    Name = "Playstation 5",
                    Description = "Konsol",
                    Price = 3408,
                    Patlangacs = null
                }
            }
        };

        public static Product getProductById(int id)
        {
            Product product = null;
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    product = item;
                    break;
                }
            }

            return product;
        }

        public static void UpdateProduct(Product product, List<int>patlangacIds)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == product.Id)
                {

                    products[i] = product;
                    break;
                }

            }

            product.Category = categories.First(y => y.Id == product.CategoryId);
            product.Patlangacs = new List<Patlangac>();


            foreach (int patlangacId in patlangacIds)
            {
               
                Patlangac patlangac = patlangacs.First(t => t.Id == patlangacId);
                product.Patlangacs.Add(patlangac);
            }

        }
        public static void DeleteProduct(int id)
        {
            Product aranan = null;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    aranan = products[i];
                    break;
                }
            }
            products.Remove(aranan);
        }

        public static void AddProduct(Product product, List<int> patlangacIds)
        {
            product.Id = products.Last().Id + 1;

            product.Category = categories.First(t => t.Id == product.CategoryId);

            product.Patlangacs = new List<Patlangac>();

            foreach (int patlangacId in patlangacIds)
            {
                
                Patlangac patlangac = patlangacs.First(t => t.Id == patlangacId);
                product.Patlangacs.Add(patlangac);
            }





            products.Add(product);
        }
    }
}