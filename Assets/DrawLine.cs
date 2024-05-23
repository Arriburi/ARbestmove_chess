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

    public LineRenderer lineRenderer;

    void Start(){

        lineRenderer = GetComponent<LineRenderer>();

        Vector3 startPoint = GetWorldPosition(startGridPosition);
        Vector3 endPoint = GetWorldPosition(endGridPosition);


        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
    Vector3 GetWorldPosition(Vector2Int gridPos)
    {
        chessboard = FindObjectOfType<Chessboard>();
        Vector2 localCoords = chessboard.GetLocalCoords(gridPos.x, gridPos.y);
        return new Vector3(localCoords.x, 0, localCoords.y); 
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
