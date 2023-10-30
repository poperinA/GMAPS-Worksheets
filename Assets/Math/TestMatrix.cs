using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.setIdentity();
        mat.Print();

        //Question2();
    }

     /*void Question2()
    {
        // Define the matrices and vector for testing
        HMatrix2D mat1 = new HMatrix2D();
        HMatrix2D mat2 = new HMatrix2D();
        HMatrix2D resultMat = new HMatrix2D();
        HVector2D vec1 = new HVector2D();

        // Test 3x3 * 3x3 matrix multiplication
        mat1.setIdentity();
        mat2.setIdentity();
        resultMat = mat1 * mat2;
        Debug.Log("3x3 * 3x3 Result:");
        resultMat.Print();

        // Test 3x3 * 3x1 matrix multiplication
        mat1.setIdentity();
        vec1 = new HVector2D(1, 2, 3);
        resultMat = mat1 * vec1;
        Debug.Log("3x3 * 3x1 Result:");
        resultMat.Print();
    } */
}
