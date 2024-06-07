using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class DrawLine : MonoBehaviour
{
    public Chessboard chessboard;
    public Vector2Int startGridPosition;
    public Vector2Int endGridPosition;
    public Transform arrowHead;
    public LineRenderer line;

    void Start(){

        float scaleFactor = 0.6f;
        arrowHead.localScale *= scaleFactor;

        Vector3 centroid = arrowHead.position;
        Vector3 lvertex = new Vector3(-0.6f, 0f, -0.5f) + centroid;  // Vertex 0 - left base
        Vector3 rvertex = new Vector3(0.6f, 0f, -0.5f) + centroid;   // Vertex 1 - right base
        Vector3 tip = new Vector3(0f, 0f, 1.0f) + centroid;          // Vertex 2 - tip
        
        Vector3 midbasevertex = (lvertex + rvertex) / 2f;
        float arrowheight = Vector3.Distance(midbasevertex, tip);
        float centertobase = Vector3.Distance(centroid, midbasevertex);

        Vector3 startPoint = GetWorldPosition(startGridPosition);
        Vector3 endPoint = GetWorldPosition(endGridPosition);
        Vector3 direction = (startPoint-endPoint).normalized;

        Vector3 shortenedEndPoint = endPoint + (direction * centertobase); 

        arrowHead.rotation = Quaternion.LookRotation(-direction);
        arrowHead.position = shortenedEndPoint;

        line.positionCount = 2;
        line.SetPosition(0, startPoint);
        line.SetPosition(1, shortenedEndPoint);
        

    }
Vector3 GetWorldPosition(Vector2Int gridPos)
{
    Vector2 localCoords = chessboard.GetLocalCoords(gridPos.x, gridPos.y);
    Vector3 offset = new Vector3(localCoords.x, 0, localCoords.y) - new Vector3(chessboard.chessboardA, 0, chessboard.chessboardB) / 2;
    return chessboard.plane.position + offset;
}

    void OnDrawGizmos(){
        //Vector3 offset = new Vector3(0.5f, 0f, 0.5f);
        //Vector3 adjustedStartPoint = startPoint + offset;
        //ector3 adjustedEndPoint = endPoint + offset;
        Gizmos.color = Color.blue;
        Vector3 startPoint = GetWorldPosition(startGridPosition);
        Vector3 endPoint = GetWorldPosition(endGridPosition);
        Gizmos.DrawLine(startPoint, endPoint);
        }       
}
