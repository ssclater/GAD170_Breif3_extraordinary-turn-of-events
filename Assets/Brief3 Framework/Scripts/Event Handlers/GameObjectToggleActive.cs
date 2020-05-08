using UnityEngine;

/*
    Script: GameObjectToggleActive
    Author: Gareth Lockett
    Version: 1.0
    Description:    Super simple script to toggle active state of this game object.

                    Usage: Call ToggleActiveState() methods from UnityEvents (or other scripts) to toggle on/off.
*/

public class GameObjectToggleActive : MonoBehaviour
{
    // Methods
    public void ToggleActiveState()
    {
        // Toggles the game object active state.
        this.gameObject.SetActive( !this.gameObject.activeSelf );
    }
}
