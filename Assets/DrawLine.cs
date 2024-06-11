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

    private Vector3 previousChessboardScale;
    private Vector3 initialArrowheadScale;

        void Start()
    {
        previousChessboardScale = Vector3.one;
        initialArrowheadScale = arrowHead.localScale * 0.6f;


        UpdateLineArrow();
        UpdateArrowhead();
    }
        void Update(){
    
        Vector3 currentChessboardScale = chessboard.plane.localScale;

            UpdateLineArrow();
            UpdateArrowhead();
            previousChessboardScale = currentChessboardScale;
    }

    void UpdateLineArrow(){

        Vector3 currentChessboardScale = chessboard.plane.localScale;

        float scaleX = currentChessboardScale.x / previousChessboardScale.x;

        line.startWidth *= scaleX;
        line.endWidth *= scaleX;
    
        Vector3 startPoint = GetWorldPosition(startGridPosition);

        line.positionCount = 2;
        line.SetPosition(0, startPoint);
        line.SetPosition(1, getShortenedEndPoint());

        previousChessboardScale = currentChessboardScale;
    }

    

    void UpdateArrowhead(){

        Vector3 currentChessboardScale = chessboard.plane.localScale;
        arrowHead.localScale = initialArrowheadScale * currentChessboardScale.x;
        ArrowheadPosition();
        
    }

    void ArrowheadPosition(){

        Vector3 startPoint = GetWorldPosition(startGridPosition);
        Vector3 endPoint = GetWorldPosition(endGridPosition);
        Vector3 direction = (startPoint - endPoint).normalized;

        arrowHead.rotation = Quaternion.LookRotation(-direction);
        arrowHead.position = getShortenedEndPoint();

    }

    
    Vector3 getShortenedEndPoint(){

        Vector3 arrowHeadScale = arrowHead.localScale;
        Vector3 centroid = arrowHead.position;

        Vector3 lvertex = Vector3.Scale(new Vector3(-0.6f, 0f, -0.5f), arrowHeadScale) + centroid;  // Vertex 0 - left base
        Vector3 rvertex = Vector3.Scale(new Vector3(0.6f, 0f, -0.5f), arrowHeadScale) + centroid;   // Vertex 1 - right base
        Vector3 tip = Vector3.Scale(new Vector3(0f, 0f, 1.0f), arrowHeadScale) + centroid;        // Vertex 2 - tip
        
        Vector3 midbasevertex = (lvertex + rvertex) / 2f;
        float centertobase = Vector3.Distance(centroid, midbasevertex);

        Vector3 startPoint = GetWorldPosition(startGridPosition);
        Vector3 endPoint = GetWorldPosition(endGridPosition);
        Vector3 direction = (startPoint-endPoint).normalized;

        Vector3 shortenedEndPoint = endPoint + (direction * centertobase); 


        return shortenedEndPoint;
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
