using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        //initialize the matrix to the identity matrix using the setIdentity method
        setIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++) // Do for each row
        {
            for (int x = 0; x < 3; x++) // Do for each column
            {
                entries[y, x] = multiArray[y, x]; //filling the values from multiArray
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
    {
        //creating a new 3x3 matrix and initializing it with the provided values
        entries = new float[3, 3]
        {
            {m00, m01, m02},
            {m10, m11, m12},
            {m20, m21, m22}
        };
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < 3; y++) // Loop thru rows
        {
            for (int x = 0; x < 3; x++) // Loop thru columns
            {
                //add corresponding elements from left and right matrices
                result.entries[y, x] = left.entries[y, x] + right.entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < 3; y++) // Loop through rows
        {
            for (int x = 0; x < 3; x++) // Loop through columns
            {
                //subtract corresponding elements from left and right matrices
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D matrix, float scalar)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < 3; y++) // Loop through rows
        {
            for (int x = 0; x < 3; x++) // Loop through columns
            {
                //multiply each element of the matrix by the scalar
                result.entries[y, x] = matrix.entries[y, x] * scalar;
            }
        }
        return result;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        //multiply each matrix row element with the corresponding vector component
        float resultX = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2];
        float resultY = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2];

        return new HVector2D(resultX, resultY);
    }


    // Note that the second argument is a HMatrix2D object
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(


            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
            /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            /* 
             00 01 02    xx 01 xx
             xx xx xx    xx 11 xx
             xx xx xx    xx 21 xx
             */
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],
            /* 
            00 01 02    xx xx 02
            xx xx xx    xx xx 12
            xx xx xx    xx xx 22
            */
            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
            /* 
            10 11 12    00 01 02
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
            /* 
            10 11 12    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],
            /* 
            10 11 12    xx xx 02
            xx xx xx    xx xx 12
            xx xx xx    xx xx 22
            */
            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
            /* 
            20 21 22    00 01 02
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
            /* 
            20 21 22    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
            /* 
            20 21 22    xx xx 02
            xx xx xx    xx xx 12
            xx xx xx    xx xx 22
            */
        );
    }


    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++) // Loop through rows
        {
            for (int x = 0; x < 3; x++) // Loop through columns
            {
                //compares each element of the matrices with the other
                if (left.entries[y, x] != right.entries[y, x])
                {
                    return false; // If any element is not equal, return false
                }
            }
        }
        return true; // If all elements are equal, return true
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++) // Loop through rows
        {
            for (int x = 0; x < 3; x++) // Loop through columns
            {
                //compares each element of the matrices with the other
                if (left.entries[y, x] != right.entries[y, x])
                {
                    return true; // If any element is not equal, return true
                }
            }
        }
        return false; // If all elements are equal, return false
    }


    // public override bool Equals(object obj)
    //{
    // your code here
    // }

    // public override int GetHashCode()
    //{
    // your code here
    // }

    // public HMatrix2D transpose()
    // {
    //return // your code here
    //}

    // public float getDeterminant()
    // {
    //return // your code here
    // }

    public void setIdentity()
    {
        //for each row
        for (int y = 0; y < 3; y++)
        {
            //for each col
            for (int x = 0; x < 3; x++)
            {
                //if diagonal, set to 1 else 0
                if (x == y)
                {
                    entries[y, x] = 1;
                }
                else
                {
                    entries[y, x] = 0;
                }
            }
        } 
    }

    public void setTranslationMat(float transX, float transY)
    {
        //initializing the matrix as indentity matrix
        setIdentity();

        //setting the translation matrix entries
        entries[0, 2] = transX; //translate in the x direction
        entries[1, 2] = transY; //translate in the y direction
    }

    public void setRotationMat(float rotDeg)
    {
        //initializing the matrix as indentity matrix
        setIdentity();

        //convert degrees to radians
        float rad = rotDeg * Mathf.Deg2Rad;

        //entries set based on the cosine and sine of the rotation angle
        entries[0, 0] = Mathf.Cos(rad);
        entries[0, 1] = -Mathf.Sin(rad);
        entries[1, 0] = Mathf.Sin(rad);
        entries[1, 1] = Mathf.Cos(rad);
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        {
            string result = "";
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    result += entries[r, c] + "  ";
                }
                result += "\n";
            }
            Debug.Log(result);
        }
    }
}