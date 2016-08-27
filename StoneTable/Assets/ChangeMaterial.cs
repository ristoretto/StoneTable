using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {
    public GameObject imageWood;
    public GameObject imageRock;
    public GameObject imageWater;

    // Use this for initialization
    void Start () { 

	}
	
	// Update is called once per frame
	void Update () {

        ItemScript.itemType tra = GameObject.Find("GameHandler").GetComponent<Game>().searchedForTypes.ToArray()[0];

        if (tra == ItemScript.itemType.Wood) {

            imageWood.SetActive(true);
            imageRock.SetActive(false);
            imageWater.SetActive(false);

        }

        if (tra == ItemScript.itemType.Rock)
        {
            imageWood.SetActive(false);
            imageRock.SetActive(true);
            imageWater.SetActive(false);
        }

        if (tra == ItemScript.itemType.Water)
        {
            imageWood.SetActive(false);
            imageRock.SetActive(false);
            imageWater.SetActive(true);
        }

    }
}
