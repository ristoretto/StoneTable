using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Game : MonoBehaviour {

    public Transform positionOFQue;
    public List<Transform> contentsOfQue = new List<Transform>();
    public List<Transform> allObjects = new List<Transform>();
    public float height;
    public float currentSpeed = 10;
    public float timer = 0;
    public Transform itemInHand = null;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        int current = 0;
        foreach(Transform t in contentsOfQue)
        {
            t.transform.position = new Vector3(positionOFQue.transform.position.x, positionOFQue.transform.position.y + (height * current));

            current++;
        }
        if (timer > currentSpeed)
        {
            timer = 0;
            int x = Random.Range(0, allObjects.Count);
            for (int y = 0; y < allObjects.Count; y++)
            {
                if (y == x)
                {
                    contentsOfQue.Add(allObjects.ToArray()[y]);
                    Debug.Log("An new item has spawned and neeb tewbed everyone!");
                    Instantiate(allObjects.ToArray()[y]);
                }
            }
        }
	}
}
