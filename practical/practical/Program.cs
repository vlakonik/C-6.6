using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace practical
{
    internal class Program
    {
        static void Main(string[] args) // Справочник «Сотрудники»
        {
            Console.WriteLine("Приветствую!\n");

            while (true)
            {
                Menu();
                string key = Console.ReadLine();

                if (key == "1")
                {
                    string text = "\nПользователь хочет вывести данные:\n\n";
                    Console.Write($"{text}");
                    Read();
                    Pause();
                    continue;
                }

                else if (key == "2")
                {
                    string text = "\nПользователь хочет сделать запись:\n\n";
                    Console.WriteLine($"{text}");
                    Write();
                    Pause();
                    continue;
                }

                else if (key == "")
                {
                    Console.WriteLine("Программа закрывается, хорошего дня!");
                    Pause();
                    break;
                }

                else if ((key != "1") && (key != "2") && (key != ""))
                {
                    Console.WriteLine("\nПожалуйста, следуйте инструкции!\n\n");
                    Pause();
                    continue;
                }
            }
        }

        /// <summary>
        /// Меню
        /// </summary>
        private static void Menu()
        {
            string text0 = "Для вывода данных на экран введите - 1";
            string text1 = "Для добавления записи введите - 2";
            string text2 = "Для выхода из программы нажмите (Enter)";
            Console.WriteLine($"{text0,40}\n\n{text1,35}\n\n{text2,41}\n");
        }
        /// <summary>
        /// Чтение и вывод файла
        /// </summary>
        private static void Read()
        {
            FileInfo file = new FileInfo("Сотрудники.txt");

            if (file.Exists)
            {
                var fileInfo = file.Length;

                if (fileInfo != 0)
                {
                    using (StreamReader streamR = new StreamReader("Сотрудники.txt"))
                    {
                        var read = streamR.ReadToEnd().Split(' ');
                        foreach (string data in read)
                        {
                            Console.Write($"{data}  ");
                        }
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("Файл пуст!\n");
                }
            }
            else
            {
                Console.WriteLine("Файл не создан, для создания добавьте запись!\n");
            }
        }
        /// <summary>
        /// Заполнение файла
        /// </summary>
        private static void Write()
        {
            using (StreamWriter streamW = new StreamWriter("Сотрудники.txt", true))
            {
                Console.Write("Введите ID (напр. 4): ");
                string ID = Console.ReadLine();

                DateTime noteDate = DateTime.Now;
                Console.Write($"Дата и время добавления записи: {noteDate}\n");
                Pause();

                Console.Write("Введите Ф.И.О.: ");
                string fullName = Console.ReadLine();

                Console.Write("Введите возраст: ");
                string age = Console.ReadLine();

                Console.Write("Введите рост в сантиметрах: ");
                string height = Console.ReadLine();

                Console.Write("Введите дату рождения (напр. 05.05.1992): ");
                string birthday = Console.ReadLine();

                Console.Write("Введите место рождения (напр. город Москва): ");
                string birthPlace = Console.ReadLine();

                streamW.Write($"ID: {ID}; Запись сделана: {noteDate}; Ф.И.О.: {fullName}; Возраст: {age}; " +
                    $"Рост: {height}; День рождения: {birthday}; Место рождения: {birthPlace};\n\n");

                Console.WriteLine("\nЗапись сделана!\n");
            }
        }
        /// <summary>
        /// Пауза 1,5 секунды
        /// </summary>
        private static void Pause()
        {
            Thread.Sleep(1500);
        }
    }
}