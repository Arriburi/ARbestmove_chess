using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chessboard : MonoBehaviour{


    public int numOfSquares = 8;

    private float width;
    private float height;
    private float squareWidth;
    private float squareHeight;
    public Transform plane;
    
    void Awake()
    {
        InitializeGrid();
        
    }
    void InitializeGrid(){

        //this snippet under is new
        
        Renderer plane = GetComponent<Renderer>();
        Bounds bounds = plane.bounds;
        width = bounds.size.x;
        height = bounds.size.z;
        
        //width = plane.localScale.x;
        //height = plane.localScale.z;

        squareWidth = width/numOfSquares;
        squareHeight = height/numOfSquares;

    }

    public Vector2 GetLocalCoords(int x , int y){
        Debug.Log(width);

        float xLocal = x * squareWidth + squareWidth/2;
        float yLocal = y * squareHeight + squareHeight/2;

        return new Vector2(xLocal, yLocal);
    }

    void OnDrawGizmos(){

        if(squareWidth == 0 || squareHeight == 0) InitializeGrid();

        Gizmos.color = Color.green;
        float gizmoHeight = 0.25f;  // Slightly above the plane

        for(int i = 0; i <= numOfSquares; i++){
            
            Gizmos.DrawLine(new Vector3(i * squareWidth, gizmoHeight, 0), new Vector3(i * squareWidth, gizmoHeight, height));
            Gizmos.DrawLine(new Vector3(0, gizmoHeight, i * squareHeight), new Vector3(width, gizmoHeight, i * squareHeight));
        }
        
    //Drawsphere
    for (int x = 0; x < numOfSquares; x++)
    {
        for (int y = 0; y < numOfSquares; y++)
        {
            Vector2 point = GetLocalCoords(x, y);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(new Vector3(point.x, gizmoHeight, point.y), 0.15f);
        }
    }
    }

}

