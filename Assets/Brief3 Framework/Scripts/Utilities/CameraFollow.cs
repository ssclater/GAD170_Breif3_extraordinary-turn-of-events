using UnityEngine;

/*
    Script: CameraFollow
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple follow camera.

                    TODO: Simplify this! not so many options <<<<<<<<<<<<<<<<
*/

public class CameraFollow : MonoBehaviour
{
    // Enumerators
    public enum Axis{ _zAxisNeg, _xAxisNeg, _yAxisNeg, _zAxisPos, _xAxisPos, _yAxisPos, _none } // Note: '_none' will keep the camera at its starting orientation to the target object.

    // Properties
    public GameObject targetObj;        // The object to follow.

    public Axis axis;                   // Axis to work with.
    public bool worldAxis;              // If true, works along world axis. Otherwise uses target object's axis.
    
    public float followDistance = 5f;   // Distance to stay "behind" (eg -forward direction) the target object.
    public float followHeight = 3f;     // Height above target object to keep.

    public float followSpeed = 2f;      // Speed which to follow by (Larger = faster to follow)
    public float heightLookAtOffset;    // Offset the camera to look above the target object (positive values) or below (negative values)

    public bool skipLookAt;             // Useful for some 2D platformer games.

    public bool followRotation;         // Useful for flight simulator games.

    private Vector3 startVector;        // Used for '_none' Axis. Keeps camera at same position as when started.

    // Methods
    private void Start()
    {
        this.startVector = -this.transform.forward;
    }

    private void Update()
    {
        // Make sure there is a target object to follow.
        if( this.targetObj == null ){ return; }

        // Calculate target follow camera position. Uses the local or world X,Y,Z axis selected by axis/worldAxis properties.
        Vector3 direction = Vector3.zero;
        float tmpFollowHeight = this.followHeight; // This is only used with _yAxisNeg to invert the height offset.
        switch( this.axis )
        {
            case Axis._xAxisPos: // To the right of the target object.
                if( this.worldAxis == false ){ direction = this.targetObj.transform.right; }else{ direction = Vector3.right; }
                break;
            case Axis._xAxisNeg: // To the left of the target object.
                if( this.worldAxis == false ){ direction = -this.targetObj.transform.right; }else{ direction = -Vector3.right; }
                break;

            case Axis._yAxisPos: // Above the target object.
                if( this.worldAxis == false ){ direction = this.targetObj.transform.up; }else{ direction = Vector3.up; }
                break;
            case Axis._yAxisNeg: // Below the target object.
                if( this.worldAxis == false ){ direction = -this.targetObj.transform.up; }else{ direction = -Vector3.up; }
                tmpFollowHeight = -tmpFollowHeight;
                break;

            case Axis._zAxisPos: // Infront of the target object.
                if( this.worldAxis == false ){ direction = this.targetObj.transform.forward; }else{ direction = Vector3.forward; }
                break;
            case Axis._zAxisNeg: // Behind the target object.
                if( this.worldAxis == false ){ direction = -this.targetObj.transform.forward; }else{ direction = -Vector3.forward; }
                break;

            case Axis._none:
                direction = this.startVector;
                break;
        }

        // Calculate the target position for the camera to move to.
        Vector3 pos = this.targetObj.transform.position +( direction *this.followDistance ) +( Vector3.up *tmpFollowHeight );

        // Move towards the target follow camera position.
        this.transform.position = Vector3.Lerp( this.transform.position, pos, Time.deltaTime *this.followSpeed );

        // Option to skip the lookAt for 2D platform games.
        if( this.skipLookAt == false )
        {
            // Get the current rotation of the camera (So can smoothly change it to look at the target object)
            Quaternion oldRotation = this.transform.rotation;

            // Calculate the position to have the follow camera look at.
            Vector3 lookAtPos = this.targetObj.transform.position;
            lookAtPos.y += this.heightLookAtOffset;
            
            // Set the follow camera to directly look at the calculated look at position.
            Vector3 upDir = Vector3.up;
            if( this.followRotation == true ){ upDir = this.targetObj.transform.up; }
            if( this.axis == Axis._yAxisPos || this.axis == Axis._yAxisNeg ){ upDir = this.targetObj.transform.forward; } // Fix for above/under look at.
            this.transform.LookAt( lookAtPos, upDir );

            // Smoothly rotate the camera from the old rotation to the current rotation to look at the target object.
            this.transform.rotation = Quaternion.Slerp( oldRotation, this.transform.rotation, Time.deltaTime *this.followSpeed );
        }
    }
}
