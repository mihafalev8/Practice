using System;
using System.Threading;

namespace FMA_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int healthBoss = 550;
            int damageBoss = 75;

            int healthPlayer = 500;
            int ragePlayer = 100;

            bool enableGame = true;
            string enterSpell;

            Console.WriteLine("Вы - рыцарь, которому подвластно всё. Ваша задача победить Дробителя - элитного босса невероятной силы. \nВаши способности: \n" +
                "1) judgment - Сокрушительный удар, наносящий 100 урона в ближнем бою, отнимает 35 едениц ярости.\n" +
                "2) willpower - Воля к победе повышает востанавление жизни игроку по 65 едениц в течении 3-х секунд, отнимает 20 единиц ярости.\n" +
                "3) rampage - Вы впадаете в буйство нанося врагу серию ударов нанеся в общей сложности 125 урона и восстановливаете 60 едениц ярости лишаясь 30 единиц здоровья.\n");

            while (enableGame)
            {
                if (healthBoss <= 0)
                {
                    Console.WriteLine("\nДробитель умер. \n\nВы победили!");
                    enableGame = false;
                }
                else if (healthPlayer <= 0)
                {
                    Console.WriteLine("\nВы погибли.");
                    enableGame = false;
                }
                else if (ragePlayer < 0)
                {
                    Console.WriteLine("\nЯрость кончилась, вы погибли.");
                    enableGame = false;
                }
                else
                {
                    Console.WriteLine("\nСтатистика Дробителя: \n Здоровье: {0} , Урон: {1} \n\nСтатистика игрока: \n Здоровье: {2} , Ярость: {3} \n", healthBoss, damageBoss, healthPlayer, ragePlayer);
                    Console.WriteLine("Введите способность: ");
                    enterSpell = Console.ReadLine();

                    switch (enterSpell)
                    {
                        case "judgment":
                            if (ragePlayer >= 35)
                            {
                                healthBoss -= 100;
                                ragePlayer -= 35;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно ярости!");
                            }
                            break;
                        case "willpower":
                            if (ragePlayer >= 20)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (healthPlayer < 500)
                                    {
                                        healthPlayer += 65;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Ваше текущее здоровье равно: {0}/500", healthPlayer);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас полный запас здоровья!");
                                    }
                                }
                                ragePlayer -= 20;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно ярости!");
                            }
                            break;
                        case "rampage":
                            if (ragePlayer >= 20)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (ragePlayer < 100)
                                    {
                                        ragePlayer += 20;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Ваша текущая ярость ровна: {0}/100", ragePlayer);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас полный запас ярости!");
                                    }
                                }
                                healthBoss -= 125;
                                healthPlayer -= 50;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно ярости!");
                            }
                            break;
                        default:
                            Console.WriteLine("{0} - неизвестная способность, используйте меч правильно.", enterSpell);
                            break;
                    }
                    healthPlayer -= damageBoss;
                    healthBoss += 10;
                    ragePlayer += 15;
                }
            }
        }
    }
}
