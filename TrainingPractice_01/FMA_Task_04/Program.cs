using System;
using System.Threading;

namespace FMA_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int healthBoss = 600;
            int damageBoss = 55;

            int healthPlayer = 300;
            int manaPlayer = 400;

            bool enableGame = true;
            string enterSpell;

            Console.WriteLine("Перед вами стоит огромный дракон Дорнозму, он настроен агрессивно и битвы избежать невозможно, приготовтесь к бою. \nВаши доступные заклинания: \n" +
                "1) fireball - Огненый шар наносит 70 урона, отнимает 95 едениц маны.\n" +
                "2) healstone - Камень жизни, который востанавливает игроку по 65 ХП в течении 3 секунд даёт неуязвимость на время действия, отнимает 50 единиц маны.\n" +
                "3) manastone - Камень маны, который востанавливает игроку по 65 MП в течении 3 секунд, даёт неуязвимость на время действия, отнимает 5 единиц маны.\n" +
                "4) killboss - Удар невиданной силы убивающий всё живое.\n");

            while (enableGame)
            {
                if (healthBoss <= 0)
                {
                    Console.WriteLine("\nДорнозму умер. \n\nВы победили!");
                    enableGame = false;
                }
                else if (healthPlayer <= 0)
                {
                    Console.WriteLine("\nВы погибли.");
                    enableGame = false;
                }
                else if (manaPlayer <= 0)
                {
                    Console.WriteLine("\nМана кончилась, вы погибли.");
                    enableGame = false;
                }
                else
                {
                    Console.WriteLine("\nСтатистика Дорнозму: \n Здоровье: {0} , Урон: {1} \n\nСтатистика игрока: \n Здоровье: {2} , Мана: {3} \n", healthBoss, damageBoss, healthPlayer, manaPlayer);
                    Console.WriteLine("Введите заклинание: ");
                    enterSpell = Console.ReadLine();

                    switch (enterSpell)
                    {
                        case "fireball":
                            if (manaPlayer >= 30)
                            {
                                healthBoss -= 70;
                                manaPlayer -= 95;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;
                        case "healstone":
                            if (manaPlayer >= 50)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (healthPlayer <= 250)
                                    {
                                        healthPlayer += 65;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Ваше текущее здоровье равно: {0}/300", healthPlayer);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас полный запас здоровья!");
                                    }
                                }
                                manaPlayer -= 50;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;
                        case "manastone":
                            if (manaPlayer >= 20)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (manaPlayer <= 250)
                                    {
                                        manaPlayer += 65;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Ваша текущая мана ровна: {0}/400", manaPlayer);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас полный запас маны!");
                                    }
                                }
                                manaPlayer -= 5;
                            }
                            else
                            {
                                Console.WriteLine("У вас не достаточно маны!");
                            }
                            break;
                        case "killboss":
                            healthBoss -= healthBoss + 10;
                            break;
                        default:
                            Console.WriteLine("{0} - неизвестное заклинание, произнесите заклинание правильно.", enterSpell);
                            break;
                    }
                    healthPlayer -= damageBoss;
                    healthBoss += 10;
                    manaPlayer += 15;
                }
            }
        }
    }
}
