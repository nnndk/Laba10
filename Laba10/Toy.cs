using System;
using System.Collections.Generic;
using System.Text;

namespace Laba10
{
    public class Toy : Item, IInit, IComparable, ICloneable
    {
        // описание игрушки
        private string toyDescription = "No description";

        public string ToyDescription
        {
            get { return toyDescription; }
            set 
            {
                if (value != string.Empty)
                    toyDescription = value;
                else 
                    toyDescription = "No description";
            }
        }

        // количество экземпляров класса Toy
        public static new int count { get; private set; } = 0;
        private static readonly string[] randomToys = { "Робот", "Кукла", "Мяч", "Шарик", "Машина", "Самолёт" };
        private static readonly string[] randomColorM = { "Красный", "Жёлтый", "Синий", "Зелёный", "Чёрный", "Оранжевый", "Голубой", "Фиолетовый", "Белый" };
        private static readonly string[] randomColorF = { "Красная", "Жёлтая", "Синяя", "Зелёная", "Чёрная", "Оранжевая", "Голубая", "Фиолетовая", "Белая" };

        // пустой конструктор
        public Toy() : base()
        {
            this.Name = "NoNameToy";
            count++;
        }

        // price, price name, price name description
        public Toy(int price, string name = "NoNameToy", string description = "No description") : base(price, name)
        {
            this.ToyDescription = description;
            count++;
        }

        // name
        public Toy(string name) : base(name)
        {
            count++;
        }

        // метод интерфейса IInit, формирующий элементы класса с помощью ДСЧ
        override public object Init()
        {
            Toy toy = new Toy();
            toy.Price = Item.rnd.Next(1, 10000);
            toy.Name = randomToys[Item.rnd.Next(0, randomToys.Length)];
            count++;

            // случайное описание (красная машина, зелёный шарик)
            if (toy.Name == "Кукла" || toy.Name == "Машина")
                toy.ToyDescription = randomColorF[Item.rnd.Next(0, randomColorF.Length)] + " " + toy.Name.ToLower();
            else
                toy.ToyDescription = randomColorM[Item.rnd.Next(0, randomColorM.Length)] + " " + toy.Name.ToLower();

            return toy;
        }

        // виртуальный метод
        override public void Show()
        {
            Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nDescription: {this.ToyDescription}\n");
        }

        // невиртуальный метод
        public new void Print()
        {
            Console.WriteLine($"Price: {this.Price} rub\nName: {this.Name}\nDescription: {this.ToyDescription}\n");
        }

        // запрос на получение информации о самой дорогой игрушке в массиве
        public static Toy GetMostExpensiveToy(Item[] items)
        {
            int maxPrice = -1;
            var mostExpensiveToy = new Toy();

            foreach (Item item in items)
            {
                Toy toy = item as Toy;

                // первая самая дорогая игрушка в массиве
                if (toy != null)
                {
                    if (toy.Price > maxPrice)
                    {
                        mostExpensiveToy = toy;
                        maxPrice = toy.Price;
                    }
                }
            }

            // если в массиве нет игрушек, возвращается null
            if (maxPrice < 0) return null;

            return mostExpensiveToy;
        }

        // запрос на получение информации о самой дешёвой игрушке в массиве
        public static Toy GetCheapestToy(Item[] items)
        {
            int minPrice = -1;
            var cheapestToy = new Toy();

            foreach (Item item in items)
            {
                Toy toy = item as Toy;

                // первая самая дешёвая игрушка в массиве
                if (toy != null)
                {
                    if (toy.Price < minPrice || minPrice < 0)
                    {
                        cheapestToy = toy;
                        minPrice = toy.Price;
                    }
                }
            }

            // если в массиве нет игрушек, возвращается null
            if (minPrice < 0) return null;

            return cheapestToy;
        }

        public override object Clone()
        {
            return new Toy(this.Price, this.Name, this.ToyDescription);
        }
    }
}
