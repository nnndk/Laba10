using System;
using System.Collections.Generic;
using System.Text;

namespace Laba10
{
    public class Product : Item, IInit, IComparable, ICloneable
    {
        // срок годности продукта (в днях)
        protected int shelfLife;

        public int ShelfLife
        {
            get { return shelfLife; }
            set 
            {
                if (value > 0)
                    shelfLife = value;
                else 
                    shelfLife = 0;
            }
        }

        // количество экземпляров класса Product (в том числе и MilkProduct)
        public static new int count { get; protected set; } = 0;
        private static readonly string[] randomProds = { "Сыр", "Кефир", "Шоколад", "Мороженое", "Помидоры", "Сметана", "Сок", "Молоко" };

        // пустой конструктор
        public Product() : base()
        {
            this.Name = "NoNameProduct";
            count++;
        }

        // price, price name, price name shelfLife
        public Product(int price, string name = "NoNameProduct", int shelfLife = 0) : base(price, name)
        {
            this.shelfLife = shelfLife;
            count++;
        }

        // name
        public Product(string name) : base(name)
        {
            count++;
        }

        // метод интерфейса IInit, формирующий элементы класса с помощью ДСЧ
        public override object Init()
        {
            count++;
            return new Product(Item.rnd.Next(1, 10000), randomProds[Item.rnd.Next(0, randomProds.Length)], Item.rnd.Next(1, 120));
        }

        // виртуальный метод
        override public void Show()
        {
            Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nShelf life: {this.ShelfLife} days\n");
        }

        // невируальный метод
        public new void Print()
        {
            Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nShelf life: {this.ShelfLife} days\n");
        }

        public override object Clone()
        {
            return new Product(this.Price, this.Name, this.ShelfLife);
        }
    }
}
