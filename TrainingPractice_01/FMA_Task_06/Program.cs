using System;

namespace FMA_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string[] dossier = new string[5], post = new string[5];
            dossier[0] = "Иванков Альберт Святославович";
            dossier[1] = "Беляков Артем Германнович";
            dossier[2] = "Титов Гордей Яковлевич";
            dossier[3] = "Терентьев Гаянэ Демьянович";
            dossier[4] = "Исаев Давид Геннадиевич";
            post[0] = "Программист";
            post[1] = "Пожарный";
            post[2] = "Сантехник";
            post[3] = "Космонавт";
            post[4] = "Преподаватель";

            while (isWork)
            {
                Console.WriteLine("Введите номер команды");
                Console.WriteLine("1 - добавить досье");
                Console.WriteLine("2 - вывести все досье");
                Console.WriteLine("3 - удалить досье");
                Console.WriteLine("4 - поиск по фамилии");
                Console.WriteLine("5 - выход\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddDossier(ref post, ref dossier);
                        break;
                    case "2":
                        ShowDossier(ref post, ref dossier);
                        break;
                    case "3":
                        DeleteDossier(ref post, ref dossier);
                        break;
                    case "4":
                        FindDossier(ref post, ref dossier);
                        break;
                    case "5":
                        isWork = !isWork;
                        break;
                }
            }

            Console.WriteLine("\nВы вышли из программы.");
            Environment.Exit(0);

        }

        public static void AddDossier(ref string[] post, ref string[] dossier)
        {
            string[] tempDossier = new string[dossier.Length + 1];
            string[] tempPost = new string[post.Length + 1];

            for (int i = 0; i < dossier.Length; i++)
            {
                tempDossier[i] = dossier[i];
                tempPost[i] = post[i];
            }

            dossier = tempDossier;
            post = tempPost;
            Console.WriteLine("\nНапишите ФИО сотрудника");
            dossier[dossier.Length - 1] = Console.ReadLine();
            Console.WriteLine("\nНапишите должность сотрудника");
            post[post.Length - 1] = Console.ReadLine();
            Console.WriteLine("\nДанные занесены успешно!!!\n");
        }

        public static void ShowDossier(ref string[] post, ref string[] dossier)
        {
            Console.WriteLine();
            Console.WriteLine("Список всех досье:");

            for (int i = 0; i < dossier.Length; i++)
            {
                if (dossier[i] != "" && post[i] != "")
                {
                    Console.WriteLine((i + 1) + " - " + dossier[i] + " - " + post[i]);
                }
            }

            Console.WriteLine();
        }

        public static void DeleteDossier(ref string[] post, ref string[] dossier)
        {
            int uselessIndexArray;
            string[] tempPost = new string[post.Length - 1];
            string[] tempDossier = new string[dossier.Length - 1];
            Console.WriteLine("\nНапишите порядковый номер досье,который вы хотите удалить");
            ShowDossier(ref post, ref dossier);
            uselessIndexArray = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < uselessIndexArray - 1; i++)
            {
                tempDossier[i] = dossier[i];
                tempPost[i] = post[i];
            }

            for (int i = uselessIndexArray; i < post.Length; i++)
            {
                tempPost[i - 1] = post[i];
                tempDossier[i - 1] = dossier[i];
            }

            post = tempPost;
            dossier = tempDossier;
        }

        public static void FindDossier(ref string[] post, ref string[] dossier)
        {
            string inputSurname, surnameSymbols = "";
            int indexArray = 0;
            Console.WriteLine("\nЧтобы найти досье, напишите полностью фамилию");
            inputSurname = Console.ReadLine();

            for (int i = 0; i < dossier.Length; i++)
            {
                for (int j = 0; j < dossier[i].Length; j++)
                {
                    if (dossier[i][j] == ' ')
                    {
                        break;
                    }
                    surnameSymbols += dossier[i][j];
                }
                if (surnameSymbols == inputSurname)
                {
                    indexArray = i;
                    break;
                }
                else
                {
                    surnameSymbols = "";
                }
            }

            if (surnameSymbols == "")
            {
                Console.WriteLine("\nДосье не найдено!\n");
            }
            else
            {
                Console.WriteLine("\nДосье найдено!\n");
                Console.WriteLine((indexArray + 1) + "-" + dossier[indexArray] + "-" + post[indexArray]);
            }
        }
    }
}
