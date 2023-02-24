using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    private Camera mainCamera;
    private Ray ray;
    private List<Vector3> linePoints;

    private LineRenderer line;
    public GameObject newLine;

    public float lineWidth;
    private Vector3 mousePos;

    private Collider drawArea;

    public bool canDraw;
    

    private void Start()
    {
       mainCamera = Camera.main;
       linePoints = new List<Vector3>();
    }
    
    private Vector2 GetMousePosition()
    {
        
        mousePos = Input.mousePosition;
        /*
        mousePos.x = Mathf.Clamp(mousePos.x, 478f, 1055f);
        mousePos.y = Mathf.Clamp(mousePos.y, 78f, 655f);
        print(mousePos.x + ", " + mousePos.y);
        */
        print(mousePos.x + ", " + mousePos.y +"," + mousePos.z);
        ray = mainCamera.ScreenPointToRay(mousePos);
        return ray.origin + ray.direction * 10;
    }

    private void Update()
    {
        if (!canDraw)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            /*
            newLine = new GameObject();
            line = newLine.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default"));
            line.startColor = Color.black;
            line.endColor = Color.black;
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            */
            
            newLine = Instantiate(newLine);
            line = newLine.GetComponent<LineRenderer>();
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            

        }
        if (Input.GetMouseButton(0))
        {
            //Debug.DrawRay(mainCamera.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.black);
            linePoints.Add(GetMousePosition());
            line.positionCount = linePoints.Count;
            line.SetPositions(linePoints.ToArray());
        }

        if (Input.GetMouseButtonUp(0))
        {
            linePoints.Clear();
        }
    }

    private void OnMouseOver()
    {
        canDraw = true;
    }

    private void OnMouseExit()
    {
        canDraw = false;
    }
}
