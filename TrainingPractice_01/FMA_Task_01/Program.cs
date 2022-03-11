using System;

namespace FMA_Task_01
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите имеющееся у Вас в кошельке количество золота: ");
            int Gold;
            int Cristal;
            int priceCristal = 5;
            string error = Console.ReadLine();

            bool test = int.TryParse(error, out Gold);
            if (test)
            {
                if (Gold < 0)
                {
                    Console.WriteLine("\nУ вас отрицательный баланс!");
                }

                else
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("В магазине есть кристаллы на продажу.\n   Цена за один кристалл - " + priceCristal + " рублей.\n");
                    Console.WriteLine("Сколько кристаллов Вы хотите купить?");
                    Cristal = Convert.ToInt32(Console.ReadLine());

                    Gold = Gold - (Cristal * priceCristal);

                    if (Gold < priceCristal)
                    {
                        Console.WriteLine("\nУ вас недостаточно денег!");
                    }

                    else
                    {
                        Console.WriteLine("Сделка совершена!\nВы приобрели кристаллов в кол-ве: " + Cristal);
                        Console.WriteLine("Остаток вашего золота: " + Gold);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nЭто не число\nНажмите любую клавишу что бы выйти.");
            }

            Console.ReadKey();
        }
    }
}
