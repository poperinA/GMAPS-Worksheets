using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            //Debug.Log($"Mouse click position: {startLinePos}");

            //checks if the mouse click is inside the ball using the IsCollidingWith function.
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                //Debug.Log("Ball clicked!");
                //gets line from LineFactory and enables drawing
                drawnLine = lineFactory.GetLine(startLinePos, startLinePos, 1f, Color.black);
                drawnLine.EnableDrawing(true);
            }
        }
        //checks when mouse button is released
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            //disables the drawing
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(drawnLine.end.x - drawnLine.start.x, drawnLine.end.y - drawnLine.start.y);
            ball.Velocity = v;
            //print out the velocity
            Debug.Log($"Ball Velocity: X = {ball.Velocity.x}, Y = {ball.Velocity.y}");

            drawnLine = null; // End line drawing            
        }
        //if a line is being drawn, update its end point based on the current mouse position
        if (drawnLine != null)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            drawnLine.end = new Vector2(mousePos.x, mousePos.y); // Update line end
        }
    }

// 	/// <summary>
// 	/// Get a list of active lines and deactivates them.
// 	/// </summary>
// 	public void Clear()
// 	{
// 		var activeLines = lineFactory.GetActive();

// 		foreach (var line in activeLines)
// 		{
// 			line.gameObject.SetActive(false);
// 		}
// 	}
 }
