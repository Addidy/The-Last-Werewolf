using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HitMask : MonoBehaviour {

    public float clearRate = 1f;
    public float red = 255;
    private Image image;

	// Use this for initialization
	void Start () {
        clearRate /= 100;               //alpha layer max is one so divide any input by 100 to get a slower rate of falloff
        image = GetComponent<Image>();  //assign image
	}
	
	// Update is called once per frame
	void Update () {
        image.color = new Color(red, 0, 0, Mathf.Clamp(image.color.a - (clearRate * Time.deltaTime), 0, 1));    //lower alpha layer every frame by the falloff rate. clamp at zero
	}

    public void GetHit() {
        FindObjectOfType<Player>().GetComponentInChildren<Voice>().Speak(1);    //scream of pain
        image.color = new Color(red, 0, 0, 0.3f);                               //when you get hit show a transparent red filter (update takes it off over time)
    }
}
