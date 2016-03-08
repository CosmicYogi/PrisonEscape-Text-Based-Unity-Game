using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPlay : MonoBehaviour {

	public Text text;
	private enum States{cell,sheet_0,mirror,lock_0,cell_mirror,sheet_1,lock_1,freedom};
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);

		if (myState == States.cell) {
			state_Cell ();
		}
		if (myState == States.sheet_0){
			state_Sheet_0 ();
		}
		if (myState == States.cell_mirror) {
			state_Cell_Mirror_0 ();
		}
		if (myState == States.lock_0) {
			state_Lock_0 ();
		}

	}
	void state_Cell(){
		text.text = "You are in a prison cell and you want to escape, There are some dirty sheets" +
			" on the bed, a mirror on the wall, and the door" +
			" is locked from the outside."+
			"\n\n"+
			"S to view Sheets , M to view Mirror and L to view Lock";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheet_0;
		} 
		if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.cell_mirror;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}
	}
	void state_Sheet_0(){
		text.text = "You can't believe you sleep in these things Surely"+
			"its time somebody change them. Plesures of Prison life"+
			"Iguess ! \n \n"+
			"\nPress R to return to roming your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_Cell_Mirror_0(){
		text.text = "The Dirty old mirror on the wall seems to loose " +
		"\n\nPress T to take teh mirror,Press R to return to cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_Lock_0(){
		text.text = "This is one of those button locks you have no Idea what the combination is" +
			" so you can just see locks. YOu can just make out fingerprints around"+
			" the buttons. YOu press the dirty buttons and hear the click \n \n"+
			"Press O to open or,Press R to return to cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

}
