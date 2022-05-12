/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoints3D : MonoBehaviour
{
    private Vector3[] landmarks;
    public GameObject[] landmarkCubes;
    public GameObject landmarkCube;
    public ReceiveScript receiver;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        landmarks = new Vector3[33];
        landmarks = receiver.landmarks;
        landmarkCubes = new GameObject[33];
        for (int i = 0; i < 33; i++)
        {
            if(landmarks[i]!=null){
                landmarkCubes[i] = Instantiate(landmarkCube, landmarks[i]*scale, Quaternion.identity);
                landmarkCubes[i].name = $"Landmark {i}";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 33; i++)
        {
            if(landmarks[i]!=null){
                if(landmarkCubes[i]!=null){
                    landmarkCubes[i].transform.position = landmarks[i]*scale;
                    landmarkCubes[i].name = $"Landmark {i}";
                }
                else{
                    landmarkCubes[i] = Instantiate(landmarkCube, landmarks[i]*scale, Quaternion.identity);
                }
            }
        }
    }
}
 */