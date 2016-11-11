using UnityEngine;
using System.Collections;

public class ItemSelectionChange : MonoBehaviour {

	public bool CircularMenu = true;

	// Sprites Unchecked Items Menu
	public Sprite OneplayerUnchecked;
	public Sprite TwoplayersUnchecked;
	public Sprite ArcadeUnchecked;
	public Sprite SettingsUnchecked;
	public Sprite CreditsUnchecked;
	public Sprite ExitUnchecked;

	// Sprites Checked Items Menu
	public Sprite OneplayerChecked;
	public Sprite TwoplayersChecked;
	public Sprite ArcadeChecked;
	public Sprite SettingsChecked;
	public Sprite CreditsChecked;
	public Sprite ExitChecked;

	// Sprites Icones Checked Item Menu
	public Sprite OneplayerLogo;
	public Sprite TwoplayersLogo;
	public Sprite ArcadeLogo;
	public Sprite SettingsLogo;
	public Sprite CreditsLogo;
	public Sprite ExitLogo;

	private int currentSelection = 0;
	private Sprite[] currentSprites;
	private Sprite[] uncheckedSprites;
	private Sprite[] checkedSprites;
	private Sprite[] logoSprites;


	// Use this for initialization
	void Start () {
		currentSprites = new Sprite[] 
		{ OneplayerChecked, TwoplayersUnchecked, ArcadeUnchecked, SettingsUnchecked, CreditsUnchecked, ExitUnchecked };
		uncheckedSprites = new Sprite[]
		{ OneplayerUnchecked, TwoplayersUnchecked, ArcadeUnchecked, SettingsUnchecked, CreditsUnchecked, ExitUnchecked };
		checkedSprites = new Sprite[]
		{ OneplayerChecked, TwoplayersChecked, ArcadeChecked, SettingsChecked, CreditsChecked, ExitChecked };
		logoSprites = new Sprite[]
		{ OneplayerLogo, TwoplayersLogo, ArcadeLogo, SettingsLogo, CreditsLogo, ExitLogo };
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			if (currentSelection + 1 >= currentSprites.Length) {
				if (this.CircularMenu) {
					currentSelection = 0;
				} else {
					currentSelection = currentSprites.Length - 1;
				}
			} else {
				currentSelection++;
			}
			this.updateSpriteMenuItem ();
		} else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Z) || Input.GetKey (KeyCode.W)) {
			if (currentSelection - 1 < 0) {
				if (this.CircularMenu) {
					currentSelection = currentSprites.Length - 1;
				} else {
					currentSelection = 0;
				}
			} else {
				currentSelection--;
			}
			this.updateSpriteMenuItem ();
		} else if (Input.GetKey (KeyCode.Return)) {
			Application.LoadLevel("testScene");
		}
	}

	private void updateSpriteMenuItem() {
		int spriteNbr = 1;
		string spriteName = "";
		for(int i = 0; i < currentSprites.Length;  i++) {
			currentSprites [i] = uncheckedSprites [i];
		}
		currentSprites [currentSelection] = checkedSprites [currentSelection];
		GameObject[] itemMenu = GameObject.FindGameObjectsWithTag ("MenuItem");
		for (int i = 0; i < currentSprites.Length; i++) {
			itemMenu [itemMenu.Length - 1 - i].GetComponent<SpriteRenderer> ().sprite = currentSprites [i];
		}
		GameObject logoSelected = GameObject.FindGameObjectWithTag ("MenuItemLogo");
		logoSelected.GetComponent<SpriteRenderer> ().sprite = logoSprites [currentSelection];
	}
}
