using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Game : MonoBehaviour {

    public GameObject Score;
    public Transform positionOFQue;
    public List<GameObject> contentsOfQue = new List<GameObject>();
    public List<Transform> allObjects = new List<Transform>();
    public List<Transform> containerObjects = new List<Transform>();
    public List<Transform> wasteBin = new List<Transform>();
    public GameObject scoreImage;
    public List<ItemScript.itemType> searchedForTypes = new List<ItemScript.itemType>();
    public float height;
    public int wrongs = 0;
    public int points = 0;
    public List<Sprite> imageList = new List<Sprite>();
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

        updateScore();
        updateScoreBuilding();
        timer += Time.deltaTime;
        int current = 0;
        foreach(GameObject t in contentsOfQue)
        {
            if (t != null) {

            }
            current++;
        }
        if (timer > currentSpeed)
        {
            Debug.Log(points);
            timer = 0;
            int x = Random.Range(0, allObjects.Count);
            if (contentsOfQue.Count < 5) {
                for (int y = 0; y < allObjects.Count; y++)
                {
                    if (y == x)
                    {
                        Debug.Log("An new item has spawned and neeb tewbed everyone!");
                        Object tra = Instantiate(allObjects.ToArray()[y], GameObject.Find("Canvas").transform.position, Quaternion.identity);
                        Transform tra2 = (Transform)tra;
                        tra2.SetParent(GameObject.Find("Canvas").transform);
                        tra2.transform.localScale = new Vector3(5.78f, 5.8f, 1);
                        tra2.position = new Vector3(positionOFQue.transform.position.x, 1000, 0);
                        contentsOfQue.Add(tra2.gameObject);
                        tra2.GetComponent<ItemScript>().setTravelThing(new Vector3(positionOFQue.transform.position.x, positionOFQue.transform.position.y + (128 * (contentsOfQue.Count - 1)), 0));
                    }
                }
            }
        }
	}

    public void ChangeMaterial() {
        //Din mamma hej hej
        //This is hardcoded
        //Change if you add more hardcore manaaa momomomom xoxooxoxoxox 1123121 10101010101
        Debug.Log("Changed Material!!!! xoxooxox mamamam");
        int x = Random.Range(0, 3);
        searchedForTypes.Clear();
        switch (x)
            {
                case 1:
                    searchedForTypes.Add(ItemScript.itemType.Rock);
                    break;
                case 0:
                searchedForTypes.Add(ItemScript.itemType.Wood);
                    break;
                case 2:
                searchedForTypes.Add(ItemScript.itemType.Water);
                    break;
            }
    
    }
    void updateScoreBuilding()
    {
        if (points >= 0)
        {
            scoreImage.GetComponent<Image>().sprite = imageList.ToArray()[points / 2];
        }

    }
    void updateScore() {

        Score.GetComponent<Text>().text = "StoneTable \n age " + (100 + points);
    }

}
