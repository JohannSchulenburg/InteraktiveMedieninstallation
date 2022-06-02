using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoints2D : MonoBehaviour
{
    private Landmark[] landmarks;
    public GameObject[] landmarkCubes;
    public GameObject landmarkCube;
    public float[] cooldowns;
    public ReceiveScript receiver;
    public float scale;
    public GameObject parent;
    public GameObject lineCreator;
    // Start is called before the first frame update
    void Start()
    {
        landmarks = new Landmark[33];
        landmarks = receiver.landmarks;
        landmarkCubes = new GameObject[33];
        for (int i = 0; i < 33; i++)
        {
            if (landmarks[i].pos != Vector3.zero)
            {
                CreatePoint(i);
                landmarkCubes[i].name = $"Landmark {i}";
            }
        }
        Invoke("ActivateLineCreator", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 33; i++)
        {
            if (landmarkCubes[i] != null)
            {
                //a kind of state system, that evaluates whether or not the landmark is still being updated
                //if two adjacent landmarks are active, draw the connection between the two. If a landmark is inactive, disable it
                //on the event that a disabled position gets updated by the ReceiveScript, turn the landmark Cube active
                landmarkCubes[i].transform.position = new Vector3(-landmarks[i].pos.x, -landmarks[i].pos.y, 0) * scale;
                landmarkCubes[i].name = $"Landmark {i}";
            }
            else
            {
                CreatePoint(i);
            }
            if(landmarks[i].cooldown > 0){
                landmarks[i].cooldown -= Time.deltaTime;
                landmarkCubes[i].GetComponent<MeshRenderer>().enabled = true;
            }
            else{
                landmarks[i].cooldown = 0;
                landmarkCubes[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    void CreatePoint(int id){
        landmarkCubes[id] = Instantiate(landmarkCube, new Vector3(-landmarks[id].pos.x, -landmarks[id].pos.y, 0) * scale, Quaternion.identity);
        //landmarkCubes[id].transform.parent = parent.transform;
    }
    void ActivateLineCreator(){
        lineCreator.SetActive(true);
    }
}
