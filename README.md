Information About the project

This is a case study project and this information has written about the code and how it works 

There is 2 major gameobject that backbone of the hierarchy 
* GameManager
* UIManager
And there is Saveload system that saves binary but works as a static instance

Both managers is an static instance and holds the important structure such as 
GameManager holds LevelManagers as prefab variants, 
LevelManagers holds SubLevelManagers as prefab variants 

Factory methods are a major in this project. All the managers in game has connected to the gamemanagers awake method which makes them controlable instead of "start or awake method" of monobehaviour on each other differently they process methods on a controlable order

GameManager Instantiates a LevelManager and then LevelManager Instantiates SubLevelManager when SubLevelManager dones progress of the game awares the parent LevelManager and LevelManager destroys the SubLevelManager and initiates next one 
When last SubLevelManager is done playing which means Level is completed levelmanager tells GameManager to initiate next level by UI awakened gameobjects such as next level button, or retry button

On the other hand UIManager Holds the UI specified items and filler bars or money text or ui particles, they are controlled in topic specified manager by itself, ui items like buttons or text or images dont knows the data that holds this is overwriten by ScriptableObjects
Which makes it easier for game designer or else to change data faster, instead of holding the data by game object 

Player is a child of LevelManager and this is driven by manager, but player operations such as aiming shooting is controlled by player and Raycast in a specific layer makes the gun firing enabled also animations is rigged with a rigbuilder and specified for a specific weapon 
Enemies which are zombies are controlled by a EnemyManager and Manager is Controlled by SubLevelManager. Enemies moves and make decisions by themselves and they have update by each other, this is controlled by a state called integer 

Furthermore Weapon Selection is connected with UI and process inputs together by weapon selection manager on each press of a button. buttons are prefabs and they are controlled by a manager and they instantiates on runtime and builds by scriptableobject data which i indicate above

Thanks for reading.
