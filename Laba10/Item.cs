using System;
using System.Collections.Generic;
using System.Text;

namespace Laba10
{
    public class Item : IInit, IComparable, ICloneable
    {
        // цена товара
        protected int price = 0;
        public IdNumber id = new IdNumber(0);

        public int Price
        {
            get { return price; }
            set 
            {
                if (value > 0)
                    price = value;
                else 
                    price = 0;
            }
        }

        // наименование товара
        protected string name = "NoNameItem";

        public string Name
        {
            get { return name; }
            set 
            {
                if (value != string.Empty)
                    name = value;
                else 
                    name = "NoNameItem";
            }
        }

        // количество созданных экземпляров класса Item (count = кол-во Item + кол-во Toy + кол-во Product + кол-во MilkProduct)
        public static int count { get; protected set; } = 0;
        protected static Random rnd = new Random();
        private static readonly string[] randomNames = { "Молоко", "Ящик", "Шоколад", "Робот", "Куртка", "Сыр", "Кукла", "Кефир", "Шапка", "Мяч", "Мороженое", "Помидоры", "Шарик", "Шарф", "Машина", "Сок", "Самолёт", "Сметана" };

        // пустой конструктор
        public Item()
        {
            count++;
        }

        // price, price name
        public Item(int price, string name = "NoNameItem", int id = 0)
        {
            this.Price = price;
            this.Name = name;
            this.id = new IdNumber(id);
            count++;
        }

        // name
        public Item(string name)
        {
            this.Name = name;
            count++;
        }

        // метод интерфейса Init, формирующий элементы класса с помощью ДСЧ
        virtual public object Init()
        {
            return new Item(Item.rnd.Next(1, 10000), Item.randomNames[rnd.Next(0, randomNames.Length)]);
        }

        // метод инферфейса ICompareable
        public int CompareTo(Object obj)
        {
            Item item = (Item)obj;

            return string.Compare(this.Name, item.Name);
        }

        public static explicit operator string(Item item)
        {
            return $"Price: {item.Price} rub\nName: {item.Name}";
        }

        // виртуальный метод
        virtual public void Show()
        {
            Console.WriteLine((string)this + "\n");
        }

        // невиртуальный метод
        public void Print()
        {
            Console.WriteLine((string)this + "\n");
        }

        // запрос на получение наименований всех товаров класса Item и его подклассов в массиве
        public static string[] GetAllNames(Item[] items)
        {
            var names = new string[items.Length];
            int i = 0;

            foreach (Item item in items)
            {
                names[i] = item.Name;
                i++;
            }

            return names;
        }

        public static string[] GetAllUniqueNames(Item[] items)
        {
            var names = new string[items.Length];
            int i = 0;

            foreach (Item item in items)
            {
                if (Array.IndexOf(names, item.Name) == -1)
                {
                    names[i] = item.Name;
                    i++;
                }
            }

            Array.Resize(ref names, i);

            return names;
        }

        // запрос на получение количества товаров с заданным наименованием в массиве
        public static int CountItems(Item[] items, string name)
        {
            string[] names = Item.GetAllNames(items);
            name = name.ToLower();
            int count = 0;

            foreach (string name1 in names)
            {
                if (name1.ToLower() == name)
                    count++;
            }

            return count;
        }

        // запрос на получение стоимости всех товаров с заданным наименованием в массиве
        public static int GetTotalCost(Item[] items, string name)
        {
            name = name.ToLower();
            int totalCost = 0;

            if (Item.CountItems(items, name) > 0)
            {
                foreach (Item item in items)
                {
                    if (item.Name.ToLower() == name)
                        totalCost += item.Price;
                }

                return totalCost;
            }
            else
                return -1;
        }

        // клонирование
        virtual public object Clone()
        {
            return new Item(this.Price, this.Name, this.id.number);
        }

        // поверхностное копирование
        virtual public object ShalowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
