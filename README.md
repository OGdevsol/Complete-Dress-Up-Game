# Complete-Dress-Up-Game

Source project code for a complete mobile dress-up game. The game includes 20+ items for two main categories, dress-up and make-up.. All items are initialized through seperate base classes from a single scriptable object so it's easier to manage their individual properties. Some of the key features are as follows:
1) Two main and over 20 sub categories.
2) Dress up items are switchable, some make-up items are applied through drag and draw functionality of a kit.
3) Each item can be locked to be purchased through in-game currency or through ads.
4) Items can be unlocked after a specific number of levels have been played. 
5) Items can be added to a weekly subscription package. (They will be unlocked for 7 days to be usable)
6) A basic AI controller that will randomly choose dresses and make up for the AI character for comparison with the player's character.
7) AI character can randomly choose from 10 states, ranging from the most basic, just a dress equipped to the highest scoring, a dress with six make up items applied. It's user's luck that which state has been chosen by the AI character for a specific level.
8) Items for users can be assigned points seperately, to give user more points if they are using weekly subscription package items or premium items.
9) Tweaks and functionalities or a better experience such as selected state and undo functionality for each item have also been added.
10) Every item has a seperate OnClick class that decides what will happen with that particular object once its relevant button is clicked. Most items share the same functionality however this makes it a lot easier to manage different animations, effects and properties for different objects.
11) To get a rough idea of what's going on, you just need to review 
i) Any one of the CreateItemButtons method of InGameplayUIManager
ii) Any one of the OnItemClick scripts
iii) Relevant item's serializable class and initialization in LevelsSo script
