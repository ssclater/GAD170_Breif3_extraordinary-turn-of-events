using UnityEngine;

/*
    Script: SimpleSpin
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for spinning a game object around an axis.
*/

public class SimpleSpin : MonoBehaviour
{
	// Constants
	public enum Axis{ xAxis, yAxis, zAxis }

	// Properties
	public float spinSpeed = 45f;	// Speed at which this GameObject will rotate (eg degrees per second. Higher values will rotate faster)
	public Axis axis;				// The axis to rotate around.


	// Methods
    void Update()
    {
        // Rotate this GameObject along the selected axis
        switch( this.axis )
        {
        	case Axis.xAxis:
        		this.transform.RotateAround( this.transform.position, this.transform.right, Time.deltaTime *this.spinSpeed );
        		break;

			case Axis.yAxis:
				this.transform.RotateAround( this.transform.position, this.transform.up, Time.deltaTime *this.spinSpeed );
        		break;

			case Axis.zAxis:
				this.transform.RotateAround( this.transform.position, this.transform.forward, Time.deltaTime *this.spinSpeed );
        		break;
        }
    }
}
