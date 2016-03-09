using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPlay : MonoBehaviour {

	public Text text;
	private enum States{cell,sheet_0,mirror,lock_0,cell_mirror,sheet_1,lock_1,freedom,
							coridoor_0,
							stairs_0,closet_door,floor,coridoor_1,stairs_1,in_closet,coridoor_2,stairs_2,coridoor_3,courtyard,
								gameOver
								};
	private States myState;

	public Text texttime;
	private float ftime;
	private int timeo;
	public Time temp;
	public int maxTime=30;
	int timeRemaining;
	int tempAdder=0;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);

		if (myState == States.cell) {
			Cell ();
		} else if (myState == States.sheet_0) {
			Sheet_0 ();
		} else if (myState == States.mirror) {
			Mirror ();
		} else if (myState == States.lock_0) {
			Lock_0 ();
		} else if (myState == States.cell_mirror) {
			cell_mirror ();
		} else if (myState == States.sheet_1) {
			Sheet_1 ();
		} else if (myState == States.lock_1) {
			Lock_1 ();
		} else if (myState == States.freedom) {
			Freedom ();
		} else if (myState == States.coridoor_0) {
			Coridoor_0 ();
		} else if (myState == States.stairs_0) {
			stairs_0 ();
		} else if (myState == States.closet_door) {
			closet_Door ();
		} else if (myState == States.floor) {
			floor ();
		} else if (myState == States.coridoor_1) {
			coridoor_1 ();
		} else if (myState == States.stairs_1) {
			stairs_1 ();
		} else if (myState == States.in_closet) {
			inCloset ();
		} else if (myState == States.coridoor_2) {
			coridoor_2 ();
		} else if (myState == States.stairs_2) {
			stairs_2 ();
		} else if (myState == States.coridoor_3) {
			coridoor_3 ();
		} else if (myState == States.courtyard) {
			courtyard ();
		} else if (myState == States.gameOver) {
			gameOver ();
		}
			

		// Timer Programming Starts from Here

		ftime = UnityEngine.Time.time;
		timeo = (int)ftime;
		timeRemaining = maxTime - timeo+ tempAdder;
		if (timeRemaining == 0) {
			myState = States.gameOver;
			tempAdder = Mathf.Abs (timeo);
			//tempAdder = tempAdder + maxTime + Mathf.Abs(timeRemaining);
		} else {
			print (timeo);
			texttime.text = timeRemaining + " : Seconds to Break Out of Prison";
		}

		//Timer Programming Ends Here
	}
	void Cell(){
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
	void Sheet_0(){
		text.text = "You can't believe you sleep in these things Surely"+
			"its time somebody change them. Plesures of Prison life"+
			"Iguess ! \n \n"+
			"\nPress R to return to roming your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	void Mirror(){
		text.text = "The Dirty old mirror on the wall seems to loose " +
		"\n\nPress T to take teh mirror,Press R to return to cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	void Lock_0(){
		text.text = "This is one of those button locks you have no Idea what the combination is" +
		"You wish you would somehow see where the dirty fingerprints were" +
		"Maybe that would help\n\n" +
		"Press R to return to roming your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	void Sheet_1(){
		text.text = "Holding the mirror in your hand doesn't make the sheet look any good" +
		"\n\nPress R to return to roming you cell.";
			if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
			}
	}
	void Lock_1(){
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
	void cell_mirror()
	{
		text.text = "You are still in your cell, and you still want to escape!" +
		"There are some dirty sheets on the bed, a mark where the mirror was" +
		", and that pesky door is still there, and firmly locked \n\n" +
		"press S to view Sheet , L to view Lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheet_1;
		}
		else if (Input.GetKeyDown(KeyCode.L))
			{
			myState = States.lock_1;
			}
	}
	void Freedom(){
		text.text = "YOu are free" +
		"Press P to play again";
		if (Input.GetKeyDown(KeyCode.P)){
		myState = States.freedom;
		}
	}

	// Seond phase functions starts from Here.
	void Coridoor_0(){
		text.text = "You're out of your cell, but not out of trouble." +
				"You are in the corridor, there's a closet and some stairs leading to " + 
				"the courtyard. There's also various detritus on the floor.\n\n" +
				"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
		myState = States.coridoor_0;
		//stair floor closet
		if (Input.GetKeyDown (KeyCode.S)) {
			stairs_0 ();
		} else if (Input.GetKeyDown (KeyCode.F)) {
			floor ();
		} else if (Input.GetKeyDown (KeyCode.C)) {
			closet_Door ();
		}
	}

	// this coridoor_0 is a bridge between code above and below this line.

	void stairs_0(){
		text.text = "You start walking up the stairs towards the outside light. " +
			"You realise it's not break time, and you'll be caught immediately. " + 
			"You slither back down the stairs and reconsider.\n\n" +
			"Press R to Return to the corridor." ;
		myState = States.stairs_0;
		if (Input.GetKeyDown (KeyCode.R)) {
			Coridoor_0 ();
		}
	}
	void floor(){
		text.text = "Rummagaing around on the dirty floor, You find a hair clip\n\n"+
			"Press R to return to the standing or H to pick up the hair clip";
		myState = States.floor;
		if (Input.GetKeyDown (KeyCode.R)) {
			Coridoor_0 ();
		}
		else if (Input.GetKeyDown (KeyCode.H)) {
			coridoor_1 ();
		}

	}
	void closet_Door(){
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
			"Maybe you could find something around to help enourage it open?\n\n" +
			"Press R to Return to the corridor";
		myState = States.closet_door;
		if (Input.GetKeyDown (KeyCode.R)) {
			Coridoor_0 ();
		}
	}


	void coridoor_1(){
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
			"Now what? You wonder if that lock on the closet would succumb to " + 
			"to some lock-picking?\n\n" +
			"P to Pick the lock, and S to climb the stairs";
		myState = States.coridoor_1;
		if (Input.GetKeyDown(KeyCode.S)){
			stairs_1();
		}
		else if (Input.GetKeyDown (KeyCode.P)) {
			inCloset ();
		}
	}

	void stairs_1(){
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs" ;
		myState = States.stairs_1;
		if (Input.GetKeyDown (KeyCode.R)) {
			coridoor_1 ();
		}
	}

	void inCloset(){
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
			"Seems like your day is looking-up.\n\n" +
			"Press D to Dress up, or R to Return to the corridor";
		myState = States.in_closet;
		if (Input.GetKeyDown (KeyCode.D)) {
			coridoor_3 ();
		}
		else if (Input.GetKeyDown (KeyCode.R)) {
			coridoor_2 ();
		}
	}

	void coridoor_2(){
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
			"Press C to revisit the Closet, and S to climb the stairs";
		myState = States.coridoor_2;
		if (Input.GetKeyDown (KeyCode.S)) {
			stairs_2 ();
		} else if (Input.GetKeyDown (KeyCode.C)) {
			inCloset ();
		}
	}

	void stairs_2(){
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
			"a hairclip (now badly bent). Even these achievements together don't give " +
			"you the courage to climb up the staris to your death!\n\n" +
			"Press R to Return to the corridor";
		myState = States.stairs_2;
		if (Input.GetKeyDown (KeyCode.R)) {
			coridoor_2 ();
		}
	}

	void coridoor_3(){
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
			"You strongly consider the run for freedom.\n\n" +
			"Press S to take the Stairs, or U to Undress";
		myState = States.coridoor_3;
		if (Input.GetKeyDown (KeyCode.S)) {
			courtyard ();
		}
		else if (Input.GetKeyDown (KeyCode.U)) {
			inCloset ();
		}
	}
	void courtyard(){
		text.text = "You walk through the courtyard dressed as a cleaner. " +
			"The guard tips his hat at you as you waltz past, claiming " + 
			"your freedom. You heart races as you walk into the sunset.\n\n" +
			"Press P to Play again." ;
		myState = States.courtyard;
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
		}
	}

	void gameOver(){
		text.text = "GAME OVER" +
		"\n\n" +
		"Press P to play again";
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
			tempAdder = Mathf.Abs (timeo);
			//tempAdder = tempAdder + maxTime;
		}
	}
	void FixedUpdate(){

	}
}
//Programmed with love by MITESH SONI.
//Please feel free to contribute if you want to something even a new story is worth.