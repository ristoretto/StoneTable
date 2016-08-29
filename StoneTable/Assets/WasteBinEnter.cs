using UnityEngine;
using System.Collections;

public class WasteBinEnter : MonoBehaviour {

    public AudioSource audioHorn;
    public GameObject woodAnimation;
    public GameObject rockAnimation;
    public GameObject waterAnimation;
    public GameObject stopAnimation;


    // Use this for initialization
    void Start () {
        //NOTE: Bypassing bug when a public audio source is not registrated! 
        audioHorn = GameObject.Find("WrongMaterialSound").GetComponent<AudioSource>();
        woodAnimation = GameObject.Find("WoodAnimation");
        rockAnimation = GameObject.Find("RockAnimation");
        waterAnimation = GameObject.Find("WaterAnimation");
        stopAnimation = GameObject.Find("Wrong");
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
                    updateThings();
                    break;
                }
                else
                {
                    Destroy(o.gameObject);
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().wrongs++;
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                    Debug.Log("Nooo!");
                    updateThings();
                    break;
                }
            }
        }
    }
    public void updateThings()
    {
        Game game = GameObject.Find("GameHandler").GetComponent<Game>();
        int count = 0;
        foreach (GameObject o in game.contentsOfQue)
        {
            o.GetComponent<ItemScript>().setTravelThing(new Vector3(GameObject.Find("PositionOfQue").transform.position.x, GameObject.Find("PositionOfQue").transform.position.y + (128 * (count)), 0));
            count++;
        }
        //tra2.GetComponent<ItemScript>().setTravelThing(new Vector3(positionOFQue.transform.position.x, positionOFQue.transform.position.y + (128 * (contentsOfQue.Count - 1)), 0));
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

                    spawnGoodSign();
                    Destroy(o.gameObject);
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                    //Debug.Log("Yay!");
                    addPoints();
                    updateThings();
                    GameObject.Find("GameHandler").GetComponent<Game>().ChangeMaterial();
                    break;
                }
                else
                {

                    Destroy(o.gameObject);
                    o.GetComponent<ItemScript>().GameHandler.GetComponent<Game>().wrongs++;
                    GameObject.Find("GameHandler").GetComponent<Game>().contentsOfQue.Remove(o);
                    //Debug.Log("Nooo!");
                    removePoints();
                    updateThings();
                    break;
                }
            }
        }
    }
    public void addPoints()
    {
        int amount = 1;
        GameObject.Find("GameHandler").GetComponent<Game>().points += amount;
        //Debug.Log("YAYAYAYAYAYAYAYA");

        


    }
    public void removePoints()
    {
        int amount = -2;
        GameObject.Find("GameHandler").GetComponent<Game>().points += amount;
        //Insert negative sound
        audioHorn.Play();
        stopAnimation.GetComponent<Animator>().SetTrigger("Start");

    }

    public void spawnGoodSign() {

        GameObject o = GameObject.Find("GameHandler").transform.GetComponent<Game>().contentsOfQue.ToArray()[0];

        if (o.GetComponent<ItemScript>().type == ItemScript.itemType.Rock) {

            rockAnimation.GetComponent<Animator>().SetTrigger("Fade");
            Debug.Log("rock");
                
        }

        if (o.GetComponent<ItemScript>().type == ItemScript.itemType.Wood)
        {

            Debug.Log("wood");
            woodAnimation.GetComponent<Animator>().SetTrigger("Fade");

        }

        if (o.GetComponent<ItemScript>().type == ItemScript.itemType.Water)
        {
            waterAnimation.GetComponent<Animator>().SetTrigger("Fade");
            Debug.Log("water");

        }

    }
}
