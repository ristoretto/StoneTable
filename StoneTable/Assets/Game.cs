using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Game : MonoBehaviour {

    public Transform positionOFQue;
    public List<Transform> contentsOfQue = new List<Transform>();
    public List<Transform> allObjects = new List<Transform>();
    public List<Transform> containerObjects = new List<Transform>();
    public List<Transform> wasteBin = new List<Transform>();
    public List<ItemScript.itemType> searchedForTypes = new List<ItemScript.itemType>();
    public float height;
    public int wrongs;
    public int totalItemsSaved;
    public float currentSpeed = 10;
    public float timer = 0;
    public Transform itemInHand = null;
    // Use this for initialization
	void Start () {
        searchedForTypes.Add(ItemScript.itemType.Rock);
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

                    Debug.Log("An new item has spawned and neeb tewbed everyone!");
                    Transform tra = Instantiate(allObjects.ToArray()[y]);

                    contentsOfQue.Add(tra);
                }
            }
        }
	}
}
