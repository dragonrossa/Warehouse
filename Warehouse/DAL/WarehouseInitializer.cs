using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Warehouse.Models;

namespace Warehouse.DAL
{
    public class WarehouseInitializer : DropCreateDatabaseAlways<WarehouseContext>
    {
      

        protected override void Seed(WarehouseContext context)
            {
                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.



                //Calculate FullPrice in LaptopModels


                decimal? FullPrice(decimal? Price, int Quantity)
                {
                    decimal? result = Price * Convert.ToDecimal(Quantity);
                    return result;
                }


                //Calculate full price with PDV

                decimal PDV = 25;

                decimal? FullPriceWithPDV(decimal? Price, int Quantity)
                {
                    decimal? result = Price * Convert.ToDecimal(Quantity);
                    decimal? resultWithPDV = result * (PDV / 100) + result;
                    return resultWithPDV;
                }


                //Calculate just PDV

                decimal? justPDV(decimal? Price, int Quantity)
                {
                    decimal? result = Price * Convert.ToDecimal(Quantity);
                    decimal? resultPDV = result * (PDV / 100);
                    return resultPDV;
                }

                //Calculate Savings in LaptopModels

                decimal? Savings(decimal? OldPrice, decimal? Price)
                {
                    decimal? result = OldPrice - Price;
                    return result;
                }



                var laptop = new List<LaptopModels>
            {
               new LaptopModels {
                   Name = "Notebook HP 250-G7",
                   Details = "UMA i3-8130U/15.6 FHD/8GB/256GB/W10H 7DC56EA",
                   Quantity = 100,
                   Manufacturer = "HP",
                   OS = "Windows 10",
                   Price = 4333,
                   OldPrice = 7754,
                   FullPrice = FullPrice(4333,100),
                   FullPriceWithPDV = FullPriceWithPDV(4333,100),
                   PDV = justPDV(4333,100),
                   Savings = Savings(7754,4333),
                   Date = DateTime.Now
               },
               new LaptopModels {
                   Name = "Notebook Acer Aspire 1",
                   Details = "NX.GVZEX.010",
                   Quantity = 23,
                   Manufacturer = "Acer",
                   OS = "Windows 10",
                   Price = 2287,
                   OldPrice = 3245,
                   FullPrice = FullPrice(2287,23),
                   FullPriceWithPDV = FullPriceWithPDV(2287,23),
                   PDV = justPDV(2287,23),
                   Savings = Savings(3245,2287),
                   Date = DateTime.Now
               },
                new LaptopModels {
                    Name = "Notebook HP 250 G7a",
                    Details = "6MR38ES",
                    Quantity = 88,
                    Manufacturer = "HP",
                    OS = "Windows 10",
                    Price = 4443,
                    OldPrice = 5552,
                    FullPrice = FullPrice(4443,88),
                    FullPriceWithPDV = FullPriceWithPDV(4443,88),
                    PDV = justPDV(4443,88),
                    Savings = Savings(5552,4443),
                    Date = DateTime.Now
                },
               new LaptopModels {
                   Name = "Notebook Acer Aspire 1a",
                   Details = "NX.SHXEX.050",
                   Quantity = 105,
                   Manufacturer = "Acer",
                   OS = "Windows 10",
                   Price = 2554,
                   OldPrice = 3438,
                   FullPrice = FullPrice(2554,105),
                   FullPriceWithPDV = FullPriceWithPDV(2554,105),
                   PDV = justPDV(2554,105),
                   Savings = Savings(3438,2554),
                   Date = DateTime.Now
               },
                new LaptopModels {
                    Name = "Notebook ASUS X509JB-WB511T",
                    Details = "i5-1035G1/8G/512G/MX110/15.6''FHD / W10",
                    Quantity = 55,
                    Manufacturer = "Asus",
                    OS = "Windows 10",
                    Price = 5998,
                    OldPrice = 7099,
                    FullPrice = FullPrice(5998,55),
                    FullPriceWithPDV = FullPriceWithPDV(5998,55),
                    PDV = justPDV(5998,55),
                    Savings = Savings(7099,5998),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Acer",
                    Details = "A315-22-94Z2, NX.HE8EX.00Q",
                    Quantity = 15,
                    Manufacturer = "Acer",
                    OS = "Linux",
                    Price = 3100,
                    OldPrice = 3300,
                    FullPrice = FullPrice(3100,15),
                    FullPriceWithPDV = FullPriceWithPDV(3100,15),
                    PDV = justPDV(3100,15),
                    Savings = Savings(3300,3100),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Acer Aspire 7",
                    Details = "A715-72G-50M9, NH.GXCEX.024",
                    Quantity = 74,
                    Manufacturer = "Acer",
                    OS = "Linux",
                    Price = 5554,
                    OldPrice = 5755,
                    FullPrice = FullPrice(5554,74),
                    FullPriceWithPDV = FullPriceWithPDV(5554,74),
                    PDV = justPDV(5554,74),
                    Savings = Savings(5755,5554),
                    Date = DateTime.Now},
                new LaptopModels {
                    Name = "Notebook HP 255 G7",
                    Details = "UMA 15.6 FHD/R5-3500U/8GB/256GB/W10Home,2D231EA",
                    Quantity = 18,
                    Manufacturer = "HP",
                    OS = "Windows 10 Home",
                    Price = 4776,
                    OldPrice = 4999,
                    FullPrice = FullPrice(4776,18),
                    FullPriceWithPDV = FullPriceWithPDV(4776,18),
                    PDV = justPDV(4776,18),
                    Savings = Savings(4999,4776),
                    Date = DateTime.Now },
                new LaptopModels {
                    Name = "Notebook Acer Aspire",
                    Details = "A515-54G-52BJ, NX.HFUEX.002",
                    Quantity = 8,
                    Manufacturer = "Acer",
                    OS = "Linux",
                    Price = 5221,
                    OldPrice = 6220,
                    FullPrice = FullPrice(5221,8),
                    FullPriceWithPDV = FullPriceWithPDV(5221,8),
                    PDV = justPDV(5221,8),
                    Savings = Savings(6220,5221),
                    Date = DateTime.Now},
                new LaptopModels {
                    Name = "Notebook Acer Aspire 7a",
                    Details = "A715-72G-50M9, NH.GXCEX.024",
                    Quantity = 55,
                    Manufacturer = "Acer",
                    OS = "Linux",
                    Price = 5554,
                    OldPrice = 5770,
                    FullPrice = FullPrice(5554,55),
                    FullPriceWithPDV = FullPriceWithPDV(5554,55),
                    PDV = justPDV(5554,55),
                    Savings = Savings(5770,5554),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook HP 255 G7a",
                    Details = "UMA 15.6 FHD/R5-3500U/8GB/256GB/W10Home,2D231EA",
                    Quantity = 18,
                    Manufacturer = "HP",
                    OS = "Windows 10 Home",
                    Price = 4776,
                    OldPrice = 4996,
                    FullPrice = FullPrice(4776,18),
                    FullPriceWithPDV = FullPriceWithPDV(4776,18),
                    PDV = justPDV(4776,18),
                    Savings = Savings(4996,4776),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Acer Aspire",
                    Details = "A515-54G-52BJ, NX.HFUEX.002",
                    Quantity = 56,
                    Manufacturer = "Acer",
                    OS = "Linux",
                    Price = 5221,
                    OldPrice = 5321,
                    FullPrice = FullPrice(5221,56),
                    FullPriceWithPDV = FullPriceWithPDV(5221,56),
                    PDV = justPDV(5221,56),
                    Savings = Savings(5321,5221),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Asus X512DA-EJ564T",
                    Details = "15.6˝/FHD/AMD R5/12GB/512GB SSD/W10",
                    Quantity = 121,
                    Manufacturer = "Asus",
                    OS = "Windows 10 Home",
                    Price = 4599,
                    OldPrice = 4699,
                    FullPrice = FullPrice(4599,121),
                    FullPriceWithPDV = FullPriceWithPDV(4599,121),
                    PDV = justPDV(4599,121),
                    Savings = Savings(4699,4599),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Acer Aspire 5",
                    Details = "NX.HN2EX.004",
                    Quantity = 42,
                    Manufacturer = "Acer",
                    OS = "Windows 10 Home",
                    Price = 5099,
                    OldPrice = 5665,
                    FullPrice = FullPrice(5099,42),
                    FullPriceWithPDV = FullPriceWithPDV(5099,42),
                    PDV = justPDV(5099,42),
                    Savings = Savings(5665,5099),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook HP Pavilion x360",
                    Details = "14-dh1027nm 8NJ30EA",
                    Quantity = 15,
                    Manufacturer = "HP",
                    OS = "Windows 10 Home",
                    Price = 5554,
                    OldPrice = 5755,
                    FullPrice = FullPrice(5554,15),
                    FullPriceWithPDV = FullPriceWithPDV(5554,15),
                    PDV = justPDV(5554,15),
                    Savings = Savings(5755,5554),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Lenovo V15",
                    Details = "R3-3250U/8GB/256GB/15,6''FHD/W10H/3god",
                    Quantity = 10,
                    Manufacturer = "Lenovo",
                    OS = "Windows 10 Home 64",
                    Price = 3887,
                    OldPrice = 3999,
                    FullPrice = FullPrice(3887,10),
                    FullPriceWithPDV = FullPriceWithPDV(3887,10),
                    PDV = justPDV(3887,10),
                    Savings = Savings(3999,3887),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook HP Pavilion x360a",
                    Details = "14-dw0012nm, 3M710EA",
                    Quantity = 33,
                    Manufacturer = "HP",
                    OS = "Windows 10 Home",
                    Price = 5887,
                    OldPrice = 5997,
                    FullPrice = FullPrice(5887,33),
                    FullPriceWithPDV = FullPriceWithPDV(5887,33),
                    PDV = justPDV(5887,33),
                    Savings = Savings(5997,5887),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook HP 250 G7",
                    Details = "3C139EA",
                    Quantity = 78,
                    Manufacturer ="HP",
                    OS = "Windows 10 Home",
                    Price = 4887,
                    OldPrice = 4997,
                    FullPrice = FullPrice(4887,78),
                    FullPriceWithPDV = FullPriceWithPDV(4887,78),
                    PDV = justPDV(4887,78),
                    Savings = Savings(4997,4887),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Acer Aspire 3",
                    Details = "NX.HS5EX.00E",
                    Quantity = 44,
                    Manufacturer = "Acer",
                    OS = "Windows 10",
                    Price = 3998,
                    OldPrice = 4125,
                    FullPrice = FullPrice(3998,44),
                    FullPriceWithPDV = FullPriceWithPDV(3998,44),
                    PDV = justPDV(3998,44),
                    Savings = Savings(4125,3998),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Acer Aspire 5a",
                    Details = "NX.HFNEX.002",
                    Quantity = 63,
                    Manufacturer = "Acer",
                    OS = "Boot-up Linux",
                    Price = 4443,
                    OldPrice = 4533,
                    FullPrice = FullPrice(4443,63),
                    FullPriceWithPDV = FullPriceWithPDV(4443,63),
                    PDV = justPDV(4443,63),
                    Savings = Savings(4533,4443),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Lenovo IdeaPad 3",
                    Details = "15IIL05, 81WE00HBSC",
                    Quantity = 34,
                    Manufacturer = "Lenovo",
                    OS = "Windows 10 Home",
                    Price = 3776,
                    OldPrice = 3996,
                    FullPrice = FullPrice(3776,34),
                    FullPriceWithPDV = FullPriceWithPDV(3776,34),
                    PDV = justPDV(3776,34),
                    Savings = Savings(3996,3776),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook Asus X509JA",
                    Details = "X509JA-WB311 W10",
                    Quantity = 45,
                    Manufacturer = "Asus",
                    OS = "Windows 10 Home HR",
                    Price = 4221,
                    OldPrice = 4331,
                    FullPrice = FullPrice(4221,45),
                    FullPriceWithPDV = FullPriceWithPDV(4221,45),
                    PDV = justPDV(4221,45),
                    Savings = Savings(4331,4221),
                    Date = DateTime.Now
                },
                new LaptopModels {
                    Name = "Notebook HP 15s-eq1020nm 1N7Z9EA",
                    Details = "AMD Ryzen 3 3250U 2.60GHz",
                    Quantity = 87,
                    OS = "Windows Home 10 Cro 64",
                    Manufacturer = "HP",
                    Price = 4332,
                    OldPrice = 4552,
                    FullPrice = FullPrice(4332,87),
                    FullPriceWithPDV = FullPriceWithPDV(4332,87),
                    PDV = justPDV(4332,87),
                    Savings = Savings(4552,4332),
                    Date = DateTime.Now
                }
            };

                var store = new List<StoreModels> {
                new StoreModels {
                    Name = "SD Store Outlet Sveta Nedelja",
                    Location ="Sveta Nedelja",
                    ZipCode = 10431,
                    Address = "Dr.Franje Tuđmana 69",
                    QoP = 280,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "sveta.nedelja@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Megastore Westgate",
                    Location = "Jablanovec",
                    ZipCode = 10290,
                    Address = "Zaprešička 2",
                    QoP = 144,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "westgate@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Megastore Arena Park",
                    Location = "Zagreb",
                    ZipCode = 10000,
                    Address = "Jaruščica 4",
                    QoP = 400,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "arena@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "Samsung Experience Store Arena",
                    Location = "Ulica Vice Vukova 6",
                    ZipCode = 10000,
                    Address = "Zagreb",
                    QoP = 221,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "samsungarena@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "PlayStation Experience Stand Arena",
                    Location = "Zagreb",
                    ZipCode = 10000,
                    Address = "Ulica Vice Vukova 6",
                    QoP = 450,
                    StockPrice = 50000,
                    Telephone = "123456789",
                    Email = "sonyarena@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Store Supernova Dubrava",
                    Location = "Zagreb",
                    ZipCode = 10000,
                    Address = "Ulica Rudolfa Kolaka 14",
                    QoP = 430,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "gardenmall@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Superstore CCO East",
                    Location = "Zagreb",
                    ZipCode = 10000,
                    Address = "Slavonska avenija 11d",
                    QoP = 202,
                    StockPrice = 50000,
                    Telephone = "123456789",
                    Email = "ccoe@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Store CCO West",
                    Location = "Zagreb",
                    ZipCode = 10000,
                    Address = "Jankomir 33",
                    QoP = 338,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "ccow@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Superstore CCO Split",
                    Location = "Split",
                    ZipCode = 21000,
                    Address = "Vukovarska 207",
                    QoP=120,
                    StockPrice=50000,
                    Telephone = "123456789",
                    Email = "split@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "SD Megastore Joker",
                    Location = "Split",
                    ZipCode = 21000,
                    Address = "Put Brodarice 6",
                    QoP = 164,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "splitjoker@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name = "Samsung Experience Store Split",
                    Location = "Split",
                    ZipCode = 21000,
                    Address = "Vukovarska 207",
                    QoP = 444,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "samsungsplit@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name= "SD Store Rijeka",
                    Location = "Rijeka",
                    ZipCode = 51000,
                    Address = "Užarska 30",
                    QoP = 454,
                    StockPrice = 500000,
                    Telephone = "123456789",
                    Email = "rijeka@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name= "SD Megastore Rijeka Marti",
                    Location = "Rijeka",
                    ZipCode = 51000,
                    Address = "Martinkovac 127",
                    QoP = 238,
                    StockPrice = 50000,
                    Telephone = "123456789",
                    Email = "rijekamarti@sancta-domenica.hr",
                    WorkingTime = "08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                },
                new StoreModels {
                    Name= "SD Store Zadar",
                    Location="Zadar",
                    ZipCode=23000,
                    Address = "Martinkovac 127",
                    QoP=499,
                    StockPrice=50000,
                    Telephone="123456789",
                    Email="zadar@sancta-domenica.hr",
                    WorkingTime="08-18h ponedjeljak-petak, Subota i nedjelja - ne radi",
                    Date = DateTime.Now
                }
            };

                var roles = new List<RolesModels>
            {
                new RolesModels {
                    Role = "Chief"
                },
                new RolesModels {
                    Role = "Manager"
                },
                new RolesModels {
                    Role = "Assisstant"
                },
                new RolesModels {
                    Role = "IT"
                },
                new RolesModels {
                    Role = "Storage manager"
                }
            };


                var task = new List<TaskListModels> {
                new TaskListModels {
                    Details = "Task1",
                    User = "rodjuga@gmail.com",
                    Status = false
                },
                new TaskListModels {
                    Details = "Task2",
                    User = "rodjuga@gmail.com",
                    Status = false
                },
                new TaskListModels {
                    Details = "Task3",
                    User = "rodjuga@gmail.com",
                    Status = false
                },
                new TaskListModels {
                    Details = "Task4",
                    User = "rodjuga@gmail.com",
                    Status = false
                }
            };

                var supplier = new List<SupplierModels>
            {
                new SupplierModels {
                    SupplierName = "Chipoteka",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
                new SupplierModels {
                    SupplierName = "Instar Informatika",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
                new SupplierModels {
                    SupplierName = "HG Spot",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
                new SupplierModels {
                    SupplierName = "Mikronis",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
                new SupplierModels {
                    SupplierName = "Ronis",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
                new SupplierModels {
                    SupplierName = "Links",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
                new SupplierModels {
                    SupplierName = "Vacom",
                    Location = "Zagreb",
                    Date = DateTime.Now
                },
            };

                var computer = new List<ComputerListModels>
            {
                    new ComputerListModels {
                        Name = "Notebook HP 250-G7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 1",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP 250 G7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 1",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook ASUS X509JB-WB511T",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP 255 G7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP 255 G7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Asus X512DA-EJ564T",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 5",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP Pavilion x360",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Lenovo V15",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP Pavilion x360",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP 250 G7",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 3",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Acer Aspire 5",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Lenovo IdeaPad 3",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook Asus X509JA",
                        Date = DateTime.Now
                    },
                    new ComputerListModels {
                        Name = "Notebook HP 15s-eq1020nm 1N7Z9EA",
                        Date = DateTime.Now
                    }

            };

                var processor = new List<ProcessorModels> {

            new ProcessorModels {
                Name = "AMD Ryzen 5",
                Details = "Best CPU",
                Quantity = 50,
                SupplierAddress = "Xiao Jon 15",
                SupplierLocation = "China" } ,
            new ProcessorModels
            {
                Name="Intel i7",
                Details="Best CPU 2",
                Quantity = 100,
                SupplierAddress = "Xiao Jon 16",
                SupplierLocation = "China"
            }
            };

                //var admin = new List<AdminModels>
                //{
                //    new AdminModels
                //    {
                //        RoleID = 4,
                //        Username = "test@gmail.com",
                //        Access = true,
                //        LaptopAccess = true,
                //        LogAccess = true,
                //        SearchAccess = true,
                //        StoreAccess = true,
                //        TransferAccess = true,
                //        TaskAccess = true,
                //        SupplierAccess = true,
                //        ProcurementAccess = true

                //    }
                //};

            //var user = new ApplicationUser
            //{
            //    UserName = "test@gmail.com",
            //    Email = "test@gmail.com",
            //    Hometown = "Zagreb",
            //};


            //Add to database and save context

                context.LaptopModels.AddRange(laptop);
                context.SaveChanges();
                context.StoreModels.AddRange(store);
                context.SaveChanges();
                context.RolesModels.AddRange(roles);
                context.SaveChanges();
                context.TaskListModels.AddRange(task);
                context.SaveChanges();
                context.SupplierModels.AddRange(supplier);
                context.SaveChanges();
                context.ComputerListModels.AddRange(computer);
                context.SaveChanges();
                context.ProccessorModels.AddRange(processor);
                context.SaveChanges();
                //context.AdminModels.AddRange(admin);
                //context.SaveChanges();
                //context.Users.Add(user);
                //context.SaveChanges();
            }
        

    }
}