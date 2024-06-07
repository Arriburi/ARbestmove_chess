using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chessboard : MonoBehaviour{


    public int numOfSquares = 8;

    private float squareA;
    private float squareB;
    public float chessboardA;
    public float chessboardB;

    public Transform target1;
    public Transform target2;

    public Transform plane;

    
    void Awake()
    {
        InitializeGrid();
         OnDrawGizmos();
    }
    void InitializeGrid()
    {
        Bounds bounds = new Bounds(target1.position, Vector3.zero);
        bounds.Encapsulate(target2.position);
        
        Vector3 size = bounds.size/10; //PLANE TOO BIG unity scales by 10 ??
        plane.localScale = new Vector3(size.x, plane.localScale.y, size.z);

        plane.position = bounds.center;

        chessboardA = bounds.size.x;
        chessboardB = bounds.size.z;

        squareA = chessboardA/numOfSquares;
        squareB = chessboardB/numOfSquares;


    }   


    public Vector2 GetLocalCoords(int x , int y){

        float xLocal = x * squareA + squareA/2;
        float yLocal = y * squareB + squareB/2;

        return new Vector2(xLocal, yLocal);
    }

    void OnDrawGizmos(){

    Gizmos.color = Color.green;
    float gizmoHeight = 0.25f;  // Slightly above the plane

    for (int i = 0; i <= numOfSquares; i++)
    {
        Gizmos.DrawLine(plane.position + new Vector3(i * squareA - chessboardA / 2, gizmoHeight, -chessboardB / 2),
                         plane.position + new Vector3(i * squareA - chessboardA / 2, gizmoHeight, chessboardB / 2));

        Gizmos.DrawLine(plane.position + new Vector3(-chessboardA / 2, gizmoHeight, i * squareB - chessboardB / 2),
                         plane.position + new Vector3(chessboardA / 2, gizmoHeight, i * squareB - chessboardB / 2));
    }

        
    //Drawsphere
    for (int x = 0; x < numOfSquares; x++)
    {
        for (int y = 0; y < numOfSquares; y++)
        {
            Vector2 point = GetLocalCoords(x, y);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(plane.position + new Vector3(point.x - chessboardA / 2, gizmoHeight, point.y - chessboardB / 2), 0.15f);
        }
    }
    Gizmos.color = Color.cyan;
    Vector2 pointzero = GetLocalCoords(0,0);
    Gizmos.DrawSphere(plane.position + new Vector3(pointzero.x - chessboardA / 2, gizmoHeight, pointzero.y - chessboardB / 2), 0.15f);
    
    }
    
}

