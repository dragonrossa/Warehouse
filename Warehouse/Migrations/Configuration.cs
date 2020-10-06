namespace Warehouse.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Warehouse.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Warehouse.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Warehouse.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //example

            //var context = new SampleContext();
            //var author = new Author { FirstName = "Stephen", LastName = "King" };
            //var books = new List<Book> {
            //new Book { Title = "It", Author = author },
            //new Book { Title = "Carrie", Author = author },
            //new Book { Title = "Misery", Author = author }
            //    };
            //context.AddRange(books);
            //context.SaveChanges();

            var laptop = new List<LaptopModels>
            {
                new LaptopModels { Name = "Notebook HP 250-G7", Description = "UMA i3-8130U/15.6 FHD/8GB/256GB/W10H 7DC56EA", Quantity = 100, Manufacturer = "HP", OS = "Windows 10",Price = 4333, OldPrice = 7754},
                new LaptopModels { Name = "Notebook Acer Aspire 1", Description = "NX.GVZEX.010", Quantity = 23, Manufacturer = "Acer", OS = "Windows 10", Price = 2287, OldPrice = 3245, },
                new LaptopModels { Name = "Notebook HP 250 G7", Description = "6MR38ES", Quantity = 88, Manufacturer = "HP", OS = "Windows 10", Price = 4443, OldPrice = 5552 },
                new LaptopModels { Name = "Notebook Acer Aspire 1",Description= "NX.SHXEX.050",Quantity=105,Manufacturer="Acer",OS= "Windows 10",Price= 2554,OldPrice=3438 },
                new LaptopModels { Name = "Notebook ASUS X509JB-WB511T",Description= "i5-1035G1/8G/512G/MX110/15.6''FHD / W10",Quantity=55,Manufacturer="Asus",OS= "Windows 10",Price= 5998,OldPrice=7099 },
                new LaptopModels { Name = "Notebook Acer",Description= "A315-22-94Z2, NX.HE8EX.00Q",Quantity=15,Manufacturer="Acer",OS= "Linux",Price= 3100,OldPrice=3300 },
                new LaptopModels { Name = "Notebook Acer Aspire 7",Description= "A715-72G-50M9, NH.GXCEX.024",Quantity=74,Manufacturer="Acer",OS= "Linux",Price= 5554,OldPrice=5755 },
                new LaptopModels { Name = "Notebook HP 255 G7",Description= "UMA 15.6 FHD/R5-3500U/8GB/256GB/W10Home, 2D231EA",Quantity= 18, Manufacturer="HP",OS= "Windows 10 Home",Price= 4776,OldPrice=4999 },
                new LaptopModels { Name = "Notebook Acer Aspire",Description= "A515-54G-52BJ, NX.HFUEX.002",Quantity= 8,Manufacturer="Acer",OS= "Linux",Price= 5221,OldPrice=6220 },
                new LaptopModels { Name = "Notebook Acer Aspire 7",Description= "A715-72G-50M9, NH.GXCEX.024",Quantity=55,Manufacturer="Acer",OS= "Linux",Price= 5554,OldPrice=5770 },
                new LaptopModels { Name = "Notebook HP 255 G7",Description= "UMA 15.6 FHD/R5-3500U/8GB/256GB/W10Home, 2D231EA",Quantity=18,Manufacturer="HP",OS= "Windows 10 Home",Price= 4776,FullPrice=4996 },
                new LaptopModels { Name = "Notebook Acer Aspire",Description= "A515-54G-52BJ, NX.HFUEX.002",Quantity=56,Manufacturer="Acer",OS= "Linux",Price= 5221,OldPrice=5321 },
                new LaptopModels { Name = "Notebook Asus X512DA-EJ564T",Description= "15.6˝/FHD/AMD R5/12GB/512GB SSD/W10",Quantity=121,Manufacturer="Asus",OS= "Windows 10 Home",Price= 4599,OldPrice=4699 },
                new LaptopModels { Name = "Notebook Acer Aspire 5",Description= "NX.HN2EX.004",Quantity=42,Manufacturer="Acer",OS= "Windows 10 Home",Price= 5099,OldPrice= 5665 },
                new LaptopModels { Name = "Notebook HP Pavilion x360",Description= "14-dh1027nm 8NJ30EA",Quantity=15,Manufacturer="HP",OS= "Windows 10 Home",Price= 5554,OldPrice=5755 },
                new LaptopModels { Name = "Notebook Lenovo V15", Description= "R3-3250U/8GB/256GB/15,6''FHD/W10H/3god",Quantity=10,Manufacturer="Lenovo",OS= "Windows 10 Home 64",Price= 3887,OldPrice=3999 },
                new LaptopModels { Name = "Notebook HP Pavilion x360",Description= "14-dw0012nm, 3M710EA",Quantity=33,Manufacturer="HP",OS= "Windows 10 Home",Price= 5887,OldPrice=5997 },
                new LaptopModels { Name = "Notebook HP 250 G7",Description= "3C139EA",Quantity=78,Manufacturer="HP",OS= "Windows 10 Home",Price= 4887,FullPrice=4997 },
                new LaptopModels { Name = "Notebook Acer Aspire 3",Description= "NX.HS5EX.00E",Quantity=44,Manufacturer="Acer",OS= "Windows 10",Price= 3998,FullPrice=4125 },
                new LaptopModels { Name = "Notebook Acer Aspire 5",Description= "NX.HFNEX.002",Quantity=63,Manufacturer="Acer",OS= "Boot-up Linux",Price= 4443,FullPrice=4533 },
                new LaptopModels { Name = "Notebook Lenovo IdeaPad 3",Description= "15IIL05, 81WE00HBSC",Quantity=34,Manufacturer="Lenovo",OS= "Windows 10 Home",Price= 3776,FullPrice=3996 },
                new LaptopModels { Name = "Notebook Asus X509JA",Description= "X509JA-WB311 W10",Quantity=45,Manufacturer="Asus",OS= "Windows 10 Home HR",Price=4221,FullPrice=4331 },
                new LaptopModels { Name = "Notebook HP 15s-eq1020nm 1N7Z9EA", Description = "AMD Ryzen 3 3250U 2.60GHz", Quantity = 87, OS = "Windows Home 10 Cro 64", Price = 4332, FullPrice = 4552 }
            };

            context.LaptopModels.AddRange(laptop);
            context.SaveChanges();



           
         
        }
    }
}
