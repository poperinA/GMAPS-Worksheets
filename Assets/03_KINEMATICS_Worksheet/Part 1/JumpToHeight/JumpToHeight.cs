using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height


        //calculate the initial velocity (u) needed to reach the specified jump height using an equation: square root of -2 * gravitational acceleration * height
        float u = Mathf.Sqrt(-2 * Physics.gravity.y * Height);

        //sets the Rigidbody's velocity to the calculated one
        rb.velocity = new Vector3(0, u, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

