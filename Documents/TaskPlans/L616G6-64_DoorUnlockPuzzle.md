 * Bilge pump will have a referance to an unlockable door
  * When the puzzle is completed, call the unlock event on the door referance
 * On the bilge pump, track when the puzzle has been completed
  * Have a bit flag for the pedestalls
  * When a cube is placed on one, set that pedestall's flag
  * when all flags are set, set the completed state to true (Will change a but with the start button part)
 * Create an unlockable door blueprint
  * Use a simpilar blueprint to the interactable door
  * Door will start in a locked state, closed
  * an event will fire that will play an opening animation
  * Will need an opened transform variable (make visible so it can be edited in engine)
