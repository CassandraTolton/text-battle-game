using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBattleGame
{
    class Character : Samurai1
    {
        //keeps track if character has drank the water and gets another attack
        protected internal bool DoubleAttack { get; set; }

        //keeps track if the character has used the torch
        protected internal bool Visable { get; set; }

        //keeps track if that character has eaten the food
        protected internal bool HasEaten {get; set;}

        //only keeps track if the character has drank the water
        //Note: i dont think this bool is neccesary but i will need to check
        protected internal bool HasDrink { get; set; }

        //keeps track the amount of kill the player has
        protected internal int Kills { get; set; }

        //sets values when the main character is created
        public void Start()
        {
            Dmg = 3;
            HitPoints = 20;
            Alive = true;

        }

        //determines whether you attack lands or not
        public override void Attack(int num)
        {
            Console.WriteLine($"you swing");
            if ((Roll = RollDice()) >= 3)
            {
                Console.WriteLine($"you hit and deal {Dmg} damage");
            }
            else Console.WriteLine("you miss!");
        }

        //Ends the game
        public override void Die()
        {
            if (this.HitPoints <= 0)
            {
                //this.alive is from teh samurai class the that character inherits from
                this.Alive = false;
                Console.WriteLine($"You have been defeated");
                return;
            }


        }

        //when character eats food, add +1 to dmg
        public virtual void Food()
        {
            Dmg += 1;
            this.DisplayInfo();
        }

        //when character drinks water, gains extra attack
        public virtual void Water()
        {
            DoubleAttack = true;
        }

    }
}
