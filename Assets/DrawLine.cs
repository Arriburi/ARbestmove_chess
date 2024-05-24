using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class DrawLine : MonoBehaviour
{
    public Chessboard chessboard;
    public Vector2Int startGridPosition;
    public Vector2Int endGridPosition;
    public Transform arrowHead;
    public LineRenderer line;

    void Start(){

        Vector3 startPoint = GetWorldPosition(startGridPosition);
        Vector3 endPoint = GetWorldPosition(endGridPosition);
        
        line.positionCount = 2;
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);

        Vector3 direction = startPoint-endPoint;
        Quaternion rotation = Quaternion.LookRotation(direction);
        arrowHead.rotation = rotation;
        arrowHead.position = endPoint;

        //arrowHead.positionCount = 2;
        //arrowHead.SetPosition(1, endPoint);

        //Vector3 middle = Vector3.Lerp(startPoint, endPoint, 0.7f);
        //line.SetPosition(1, middle);
       // arrowHead.SetPosition(0, middle);



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
