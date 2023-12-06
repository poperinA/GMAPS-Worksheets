using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.setIdentity();
        //mat.Print();

        Question2();
    }

    void Question2()
    {
        //declare the matrices and vector
        HMatrix2D mat1, mat2, resultMat;
        HVector2D vec1;


        //test 3x3 * 3x3 matrix multiplication

        mat1 = new HMatrix2D //3x3 matrix
            (1, 2, 3,
             4, 5, 6,
             7, 8, 9);
        
        mat2 = new HMatrix2D //3x3 matrix
            (9, 8, 7,
             6, 5, 4,
             3, 2, 1);
 
        resultMat = mat1 * mat2; //multipling the matrices

        //printing result
        Debug.Log("3x3 * 3x3 Result:");
        resultMat.Print();



        //test 3x3 * 3x1 matrix multiplication

        mat1 = new HMatrix2D //3x3 matrix
            (1, 2, 3,
             4, 5, 6,
             7, 8, 9);
       
        mat2 = new HMatrix2D //3x1 matrix (by inputting 0 in remaining spaces)
            (1, 0, 0,
             2, 0, 0,
             3, 0, 0);

        resultMat = mat1 * mat2; //multiplying the matrices

        //printing result
        Debug.Log("3x3 * 3x1 Result:");
        resultMat.Print();



        //test matrix & vector multiplication

        mat1.setIdentity(); //set mat1 to the identity matrix (to test)
        /*
        1 0 0
        0 1 0
        0 0 1
        */

        vec1 = new HVector2D(1, 2); //create a vector with values 1 and 2 (considered as a 2x1 matrix)

        HVector2D resultVec = mat1 * vec1; //multiply the matrix mat1 by the vector vec1

        //printing result
        Debug.Log("matrix & vector Result:");
        resultVec.Print();
    }


}