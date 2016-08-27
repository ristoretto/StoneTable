using UnityEngine;
using System.Collections;

public class WasteBinEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void buttonPress()
    {
        Transform o = GameObject.Find("GameHandler").transform.GetComponent<Game>().contentsOfQue.ToArray()[0].transform;
        Debug.Log("Hello");
        if (o.GetComponent<ItemScript>())
        {
            foreach (ItemScript.itemType t in GameObject.Find("GameHandler").GetComponent<Game>().searchedForTypes)
            {
                if (o.GetComponent<ItemScript>().type == t)
                {
                    Destroy(o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().itemInHand);
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().itemInHand = null;
                    Debug.Log("Yay!");
                }
                else
                {
                    Destroy(o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().itemInHand);
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().itemInHand = null;
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().wrongs++;
                    Debug.Log("Nooo!");
                }
            }
        }
    }
}
