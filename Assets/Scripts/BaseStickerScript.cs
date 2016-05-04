using UnityEngine;
using System.Collections;

public class BaseStickerScript : MonoBehaviour {

	public int imageIndex;
	private Vector3 screenPoint;
	private Vector3 offset;
	public GameObject sticker;

	// Use this for initialization
	void Start () {

		int i =  int.Parse(gameObject.name);
		gameObject.transform.position = Startup.slots [i];
		gameObject.AddComponent<SpriteRenderer> ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = Startup.colorwords [i];
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<AudioSource> ().clip = Startup.sounds [i];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
	}

	void OnMouseUp(){
	}
		
}
