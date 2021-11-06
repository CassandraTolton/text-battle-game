using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBattleGame
{
    class Samurai1
    {
        //You will need to use at least 1 additional class other than the class with the main method.
        //The class needs to contain at least 3 different private members (variable/attribute) and public getter and setter properties for those members.
        //These could be name, points, whether the character is good or evil, etc.
        protected internal int HitPoints { get; set; }
        protected internal string Name { get; set; }
        protected internal bool Alive { get; set; }
        protected internal int Dmg { get; set; }
        protected internal int Roll { get; set; }




        //You can add as many other methods as you want to the class as well, but you must show the default constructor and an overloaded constructor.
        public Samurai1() 
        { }

        public Samurai1(string name, int health, int damage, bool alive)
        {
            Name = name;
            HitPoints = health;
            Dmg = damage;
            Alive = alive;


        }

        //You might have a method for displaying information about the object created from the class, or maybe a method that subtracts points from the Hit Points attribute.
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Health: {this.HitPoints}");
            Console.WriteLine($"Damage: {this.Dmg}");
        }

        //rolls to see if the attack will do damage or miss
        public virtual void Attack(int num)
        {
            Console.WriteLine($"{this.Name} swings");

            if ((Roll = RollDice()) >= 3) 
            {
                Console.WriteLine($"{this.Name} hits you, you take {Dmg} damage");

            }
            else Console.WriteLine($"{this.Name} misses");

        }

        //if attack lands this causes health to go down based on damage taken
        public virtual void TakeDamage(int dmg)
        {
            this.HitPoints -= dmg;
        }

        //rolls a random number
        static Random rand = new Random();
        static internal int RollDice()
        {
            return rand.Next(7);
        }

        //if hitpoints is 0 or less changes the alive bool to false and ends the battle sequence
        public virtual void Die()
        {
            if(this.HitPoints <= 0)
            {
                this.Alive = false;
                Console.WriteLine($"You have defeated {this.Name}");
                return;
            }
        }

        //when character or enemy uses potion, gain 5 health
        public virtual void Potion()
        {
            this.HitPoints += 5;
            Console.WriteLine($"{this.Name} uses a potion!");
            DisplayInfo();
        }

       

        




    }
}
