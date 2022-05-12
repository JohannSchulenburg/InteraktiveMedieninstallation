/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonText;

    [System.Serializable]
    public class Landmark{
        public int id;
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class LandmarkList{
        public Landmark[] landmarkList;
    }

    public LandmarkList myLandmarkList = new LandmarkList();

    private void Start() {
        myLandmarkList = JsonUtility.FromJson<LandmarkList>(jsonText.text);
    }
}
 */