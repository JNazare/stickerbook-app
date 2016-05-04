using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

	public static Sprite[] words;
	public static Sprite[] colorwords;
	public static Sprite[] images;
	public static AudioClip[] sounds;

	public static Vector2[] slots;
	public int imageIndex;

	void Awake() {

		Camera camera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
		float worldX = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)).x;
		float worldY = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0)).y;

		words = Resources.LoadAll <Sprite> ("Stickers/Words");
		colorwords = Resources.LoadAll <Sprite> ("Stickers/ColorWords");
		images = Resources.LoadAll <Sprite> ("Stickers/Images");
		sounds = Resources.LoadAll <AudioClip> ("Stickers/Sounds");

		GameObject frame = GameObject.FindGameObjectWithTag ("frame");
		frame.transform.position = new Vector3 (worldX/5, 0, 0);

		GameObject backdrop = GameObject.FindGameObjectWithTag ("backdrop");
		backdrop.transform.position = new Vector3 (worldX/5, 0, 0);

		slots = new Vector2[words.Length];

		float xpos = -5f;
		float ypos = -3.5f;

		for (int i = 0; i < words.Length; i++) {
			slots [i] = new Vector2 (xpos, ypos);
			GameObject baseSticker = new GameObject (i.ToString());
			GameObject sticker = new GameObject (i.ToString ());
			baseSticker.tag = "bs" + i.ToString ();
			sticker.tag = "s" + i.ToString ();
			baseSticker.AddComponent<BaseStickerScript> ();
			sticker.AddComponent<StickerScript> ();
			ypos = ypos + 1.5f;
		}
			

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
