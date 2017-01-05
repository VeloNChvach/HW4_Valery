using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Valery
{
    class Task_1
    // Массив из рандомных чисел (-10000 до 10000)
    //из них найти числа что делятся на 3 и их количество
    {
        int[] array;
        Random rnd = new Random();

        public Task_1()
        {
            array = new int[20];
            for (int i = 0; i < 20; i++)
                array[i] = rnd.Next(-10000, 10001);
        }

        public void Disp()
        {
            Console.WriteLine("Так выглядит начальный массив:");
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]}; ");
            Console.WriteLine();
        }

        public void Find_dev_3()
        {
            Console.WriteLine("Числа делимые нацело на 3: ");
            int n_dev_3 = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 3 == 0)
                {
                    Console.Write($"{array[i]}, ");
                    n_dev_3++;
                }
            Console.WriteLine("\nОбщее количество чисел нацело делимых на 3: {0}", n_dev_3);
        }
    }

    class Task_2
    //а)Дописать класс для работы с одномерным массивом.Реализовать конструктор, 
    // создающий массив заданной размерности и заполняющий массив числами от начального
    // значения с заданным шагом.Создать свойство Sum, которые возвращают сумму элементов 
    // массива, метод Inverse, меняющий знаки у всех элементов массива,  Метод Multi, 
    // умножающий каждый элемент массива на определенное число, свойство MaxCount, 
    // возвращающее количество максимальных элементов.
    //б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    {
        int[] array;

        public Task_2()
        {
            Console.WriteLine("Вы создали экземпляр, теперь у вас есть возможность импортировать данные");
        }

        public Task_2(int n, int start, int step)
        {
            array = new int[n];
            for (int i = 0; i < array.Length; i++)
                if (i == 0) array[i] = start;
                else array[i] = start + step * i;
        }

        public void Disp()
        {
            Console.WriteLine("Так выглядит массив:");
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]}; ");
        }

        public void Sum()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            Console.WriteLine($"\nСумма всех элементов массива: {sum}");
        }

        public void Inverse()
        {
            for (int i = 0; i < array.Length; i++)
                array[i] *= -1;
            Console.WriteLine("Инверсия чисел массива!");
        }

        public void Multi(int m)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] *= m;
            Console.WriteLine($"\nЭлементы массива были умножены на {m}");
        }

        public void Max()
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > max) max = array[i];
            Console.WriteLine($"\nМаксимальное число из массива: {max}");
        }

        public void Export(string fname)
        {
            string path = Directory.GetCurrentDirectory();
            StreamWriter str = new StreamWriter(fname);
            for (int i = 0; i < array.Length; i++)
                str.WriteLine(array[i]);
            str.Close();
            Console.WriteLine($"\nМассив записан в файл {fname}");
            Console.WriteLine($"Путь к файлу {path}");
        }

        public void Import(string fname)
        {
            if (File.Exists(fname))
            {
                StreamReader str = new StreamReader(fname);
                int count = File.ReadAllLines(fname).Length;
                array = new int[count];
                for (int i = 0; i < count; i++)
                    array[i] = int.Parse(str.ReadLine());
                str.Close();
                Console.WriteLine($"Данные с файла {fname} импортированы");
            }
        }
    }

    class Task_3
    //Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив
    {
        string login, password, log_enter, pass_enter;
        string fname = "log_pass.txt";
        bool y_n;

        public Task_3()
        {
            import();
            y_n = ver_with_repeat();
            true_or_false();
        }

        void true_or_false()
        {
            if (y_n)
                Console.WriteLine("Приветствуем!");
            else Console.WriteLine("Исчерпаны все попытки");
        }

        bool ver_with_repeat()
        {
            int i = 0;

            do
            {
                log_enter = login_e();
                pass_enter = pass_e();
                if (verification())
                    return true;
                i++;
            }
            while (i < 3);
            return false;
        }

        bool verification()
        {
            if (log_enter == login && pass_enter == password) return true;
            else return false;
        }

        void import()
        {
            StreamReader str = new StreamReader(fname);
            login = str.ReadLine();
            password = str.ReadLine();
        }

        string login_e()
        {
            Console.Write("Enter login: ");
            return Console.ReadLine();
        }

        string pass_e()
        {
            Console.Write("Enter password: ");
            return Console.ReadLine();
        }
    }

    class Task_4
    //* а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор, заполняющий массив 
    //    случайными числами.Создать методы, которые возвращают сумму всех элементов массива, сумму всех 
    //    элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, 
    //    возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива
    //    (через параметры, используя модификатор ref или out) ** 
    //б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    {
        int[,] array;
        int s_n, s_k;
        Random rnd = new Random();

        public Task_4(int n, int k)
        {
            s_n = n;
            s_k = k;
            array = new int[s_n, s_k];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    array[i, j] = rnd.Next(100);
        }

        public void Sum()
        {
            int sum = 0;

            for (int i = 0; i < s_n; i++)
                for (int j = 0; j < s_k; j++)
                    sum += array[i, j];
            Console.WriteLine($"Сумма всех значений равна {sum}");
        }

        public void Sum(int m)
        {
            int sum = 0;

            for (int i = 0; i < s_n; i++)
                for (int j = 0; j < s_k; j++)
                    if (array[i, j] > m)
                        sum += array[i, j];
            Console.WriteLine($"Сумма всех значений больше {m} равна {sum}");
        }

        public void Max()
        {
            int max = array[0, 0];
            int ii = 0, jj = 0;

            for (int i = 0; i < s_n; i++)
                for (int j = 0; j < s_k; j++)
                    if (array[i, j] > max)
                        max = array[i, j];

            for (int i = 0; i < s_n; i++)
                for (int j = 0; j < s_k; j++)
                    if (array[i, j] == max)
                    {ii = i; jj = j;}
            Console.WriteLine($"Максимальное значение в массиве {max}, его положение ({ii}, {jj})");
        }

        public void Min()
        {
            int min = array[0, 0];
            int ii = 0, jj = 0;

            for (int i = 0; i < s_n; i++)
                for (int j = 0; j < s_k; j++)
                    if (array[i, j] < min)
                        min = array[i, j];

            for (int i = 0; i < s_n; i++)
                for (int j = 0; j < s_k; j++)
                    if (array[i, j] == min)
                    { ii = i; jj = j; }
            Console.WriteLine($"Максимальное значение в массиве {min}, его положение ({ii}, {jj})");
        }

        public void Export(string fname)
        {
            StreamWriter str = new StreamWriter(fname);

            for (int i = 0; i < s_n; i++)
            {
                for (int j = 0; j < s_k; j++)
                    str.Write($"{array[i, j]} ");
                str.WriteLine();
            }
            str.Close();
        }

        public void Disp()
        {
            for (int i = 0; i < s_n; i++)
            {
                for (int j = 0; j < s_k; j++)
                    Console.Write($"{array[i, j]} ");
                Console.WriteLine();
            }
        }
    }

    class Task_5
    // Игра удвоитель
    {
        int start, finish, step, current;
        string oper;

        public Task_5(int start_e, int finish_e, int step_e)
        {
            start = start_e;
            finish = finish_e;
            step = step_e;
            current = start;

            Console.WriteLine($"Вам нужно с числа {start} переобразовать в число {finish} за {step} шагов.");
            Console.WriteLine("Символ '-' отнимает от текущего числа 1");
            Console.WriteLine("Символ '+' прибавляет к текущему числу 1");
            Console.WriteLine("Символ '*' умножает текущее число на 2 \n");
            Console.WriteLine($"Текущее значение {current}");

            Start();
        }

        private void Start()
        {
            int i = 0;

            do
            {
                i++;

                Operation();

                if (current == finish)
                {
                    Console.WriteLine("У Вас получилось!");
                    break;
                }
                if (i == step)
                {
                    Console.WriteLine("Закончились попытки. Вы проиграли!");
                    break;
                }
            }
            while (true);
        }

        private void Operation()
        {
            oper = Console.ReadLine();

            switch (oper)
            {
                case "+":
                    current++;
                    break;
                case "-":
                    current--;
                    break;
                case "*":
                    current *= 2;
                    break;
                default:
                    Console.WriteLine("Повторите попытку");
                    Operation();
                    break;
            }

            Console.WriteLine($"Текущее значение {current}");

        }

    }

    class Task_6
    {

    }

    class Program
    {
        static void Task_1_run()
        {
            Task_1 array = new Task_1();
            array.Disp();
            array.Find_dev_3();
        }

        static void Task_2_run()
        {
            Task_2 array = new Task_2(10, -10, 5);
            array.Disp();
            array.Sum();
            array.Inverse();
            array.Disp();
            array.Multi(10);
            array.Disp();
            array.Max();
            array.Export("data.txt");

            Task_2 array2 = new Task_2();
            array2.Import("data.txt");
            array2.Disp();
        }

        static void Task_3_run()
        {
            Task_3 verif = new Task_3();
        }

        static void Task_4_run()
        {
            Task_4 array_2d = new Task_4(3, 5);
            array_2d.Disp();
            array_2d.Sum();
            array_2d.Sum(50);
            array_2d.Max();
            array_2d.Min();
            array_2d.Export("array_2d.txt");
        }

        static void Task_5_run()
        {
            Task_5 udvoitel = new Task_5(10, 50, 5); //1 - start; 2 - finish; 3 - N step
        }

        static void Task_6_run()
        {

        }

        static void Main(string[] args)
        {
            //Task_1_run();
            //Task_2_run();
            //Task_3_run();
            //Task_4_run();
            //Task_5_run();
            Task_6_run();

            Console.ReadKey();
        }
    }
}
