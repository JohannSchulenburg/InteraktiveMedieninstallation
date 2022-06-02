using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public CreatePoints2D cp2d;
    public Pair[] pairs;
    public Material lineMaterial;
    private bool isSetUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pairs = new Pair[35];
        CreatePairs();
        isSetUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSetUp){
            UpdatePairs();
        }
    }
    void CreatePairs()
    {
        pairs[0] = new Pair(0,0,1);
        pairs[1] = new Pair(1,1,2);
        pairs[2] = new Pair(2,2,3);
        pairs[3] = new Pair(3,3,7);
        pairs[4] = new Pair(4,0,4);
        pairs[5] = new Pair(5,4,5);
        pairs[6] = new Pair(6,5,6);
        pairs[7] = new Pair(7,6,8);
        pairs[8] = new Pair(8,10,9);
        pairs[9] = new Pair(9,11,13);
        pairs[10] = new Pair(10,13,15);
        pairs[11] = new Pair(11,15,17);
        pairs[12] = new Pair(12,17,19);
        pairs[13] = new Pair(13,19,15);
        pairs[14] = new Pair(14,15,21);
        pairs[15] = new Pair(15,11,12);
        pairs[16] = new Pair(16,12,14);
        pairs[17] = new Pair(17,14,16);
        pairs[18] = new Pair(18,16,18);
        pairs[19] = new Pair(19,18,20);
        pairs[20] = new Pair(20,20,16);
        pairs[21] = new Pair(21,16,22);
        pairs[22] = new Pair(22,11,23);
        pairs[23] = new Pair(23,23,25);
        pairs[24] = new Pair(24,25,27);
        pairs[25] = new Pair(25,27,29);
        pairs[26] = new Pair(26,29,31);
        pairs[27] = new Pair(27,31,27);
        pairs[28] = new Pair(28,12,24);
        pairs[29] = new Pair(29,24,23);
        pairs[30] = new Pair(30,24,26);
        pairs[31] = new Pair(31,26,28);
        pairs[32] = new Pair(32,28,30);
        pairs[33] = new Pair(33,30,32);
        pairs[34] = new Pair(34,32,28);
    }
    void UpdatePairs(){
        foreach (Pair pair in pairs)
        {
            if(pair.point1.GetComponent<MeshRenderer>().enabled && pair.point2.GetComponent<MeshRenderer>().enabled&&pair.lr != null){
                pair.lr.enabled = true;
                pair.lr.SetPosition(0, pair.point1.transform.position);
                pair.lr.SetPosition(1, pair.point2.transform.position);
            }
            else if(pair.lr != null){
                pair.lr.enabled = false;
            }
        }
    }
}
