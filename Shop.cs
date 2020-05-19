using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace KR
{
    class Shop
    {
        string name;
        int number;
        string email;
        int hours1;
        int hours2;
        double sum = 0;
        List <Product> products = new List<Product>();
        Consumer consumer = new Consumer();
        public void BdaySale() // Метод для знижки у випадку дня народження клієнта
        {
            consumer.Bday();
            if ((consumer.Day >= consumer.OrdDay || consumer.Day <= consumer.OrdDay + 3) && consumer.Month == consumer.OrdMonth)
            {
                sum = sum * 0.9;
                Console.WriteLine("\n____________________________________________\n\n..:: You have 10% of sale additionally ::..\n____________________________________________\n"); 
                Console.WriteLine("\nYou've ordered {0} products. To pay {1} UAH:", cart.Count, sum);
            }
            else
            {
                Console.WriteLine("\n..:: Unfortunately, you don't have any extra sales ::..");
            }
        }
        public void InputProducts(string file) // Метод зчитування списку товарів з файлу 
        {
            string line; 
            using (StreamReader MyFile = new StreamReader(file))
            {
                while ((line = MyFile.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    if (data.Length == 3)
                    {
                        Product NewProduct = new Product(int.Parse(data[0]), data[1], float.Parse(data[2]));
                        products.Add(NewProduct);
                    }
                }
            }
            if (products.Count != 0)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(products[i] + "\n");
                }
            }
            else
            {
                Console.WriteLine("List of products is empty. Enter any key to exit... "); Console.ReadKey();
            }
        }
        List<Product> cart = new List<Product>();
        public void AddInCart() // Метод додавання товару в кошик
        {
            while (true)
            {
                Console.WriteLine("\nEnter code to add item");
                int cheker = 0;
                int code1 = int.Parse(Console.ReadLine());
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Code == code1)
                    {
                        cart.Add(products[i]);
                        sum += products[i].Price;
                        cheker++;
                    }
                }
                if (cheker == 0)
                {
                    Console.WriteLine("Incorrect code");
                }
                Console.WriteLine("\nContinue? Enter 1 to continue or 0 to do not");
                int a = int.Parse(Console.ReadLine());
                if (a == 0) { break; }
                else
                {
                    if (a == 1) { continue; }
                    else
                        Console.WriteLine("Incorrect symbol");
                }
            }
        }
        public void RemoveCart() //Метод для видалення товару з кошику
        {
            if (cart.Count != 0)
            {
                Console.WriteLine("\nDo you want to delete item? Enter 1 to do or 0 to do not");
                int answ1 = int.Parse(Console.ReadLine()); int cheker = 0;
                if (answ1 == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter code to delete item");
                        int code1 = int.Parse(Console.ReadLine());
                        for (int i = 0; i < cart.Count; i++)
                        {
                            if (cart[i].Code == code1)
                            {
                                sum -= cart[i].Price;
                                cart.Remove(cart[i]);
                                cheker++;
                            }
                            if (cheker == 0)
                            {
                                Console.WriteLine("!!! Incorrect code !!!");
                            }
                        }
                        Console.WriteLine("Continue? Enter 1 to continue or 0 to do not");
                        int answ2 = int.Parse(Console.ReadLine());
                        if (answ2 == 0) { break; }
                        else
                        {
                            if (answ2 == 1) { continue; }
                            else
                                Console.WriteLine("Incorrect symbol");
                        }
                    }
                }
                else
                {
                    if (answ1 != 0)
                    {
                        Console.WriteLine("\n!!! Incorrect answer !!!");
                        RemoveCart();
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYour cart is empty. Add something in your Shopping cart");
            }
        }
        public void Sort() // Метод для сортування списку товарів за ціною
        {
            Console.WriteLine("\nFor :LOW - HIGH: sort enter 1\nfor :HIGH - LOW: sort enter 2");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    Console.WriteLine("\nLOW - HIGH\n");
                    products.Sort();
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(products[i] + "\n");
                    }
                    break;
                case "2":
                    Console.WriteLine("\nHIGH - LOW\n");
                    products.Sort();
                    for (int i = products.Count - 1; i > -1; i--)
                    {
                        Console.WriteLine(products[i] + "\n");
                    }
                    break;
                default:
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(products[i] + "\n");
                    }
                    break;
            }
        }
        public void Operations() // Метод для вибору операції
        {
            Console.WriteLine("====== C H O O S E   O P E R A T I O N =====\n\nAdd\nDelete\nShow\nAccept\n\n===========================================\n");
            string sw = Console.ReadLine();
            switch (sw)
            {
                case ("Add"):
                    AddInCart(); Operations();
                    break;
                case ("Delete"):
                    RemoveCart(); Operations();
                    break;
                case ("Show"):
                    ShowCart(); Operations();
                    break;
                case ("Accept"):
                    Accepting();
                    Console.WriteLine("Thank You for Your order!");
                    break;
                default:
                    Console.WriteLine("Incorrect operation");
                    Operations();
                    break;
            } 
        }
        public void Accepting() // Метод для підтвердження замовлення
        {
            if (cart.Count != 0)
            {
                int delivery = 50;
                    float V = 1000; float V1 = 1500;
                    if (sum >= V && sum < V1)
                    {
                        sum = 0.95 * sum; Console.WriteLine("\nDelivery is free\n\nYour sale is 5%. Cost is {0}", sum);
                    }
                    else
                    {
                        if (sum >= V1)
                        {
                            sum = 0.93 * sum;
                            Console.WriteLine("\nDelivery is free\n\nYour sale is 7%. Cost is {0}", sum);
                        }
                        else
                        {
                        sum += delivery;
                        Console.WriteLine("\nDelivery is {0} UAH, full price is {1}", delivery, sum);
                        }
                    }
                Console.WriteLine("\nThe time of making order is {0}:{1}\n", consumer.Hour, consumer.Minutes);
            }
            else
            {
                Console.WriteLine("\nYour cart is empty. Add something in your Shopping cart");
                Operations();
            }
        }
        public void ShowCart() // Метод для показу переліку товарів у кошику
        {
            if (cart.Count != 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    Console.WriteLine("\n" + cart[i]);
                }
                Console.WriteLine("\n{0} products are added. Full price is {1} UAH:", cart.Count, sum);
            }
            else
            {
                Console.WriteLine("\nYour cart is empty. Add something in your Shopping cart");
                Operations();
            }
        }
        public Shop() // Конструктор за замовчуванням
        {
            name = "RUSTLE";
            number = 834943;
            email = "rustle@gmail.com";
            hours1 = 9;
            hours2 = 19;
            sum = 0;
            if (consumer.Hour < 9 || consumer.Hour > 19)
            {
                Console.WriteLine("Proccesing will be at {0} to {1}", hours1, hours2);
            }
            Console.WriteLine("\nDelivery for all cities of Ukraine is provided by Nova Poshta\nInternational ship is provided by Meest");
        }
        public Shop(string n, int nm,string em,int h1,int h2) // Конструктор з параметрами
        {
            name = n;
            number = nm;
            email = em;
            hours1 = h1;
            hours2 = h2;
        }
        public override string ToString() // Метод для виведення інформації про магазин
        {
            string line = String.Empty;
            line += ("\n========= Our contact information ==========\n\n"+name +" " );
            line += ("\nN U M B E R: "+number + " " );
            line += ("\nE - M A I L: "+email + " ");
            line += ("\nWork FROM " + hours1+" TO "+hours2+ "\n\n============== W E L C O M E ===============\n\n");
            return line;
        }
        public void SearchByName() //Метод пошуку товару за наіменуванням
        {
            int cheker = 0;
            Console.WriteLine("\nEnter name of product to search");
            string name1 = Console.ReadLine();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.Equals(name1)) { 
                products[i].Output(); cheker++;
                }
            }
            if (cheker == 0)
            {
                Console.WriteLine("Incorrect name");
                SearchByName();
            }
        }
    }
}
