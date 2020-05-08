using UnityEngine;
using UnityEngine.Events;

/*
    Script: TimedEvent
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script to invoke an event at a regular time interval.
*/

public class TimedEvent : MonoBehaviour
{
    // Events
    public UnityEvent timedEvent;           // An event that is invoked at a regular interval.

    // Properties
    public float timeInterval = 3f;         // Time between invoking events (In seconds)
    public int maximumNumberOfEvents = -1;  // Maximum number of times to invoke the timedEvent. Set to less than 0 to run forever.

    public bool useRandomTimeRange;         // Use the random time range instead of timeInterval.
    public Vector2 timeRange;               // Will generate a random time between timeRange.x and timeRange.y for timeInterval.

    private float lastTimedEvent;           // Time of the last event (In seconds)
    private int numberOfTimesEventInvoked;  // Internal count of the number of times the timedEvent has been invoked.
    
    // Methods
    private void Start()
    {
        // Initalize the lastTimedEvent to the current time. So events don't start straight away.
        if( this.useRandomTimeRange == true ) { this.timeInterval = Random.Range( this.timeRange.x, this.timeRange.y ); }
        this.lastTimedEvent = Time.time;
    }

    private void Update()
    {
        // Check if already invoked the event a maximum number of times.
        if( this.maximumNumberOfEvents > -1 )
            if( this.numberOfTimesEventInvoked >= this.maximumNumberOfEvents ) { return; }
        

        // Check if it is time to invoke the event again.
        if( Time.time >= this.lastTimedEvent + this.timeInterval )
        {
            this.lastTimedEvent = Time.time;    // Record the time of this event.
            if( this.useRandomTimeRange == true ) { this.timeInterval = Random.Range( this.timeRange.x, this.timeRange.y ); } // Randomize the time if useRandomTimeRange is true.

            if( this.timedEvent != null )       // Check something has subscribed to the event.
                this.timedEvent.Invoke();       // Invoke the event.

            this.numberOfTimesEventInvoked++;   // Increment the invoke counter.
        }
    }
}
