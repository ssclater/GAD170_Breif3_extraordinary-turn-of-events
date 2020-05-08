using UnityEngine;

/*
    Script: TriggerAddVelocity
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for adding velocity to a Rigidbody that enters this game objects trigger (Eg collider with isTrigger set to true)
*/

public class TriggerAddVelocity : MonoBehaviour
{
    // Enumerators
    public enum Axis { XAXIS, YAXIS, ZAXIS }

    // Properties
    public Vector3 velocityDirection;           // Direction of the velocity.
    public bool useAxis;                        // Option to use one of this game objects axis for direction (Eg will override velocityDirection)
    public Axis axis;                           // Axis to use when useAxis is true.
    public float velocityAmount = 1f;           // Amount of velocity to add.
    public ForceMode forceMode;                 // Type of force to add (See Unity Scripting Reference for more)

    // Methods
    private void OnTriggerEnter( Collider other )
    {
        // Check other has a Rigidbody.
        if( other.attachedRigidbody == null ) { return; }

        // Get the direction.
        Vector3 direction = this.velocityDirection.normalized;
        if( this.useAxis == true )
        {
            switch( this.axis )
            {
                case Axis.XAXIS: direction = this.transform.right; break;
                case Axis.YAXIS: direction = this.transform.up; break;
                case Axis.ZAXIS: direction = this.transform.forward; break;
            }
        }

        // Add velocity to the Rigidbody.
        other.attachedRigidbody.AddForce( direction * this.velocityAmount, this.forceMode );
    }
}
