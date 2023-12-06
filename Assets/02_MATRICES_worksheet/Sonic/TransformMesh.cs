//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        // Your code here
    }


    void Translate(float x, float y)
    {
        transformMatrix.setIdentity();
        //code.SetTranslationMatrix(code);
        Transform();

        pos = //code * pos;
    }

    void Rotate(float angle)
    {
        transformMatrix.setIdentity();

        // Step 1: move to the origin
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);

        // Step 2: rotate
        rotateMatrix.setRotationMat(angle);

        // Step 3: move back from the origin
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        // Step 4: combine the matrices
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

       Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            //convert each vertex to homogeneous coordinates
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);

            //apply the transformation
            vert = transformMatrix * vert;

            //update the vertex position
            vertices[i] = new Vector3(vert.x, vert.y, 0);
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
