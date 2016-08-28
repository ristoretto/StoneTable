using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
    public Transform GameHandler;
    public Vector3 startMarker;
    public Vector3 endMarker;
    private float speed = 500.0f;
    private float startTime;
    private float journeyLength;
    public enum itemType
    {
        Wood, Rock, Water
    }
    public itemType type;
	// Use this for initialization
	void Start () {
        GameHandler = GameObject.Find("GameHandler").transform;
	}
	
    void Update()
    {
        if (startMarker != null) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
    }
   public void setTravelThing(Vector3 target)
    {
        startTime = Time.time;
        startMarker = transform.position;
        endMarker = target;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

	// Update is called once per frame
	/*void Update () {
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
            GameHandler.GetComponent<Game>().contentsOfQue.Remove(GameHandler.GetComponent<Game>().itemInHand);
        }
        else
        {
            GameHandler.GetComponent<Game>().itemInHand = null;
            GameHandler.GetComponent<Game>().contentsOfQue.Add(transform);
        }
    }*/
}
