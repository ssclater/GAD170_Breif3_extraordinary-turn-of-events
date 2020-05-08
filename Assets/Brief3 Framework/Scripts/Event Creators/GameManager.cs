using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*
    Script: GameManager
    Author: Gareth Lockett
    Version: 1.0
    Description:    This is the main game manager script. It controls when the game is over (and can invoke a game over event when it detects the game is over)
*/

public class GameManager : MonoBehaviour
{
    // Events
    public UnityEvent gameOverEvent;                // This event is invoked whenever this game manager detects the game is over.

    // Enumerators
    public enum GameState { PLAYING, GAMEOVER_WIN, GAMEOVER_STALL, GAMEOVER_OTHER } // The various game states.

    // Properties
    public GameObject ballGameObject;               // Reference to the Ball game object.
    public float minimumBallHeight = -150f;         // If the ball game objects height is less than this value, this game manager will determine to game is over (Eg assumes the ball fell off the level)
    public float checkBallMoveTime = 2f;            // Interval (in seconds) to check the ball has moved (Eg check to see if the ball has stalled)
    public float minimumBallMoveDistance = 0.1f;    // The minimum distance the ball object should move. If less than this then consider the ball stalled and game over.

    public Text gameOverText;                       // A reference to the game over text (So can display game over win/stall/lose in GameOver())

    private GameState gameState;                    // Simple state machine keeping track of the games current state.
    private Vector3 ballsLastPosition;              // Last updates ball position.
    private float ballDistanceMoved;                // Distance the ball has moved since the last check.
    private float nextBallCheckTime;                // Next time to check if the ball has moved.

    // Methods
    private void Start()
    {
        // Check we start the game with a valid ball object reference. If not, output a warning and called an end to the game.
        if( this.ballGameObject == null ) { Debug.LogWarning( "No ball object set on GameManager!", this ); this.GameOver( GameState.GAMEOVER_OTHER ); }

        // Set the time of the first ball stall check (Eg give it a chance to get moving)
        this.nextBallCheckTime = Time.time + this.checkBallMoveTime;

        // Subscribe the BallInGoal() method to EndGoal's ballInGoal action (Eg see EndGoal.cs script)
        EndGoal.ballInGoal += this.BallInGoal;
    }

    private void Update()
    {
        // Sanity checks.
        if( this.gameState != GameState.PLAYING ) { return; }
        if( this.ballGameObject == null )
        {
            if( this.gameState == GameState.PLAYING ) { this.GameOver( GameState.GAMEOVER_OTHER ); } // If there is no ball object call an end to the game.
            return;
        }

        // Check the ball objects height.
        if( this.ballGameObject.transform.position.y < this.minimumBallHeight )
        {
            this.GameOver( GameState.GAMEOVER_OTHER ); // Ball has probably fallen off the level. Call an end to the game.
        }

        // Update the distance the ball has travelled since the last Update()
        this.ballDistanceMoved += Vector3.Distance( this.ballsLastPosition, this.ballGameObject.transform.position );

        // Check if the ball movement has stalled.
        if( Time.time >= this.nextBallCheckTime )
        {
            this.nextBallCheckTime = Time.time + this.checkBallMoveTime;

            // If the ball has moved less distance than the set minimum, then call an end to the game.
            if( this.ballDistanceMoved < this.minimumBallMoveDistance ) { Debug.Log( "Ball movement has stalled!" ); this.GameOver( GameState.GAMEOVER_STALL ); }

            // Reset the distance the ball has moved.
            this.ballDistanceMoved = Vector3.Distance( this.ballsLastPosition, this.ballGameObject.transform.position );
        }

        // Record the balls current position ready for the next Update() (NOTE: Check the ball object still exists just in case it has been destroyed)
        if( this.ballGameObject != null ) { this.ballsLastPosition = this.ballGameObject.transform.position; }
    }

    private void BallInGoal()
    {
        // Call an end to the game with a win since the Goal let us know the ball went in.
        this.GameOver( GameState.GAMEOVER_WIN );
    }

    private void GameOver( GameState newGameState )
    {
        // Sanity checks.
        if( newGameState == GameState.PLAYING ) { newGameState = GameState.GAMEOVER_OTHER; } // GameOver() should not be getting called with new game state PLAYING?!

        // Check for any subscribed game over events to invoke.
        if( this.gameOverEvent != null ) { this.gameOverEvent.Invoke(); }

        // Set the game as over.
        this.gameState = newGameState;

        // Update the game over text to reflect why the game is over.
        this.gameOverText.text = "GAME OVER!\n"; // Note: the \n here is to tell it to start a new text line after GAME OVER!.
        switch( this.gameState )
        {
            case GameState.GAMEOVER_WIN:
                this.gameOverText.text += "You got the ball into the goal.";
                break;

            case GameState.GAMEOVER_STALL:
                this.gameOverText.text += "The ball stalled. Better luck next time.";
                break;

            case GameState.GAMEOVER_OTHER:
                this.gameOverText.text += "You didn't get the ball into the goal.";
                break;
        }

        Debug.Log( "GAME OVER!" );
    }
}
