# ShoulderVRAssessment
**10/11/20 Current State of the Project (Contact lbaron@udel.edu for questions): <br /> <br />**
**What is done-**
  * fish task (Intermediate Level) and chicken task (Hard Level) 
    * load task from main menu
    * color changes from red to green when collide with controller and has ding sound
    * ability to use left controller to adjust position of task
    * victory animations and return menu when completed 
  * lab streaming layer implemented to get a csv file of the hand controller coordinates 

**What is incomplete-**
  * square task (Easy Level)
    * pressing it from the menu loads the dots, but the dots are gray (need to implement ChangeColorOnEnter to get it to be red and to turn green when hit I believe. 
    * needs a script modelled like ChickMenuScript and FishMenuScript to initiaize the task when you hit Easy Level from the menu (get rid of menu and show dots)
    * Square Task has already been added to TaskCounter code
 
<br />

**What could be improved-**
  * return menu (after you complete the task and after the victory animations)
    * quit script - quit only works when you build the project (doesn't work on edit mode) so it would be nice to find a way for it to work all the time (there's stack overflow articles on this but I had no luck)
    * doesn't always work right when you repeat levels. ex: you did the easy level then press play again then press easy level again in the return menu. It can be fidgety - doesnt always work 
  * numerical displays
    * the timer that displays on the screen is in miliseconds I believe. This is not really practical / easy to read for the user
    * the task counter (saying you hit x/150 dots) displays on the screen in Unity when the game is playing but does not display for the user to see in the game
  * UI 
    * sound effects for victory animations
    * ability to use a laser from the trigger button to click menu options
<br />

# Set Up 
* VR Tool Kit (VRTK) - download through Unity, how we get the collisions to work
* Zinna - Eric did this for me, I am not quite sure what this does
* SteamVR - how to run the game with the VR headset and hand controllers
* Kite Python program - from Vincent, how to collect hand controller data. Must run this program on an IDE separate from Unity 
* Unity / Unity Hub - the game development software, should have Android module, see Teams instructions 
* FOR GAME OBJECTS WITH SCRIPTS: Initialize the public variables in the Inspector tab 
<br />

# File Descriptions
* MenuScript - for the main menu blocks. When you put your controller through a menu block and pull the trigger, it initializes the task by moving the dots from under the floor to the center, remove the menu blocks, and reset the dots  (through ResetDots)
* TaskCounter - if the dots hit equals the total there is to hit, play the victory animation and get rid of task and show menu asking if they want to quit out of the game or play again (which takes them to the main menu again)
* TaskController - keeps track of how many dots were hit (tasksAchieved)
* There are individualized scripts under each menu's block to handle what happens when a collision occurs (controller hits the block meaning they selected it)
