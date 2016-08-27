using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public AudioSource audio1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PressButton() {

        audio1.Play();

    }
}
