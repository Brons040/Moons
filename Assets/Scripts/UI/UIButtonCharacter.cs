using UnityEngine;
using System.Collections;

public class UIButtonCharacter : MonoBehaviour {

    public UISelectCharacter selectChar;

    public UILabel label;

    public Character character;

    public int charId;


	void Start () {
        label.text = character.characterName;
	}

    void OnClick()
    {
        selectChar.ButtonClicked(this);
    }
}
