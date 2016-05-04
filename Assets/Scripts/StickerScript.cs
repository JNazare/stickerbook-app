using UnityEngine;
using System.Collections;

public class StickerScript : MonoBehaviour {

	public int i;
	private Vector3 screenPoint;
	public bool triggered = false;

	// Use this for initialization
	void Start () {

		i =  int.Parse(gameObject.name);
		gameObject.tag = "s" + i.ToString ();
		gameObject.transform.position = Startup.slots [i];
		gameObject.AddComponent<SpriteRenderer> ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = Startup.words [i];
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		gameObject.AddComponent<BoxCollider> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider other) 
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = Startup.images [i];
		triggered = true;
	}

	void OnTriggerExit (Collider other) 
	{
		Destroy(gameObject);
		triggered = false;
//		replaceSticker ();
	}

	void OnMouseDown(){

		GameObject baseSticker = GameObject.FindGameObjectWithTag("bs" + i.ToString());
		baseSticker.GetComponent<AudioSource> ().Play();
		baseSticker.GetComponent<SpriteRenderer> ().sortingOrder = 2;
	
	}
		
	void OnMouseDrag(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
		transform.position = cursorPosition;
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 2;
	}

	void OnMouseUp(){
		GameObject baseSticker = GameObject.FindGameObjectWithTag("bs" + i.ToString());
		baseSticker.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		if (triggered == false) {
			Destroy(gameObject);
		}

		replaceSticker ();
	}

	void replaceSticker(){

		GameObject[] stickers = GameObject.FindGameObjectsWithTag ("s" + i.ToString ());
		GameObject bs = GameObject.FindGameObjectWithTag ("bs" + i.ToString ());

		bool onTop = false;

		if (bs != null && stickers.Length > 0) {
			onTop = false;
			foreach (GameObject s in stickers) {
				Vector3 distance = bs.transform.position - s.transform.position;
				if (distance.x == 0.0 && distance.y == 0.0) {
					onTop = true;
				}
			}
		}
			
		Debug.Log (stickers.Length);
		if (onTop == false || stickers.Length == 0) {
			GameObject sticker = new GameObject (i.ToString ());
			sticker.AddComponent<StickerScript> ();
		}

	}

}
