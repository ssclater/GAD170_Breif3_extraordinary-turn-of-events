using UnityEngine;

/*
    Script: GravityDirection
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script that sets the direction of Physics.gravity to the opposite of this game objects up vector.
                    NOTE: This is basically the opposite of the OrientToGravity script.
*/

public class GravityDirection : MonoBehaviour
{
    // Methods
    public void Update()
    {
        // Set the direction of gravity to the opposite of the target game objects up vector (Eg -Y axis)
        Physics.gravity = -this.transform.up;
    }
}
