using System;
using System.Collections.Generic;
using System.Text;

namespace Laba10
{
    public class Time : IInit
    {
        private int hours = 0;
        private int minutes = 0;
        public static int count { get; private set; } = 0;
        private static Random rnd = new Random();

        // конструктор
        public Time(int hours = 0, int minutes = 0)
        {
            if (hours < 0 || minutes < 0)
            {
                hours = 0;
                minutes = 0;
            }

            this.hours = hours + (minutes / 60);
            this.minutes = minutes % 60;
            count++;
        }

        public Object Init()
        {
            return new Time(Time.rnd.Next(0, 100), Time.rnd.Next(0, 60));
        }

        // свойства для hours
        public int Hours
        {
            get { return hours; }
            // Часы не прибавляются, а обновляются
            set { hours = value; }
        }

        // свойства для minutes
        public int Minutes
        {
            get
            {
                return minutes;
            }

            set
            {
                // Если minutes > 59, они конвертируются в часы
                // Минуты не прибавляются, а обновляются
                hours += value / 60;
                minutes = value % 60;
            }
        }//dsadsa

        public void Sub(Time smallTime)
        {
            // Метод вычитает из this smallTime
            // Если smallTime > bigTime, возвращается время 00:00
            if (this.hours * 60 + this.minutes > smallTime.hours * 60 + smallTime.minutes)
            {
                int ans = (this.hours * 60 + this.minutes - smallTime.hours * 60 - smallTime.minutes);
                this.hours = ans / 60;
                this.minutes = ans % 60;
            }
            else
            {
                this.hours = 0;
                this.minutes = 0;
            }
        }

        public static Time Subtraction(Time bigTime, Time smallTime)
        {
            // Метод вычитает из bigTime smallTime
            // Если smallTime > bigTime, возвращается время 00:00
            if (bigTime.hours * 60 + bigTime.minutes > smallTime.hours * 60 + smallTime.minutes)
            {
                int ans = (bigTime.hours * 60 + bigTime.minutes - smallTime.hours * 60 - smallTime.minutes);
                return new Time((ans / 60), (ans % 60));

            }

            return new Time(0, 0);
        }

        public void Show()
        {
            // Выводит время на экран в формате xx:xx
            Console.WriteLine((string)this + "\n");
        }

        public static Time operator ++(Time time)
        {
            // перегруженный инкремент (+1 минута)
            var newTime = new Time(time.hours + ((time.minutes + 1) / 60), (time.minutes + 1) % 60);

            return newTime;
        }

        public static Time operator --(Time time)
        {
            // перегруженный декремент (-1 минута)
            // возвращает 00:00, если исходное время 00:00
            var newTime = new Time();
            int temp;

            if (time.hours > 0 || time.minutes > 0)
            {
                temp = time.hours * 60 + time.minutes - 1;
                newTime.hours = temp / 60;
                newTime.minutes = temp % 60;
            }

            return newTime;
        }

        public static implicit operator int(Time time)
        {
            // неявное преобразование к типу int
            return time.hours * 60 + time.minutes;
        }

        public static explicit operator string(Time time)
        {
            string strTime = "";

            if (time.hours < 10)
                strTime += $"0{time.hours}:";
            else
                strTime += $"{time.hours}:";

            if (time.minutes < 10)
                strTime += $"0{time.minutes}";
            else
                strTime += $"{time.minutes}";

            return strTime;
        }

        public static explicit operator bool(Time time)
        {
            // явное преобразование к типу bool
            if (time.hours == 0 && time.minutes == 0)
                return false;

            return true;
        }

        public static bool operator <(Time t1, Time t2)
        {
            // оператор "меньше"
            if ((int)t1 < (int)t2)
                return true;

            return false;
        }

        public static bool operator >(Time t1, Time t2)
        {
            // оператор "больше"
            if ((int)t1 > (int)t2)
                return true;

            return false;
        }
    }
}
