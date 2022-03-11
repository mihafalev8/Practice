using System;

namespace FMA_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool commandStartProgramm = true;

            while (commandStartProgramm)
            {
                Console.WriteLine("Введите команду (/help - для получения справки)");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "/help":
                        Console.WriteLine("/hacked - взломать систему. \n/offinternet - отключить интернет. \n/reloadpc - перезапуск PC. \n/clear - очистка окна. \n/exit - выйти из программы.");
                        break;
                    case "/hacked":
                        Console.WriteLine("Система взломана");
                        break;
                    case "/offinternet":
                        Console.WriteLine("Интернет отключен. Невозможно соединиться с сервером для передачи команд...");
                        break;
                    case "/reloadpc":
                        Console.WriteLine("Компьютер перезагружен.");
                        break;
                    case "/clear":
                        Console.Clear();
                        Console.WriteLine("Окно приложения очищено.");
                        break;
                    case "/exit":
                        commandStartProgramm = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверную команду. Воспользуйтесь справкой(/help)");
                        break;
                }
            }
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
