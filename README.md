![Screenshot](https://github.com/niccojacinto/DiceRollSimulator/blob/main/Screenshots/Screenshot.JPG)

# DiceRollSimulator
- A simple dice roll simulator that uses Unity Physics to simulate dice rolls

# The Theory
## Is there a reason for this?
- tldr; I just wanted to see if in-game physics would be a reliable 'controlled randomness' generator that dictates game mechanics and progression. Basically, if are you able to create acceptably accurate simulations if you're using floating point values.

- The idea is that normally using floating point values compared to double precision values are more efficient in terms of performance and memory in most game applications.
However, when I was playing Civ VI the other day, I came to question whether it might be possible to create a 'seeded' but at the same time 'random'  value that would yield the same results each time
by relying on something that isn't really definite, such as a physics engine, but again, with the restriction that the use double precision values are void (because it would be impractical tech wise).

If the variance is low enough, I could introduce some kind of 'butterfly effect' that relies on the intial seed that may create a lot of changes if one object is tightly related enough to another object in game.

It is event driven randomness that simulate progression.


Some questions to think about:
Q: Is it possible for me to hit a Cue ball to break a 9-ball formation exactly the same place each time to guarantee that the number 9 goes in every time I try it?
Q: If I drop multiple dice oriented the same way, from a certain height, facing a certain angle, would I always get the same results each time?
Q: If I do the same die drop, but this time I spread the dice too far apart, will I get consistent results? Are the dice interacting with each other that might be affecting the results?
Q: What if I do this die drop but I keep 99% of the dice apart from each other, but keep the 1% tightly packed, would the variance in the 1% affect the 99% and slightly shift the simulation overall?


--- START SCENARIO ---

Consider this in a vast RPG GAME: (woohoo!)
You, the 'Player' spawns quite a distance way from the 'Town of Beginnings', where you will learn about the lore of the magic realm from the trusty knight, 'Sir Galahad'. After you bond together for some time, He receives a an urgent message from a passing merchant. He tells you that he received word that bandits were attacking a nearby encampent in a brutal and bloody slaughter! (How terrible!) and he tells you to meet him there after making your preparations.

You, being a veteran adventurer from other games decide to browse the merchant's wares for a good 5 minutes and then deciding to purchase nothing (because you can't afford anything) for the battle to come.

Upon reaching the battlefield and a show of your adventuring skills, the battle came to a close, but with a grave injury to Sir Galahad. If only you had a potion to heal him with (tragic!). He finally succumbs to his wounds and is incapacitated for the rest of the playthrough. You linger around looting for about 4 minutes when the merchant back from town shows up carrying the precious potions! Why couldn't he have arrived sooner! It was probably because you casually browsed his wares for 5 minutes before moving on.

Feeling a sense of failure, you decide to load the file and talk to the merchant much faster this time. Letting you purchase the potion in the battlefield just in time! (After letting the good knight pay for it of course!). As you went back to town, you realize that a couple of the townsfolk including the local Alchemist (who you think is pretty important) died from the fleeing bandits that passed through town.

Enraged, you decide to Alt+F4 and try again later.

After booting up the game next morning, you decide to Skip the 'Town of Beginnings' and just raid the bandit camp yourself at the expense of losing rapport with the town, and locking yourself out of the special dialogue for Sir Galahad that is pretty important! So what do we have here???

--- END SCENARIO ---


- Normally these events would have been handled in such a way that it balances the Writing and the Gameplay, however, what if you want to make an rpg that is driven by object-to-object interaction in a defined simulation? If I move this rock, how would the game react? If clearly this character is tightly coupled to this other character, what would happen if... I just block this character long enough so that they wouldn't ever meet?

- It's just interesting to me how this is possible espcially with the dawn of AI driven interactions
