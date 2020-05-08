using UnityEngine;

/*
    Script: KeepBallAwake
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script to keep a Rigidbody physics object awake (Eg reacting to physics)
*/

[ RequireComponent( typeof( Rigidbody ) ) ]
public class KeepBallAwake : MonoBehaviour
{
    // Properties
    private Rigidbody rb;       // Reference to a Rigidbody component on this game obejct.

    // Methods
    private void Start()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Stop the Rigidbody from going to sleep.
        if( this.rb.IsSleeping() == true ) { this.rb.WakeUp(); }
    }
}
