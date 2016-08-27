using UnityEngine;
using System.Collections;

public class WasteBinEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void buttonPressTrashCan()
    {
        GameObject o = GameObject.Find("GameHandler").transform.GetComponent<Game>().contentsOfQue.ToArray()[0];
        if (o.GetComponent<ItemScript>())
        {
            foreach (ItemScript.itemType t in GameObject.Find("GameHandler").GetComponent<Game>().searchedForTypes)
            {
                if (o.GetComponent<ItemScript>().type != t)
                {
                    Destroy(o.gameObject);
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                  //  Debug.Log("Yay!");
                    break;
                }
                else
                {
                    Destroy(o.gameObject);
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().wrongs++;
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                    Debug.Log("Nooo!");
                    break;
                }
            }
        }
    }

    public void buttonPressCollector()
    {
        //Hitta den som är längst ner
        GameObject o = GameObject.Find("GameHandler").transform.GetComponent<Game>().contentsOfQue.ToArray()[0];
        if (o.GetComponent<ItemScript>())
        {
            foreach (ItemScript.itemType t in GameObject.Find("GameHandler").GetComponent<Game>().searchedForTypes)
            {
                if (o.GetComponent<ItemScript>().type == t)
                {
                    Destroy(o.gameObject);
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                    Debug.Log("Yay!");
                    addPoints();
                    GameObject.Find("GameHandler").GetComponent<Game>().ChangeMaterial();
                    break;
                }
                else
                {
                    Destroy(o.gameObject);
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().wrongs++;
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                    Debug.Log("Nooo!");
                    removePoints();
                    break;
                }
            }
        }
    }
    public void addPoints()
    {
        int amount = 1;
        GameObject.Find("GameHandler").GetComponent<Game>().points += amount;
        Debug.Log("YAYAYAYAYAYAYAYA");
    }
    public void removePoints()
    {
        int amount = -2;
        GameObject.Find("GameHandler").GetComponent<Game>().points += amount;
    }
}
