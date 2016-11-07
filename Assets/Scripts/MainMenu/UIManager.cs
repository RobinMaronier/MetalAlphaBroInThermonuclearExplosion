using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadLevel(string level) {
		Application.LoadLevel(level);
	}

	public void exitGame() {
		Application.Quit ();
	}
}
