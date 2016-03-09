using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Time : MonoBehaviour {

	public Text text;
	private float ftime;
	private int timeo;
	public Time temp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ftime = (UnityEngine.Time.time);
		timeo += (int)ftime;
		print (timeo);
		text.text = "" + timeo;
	}


}
