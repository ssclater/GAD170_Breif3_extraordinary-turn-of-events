using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script: Coin
    Author: Gareth Lockett
    Version: 1.0
    Description:    A simple script for a coin pickup. Make sure the coin object has a collider set to trigger.
                    The script spins/rotates the GameObject it is on.
                    When a GameObject, with a Rigidbody component, enters the trigger, this GameObject will be destroyed.

                    Note: We will update this script in the future to allow a 'score' to increment with each coin we pick up.
*/

public class Coin : MonoBehaviour
{
    public float spinSpeed = 100f;

    void Update()
    {
        this.transform.Rotate(0f, Time.deltaTime * this.spinSpeed, 0f  );
    }

    private void OnTriggerEnter( Collider other )
    {
        Destroy( this.gameObject );
    }
}
