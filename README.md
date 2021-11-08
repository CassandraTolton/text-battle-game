# text-battle-game
short text battle game using c#

uses simple classes to keep track of monsters and character health, damage, and items. only one level with rng turn base action and up to 3 monsters can be faught. Created soley with C# and is a C# console application.

## Fighting

You will know when encounter is about to happen when you are given three choices:
1. Fight - Initiates the fight
2. Sneak - Rolls a dice to see whether or not the playable character sneaks passed the monster. You have to roll a number higher than 3 on a six sided die, if you pass the check you skip the encounter. If not, you are forced into a fight.
3. Look in Inventory - Allows you to look in your inventory and use an item before the fight.

![fight1](https://user-images.githubusercontent.com/69628215/140593535-71a6f340-0e32-4351-87be-facff38fff33.PNG)

During the fight you have two options
1. Attack - attacks the monster by rolling a dice and seeing if you hit the monster
2. Look into Inventory - allows you to look into the inventory. (Note: if you use an item it counts as a turn, however, if you do not use an item then it does not count as a turn)

![fight2](https://user-images.githubusercontent.com/69628215/140593543-6c13a017-d17b-4dd2-95a0-0a0f251ad9fc.PNG)

## Inventory

The inventory takes you to a seperate screen when you can see your list of options. There are no items that will be added during the duration of the game and you can only use three items.
1. Potion - Adds 20 hp to the main characters health pool
2. Torch - This can be used to either initiate a fight or skip a fight, depending on the encounter.
3. Food - this adds +1 to the damage of each attack (Note: on hit is not effected by this stat, on the damage.)
4. Water - this allows you to have two attacks in one turn. 


![inventory](https://user-images.githubusercontent.com/69628215/140593562-25091f5f-2253-4d3f-8806-0f3bdfad74ba.PNG)

## End Screen

End screen will appear when you reach the final monster (Note: you can complete the game without fighting any monsters) where you will then be promted if you would like to play again.


![end screen](https://user-images.githubusercontent.com/69628215/140593352-41a6e8cf-d096-48c5-890f-ac7528ca1b4e.PNG)
