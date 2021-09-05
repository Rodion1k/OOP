using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LP_lab02
{
    internal class Program
    {
        private static bool boolVariable = true;
        private static char charVariable = 'A';
        private static byte byteVariable = 2; // 0 255
        private static sbyte @sbyteVariable = 127; // -128 127
        private static short shortVariable = 32767;
        private static ushort @ushortVariable = 65535;
        private static int intVariable = -5;
        private static int uintVariable = 2225;
        private static long longVariable = -9223372036854775807;
        private static long ulongVariable = 9223372036854775807;
        private static decimal @decimalVariable = 23.324m;
        private static float floatVariable = 53.234234f;
        private static double doubleVariable = 23.345346547;
        private static string stringVariable = "hello world";

        struct Car
        {
            public int wheels;
            public int passengers;
            public string mark;

            public Car(int wheels, int passengers, string mark)
            {
                this.passengers = passengers;
                this.wheels = wheels;
                this.mark = mark;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("**********************ТИПЫ***********************");
            ConsoleWriteVariables();
            ConsoleReadVariable();
            ImplicitConversion();
            ExplicitConversion();
            ConversionWithClassConvert();
            PackagingAndUnpackingOfTypes();
            ImplicitlyTypedVariables();
            NullableStruct();
            RedefinitionVarVariable();
            Console.WriteLine("**********************СТРОКИ***********************");
            StringComparison();
            DifferentOperationsWithStrings();
            Console.WriteLine("**********************МАССИВЫ***********************");
            CreateArrays();
            Console.WriteLine("**********************КОРТЕЖЫ***********************");
            UsingCortege();
            CheckedAndUnchecked();
            UsingCortageFunction();
            Console.WriteLine("**********************КОНЕЦ ЛАБЫ***********************");
        }

        /////////////типы///////////////////
        private static void ConsoleReadVariable()
        {
            Console.WriteLine("введите число ");
            var strVariable = Console.ReadLine();
            float variable;
            if (float.TryParse(strVariable, out variable)) Console.WriteLine("Вы ввели число {0}", variable);
            else
            {
                Console.WriteLine("неверный ввод числа");
                ConsoleReadVariable();
            }
        }

        private static void ExplicitConversion()
        {
            // явное преобразование типов. Оператор, который делает это называется cast
            short implByte = (short)intVariable;
            byte implshort = (byte)shortVariable;
            int implShort = (int)floatVariable;
            byte implInt = (byte)intVariable;
            long implint = (long)floatVariable;
        }

        private static void ImplicitConversion()
        {
            // неявное преобразование типов
            short implByte = byteVariable;
            int implshort = shortVariable;
            float implShort = shortVariable;
            float implInt = intVariable;
            long implint = intVariable;
        }

        private static void ConversionWithClassConvert()
        {
            // преобразование типов классом Convert
            string implByte = Convert.ToString(byteVariable);
            int impldouble = Convert.ToInt32(doubleVariable);
            string s = Convert.ToString(31, 2); // преобразование числа в другую систему счисления 
            Console.WriteLine("31 в двоичной: " + s);
        }

        private static void PackagingAndUnpackingOfTypes()
        {
            int i = 2;
            object o = i; // пакуем 
            i = (int)o; // распаковка 
        }

        private static void ImplicitlyTypedVariables()
        {
            var kek = 34;
            var str = "sgds";
            var list = new List<int>();
            foreach (var exemplar in list)
            {
                // делаем что нужно 
            }
        }

        private static void NullableStruct()
        {
            Car defaultCar = new Car(4, 4, "defaultCar");
            Car? BMW = new Car(4, 2, "bmw");
            Car? zhiga = null;
            List<Car?> cars = new List<Car?>();
            cars.Add(BMW);
            cars.Add(zhiga);
            foreach (var car in cars)
            {
                if (car.HasValue) // если не null 
                {
                    Console.WriteLine("машина инициализирована " + car.Value.mark);
                }
                else
                {
                    Console.WriteLine(car.GetValueOrDefault(defaultCar).mark);

                }
            }

        }

        private static void RedefinitionVarVariable()
        {
            try
            {
                // var kek = 5;
                //  kek = 24.45f;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private static void ConsoleWriteVariables()
        {
            Console.WriteLine("boolVariable: " + boolVariable);
            Console.WriteLine("charVariable: " + charVariable);
            Console.WriteLine("byteVariable: " + byteVariable);
            Console.WriteLine("sbyteVariable: " + sbyteVariable);
            Console.WriteLine("shortVariable: " + shortVariable);
            Console.WriteLine("ushortVariable: " + ushortVariable);
            Console.WriteLine("intVariable: " + intVariable);
            Console.WriteLine("uintVariable: " + uintVariable);
            Console.WriteLine("longVariable: " + longVariable);
            Console.WriteLine("ulongVariable: " + ulongVariable);
            Console.WriteLine("decimalVariable: " + decimalVariable);
            Console.WriteLine("floatVariable: " + floatVariable);
            Console.WriteLine("doubleVariable: " + doubleVariable);
            Console.WriteLine("strintVariable: " + stringVariable);
        }

        /////////////строки///////////////////
        private static void StringComparison()
        {
            string firstStr = "abb", therdStr = "bfg";
            var index = String.Compare(firstStr, therdStr);
            if (index < 0)
            {
                Console.WriteLine("первая предшествует второй");
            }
            else if (index > 0)
            {
                Console.WriteLine("вторая предшествует первой");
            }
            else
            {
                Console.WriteLine("равны");
            }

        }

        private static void DifferentOperationsWithStrings()
        {
            string string1 = "hello";
            string string2 = "hello world";
            string string3 = new string('0', 3);
            Console.WriteLine("соединение: " + String.Concat(string1, string3));
            Console.WriteLine("копия: " + String.Copy(string2));
            var string4 = string2.Substring(6);
            Console.WriteLine("подстрока: " + string4);
            Console.WriteLine("вставить построки: " + string2.Insert(6, string3));
            Console.WriteLine("удаление подстроку: " + string2.Replace(string1, ""));
            string[] subs = string2.Split(' ');
            foreach (var sub in subs)
            {
                Console.WriteLine(sub);

            }

            int a = 5, b = 6;
            Console.WriteLine($"Area of the right triangle with legs of {a} and {b} is {0.5 * a * b}");
            string1 = null;
            string2 = "";
            Console.WriteLine(string.IsNullOrEmpty(string1));
            Console.WriteLine(string.IsNullOrEmpty(string2));
            StringBuilder stringBuilder = new StringBuilder("kek");
            stringBuilder.Append("lol");
            stringBuilder.AppendFormat("GHI{0}{1}", 'J', 'k'); // хз что делает 
            stringBuilder.Insert(0, "allal");
            stringBuilder.Replace('a', 'A');
            Console.WriteLine(stringBuilder);
            stringBuilder.Remove(2, 5);
            Console.WriteLine(stringBuilder);
        }

        ////массивы//////
        private static void CreateArrays()
        {
            Console.WriteLine("целочисленная матрица:\n ");
            int[,] arr = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }

                Console.WriteLine();
            }

            string[] towns = new[] { "Minsk", "Bobruisk", "Gomel" };
            foreach (var town in towns)
            {
                Console.WriteLine(town + "\t");
            }


            int index = ChangeIndex(towns);

            ChangeValues(towns, index);
            Console.Write("Новый список городов: \n");
            foreach (var town in towns)
            {
                Console.WriteLine(town + "\t");
            }

            Random rnRandom = new Random();
            int[][] stepwiseArray = new int[3][];
            stepwiseArray[0] = new int[2];
            stepwiseArray[1] = new int[3];
            stepwiseArray[2] = new int[4];

            Console.WriteLine("\nСтупенчатый массив: ");
            for (int i = 0; i < stepwiseArray.Length; i++)
            {
                for (int j = 0; j < stepwiseArray[i].Length; j++)
                {
                    stepwiseArray[i][j] = rnRandom.Next(0, 10);
                    Console.Write(stepwiseArray[i][j] + "\t");
                }

                Console.WriteLine();
            }

            var kek = new int[] { 2, 3, 4 };
            var lol = "sgdsgsg";

        }

        private static int ChangeIndex(string[] towns)
        {
            int Index;
            Console.Write("\nВведите позицию: ");
            boolVariable = false;
            do
            {
                if (boolVariable)
                    Console.WriteLine("Неверный индекс!" + "Повторите попытку ");
                Index = Convert.ToInt32(Console.ReadLine());
                boolVariable = true;

            } while (Index - 1 > towns.Length || Index < 0);

            return Index;
        }

        private static void ChangeValues(string[] towns, int index)
        {
            boolVariable = false;
            Console.Write("Введите значение: ");
            string Change;
            do
            {
                Change = Console.ReadLine();
                if (boolVariable)
                    Console.WriteLine("Неверное значение!" + "Повторите попытку ");
                boolVariable = true;

            } while (String.IsNullOrWhiteSpace(Change));

            towns[index - 1] = Change;
        }

////////Кортежи//////////////
        private static void UsingCortege()
        {

            (string company, string country, string city, int year, int staff) Cortege = ("P&V", "Belarus", "Minsk",
                2021, 3);
            Console.WriteLine("\n********Информация о компании********");
            Console.WriteLine("Название компании:         " + Cortege.company);
            Console.WriteLine("Страна:             " + Cortege.country);
            Console.WriteLine("Город:             " + Cortege.city);
            Console.WriteLine("Год:         " + Cortege.year);
            Console.WriteLine("кол-во сотрудников:    " + Cortege.staff);
            Console.WriteLine("\nЧастичный вывод\n" + Cortege.company + " " + Cortege.country + " " + Cortege.year);
            var first = (a: 10, b: "A");
            var second = (a: 10, b: "B");
            if (first == second)
            {
                Console.WriteLine("\nКортежи равны!");
            }
            else
            {
                Console.WriteLine("\nКортежи не равны!");
            }


        }

        private static void UsingCortageFunction()
        {
            Tuple<int, int, int, char> CortageFunc(int[] num, string str)
            {
                return Tuple.Create(num.Max(), num.Min(), num.Sum(), str[0]);
            }

            int[] Array = { 3, 18, 36 };
            string Str = "kelol";
            Tuple<int, int, int, char> tuple1 = CortageFunc(Array, Str);
            Console.WriteLine("\nКортёж: " + tuple1);
        }

        private static void CheckedAndUnchecked()
        {
            void FirstFoo()
            {
                try
                {
                    checked
                    {
                        int x = int.MaxValue;
                        x++;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Произошло переполнение!");
                }
            }

            void SecondFoo()
            {
                try
                {
                    unchecked // Не вызывает OverflowException
                    {
                        int x = int.MaxValue;
                        x++;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Произошло переполнение!");
                }
            }

            FirstFoo();
            SecondFoo();

        }

    }
}