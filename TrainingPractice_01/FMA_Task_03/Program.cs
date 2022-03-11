using System;

namespace FMA_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "123456";

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Введите пароль: ");
                string userEnter = Console.ReadLine();
                if (!userEnter.Equals(password))
                {
                    Console.WriteLine("Пароль не верен! Повторите попытку.\n Попыток осталось: {0}/3", i);
                }
                else
                {
                    Console.WriteLine("Мы рады видеть вас в системе");
                    break;
                }
            }
        }
    }
}
