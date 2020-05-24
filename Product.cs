using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR {

    /// <summary>
    /// Клас для задання та читання даних про товар
    /// </summary>
    class Product : IComparable
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
        /// <summary>
        /// Метод для виведення інформації про об'єкт
        /// </summary>
        /// <returns>Інформація про об'єкт: код, найменування, ціна</returns>
        public override string ToString() 
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
        /// <summary>
        ///  Метод для сортування об'єктів за ціною
        /// </summary>
        /// <param name="obj">Об'єкт з яким порівнюємо інший об'єкт</param>
        /// <returns>Результат порівняння двох об'єктів</returns>
        public int CompareTo(object obj)
        {
            Product b = (Product)obj;
            if (Price == b.Price) return 0;
            else if (Price > b.Price) return 1;
            else return -1;
        }
    }
}
    

