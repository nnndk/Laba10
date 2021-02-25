using System;
using System.Collections.Generic;
using System.Text;

namespace Laba10
{
    public class MilkProduct : Product, IInit, IComparable, ICloneable
    {
        // статус молочного продукта: свежий или нет
        public bool isFresh { get; set; } = true;

        // количество экземпляров класса MilkProduct
        public static new int count { get; private set; } = 0;
        private static readonly string[] randomMilkProds = { "Сыр", "Кефир", "Мороженое", "Молоко", "Сметана" };

        // пустой конструктор
        public MilkProduct() : base()
        {
            this.Name = "NoNameMilkProduct";
            count++;
        }

        // price, price name, price name sheflLife, price name shelfLife isFresh
        public MilkProduct(int price, string name = "NoNameMilkProduct", int shelfLife = 0, bool isFresh = true) : base(price, name, shelfLife)
        {
            this.isFresh = isFresh;
            count++;
        }

        // name
        public MilkProduct(string name) : base(name)
        {
            count++;
        }

        // метод интерфейса IInit, формирующий элементы класса с помощью ДСЧ
        public override object Init()
        {
            count++;
            return new MilkProduct(Item.rnd.Next(1, 10000), randomMilkProds[Item.rnd.Next(0, randomMilkProds.Length)], Item.rnd.Next(1, 120), Item.rnd.Next(0, 2) > 0);
        }

        // виртуальный метод
        override public void Show()
        {
            if (this.isFresh)
                Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nShelf life: {this.ShelfLife} days\nСвежее: Да\n");
            else
                Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nShelf life: {this.ShelfLife} days\nСвежее: Нет\n");
        }

        // невиртуальный метод
        public new void Print()
        {
            if (this.isFresh)
                Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nShelf life: {this.ShelfLife} days\nСвежее: Да\n");
            else
                Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nShelf life: {this.ShelfLife} days\nСвежее: Нет\n");
        }

        public override object Clone()
        {
            return new MilkProduct(this.Price, this.Name, this.ShelfLife, this.isFresh);
        }
    }
}
