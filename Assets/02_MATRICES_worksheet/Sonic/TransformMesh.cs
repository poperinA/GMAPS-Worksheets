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

        Translate(1f,1f);
        Rotate(45f);
    }

    void Translate(float x, float y)
    {

        // Step 1: set the transform matrix to identity
        transformMatrix.setIdentity();

        // Step 2: apply translation
        HMatrix2D translationMatrix = new HMatrix2D();
        translationMatrix.setTranslationMat(x, y);

        // Step 3: combine the matrices
        transformMatrix = translationMatrix;

        // Step 4: apply the transformation to the vertices
        Transform();

        // Step 5: update the object's position
        pos = translationMatrix * pos;
    }

    void Rotate(float angle)
    {
        // Step 1: Move to origin
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);

        // Step 2: Rotate at origin
        rotateMatrix.setRotationMat(angle);

        // Step 3: Move back from orgin
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        // Step 4: Combine the matrices
        transformMatrix.setIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
        Debug.Log(transformMatrix);
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
