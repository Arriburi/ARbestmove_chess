using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chessboard : MonoBehaviour{

    public int numOfSquares = 8;

    private float width;
    private float height;
    private float squareWidth;
    private float squareHeight;
    
    void Start()
    {
        InitializeGrid();
        
    }
    void InitializeGrid(){
        width = transform.localScale.x;
        height = transform.localScale.z;

        squareWidth = width/numOfSquares;
        squareHeight = height/numOfSquares;

    }

    public Vector2 GetLocalCoords(int x , int y){
        float xLocal = (x + 0.5f) * squareWidth;
        float yLocal = (y + 0.5f) * squareHeight;

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
        
        
    // Draw a sphere at each grid center
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

