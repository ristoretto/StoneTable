using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ItemScript : MonoBehaviour {
    public Transform GameHandler;
    public Vector3 startMarker;
    public Vector3 endMarker;
    private float speed = 2000.0f;
    private float startTime;
    private float journeyLength;

    public Sprite wood1;
    public Sprite wood2;
    public Sprite wood3;

    public Sprite rock1;
    public Sprite rock2;
    public Sprite rock3;

    public Sprite water1;
    public Sprite water2;
    public Sprite water3;

    public enum itemType
    {
        Wood, Rock, Water
    }
    public itemType type;
	// Use this for initialization
	void Start () {
        GameHandler = GameObject.Find("GameHandler").transform;
        changeMaterialImage();

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

    void changeMaterialImage() {

        if(type==itemType.Wood)
        switch (Random.Range(0, 3))
        {
            case 1:
                GetComponent<Image>().sprite = wood1;
                break;
            case 0:
                    GetComponent<Image>().sprite = wood2;
                    //searchedForTypes.Add(ItemScript.itemType.Wood);
                    break;
            case 2:
                    GetComponent<Image>().sprite = wood3;
                    //searchedForTypes.Add(ItemScript.itemType.Wood);

                    break;
        }

        if (type == itemType.Rock)
            switch (Random.Range(0, 3))
            {
                case 1:
                    GetComponent<Image>().sprite = rock1;
                    break;
                case 0:
                    GetComponent<Image>().sprite = rock2;
                    //searchedForTypes.Add(ItemScript.itemType.Wood);
                    break;
                case 2:
                    GetComponent<Image>().sprite = rock3;
                    //searchedForTypes.Add(ItemScript.itemType.Wood);

                    break;
            }

        if (type == itemType.Water)
            switch (Random.Range(0, 3))
            {
                case 1:
                    GetComponent<Image>().sprite = water1;
                    break;
                case 0:
                    GetComponent<Image>().sprite = water2;
                    //searchedForTypes.Add(ItemScript.itemType.Wood);
                    break;
                case 2:
                    GetComponent<Image>().sprite = water3;
                    //searchedForTypes.Add(ItemScript.itemType.Wood);

                    break;
            }

    }
}
