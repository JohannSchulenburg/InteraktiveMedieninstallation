using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair
{
    public GameObject point1;
    public GameObject point2;
    public LineRenderer lr;
    public static float width = 0.1f;
    public CreatePoints2D cp2d;
    public LineManager lineManager;
    private GameObject parent;
    public Pair(int pairId, int id1, int id2){
        cp2d = GameObject.Find("PointCreator").GetComponent<CreatePoints2D>();
        lineManager = GameObject.Find("LineCreator").GetComponent<LineManager>();
        
        GameObject line = new GameObject($"Line{pairId}");
        line.transform.parent = GameObject.Find("Lines").transform;
        lr = line.AddComponent<LineRenderer>();
        lr.startWidth = width;
        lr.endWidth = width;
        lr.positionCount = 2;
        lr.material = lineManager.lineMaterial;
        point1 = cp2d.landmarkCubes[id1];
        point2 = cp2d.landmarkCubes[id2];
    }
    

}
