using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Game : MonoBehaviour {

    public Transform positionOFQue;
    public List<GameObject> contentsOfQue = new List<GameObject>();
    public List<Transform> allObjects = new List<Transform>();
    public List<Transform> containerObjects = new List<Transform>();
    public List<Transform> wasteBin = new List<Transform>();
    public List<ItemScript.itemType> searchedForTypes = new List<ItemScript.itemType>();
    public float height;
    public int wrongs = 0;
    public int points = 0;
    public int totalItemsSaved;
    public float currentSpeed = 3;
    public float timer = 0;
    public Transform itemInHand = null;
    // Use this for initialization
	void Start () {
        searchedForTypes.Add(ItemScript.itemType.Wood);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        int current = 0;
        foreach(GameObject t in contentsOfQue)
        {
            if (t != null) {
                t.transform.position = new Vector3(positionOFQue.transform.position.x, positionOFQue.transform.position.y + (height * current));
            }
            current++;
        }
        if (timer > currentSpeed)
        {
            Debug.Log(points);
            timer = 0;
            int x = Random.Range(0, allObjects.Count);
            for (int y = 0; y < allObjects.Count; y++)
            {
                if (y == x)
                {
                    Debug.Log("An new item has spawned and neeb tewbed everyone!");
                    Object tra = Instantiate(allObjects.ToArray()[y], GameObject.Find("Canvas").transform.position, Quaternion.identity);
                    Transform tra2 = (Transform)tra;
                    tra2.SetParent(GameObject.Find("Canvas").transform);
                    tra2.transform.localScale = new Vector3(5.78f, 5.8f, 1);
                    contentsOfQue.Add(tra2.gameObject);
                }
            }
        }
	}

    public void ChangeMaterial() {
        //Din mamma hej hej
        //This is hardcoded
        //Change if you add more hardcore manaaa momomomom xoxooxoxoxox 1123121 10101010101
        Debug.Log("Changed Material!!!! xoxooxox mamamam");
        int x = 1;/*Random.Range(0, 2);*/
            
            switch (x)
            {
                case 1:
                    searchedForTypes.ToArray()[0] = ItemScript.itemType.Rock;
                    break;
                case 0:
                    searchedForTypes.ToArray()[0] = ItemScript.itemType.Wood;
                    break;
                case 2:
                    searchedForTypes.ToArray()[0] = ItemScript.itemType.Water;
                    break;
            }
    
    }


}
