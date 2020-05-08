using UnityEngine;

/*
    Script: CollisionExplosion
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script to add an explosive force to an object with a Rigidbody when it collides with this game object.
*/

public class CollisionExplosion : MonoBehaviour
{
    // Properties
    public float explosionForce = 1000f;            // Amount of explosive force.
    public float explosionRadius = 10f;             // Area in which the explosive force effects the rigidbody.
    public float upwardsModifier = 0f;              // Add some extra upwards force.
    public ForceMode forceMode;                     // The type of force (See Unity Scripting Reference for ForceMode for more details)

    // Methods
    private void OnCollisionEnter( Collision collision )
    {
        // Check the colliding object has a Rigidbody component.
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if( rb == null ) { return; }

        // Create an explosive force at the first contact point.
        rb.AddExplosionForce( this.explosionForce, collision.contacts[ 0 ].point, this.explosionRadius, upwardsModifier, ForceMode.Acceleration );
    }
}
