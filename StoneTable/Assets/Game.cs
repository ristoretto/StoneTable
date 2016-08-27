using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Game : MonoBehaviour {

    public Transform positionOFQue;
    public List<Transform> contentsOfQue = new List<Transform>();
    public List<Transform> allObjects = new List<Transform>();
    public int height;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int current = 0;
        foreach(Transform t in contentsOfQue)
        {
            t.transform.position = new Vector3(positionOFQue.transform.position.x, positionOFQue.transform.position.y + (height * current));

            current++;
        }
	}
}
