using System;

namespace SapeginaKatya
{
    class Program
    {
        static void Main(string[] args)
        {
            //ВАРИАНТ 5

            //ЗАДАНИЕ 1 
            string s1 = "Hello, it's Kate! And i love 123 number!";
            string s2 = "123";
            bool b = s1.Contains(s2);
            Console.WriteLine("'{0}' is in the string '{1}': {2}", s2, s1, b); //если true - есть совпадение с 123, если false - нет 123
            var array = new double[3, 4];

            var rnd = new Random();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    array[i, j] = Math.Round(rnd.NextDouble() * 100, 2);
                }
            }

            // print array of doubles
            Console.WriteLine("Array of doubles:");
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            var data = new Date(25, 10, 2021);
            Console.WriteLine(data.ToString());
            Console.WriteLine(data % 1);
            Console.WriteLine(data % 2);
            //Console.WriteLine(data % 100);

            var belDate = new BelDate(25, 10, 2021, "Cool");
            (belDate as IGood).Plus();
            (belDate as IBad).Plus();
        }
        //ЗАДАНИЕ 2 
        public class Date
        {
            public int Day { get; set; }
            public int Month { get; set; }
            public readonly int Year;

            public Date(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                Date date = obj as Date;
                if (date == null)
                {
                    return false;
                }

                return (date.Day == Day) && (date.Month == Month) && (date.Year == Year);
            }

            public static bool operator ==(Date date1, Date date2)
            {
                return date1.Equals(date2);
            }

            public static bool operator !=(Date date1, Date date2)
            {
                return !date1.Equals(date2);
            }

            public static Date operator %(Date date, int index)
            {
                switch (index)
                {
                    case 1:
                        return new Date(date.Day, 0, 0);
                    case 2:
                        return new Date(0, date.Month, 0);
                    default:
                        throw new Exception("Error index!");
                }
            }

            public override string ToString()
            {
                return $"{Day:D2}.{Month:D2}.{Year:D4}";
            }
        }
        public class BelDate : Date, IGood, IBad
        {
            public string Status { get; set; }

            public BelDate(int day, int month, int year, string status) : base(day, month, year)
            {
                Status = status;
            }

            void IGood.Plus() => Console.WriteLine("Good");

            void IBad.Plus() => Console.WriteLine("Bad");
        }

        interface IGood
        {
            void Plus();
        }

        interface IBad
        {
            void Plus();
        }
    }

}
