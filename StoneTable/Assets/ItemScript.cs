using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
    public Transform GameHandler;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameHandler.GetComponent<Game>().itemInHand != null) {
            if (GameHandler.GetComponent<Game>().itemInHand.Equals(transform))
            {
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            }
        }
	}
    void OnMouseDown()
    {
        if (GameHandler.GetComponent<Game>().itemInHand != transform) {
            GameHandler.GetComponent<Game>().itemInHand = transform;
            GameHandler.GetComponent<Game>().contentsOfQue.Remove(transform);
        }
        else
        {
            GameHandler.GetComponent<Game>().itemInHand = null;
            GameHandler.GetComponent<Game>().contentsOfQue.Add(transform);
        }
    }
}
