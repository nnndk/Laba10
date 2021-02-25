using System;

namespace Laba10
{
    class Program
    {
        static int CheckInput(string options, string error, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int choice;
            bool isCorrect;
            Console.Write(options);

            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out choice);

                if (!isCorrect || choice < minValue || choice > maxValue)
                {
                    isCorrect = false;
                    Console.Write(error);
                }
            } while (!isCorrect);

            return choice;
        }

        static Item[] CreateItemArray()
        {
            // Item - 7, Toy - 5, Product - 5, MilkProduct - 7
            Item item1 = new Item(), item2 = new Item(266), item3 = new Item("Куртка"), item4 = new Item(3752, "Стул");
            Toy toy1 = new Toy(), toy2 = new Toy(537), toy3 = new Toy("Кукла"), toy4 = new Toy(350, "Робот"), toy5 = new Toy(680, "Робот", "Красный робот");
            Product prod1 = new Product(), prod2 = new Product(49), prod3 = new Product("Сок"), prod4 = new Product(129, "Печенье"), prod5 = new Product(249, "Помидоры", 30);
            MilkProduct milkProd1 = new MilkProduct(), milkProd2 = new MilkProduct(149), milkProd3 = new MilkProduct("Сыр"), milkProd4 = new MilkProduct(110, "Молоко"),
            milkProd5 = new MilkProduct(230, "Кефир", 60), milkProd6 = new MilkProduct(89, "Сметана", 90, false), milkProd7 = new MilkProduct(130, "Мороженое", 25, true);

            Item[] items = { item1, item2, item3, item4, toy1, toy2, toy3, toy4, toy5, prod1, prod2, prod3, prod4, prod5, milkProd1, milkProd2, milkProd3, milkProd4, milkProd5, milkProd6, milkProd7 };

            return items;
        }

        static void Main()
        {
            Console.Write("Лабораторная работа № 10. Вариант 7");
            bool isEnd = false;

            do
            {
                string mainMenu = "\n1. Часть 1\n2. Часть 2\n3. Часть 3\n0. Выход\nВыберите пункт меню: ";
                string inputError = "Ошибка! Введите номер пункта меню: ";
                string part1Menu, part2Menu, part3Menu, name;
                int part1Choice, part2Choice, part3Choice;
                bool part1IsEnd = false, part2IsEnd = false, part3End = false;
                int mainChoice = CheckInput(mainMenu, inputError, 0, 3);
                Item[] items = null;
                IInit[] itemsArray = null;

                switch (mainChoice)
                {
                    case 1:
                        // Часть 1
                        if (items == null)
                            items = CreateItemArray();

                        do
                        {
                            part1Menu = "\nЧасть 1\n1. Просмотр элементов массива (виртуальный метод)\n2. Просмотр элементов массива (невиртуальный метод)\n3. Количество экземпляров каждого из классов\n0. Выход\nВыберите пункт меню: ";
                            part1Choice = CheckInput(part1Menu, inputError, 0, 3);

                            switch (part1Choice)
                            {
                                case 1:
                                    // Вывод на экран всех элементов массива с помощью виртуального метода
                                    Part1Virtual(items);
                                    break;
                                case 2:
                                    // Вывод на экран всех элементов массива с помощью невиртуального метода
                                    Part1NotVirtual(items);
                                    break;
                                case 3:
                                    // Количество экземпляров классов
                                    Part1NumberOfItems();
                                    break;
                                case 0:
                                    // Выход
                                    part1IsEnd = true;
                                    break;
                            }
                        } while (!part1IsEnd);

                        break;
                    case 2:
                        // Часть 2
                        if (items == null)
                            items = CreateItemArray();

                        do
                        {
                            part2Menu = "\nЧасть 2\n1. Первый запрос\n2. Второй запрос\n3. Третий запрос\n4. Четвёртый запрос\n0. Выход\nВыберите пункт меню: ";
                            part2Choice = CheckInput(part2Menu, inputError, 0, 4);

                            switch (part2Choice)
                            {
                                case 1:
                                    // 1 запрос: самая дорогая и самая дешёвая игрушка в магазине (массиве)
                                    Part2FirstRequest(items);
                                    break;
                                case 2:
                                    // 2 запрос: наименование всех товаров в магазине (массиве)
                                    Part2SecondRequest(items);
                                    break;
                                case 3:
                                    // 3 запрос: количество товаров заданного наименования в магазине (массиве)
                                    Console.WriteLine("\nТретий запрос: найти количество товаров с заданным наименованием в магазине\nДля выхода вместо ввода наименования товара нажмите Enter");

                                    do
                                    {
                                        Console.Write("Введите наименование товара: ");
                                        name = Console.ReadLine();

                                        if (name == string.Empty)
                                            break;

                                        Part2ThirdRequest(items, name);
                                    } while (true);
                                    break;
                                case 4:
                                    // 4 запрос: суммарная стоимость товаров заданного наименования в магазине (массиве)
                                    Console.WriteLine("\nЧётвёртый запрос: найти суммарную стоимость товаров с заданным наименованием в магазине\nДля выхода вместо ввода наименования товара нажмите Enter");

                                    do
                                    {
                                        Console.Write("Введите наименование товара: ");
                                        name = Console.ReadLine();

                                        if (name == string.Empty)
                                            break;

                                        Part2FourthRequest(items, name);
                                    } while (true);
                                    break;
                                case 0:
                                    // Выход
                                    part2IsEnd = true;
                                    break;
                            }
                        } while (!part2IsEnd);

                        break;
                    case 3:
                        // 3 часть
                        do
                        {
                            part3Menu = "\nЧасть 3\n1. Создать и вывести на экран массив элементов типа IInit\n2. Создать массив только из тех элементов, которые относятся к иерархии классов\n" +
                                "3. Вывести массив из пункта 2 на экран\n4. Сортировать массив из пункта 2 по наименованию\n5. Сортировать массив из пункта 2 по цене и найти заданный элемент\n" +
                                "6. Поверхностное копирование объекта\n7. Клонирование объекта\n0. Выход\n";
                            part3Choice = CheckInput(part3Menu, inputError, 0, 7);

                            switch (part3Choice)
                            {
                                case 1:
                                    // Создание и вывод на экран массива типа IInit
                                    Part3Task1();
                                    break;
                                case 2:
                                    // Создание массива только из элементов, относящихся к иерархии классов
                                    Part3Task2(ref itemsArray);
                                    break;
                                case 3:
                                    // Вывод на экран массива из пункта 2
                                    if (itemsArray == null)
                                        Part3Task2(ref itemsArray);

                                    Part3Task2PrintArray(itemsArray);
                                    break;
                                case 4:
                                    // Сортировка массива из пункта 2 по цене
                                    if (itemsArray == null)
                                        Part3Task2(ref itemsArray);

                                    Array.Sort(itemsArray);
                                    Console.WriteLine("Сортировка по цене\n\n");
                                    Part3Task2PrintArray(itemsArray);
                                    break;
                                case 5:
                                    // Сортировка массива из пункта 2 по наименованию и найти заданный элемент
                                    if (itemsArray == null)
                                        Part3Task2(ref itemsArray);

                                    Array.Sort(itemsArray, new SortByPrice());
                                    Console.WriteLine("Сортировка по наименованию\n\n");
                                    Part3Task2PrintArray(itemsArray);
                                    int index = FindElement(itemsArray) + 1;

                                    if (index > 0)
                                        Console.WriteLine($"Искомый элемент имеет индекс {index}");
                                    else
                                        Console.WriteLine("Искомого элемента нет в списке");
                                    break;
                                case 6:
                                    // Поверхностное копирование объекта
                                    Console.WriteLine("Поверхностное копирование");
                                    Item temp = new Item(279, "Шапка", 111);
                                    Item copyTemp = (Item)temp.ShalowCopy();

                                    Console.WriteLine("Первый объект (temp.Init())");
                                    temp.Show();
                                    Console.WriteLine($"Id: {temp.id.number}\n\n");

                                    Console.WriteLine("Второй объект (Item copyTemp = temp)");
                                    copyTemp.Show();
                                    Console.WriteLine($"Id: {copyTemp.id.number}\n\n");

                                    copyTemp.Name = "copy" + copyTemp.Name;
                                    copyTemp.id.number = 239;

                                    Console.WriteLine("Меняем значение первого объекта (temp)");
                                    temp.Show();
                                    Console.WriteLine($"Id: {temp.id.number}\n\n");
                                    Console.WriteLine("Второй объект (copyTemp)");
                                    copyTemp.Show();
                                    Console.WriteLine($"Id: {copyTemp.id.number}\n\n");
                                    break;
                                case 7:
                                    // Клонирование объекта
                                    Console.WriteLine("Клонирование");
                                    Item temp1 = new Item(279, "Шапка", 111);
                                    Item cloneTemp1 = (Item)temp1.Clone();

                                    Console.WriteLine("Первый объект (temp.Init())");
                                    temp1.Show();
                                    Console.WriteLine($"Id: {temp1.id.number}\n\n");

                                    Console.WriteLine("Второй объект (Item copyTemp = temp)");
                                    cloneTemp1.Show();
                                    Console.WriteLine($"Id: {cloneTemp1.id.number}\n\n");

                                    cloneTemp1.Name = "copy" + cloneTemp1.Name;
                                    cloneTemp1.id.number = 239;

                                    Console.WriteLine("Меняем значение первого объекта (temp)");
                                    temp1.Show();
                                    Console.WriteLine($"Id: {temp1.id.number}\n\n");
                                    Console.WriteLine("Второй объект (copyTemp)");
                                    cloneTemp1.Show();
                                    Console.WriteLine($"Id: {cloneTemp1.id.number}\n\n");
                                    cloneTemp1.Show();
                                    break;
                                case 0:
                                    // Выход
                                    part3End = true;
                                    break;
                            }
                        } while (!part3End);
                        break;
                    case 0:
                        // Выход
                        isEnd = true;
                        break;
                }
            } while (!isEnd);
        }

        static void Part1Virtual(Item[] items)
        {
            // Вывод на экран всех элементов массива с помощью виртуального метода
            Console.WriteLine("Виртуальный метод:\n");
            foreach (Item item in items)
                item.Show();
        }

        static void Part1NotVirtual(Item[] items)
        {
            // Вывод на экран всех элементов массива с помощью невиртуального метода
            Console.WriteLine("Невиртуальный метод:\n");
            foreach (Item item in items)
                item.Print();
        }

        static void Part1NumberOfItems()
        {
            // Количество экземпляров классов
            Console.WriteLine($"\nВсего товаров: {Item.count}\nКоличество игрушек: {Toy.count}\nКоличество продуктов: {Product.count}\nКоличество молочных продуктов: {MilkProduct.count}");
        }

        static void Part2FirstRequest(Item[] items)
        {
            // Самая дорогая и самая дешёвая игрушка в магазине
            Console.WriteLine("\nПервый запрос: найти самую дорогую и самую дешёвую игрушку в магазине");
            Toy mostExpensiveToy = Toy.GetMostExpensiveToy(items);
            Toy cheapestToy = Toy.GetCheapestToy(items);

            if (mostExpensiveToy == null)
                Console.WriteLine("В магазине нет игрушек!");
            else
            {
                Console.WriteLine("Самая дорогая игрушка в магазине:");
                //mostExpensiveToy.Show(); //полная информация
                (mostExpensiveToy as Item).Print(); // только наименование и цена
                Console.WriteLine("Самая дешёвая игрушка в магазине:");
                //cheapestToy.Show(); // полная информация
                (cheapestToy as Item).Print(); // только наименование и цена
            }
        }

        static void Part2SecondRequest(Item[] items)
        {
            // Наименование всех товаров в магазине (массиве)
            Console.WriteLine("\nВторой запрос: вывести наименование всех товаров в магазине");
            string[] names = Item.GetAllUniqueNames(items); // только уникальные имена
            //string[] names = Item.GetAllNames(items); // все имена
            int i = 0;

            foreach (string name in names)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
                i++;
            }
        }

        static void Part2ThirdRequest(Item[] items, string name)
        {
            // Количество товаров заданного наименования в магазине (массиве)
            int count = Item.CountItems(items, name);

            if (count > 0)
                Console.WriteLine($"Количество товаров с наименованием \"{name}\": {count}");
            else 
                Console.WriteLine($"В магазине нет товаров с наименованием \"{name}\"");
        }

        static void Part2FourthRequest(Item[] items, string name)
        {
            // 4 запрос: суммарная стоимость товаров заданного наименования в магазине (массиве)
            int totalCost = Item.GetTotalCost(items, name);

            if (totalCost > -1)
                Console.WriteLine($"Суммарная стоимость товаров с наименованием {name}: {totalCost}");
            else
                Console.WriteLine($"В магазине нет товаров с наименованием \"{name}\"");
        }

        static void Part3Task1()
        {
            string part3Task1Menu = "Введите длину массива: ";
            string numberInputError = "Ошибка! Введите натуральное число: ";
            int len = CheckInput(part3Task1Menu, numberInputError, 1);
            IInit[] arr = new IInit[len];

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 5 == 0)
                {
                    Time time = new Time();
                    time = (Time)time.Init();
                    arr[i] = time;
                }
                else if (i % 5 == 1)
                {
                    Item item = new Item();
                    item = (Item)item.Init();
                    arr[i] = item;
                }
                else if (i % 5 == 2)
                {
                    Toy toy = new Toy();
                    toy = (Toy)toy.Init();
                    arr[i] = toy;
                }
                else if (i % 5 == 3)
                {
                    Product prod = new Product();
                    prod = (Product)prod.Init();
                    arr[i] = prod;
                }
                else 
                {
                    MilkProduct milkProd = new MilkProduct();
                    milkProd = (MilkProduct)milkProd.Init();
                    arr[i] = milkProd;
                }
            }

            foreach (var item in arr)
                item.Show();
        }

        static void Part3Task2(ref IInit[] arr)
        {
            string part3Task2Menu = "Введите длину массива: ";
            string numberInputError = "Ошибка! Введите натуральное число: ";
            int lenItemArray = CheckInput(part3Task2Menu, numberInputError, 1);
            arr = Part3Task2InitArray(lenItemArray);
        }

        static IInit[] Part3Task2InitArray(int len)
        {
            IInit[] arr = new IInit[len];

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 4 == 0)
                {
                    Item item = new Item();
                    item = (Item)item.Init();
                    arr[i] = item;
                }
                else if (i % 4 == 1)
                {
                    Toy toy = new Toy();
                    toy = (Toy)toy.Init();
                    arr[i] = toy;
                }
                else if (i % 4 == 2)
                {
                    Product prod = new Product();
                    prod = (Product)prod.Init();
                    arr[i] = prod;
                }
                else
                {
                    MilkProduct milkProd = new MilkProduct();
                    milkProd = (MilkProduct)milkProd.Init();
                    arr[i] = milkProd;
                }
            }

            return arr;
        }

        static void Part3Task2PrintArray(IInit[] arr)
        {
            foreach(var item in arr)
                item.Show();
        }

        static string InputType()
        {
            Console.Write("Введите тип искомого объекта (Item, Toy, Product или MilkProduct): ");
            string[] types = { "item", "toy", "product", "milkproduct" };
            string str;
            bool isType = false;

            do
            {
                str = Console.ReadLine().ToLower().Trim();

                if (str == types[0] || str == types[1] || str == types[2] || str == types[3])
                    isType = true;
                else
                    Console.Write("Ошибка! Введите корректный тип искомого объекта: ");
            } while (!isType);

            return str;
        }

        static string InputName(string type)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine().Trim();

            if (name == string.Empty)
                name = "NoName" + type;

            return name;
        }

        static string InputDescription()
        {
            Console.Write("Введите описание игрушки: ");
            string description = Console.ReadLine().Trim();

            if (description == string.Empty)
                description = "No description";

            return description;
        }

        static bool InputStatus()
        {
            Console.WriteLine("Молочный продукт свежий? (Да или Нет)");
            bool status;
            string str;

            do
            {
                Console.Write("Ответ: ");
                str = Console.ReadLine().ToLower().Trim();

                if (str == "да")
                {
                    status = true;
                    break;
                }
                else if (str == "нет")
                {
                    status = false;
                    break;
                }
                else
                    Console.WriteLine("Некорректное значение!");
            } while (true);

            return status;
        }

        static object InputElement(string type)
        {
            string inputPrice = "Введите цену товара: ", inputShelfLife = "Введите срок годности товара: ", error = "Введите натуральное число: ";

            if (type == "item")
                return new Item(CheckInput(inputPrice, error, 1), InputName(type));
            else if (type == "toy")
                return new Toy(CheckInput(inputPrice, error, 1), InputName(type), InputDescription());
            else if (type == "product")
                return new Product(CheckInput(inputPrice, error, 1), InputName(type), CheckInput(inputShelfLife, error, 1));
            else
                return new MilkProduct(CheckInput(inputPrice, error, 1), InputName(type), CheckInput(inputShelfLife, error, 1), InputStatus());
        }

        static int FindElement(IInit[] arr)
        {
            string type = InputType();

            if (type == "item")
            {
                Item element = (Item)InputElement(type);
                int answer = Array.BinarySearch(arr, element, new SortByPrice());
                Console.WriteLine("\n\nИскомый элемент");
                element.Show();

                if (answer >= 0 && answer < arr.Length)
                    return answer;

                return -1;
            }
            else if (type == "toy")
            {
                Toy element = (Toy)InputElement(type);
                int answer = Array.BinarySearch(arr, element, new SortByPrice());
                Console.WriteLine("\n\nИскомый элемент");
                element.Show();

                if (answer >= 0 && answer < arr.Length)
                    return answer;

                return -1;
            }
            else if (type == "product")
            {
                Product element = (Product)InputElement(type);
                int answer = Array.BinarySearch(arr, element, new SortByPrice());
                Console.WriteLine("\n\nИскомый элемент");
                element.Show();

                if (answer >= 0 && answer < arr.Length)
                    return answer;

                return -1;
            }
            else
            {
                MilkProduct element = (MilkProduct)InputElement(type);
                int answer = Array.BinarySearch(arr, element, new SortByPrice());
                Console.WriteLine("\n\nИскомый элемент");
                element.Show();

                if (answer >= 0 && answer < arr.Length)
                    return answer;

                return -1;
            }
        }
    }
}
