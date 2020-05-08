using UnityEngine;

/*
    Script: ComponentToggleEnable
    Author: Gareth Lockett
    Version: 1.0
    Description:    Super simple script to toggle enabled state of a target component.

                    Usage: Call ToggleActiveState() methods from UnityEvents (or other scripts) to toggle on/off.
*/

public class ComponentToggleEnable : MonoBehaviour
{
    // Properties
    public MonoBehaviour targetComponent;       // The target component to toggle on/off.

    // Methods
    public void ToggleEnabledState()
    {
        // Check a component reference ahs been set.
        if( this.targetComponent == null ) { return; }

        // Toggles the component enabled state.
        this.targetComponent.enabled = !this.targetComponent.enabled;
    }
}
