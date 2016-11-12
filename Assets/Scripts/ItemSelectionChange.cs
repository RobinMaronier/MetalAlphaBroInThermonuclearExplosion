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

	private bool waitInput = false;
	private float waitInputSecond = 0.1f;

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
		if (!this.waitInput) {
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
				StartCoroutine(this.MyCoroutine ());
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
				StartCoroutine(this.MyCoroutine ());
				this.updateSpriteMenuItem ();
			} else if (Input.GetKey (KeyCode.Return)) {
				this.activeAction ();
			}
		}
	}

	private IEnumerator MyCoroutine() {
		waitInput = true;
		yield return new WaitForSeconds (this.waitInputSecond);
		waitInput = false;
	}

	private void updateSpriteMenuItem() {
		int spriteNbr = 1;
		string spriteName = "";
		for(int i = 0; i < currentSprites.Length;  i++) {
			currentSprites [i] = uncheckedSprites [i];
		}
		currentSprites [currentSelection] = checkedSprites [currentSelection];

		this.setNewSprite (GameObject.Find ("OnePlayer"), currentSprites [0]);
		this.setNewSprite (GameObject.Find ("TwoPlayers"), currentSprites [1]);
		this.setNewSprite (GameObject.Find ("Arcade"), currentSprites [2]);
		this.setNewSprite (GameObject.Find ("Settings"), currentSprites [3]);
		this.setNewSprite (GameObject.Find ("Credits"), currentSprites [4]);
		this.setNewSprite (GameObject.Find ("Exit"), currentSprites [5]);
		this.setNewSprite (GameObject.Find ("SelectedItemLogo"), logoSprites [currentSelection]);
	}

	private void setNewSprite(GameObject sr, Sprite newSprite) {
		sr.GetComponent<SpriteRenderer> ().sprite = newSprite;
	}

	private void activeAction() {
		switch (this.currentSelection) {
		case 0: // One Player
			Application.LoadLevel ("testScene");
			break;
		case 1: // Two Players
			Application.LoadLevel ("testScene");
			break;
		case 2: // Arcade
			Application.LoadLevel ("testScene");
			break;
		case 3: //Settings
			break;
		case 4: // Credits
			break;
		case 5: // Exit
			Application.Quit ();
			break;
		default:
			break;
		}
	}
}
