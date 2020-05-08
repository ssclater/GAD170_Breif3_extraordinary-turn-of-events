using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Script: ReloadLevel
    Author: Gareth Lockett
    Version: 1.0
    Description:    Super simple script for reloading the currently open scene if a key is pressed.
*/

public class ReloadLevel : MonoBehaviour
{
    // Properties
    public KeyCode reloadKey = KeyCode.Escape;       // The key to press to reload the current scene.

    // Methods
    private void Update()
    {
        // Check if reloadKey is pressed. If so, reload the current level.
        if( Input.GetKeyDown( this.reloadKey ) == true ) { SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ); }
    }
}
