using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;

        //two example tests for FindDistance (part 2b)
        //creating points
        HVector2D point1 = new HVector2D(8f, 5f);
        HVector2D point2 = new HVector2D(1f, 3f);
        HVector2D point3 = new HVector2D(3f, 2f);
        HVector2D point4 = new HVector2D(7f, 5f);

        //calculating the distance
        float distance = Util.FindDistance(point1, point2);
        float distance2 = Util.FindDistance(point3, point4);

        //printing the result
        Debug.Log($"Distance between points 1 & 2: {distance}");
        Debug.Log($"Distance between points 3 & 4: {distance2}");
    }

    public bool IsCollidingWith(float x, float y)
    {
        //Debug.Log($"Checking collision at x: {x}, y: {y}");
        //to find the cursor's position
        HVector2D mousePosition = new HVector2D(x, y);

        //calculate distance between the ball's pos and mouse pos
        float distance = Util.FindDistance(Position, mousePosition);

        //if  distance is <= to the radius (of the ball), it will return true, otherwise false. (to check whether cursor is in the ball)
        return distance <= Radius;
    }

    //    public bool IsCollidingWith(Ball2D other)
    //    {
    //        float distance = Util.FindDistance(Position, other.Position);
    //        return distance <= Radius + other.Radius;
    //    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //calculating displacement
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;
        
        //updating ball's pos
        Position.x += displacementX;
        Position.y += displacementY;

        //set new pos of ball
        transform.position = new Vector2(Position.x, Position.y);
    }
}

