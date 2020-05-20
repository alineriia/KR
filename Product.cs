using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Product: IComparable
    {
        float price;
        string name;
        int code;
        public Product() { } // Порожній конструктор
        public Product(int c, string n, float p) // Конструктор з параметрами
        {
            code = c;
            name = n;
            price = p;
        }
        public override string ToString() // Метод для рядкового представлення об'єкту
        {
            string line = String.Empty;
            line += (code+ " ");
            line += (name + " ");
            line += (price);
            return line;
        }
       
        public float Price
        {
            get
            {
                return price;
            }
        }
        public int Code
        {
            get
            {
                return code;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int CompareTo(object obj) // Метод для сортування об'єктів за ціною
        {
            Product b = (Product)obj;
            if (Price == b.Price) return 0;
            else if (Price > b.Price) return 1;
            else return -1;
        }
    }
}
    

