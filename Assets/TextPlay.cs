using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPlay : MonoBehaviour {

	public Text text;
	private enum States{cell,sheet_0,mirror,lock_0,cell_mirror,sheet_1,lock_1,freedom,
							coridoor_0
								};
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
		} else if (myState == States.sheet_0) {
			state_Sheet_0 ();
		} else if (myState == States.mirror) {
			state_Mirror ();
		} else if (myState == States.lock_0) {
			state_Lock_0 ();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror ();
		} else if (myState == States.sheet_1) {
			state_Sheet_1 ();
		} else if (myState == States.lock_1) {
			state_Lock_1 ();
		} else if (myState == States.freedom) {
			state_Freedom ();
		} else if (myState == States.coridoor_0) {
			state_Coridoor_0 ();
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
		else if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
		else if (Input.GetKeyDown (KeyCode.L)) {
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
	void state_Mirror(){
		text.text = "The Dirty old mirror on the wall seems to loose " +
		"\n\nPress T to take teh mirror,Press R to return to cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	void state_Lock_0(){
		text.text = "This is one of those button locks you have no Idea what the combination is" +
		"You wish you would somehow see where the dirty fingerprints were" +
		"Maybe that would help\n\n" +
		"Press R to return to roming your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_Sheet_1(){
		text.text = "Holding the mirror in your hand doesn't make the sheet look any good" +
		"\n\nPress R to return to roming you cell.";
			if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
			}
	}
	void state_Lock_1(){
		text.text = "You carefully put the mirror through the bars, and turn it round"+
			" so you can just see locks. YOu can just make out fingerprints around"+
			" the buttons. YOu press the dirty buttons and hear the click \n \n"+
			"Press O to open or,Press R to return to cell";
		if (Input.GetKeyDown (KeyCode.O)) {
			myState = States.coridoor_0;
		}
		else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	void state_cell_mirror()
	{
		text.text = "You are still in your cell, and you still want to escape!" +
		"There are some dirty sheets on the bed, a mark where the mirror was" +
		", and that pesky door is still there, and firmly locked \n\n" +
		"press S to view Sheet , L to view Lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheet_1;
		}
		if (Input.GetKeyDown(KeyCode.L))
			{
			myState = States.lock_1;
			}
	}
	void state_Freedom(){
		text.text = "YOu are free" +
		"Press P to play again";
		if (Input.GetKeyDown(KeyCode.P)){
		myState = States.freedom;
		}
	}
	void state_Coridoor_0(){
		text.text = "reached coridoor 0";
		myState = States.coridoor_0;
	}
}
