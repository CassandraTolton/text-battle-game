using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a text battle game using a story of your own choosing or writing.
            //When I say text battle what I am referring to is a battle situation that is displayed using nothing but text

            //The game should not take longer than 10 minutes to play. You may have an option for it to last longer if you wish,
            //but please document (in the code) the method of getting through the game in 10 minutes or less.

            //All values in the game should be stored in variables. For instance if you need to use the number 10, it should be an int variable that has been initialized previously.
            //Or if you are displaying a character’s name, it should be in a string variable that has been initialized previously.

            //Somewhere in the game there needs to be an if/else, a switch construct, a for loop, and either a while or a do/while loop
            //if/else in battle1 and 
            //switch in menu
            //while and do/while loop for menu and main sequence of game


            //controlls when the menu is active and when the game starts
            bool playGame = false;
            bool menu = true;
            int roll = RollDice();




            //Array used to keep track of items
            //You need to use a single dimensional array to store and display some part of the game, perhaps character names? Maybe even character objects from a Character class?
            string[] items = new string[4] { "Potion", "Torch", "Food", "Water" };

            //You need to use a List somewhere in the game.
            //keeps track of enemies in the game
            List<Samurai1> Names = new List<Samurai1>
            {
                new Samurai1("Oni", 15, 3, true),
                new Samurai1("Toshiro", 10, 2, true)
            };

            //creates the player character
            Character Mc = new Character();


            //presents the menu while menu bool is set to true
            while (menu)
            {
                Console.WriteLine("welcome to the Samurai Battle Game!");
                Console.WriteLine("\t1) Start");
                Console.WriteLine("\t2) Info");
                Console.WriteLine("\t3) Exit");
                int userChoice = int.Parse(Console.ReadLine());

                //switch case that uses the users choice from the menu
                switch (userChoice)
                {
                    case 1:
                        playGame = true;
                        menu = false;
                        break;
                    case 2:
                        Console.WriteLine("Game with samurais and onis, be prepared as you will be fighting in this game");
                        break;
                    case 3:
                        Console.WriteLine("Goodbye, thank you for play!");
                        menu = false;
                        playGame = false;
                        break;
                    default:
                        Console.WriteLine("Sorry that is not a valid input, please try again");
                        break;
                }
            }

            //controlls the main sequence of game
            //Note: im going to be using different methods as a chapter system
            do
            {

                Mc.Start();
                Console.WriteLine("What is your name?");
                Mc.Name = Console.ReadLine();
                Start();

            } while (playGame == true);

            

            //There should be at least 3 methods included in the main class:
           
            //starting message that gives context to the area and your mission
            void Start()
            {
                Console.WriteLine("You finally reach the emperor's city, what used to be of your home.");
                Console.ReadLine();
                Console.WriteLine("walking through the arch way you see the shattered windows and warn down houses. The place being desolate and devoid and anything.");
                Console.ReadLine();
                Console.WriteLine("You stand at the base of the stairs, looking up the castle looms over you as the moon provides the only light in the dark evening");
                Console.ReadLine();
                Console.WriteLine("You go up the numerous steps and reach the enterence of the castle.");
                Console.ReadLine();
                Console.WriteLine("The doors open automatically, as if someone or something is waitng for you inside");
                Console.ReadLine();
                Fight1();
            }

            //first fight in courtyard
            //you can sneak past this first encounter
            void Fight1()
            {
                Console.Clear();
                Console.WriteLine("you see a samurai standing before you, gaurding the entrance to the palace");
                Console.WriteLine("what do you do?");
                Console.WriteLine("\t1) Fight");
                Console.WriteLine("\t2) Sneak");
                Console.WriteLine("\t3) Look in iventory");
                Console.WriteLine("\t4) Exit");
                int userChoice = int.Parse(Console.ReadLine());

                //uses user choice to see which route to take
                switch (userChoice)
                {
                    //fight the monster
                    case 1:
                        Console.WriteLine("the samruai sees you and makes eye contact, unsheathing his weapon");
                        Console.WriteLine("you draw your sword and prepare to fight.");
                        GoesFirstBattle(1);
                        LongHallway();
                        
                        break;
                    //sneak past
                    case 2:
                        Console.WriteLine("you go off to the left side, hiding in the shadows");
                        RollDice();
                        Console.WriteLine($"you rolled a {roll}");
                        if (roll > 3 && (Mc.Visable == false))
                        {
                            Console.WriteLine("you successfully sneak pass the samurai and enter through a tattered door.");
                            Console.ReadLine();
                            LongHallway();

                        }
                        //visiable is a bool value that is turned true when the character uses the torch
                        else
                        {
                            if(Mc.Visable)
                            {
                                Console.WriteLine("due to the torch's light, the samurai notices you and draws his weapon");
                            } else
                            {
                                Console.WriteLine("The samurai has found you and draws his weapon");
                            }
                            GoesFirstBattle(1);
                            LongHallway();

                        }
                        break;
                    //opens the inventory
                    case 3:
                        OpenInventory();
                        Fight1();
                        break;
                    //exits the text game
                    case 4:
                        Console.WriteLine("Goodbye, thank you for playing!");
                        playGame = false;
                        break;
                    //catches invalid inputs
                    default:
                        Console.WriteLine("Sorry that is not a valid input, please try again");
                        break;
                }
                //At the end of the game you must display the winner’s and loser’s information from the class and all of the information in both the array and the list.
            }

            //Battle sequence If the player goes first
            //takes x which is the index for the names list part of the samurai1 class
            void Battle1(int x)
            {
                do
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("\t1) Attack");
                    Console.WriteLine("\t2) Look in inventory");
                    int ans = int.Parse(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            Mc.Attack(Mc.Dmg);
                            if (Mc.Roll >= 3)
                            {
                                Names[x].TakeDamage(Mc.Dmg);
                            }

                            if (Mc.HasDrink)
                            {
                                Console.WriteLine("You attack again");
                                Mc.Attack(Mc.Dmg);
                                if (Mc.Roll >= 3)
                                {
                                    Names[x].TakeDamage(Mc.Dmg);
                                }
                            }
                            break;
                        case 2:
                            OpenInventory();
                            break;
                    }

                    Names[x].DisplayInfo();
                    Names[x].Die();



                    Console.ReadLine();

                    if(Names[x].Alive)
                    {
                        Names[x].Attack(Names[x].Dmg);
                        if (Names[x].Roll >= 3)
                        {
                            Mc.TakeDamage(Names[x].Dmg);
                        }

                        if (Names[x].Roll < 1)
                        {
                            Names[x].Potion();
                        }

                        Mc.DisplayInfo();
                        Mc.Die();
                    }

                    Console.ReadLine();
                } while (Mc.Alive == true && Names[x].Alive == true);
                if(Mc.Alive == false)
                {
                    GameOver(x);
                }
                Mc.Kills += 1;

                return;

            }

            //Battle sequence If the enemy goes first
            //takes x which is the index for the names list part of the samurai1 class
            void Battle2(int x)
            {
                do
                {
                    if (Names[x].Alive)
                    {
                        Names[x].Attack(Names[x].Dmg);
                        if (Names[x].Roll >= 3)
                        {
                            Mc.TakeDamage(Names[x].Dmg);
                        }

                        if (Names[x].Roll < 1)
                        {
                            Names[x].Potion();
                        }

                        Mc.DisplayInfo();
                        Mc.Die();
                    }

                    Console.ReadLine();

                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("\t1) Attack");
                    Console.WriteLine("\t2) Look in inventory");
                    int ans = int.Parse(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            Mc.Attack(Mc.Dmg);
                            if (Mc.Roll >= 3)
                            {
                                Names[x].TakeDamage(Mc.Dmg);
                            }

                            if (Mc.HasDrink)
                            {
                                Console.WriteLine("You attack again");
                                Mc.Attack(Mc.Dmg);
                                if (Mc.Roll >= 3)
                                {
                                    Names[x].TakeDamage(Mc.Dmg);
                                }
                            }
                            break;
                        case 2:
                            OpenInventory();
                            break;
                    }
                    Names[x].DisplayInfo();
                    Names[x].Die();

                    Console.ReadLine();
                } while (Mc.Alive == true && Names[x].Alive == true);
                if (Mc.Alive == false)
                {
                    GameOver(x);
                }
                Mc.Kills += 1;

                return;
            }

            //the next "level" in the game
            void LongHallway()
            {
                Console.Clear();
                Console.WriteLine("after walking through the palace you come to a long hall with little to no light.");
                Console.ReadLine();
                Console.WriteLine("what do you do?");
                Console.WriteLine("\t1) Continue Straight");
                Console.WriteLine("\t2) Look in iventory");
                Console.WriteLine("\t3) Exit");
                int ans = int.Parse(Console.ReadLine());

                switch (ans) 
                {
                    case 1:
                        Console.WriteLine("going straight, you bump into a figure and it knocks you back");
                        Console.WriteLine("In front of you is a shadowing figure with piercing red eyes");
                        Console.WriteLine("The figure unsheaths his katana and prepares for battle");
                        Console.WriteLine("What do you do?");
                        Console.WriteLine("\t1) Fight");
                        Console.WriteLine("\t2) Look in iventory");
                        Console.WriteLine("\t3) Exit");
                        int ans1 = int.Parse(Console.ReadLine());

                        switch(ans1) {
                            case 1:
                                GoesFirstBattle(0);
                                Console.WriteLine("upon opening the doors you are blinded by a bright light and then everything turns black");
                                Console.ReadLine();
                                GameOver(0);
                                break;
                            case 2:
                                OpenInventory();
                                GoesFirstBattle(0);
                                Console.WriteLine("upon opening the doors you are blinded by a bright light and then everything turns black");
                                Console.ReadLine();
                                GameOver(0);
                                break;
                            case 3:
                                Console.WriteLine("WARNING! This will end your game, are you sure you want to exit? (y/n)");
                                char ans2 = char.Parse(Console.ReadLine());

                                if(ans2 == 'y')
                                {
                                    playGame = false;
                                }
                                break;

                        }
                        
                        break;
                    case 2:
                        OpenInventory();
                        if(Mc.Visable == true)
                        {
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("using the torch lights up the hallway and clears away all shadows");
                            Console.WriteLine("you walk down the hallway reaching a gaint door");
                            Console.WriteLine("upon opening the doors you are blinded by a bright light and then everything turns black");
                        }
                        Console.ReadLine();
                        GameOver(0);
                        break;
                    case 3:
                        Console.WriteLine("Goodbye, thank you for playing!");
                        playGame = false;
                        break;
                }


            }

            //this combines battle with a roll to see who will go first. takes an int for the index of List Names
            void GoesFirstBattle(int x)
            {
                RollDice();
                Console.WriteLine($"you rolled a {roll}");
                int enermyRoll = RollDice();
                Console.WriteLine($"The enemy rolls a {enermyRoll}");
                if (roll > enermyRoll)
                {
                    Console.WriteLine("you attack first");
                    Battle1(x);
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("The enemy attacks first");
                    Battle2(x);
                    Console.ReadLine();
                }
            }

            //foreach loop to print out each item in the items array
            //contains the switch statement and which item to use
            void OpenInventory()
            {

                Console.Clear();
                Console.WriteLine("Inventory: ");
                int x = 1;
                foreach (string item in items)
                {
                    Console.WriteLine($"\t{x}) {item}");
                    x++;
                }
                Console.WriteLine("To exit inventory, press 0");
                Console.WriteLine("which item would you like to use");
                string Response = Console.ReadLine();
                Console.WriteLine("");

                switch (Response)
                {
                    case "potion":
                    case "1":
                        Console.WriteLine("Potion: drink to gain 5 health");
                        Console.WriteLine("Do you want to use a Potion? (y/n)");
                        char ans1 = char.Parse(Console.ReadLine());

                        if (ans1 == 'y')
                        {
                            Mc.Potion();
                        }
                        break;
                    case "torch":
                    case "2":
                        Console.WriteLine("Torch: Illuminates the area around you.");
                        Console.WriteLine("But be carefull, if enimies are around they will spot you.");
                        Console.WriteLine("Do you want to use a torch? (y/n)");
                        char ans2 = char.Parse(Console.ReadLine());
                        if (ans2 == 'y')
                        {
                            Mc.Visable = true;
                        }
                        break;
                    case "food":
                    case "3":
                        Console.WriteLine("Food: Eat to gain plus 1 to damage");
                        Console.WriteLine("Buff is permenent, but you can only eat once during this adventure.");
                        Console.WriteLine("Do you want to eat? (y/n)");
                        char ans3 = char.Parse(Console.ReadLine());
                        if (ans3 == 'y')
                        {
                            if (Mc.HasEaten == false)
                            {
                                Mc.Food();
                                Mc.HasEaten = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, you have already eaten today.");
                            }
                        }
                        break;
                    case "water":
                    case "4":
                        Console.WriteLine("Water: Drink to gain an extra attack per turn");
                        Console.WriteLine("Lasts for one battle, can only be consumed once");
                        Console.WriteLine("Do you want to drink? (y/n)");
                        char ans4 = char.Parse(Console.ReadLine());
                        if (ans4 == 'y')
                        {
                            if (Mc.HasDrink == false)
                            {
                                Mc.Water();
                                Mc.HasDrink = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, you have already drank water today.");
                            }
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Sorry that is not an option, please try again");
                        break;
                }
            }

            //game over method
            //shows character details and who they were killed by
            void GameOver(int x)
            {
                Console.Clear();
                if(Mc.Alive == false)
                {
                    Console.WriteLine($"You have died, {Names[x]} has killed you");

                    Console.WriteLine("Winner: ");
                    Names[x].DisplayInfo();

                    Console.WriteLine("Loser:");
                    Mc.DisplayInfo();
                    Console.WriteLine($"Kills: {Mc.Kills}");

                    Console.WriteLine("\n");
                    Console.WriteLine("Inventory: ");
                    foreach(string item in items)
                    {
                        Console.WriteLine($"{item}");
                    }
                } else
                {
                    Console.WriteLine("Congratulations, you survived the first level!");
                    Console.WriteLine("Unfortunatly there is only one level in this castle and you fell off the cliff that was awaiting you behind the door");

                    Console.WriteLine("\n");

                    Mc.DisplayInfo();
                    Console.WriteLine($"Kills: {Mc.Kills}");

                    Console.WriteLine("Inventory: ");
                    foreach (string item in items)
                    {
                        Console.WriteLine($"{item}");
                    }
                    Console.WriteLine(Names);

                }

                Console.WriteLine("Would you like to play again? (y/n)");
                char ans = char.Parse(Console.ReadLine());

                if (ans == 'y')
                {
                    Start();
                }

                Console.WriteLine("Thank you for playing!");
                playGame = false;

            }
        }


        //Use the Random class somewhere to create and use a Random number.
        //creates a random object called rand
        static internal Random rand = new Random();
        static internal int RollDice()
        {
            Console.WriteLine("Hit enter to roll.");
            Console.ReadLine();
            return rand.Next(7);
        }

        

        
        


}
}
