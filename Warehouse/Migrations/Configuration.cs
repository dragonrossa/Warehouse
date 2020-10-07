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



            //var laptop = new List<LaptopModels>
            //{
            //    new LaptopModels { Name = "Notebook HP 250-G7",Description = "UMA i3-8130U/15.6 FHD/8GB/256GB/W10H 7DC56EA", Quantity = 100, Manufacturer = "HP", OS = "Windows 10",Price = 4333, OldPrice = 7754},
            //    new LaptopModels { Name = "Notebook Acer Aspire 1", Description = "NX.GVZEX.010", Quantity = 23, Manufacturer = "Acer", OS = "Windows 10", Price = 2287, OldPrice = 3245, },
            //    new LaptopModels { Name = "Notebook HP 250 G7", Description = "6MR38ES", Quantity = 88, Manufacturer = "HP", OS = "Windows 10", Price = 4443, OldPrice = 5552 },
            //    new LaptopModels { Name = "Notebook Acer Aspire 1", Description= "NX.SHXEX.050",Quantity=105,Manufacturer="Acer",OS= "Windows 10",Price= 2554,OldPrice=3438 },
            //    new LaptopModels { Name = "Notebook ASUS X509JB-WB511T",Description= "i5-1035G1/8G/512G/MX110/15.6''FHD / W10",Quantity=55,Manufacturer="Asus",OS= "Windows 10",Price= 5998,OldPrice=7099 },
            //    new LaptopModels { Name = "Notebook Acer", Description= "A315-22-94Z2, NX.HE8EX.00Q",Quantity=15,Manufacturer="Acer",OS= "Linux",Price= 3100,OldPrice=3300 },
            //    new LaptopModels { Name = "Notebook Acer Aspire 7", Description= "A715-72G-50M9, NH.GXCEX.024",Quantity=74,Manufacturer="Acer",OS= "Linux",Price= 5554,OldPrice=5755 },
            //    new LaptopModels { Name = "Notebook HP 255 G7",Description= "UMA 15.6 FHD/R5-3500U/8GB/256GB/W10Home, 2D231EA",Quantity= 18, Manufacturer="HP",OS= "Windows 10 Home",Price= 4776,OldPrice=4999 },
            //    new LaptopModels { Name = "Notebook Acer Aspire",Description= "A515-54G-52BJ, NX.HFUEX.002",Quantity= 8,Manufacturer="Acer",OS= "Linux",Price= 5221,OldPrice=6220 },
            //    new LaptopModels { Name = "Notebook Acer Aspire 7",Description= "A715-72G-50M9, NH.GXCEX.024",Quantity=55,Manufacturer="Acer",OS= "Linux",Price= 5554,OldPrice=5770 },
            //    new LaptopModels { Name = "Notebook HP 255 G7",Description= "UMA 15.6 FHD/R5-3500U/8GB/256GB/W10Home, 2D231EA",Quantity=18,Manufacturer="HP",OS= "Windows 10 Home",Price= 4776,FullPrice=4996 },
            //    new LaptopModels { Name = "Notebook Acer Aspire",Description= "A515-54G-52BJ, NX.HFUEX.002",Quantity=56,Manufacturer="Acer",OS= "Linux",Price= 5221,OldPrice=5321 },
            //    new LaptopModels { Name = "Notebook Asus X512DA-EJ564T",Description= "15.6˝/FHD/AMD R5/12GB/512GB SSD/W10",Quantity=121,Manufacturer="Asus",OS= "Windows 10 Home",Price= 4599,OldPrice=4699 },
            //    new LaptopModels { Name = "Notebook Acer Aspire 5",Description= "NX.HN2EX.004",Quantity=42,Manufacturer="Acer",OS= "Windows 10 Home",Price= 5099,OldPrice= 5665 },
            //    new LaptopModels { Name = "Notebook HP Pavilion x360",Description= "14-dh1027nm 8NJ30EA",Quantity=15,Manufacturer="HP",OS= "Windows 10 Home",Price= 5554,OldPrice=5755 },
            //    new LaptopModels { Name = "Notebook Lenovo V15", Description= "R3-3250U/8GB/256GB/15,6''FHD/W10H/3god",Quantity=10,Manufacturer="Lenovo",OS= "Windows 10 Home 64",Price= 3887,OldPrice=3999 },
            //    new LaptopModels { Name = "Notebook HP Pavilion x360",Description= "14-dw0012nm, 3M710EA",Quantity=33,Manufacturer="HP",OS= "Windows 10 Home",Price= 5887,OldPrice=5997 },
            //    new LaptopModels { Name = "Notebook HP 250 G7",Description= "3C139EA",Quantity=78,Manufacturer="HP",OS= "Windows 10 Home",Price= 4887,FullPrice=4997 },
            //    new LaptopModels { Name = "Notebook Acer Aspire 3",Description= "NX.HS5EX.00E",Quantity=44,Manufacturer="Acer",OS= "Windows 10",Price= 3998,FullPrice=4125 },
            //    new LaptopModels { Name = "Notebook Acer Aspire 5",Description= "NX.HFNEX.002",Quantity=63,Manufacturer="Acer",OS= "Boot-up Linux",Price= 4443,FullPrice=4533 },
            //    new LaptopModels { Name = "Notebook Lenovo IdeaPad 3",Description= "15IIL05, 81WE00HBSC",Quantity=34,Manufacturer="Lenovo",OS= "Windows 10 Home",Price= 3776,FullPrice=3996 },
            //    new LaptopModels { Name = "Notebook Asus X509JA",Description= "X509JA-WB311 W10",Quantity=45,Manufacturer="Asus",OS= "Windows 10 Home HR",Price=4221,FullPrice=4331 },
            //    new LaptopModels { Name = "Notebook HP 15s-eq1020nm 1N7Z9EA", Description = "AMD Ryzen 3 3250U 2.60GHz", Quantity = 87, OS = "Windows Home 10 Cro 64", Price = 4332, FullPrice = 4552 }
            //};

            //var store = new List<StoreModels> {
            //    new StoreModels{ Name = "SD Store Outlet Sveta Nedelja",Location="Sveta Nedelja",ZipCode=10431,Address="Dr.Franje Tuđmana 69",QoP=280,StockPrice=500000,Telephone="010101012",Email="sveta.nedelja@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Megastore Westgate",Location="Jablanovec",ZipCode=10290,Address="Zaprešička 2",QoP=144,StockPrice=500000,Telephone="00000000",Email="westgate@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Megastore Arena Park",Location="Zagreb",ZipCode=10000,Address="Jaruščica 4",QoP=400,StockPrice=500000,Telephone="03030303",Email="arena@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "Samsung Experience Store Arena",Location="Ulica Vice Vukova 6",ZipCode=10000,Address="Zagreb",QoP=221,StockPrice=500000,Telephone="04040404",Email="samsungarena@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "PlayStation Experience Stand Arena",Location="Zagreb",ZipCode=10000,Address="Ulica Vice Vukova 6",QoP=500,StockPrice=50000,Telephone="05050505",Email="sonyarena@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Store Supernova Dubrava (ex-Garden Mall)",Location="Zagreb",ZipCode=10000,Address="Ulica Rudolfa Kolaka 14",QoP=600,StockPrice=500000,Telephone="06060606",Email="gardenmall@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Superstore CCO East",Location="Zagreb",ZipCode=10000,Address="Slavonska avenija 11d",QoP=202,StockPrice=50000,Telephone="06060606",Email="ccoe@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Store CCO West",Location="Zagreb",ZipCode=10000,Address="Jankomir 33",QoP=338,StockPrice=500000,Telephone="07070707",Email="ccow@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Superstore CCO Split",Location="Split",ZipCode=21000,Address="Vukovarska 207",QoP=120,StockPrice=50000,Telephone="08080808",Email="split@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name = "SD Megastore Joker",Location="Split",ZipCode=21000,Address="Put Brodarice 6",QoP=164,StockPrice=500000,Telephone="09090909",Email="splitjoker@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name= "Samsung Experience Store Split",Location="Split",ZipCode=21000,Address="Vukovarska 207",QoP=444,StockPrice=500000,Telephone="10101010",Email="samsungsplit@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name= "SD Store Rijeka",Location="Rijeka",ZipCode=51000,Address="Užarska 30",QoP=454,StockPrice=500000,Telephone="1111111",Email="rijeka@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name= "SD Megastore Rijeka Marti",Location="Rijeka",ZipCode=51000,Address="Martinkovac 127",QoP=238,StockPrice=50000,Telephone="45454545",Email="rijekamarti@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"},
            //    new StoreModels{ Name= "SD Store Zadar",Location="Zadar",ZipCode=23000,QoP=499,StockPrice=50000,Telephone="45454512",Email="zadar@sancta-domenica.hr",WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi"}
            //};

            //var roles = new List<RolesModels>
            //{
            //    new RolesModels{ Role="Chief"},
            //    new RolesModels{ Role="Manager"},
            //    new RolesModels{ Role="Assisstant"},
            //    new RolesModels{ Role="IT"},
            //    new RolesModels{ Role="Storage manager"}
            //};


            //var task = new List<TaskListModels> {
            //    new TaskListModels{ Details="task", User="rodjuga@gmail.com", Status=false},
            //    new TaskListModels{ Details="task", User="rodjuga@gmail.com", Status=false},
            //    new TaskListModels{ Details="task", User="rodjuga@gmail.com", Status=false},
            //    new TaskListModels{ Details="task1", User="rodjuga@gmail.com", Status=false}
            //};
            
            //context.LaptopModels.AddRange(laptop);
            //context.StoreModels.AddRange(store);
            //context.RolesModels.AddRange(roles);
            //context.TaskListModels.AddRange(task);
            //context.SaveChanges();


        }
    }
}
