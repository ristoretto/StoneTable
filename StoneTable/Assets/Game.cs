using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour {
    public GameObject GameOver;
    public AudioSource AudioReset;
    public AudioSource AudioBuild;
    public AudioSource AudioMaterial1;
    public AudioSource AudioMaterial2;
    public AudioSource AudioMaterial3;
    public GameObject textTimer;
    public GameObject textScore;
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
    public float totalTimer = 24;
    public List<Sprite> imageList = new List<Sprite>();
    public int totalItemsSaved;
    public float currentSpeed = 0.1f;
    public float timer = 0;
    private bool stopped = false;
    public Transform itemInHand = null;
    // Use this for initialization
	void Start () {
        searchedForTypes.Add(ItemScript.itemType.Wood);

    }
    // Update is called once per frame
    void Update () {

        if (totalTimer <= 0)
        {
            if (!stopped) {
                GameOver.SetActive(true);
                //StoreHighscore(points);
                AudioReset.Play();
                foreach (GameObject o in contentsOfQue)
                {
                    Destroy(o);
                }
                contentsOfQue.Clear();
                textScore.GetComponent<Text>().text = "age " + (100 + (int)points);
                
                stopped = true;
            }
            return;
        }
        totalTimer -= Time.deltaTime;
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
                        tra2.position = new Vector3(positionOFQue.transform.position.x, 1725, 0);
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
                AudioMaterial1.Play();
                break;

            case 0:
                //wood
                switch (Random.Range(0, 3))
                {
                    case 1:
                        searchedForTypes.Add(ItemScript.itemType.Wood);
                        break;
                    case 0:
                        searchedForTypes.Add(ItemScript.itemType.Wood);
                        break;
                            case 2:
                        searchedForTypes.Add(ItemScript.itemType.Wood);
                        break;

                }
                AudioMaterial2.Play();
                break;

                case 2:
                searchedForTypes.Add(ItemScript.itemType.Water);
                AudioMaterial3.Play();
                break;
            }
    
    }
    void updateScoreBuilding()
    {
        if (points >= 0)
        {
            //AudioBuild.Play();
            scoreImage.GetComponent<Image>().sprite = imageList.ToArray()[points];
        }

    }
    void updateScore() {
        textTimer.GetComponent<Text>().text = "" + ((int)totalTimer);
    }

    public void PressReset() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
