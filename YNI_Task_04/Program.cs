using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace YNI_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int bossHealth = 600;
            int playerHealth = 400;
            int playerDamage = 25;
            int playerAttack;
            int chakra = 250;
            var rnd = new Random();
            int dodge = 4;
            int bossDodge = 0;
            int bossAttack = 1;
            int actionCount = 0;
            int clons = 0;
            int chooseWhoAttack = rnd.Next(1, 3);

            Console.Write("В этой игре вы Наруто Узумаки и ваше будущее - стать хокаге. Но чтобы стать хокаге - вам нужна деревня, а Пэйн ставит под вопрос ее существование. Вам предстоит одолеть Пэйна в одиночку, таков ваш путь ниндзя.");

            string help = "\nСписок ваших возможностей: \n1. Теневое клонирование - вы создаете еще одного себя. (50 чакры) \n2. Тайдзюцу - физические атаки, которые не тратят чакру и даже немного восстанавливают. Рискуете получить урон сами. \n3. Разенган. Нужен хотя бы 1 клон. (100 чакры, 150 урона) \n4. Режим отшельника. Заряжается 5 ходов. В нем вы становитесь очень быстрым и противник не успевает вас атаковать, но вы тратите 50 чакры каждый ход и получаете 50 хп кадый ход.";

            Console.WriteLine(help);
            Console.WriteLine("Нажмите 0 во время атаки, чтобы посмотреть список свлих атак");
            while (true)
            {
                Console.WriteLine($"\n\t Ваше здоровье: {playerHealth} \n\t Ваша чакра: {chakra} \n\t Здоровье противника: {bossHealth}");
                if (chooseWhoAttack == 1)
                {
                    bossDodge = rnd.Next(1, dodge);
                    Console.WriteLine("\n\n\nВаш ход: ");
                inputAttackErr:

                    try
                    {
                        playerAttack = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Вы не успели выучить такое дзюцу");
                        goto inputAttackErr;
                    }

                    switch (playerAttack)
                    {
                        case (0):
                            Console.WriteLine(help);
                            goto inputAttackErr;
                        case (1):
                            if (chakra >= 50)
                            {
                                Console.WriteLine("Теневое клонирование. Ваш урон от тайдзюцу вырос, а шансы противника увернуться уменьшились");
                                playerDamage += 25;
                                dodge += 1;
                                chakra -= 50;
                                clons += 1;
                            }
                            else
                            {
                                Console.WriteLine("Вам не хватило чакры на создание клона");
                            }
                            chooseWhoAttack = 2;
                            break;
                        case (2):
                            Console.WriteLine("Ближний бой");
                            chakra += 30;
                            if (clons <= 6)
                            {
                                Console.WriteLine("Пэйн это 6 кукол, будет сложно попасть по нему с малым количеством клонов, есть риск получить урон самому");
                                bossDodge = rnd.Next(1, 5);
                                if (bossDodge == 4)
                                {
                                    Console.WriteLine("Вы не успели уследить за всеми Пэйнами и получили удар");
                                    playerHealth -= 35;
                                }
                                else
                                {
                                    Console.WriteLine("Вам удалось попасть по Пэйну");
                                    bossHealth -= playerDamage;
                                    bossDodge = rnd.Next(1, 3);
                                    if (bossDodge == 1)
                                    {
                                        Console.WriteLine("Вы сбили Пэйна с толку!");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (bossDodge == 4)
                                {
                                    Console.WriteLine("Вам не удалось попасть по Пэйну");
                                    if (bossDodge == 2)
                                    {
                                        Console.WriteLine("А вот ему по вам удалось");
                                        playerHealth -= 30;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Вам удалось попасть по Пэйну");
                                    bossHealth -= playerDamage;
                                    bossDodge = rnd.Next(1, 3);
                                    if (bossDodge == 1)
                                    {
                                        Console.WriteLine("Вы сбили Пэйна с толку!");
                                        break;
                                    }

                                }
                            }
                            chooseWhoAttack = 2;
                            break;
                        case (3):
                            if (clons >= 1)
                            {
                                if (chakra >= 100)
                                {
                                    chakra = 100;
                                    Console.WriteLine("Разенган!");
                                    if (bossDodge != 4)
                                    {
                                        Console.WriteLine("Прямо в цель!");
                                        bossHealth -= 150;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Проклятье... мимо...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Вам не хватило чакры на разенган");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы не можете сделать разенган без клона");
                                goto inputAttackErr;
                            }
                            chooseWhoAttack = 2;
                            break;
                        case (4):
                            if (chakra >= 75 && actionCount > 5)
                            {
                                Console.WriteLine("Режим отшельника!");
                                Console.WriteLine("Этот режим действует до тех пор, пока ваша чакра не иссякнет \nКаждый ход вы получаете 50 хп и тратите 50 чакры \nВ этом режиме вам доступны только: \n\t 1. Сверхзвуковой разенган (тратит 25 чакры и наносит 150 урона)
 
\n\t 2.Барикада разенганов(тратит 80 чакры и наносит 200 урона)");
                            
while (chakra >= 50)
                                {
                                    chakra -= 50;
                                    playerHealth += 50;
                                    Console.WriteLine($"\n\t Ваше здоровье: {playerHealth} \n\t Ваша чакра: {chakra} \n\t Здоровье противника: {bossHealth}");

                                    int choose = Convert.ToInt32(Console.ReadLine());

                                    switch (choose)
                                    {
                                        case (1):
                                            if (chakra > 25)
                                            {
                                                Console.WriteLine("Сверхзвуковой разенган!");
                                                bossHealth -= 150;
                                                chakra -= 25;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Мало чакры");
                                            }
                                            break;
                                        case (2):
                                            if (chakra > 80)
                                            {
                                                Console.WriteLine("Барикады разенганов!");
                                                bossHealth -= 200;
                                                chakra -= 80;
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Режим мудреца не терпит ошибок");
                                            break;
                                    }
                                }
                                actionCount = 0;
                            }
                            else
                            {
                                Console.WriteLine("Режим еще не готов");
                                chooseWhoAttack = 2;
                            }
                            break;
                        default:
                            Console.WriteLine("Новые дзюцу даются сложно в бою, используйте уже знакомые");
                            break;
                    }
                    actionCount += 1;

                    if (playerHealth > 400)
                    {
                        playerHealth = 400;
                    }
                }

                else
                {
                    Console.WriteLine("\n\n\nАтака Пэйна!");
                    bossAttack = rnd.Next(1, 5);

                    switch (bossAttack)
                    {
                        case (1):
                            Console.WriteLine("Металлические штыри!");
                            Console.WriteLine("Вы теряете 50 hp");
                            playerHealth -= 50;
                            break;
                        case (2):
                            Console.WriteLine("Сила бога!");
                            Console.WriteLine("Вы теряете 80 hp");
                            playerHealth -= 80;
                            break;
                        case (3):
                            Console.WriteLine("Врата Пэйна!");
                            Console.WriteLine("Вы теряете 100 hp");
                            playerHealth -= 100;
                            break;
                        case (4):
                            Console.WriteLine("Восстановление бога!");
                            Console.WriteLine("Пэйн получает 50 hp");
                            bossHealth += 50;
                            break;
                    }

                    if (bossHealth > 600)
                    {
                        bossHealth = 600;
                    }

                    chooseWhoAttack = 1;
                }

                if (bossHealth <= 0) break;
                if (playerHealth <= 0) break;
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("\n\nВы не оправдали надежд Конохи и пали в бою");
            }
            else
            {
                Console.WriteLine("\n\nВы отомстили за Джирайю и вернули мирное небо над Конохой. Пэйн пал!");
            }
            Console.ReadKey();
        }
    }
}