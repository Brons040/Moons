using UnityEngine;
using System.Collections;

public class UISelectCharacter : MonoBehaviour {

	// Use this for initialization

    Character currChar;

    public UIGrid grid;
    public UIGrid gridTwo;
    public GameObject prefabButtonCharacter;
    public GameObject prefabTooltipCharacter;
    Faction playerFaction;
    UIButtonCharacter currButton;

	void Start () {
        playerFaction = GameManager.Instance.playerFaction;
        StartCoroutine(LoadCharacters());
	}

    IEnumerator LoadCharacters()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("UICharacter");
        if (gameObjects == null)
            Debug.Log("No items found with tag");
        else
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                DestroyImmediate(gameObjects[i]);
            }
        }
        for (int i = 0; i < playerFaction.characters.Count; i++)
        {
            GameObject go = NGUITools.AddChild(grid.gameObject, prefabButtonCharacter);
            UIButtonCharacter button = go.GetComponent<UIButtonCharacter>();
            button.character = playerFaction.characters[i];
            button.charId = i;
            button.selectChar = this;
        }
        grid.enabled = true;
        grid.Reposition();
            yield return null;
    }

    IEnumerator LoadCharacteristics()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Characteristic Tooltip");
        if (gameObjects == null)
            Debug.Log("No items found with tag");
        else
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                DestroyImmediate(gameObjects[i]);
            }
        }
        for (int i = 0; i < currChar.characteristics.Count; i++)
        {
            Debug.Log("Count of Chars: " + currChar.characteristics.Count);
            GameObject go = NGUITools.AddChild(gridTwo.gameObject, prefabTooltipCharacter);
            UITooltipCharacteristic tooltip = go.GetComponent<UITooltipCharacteristic>();
            tooltip.characteristic = currChar.characteristics[i];            
        }
        gridTwo.enabled = true;
        gridTwo.Reposition();

        yield return null;
    }

    public void ButtonClicked(UIButtonCharacter chara)
    {
        currChar = chara.character;
        currButton = chara;
        Debug.Log("Current Character Speciality: " + currChar.Speciality);
        StartCoroutine(LoadCharacteristics());
    }

    public void RandomizeCharacter()
    {
        Debug.Log("Randomizing");
        Character newChar = CharacterGenerator.GenerateCharacter(false, currChar.Speciality);
        playerFaction.characters[currButton.charId] = newChar;
        currChar = newChar;
        Debug.Log("Current Character Speciality: " + currChar.Speciality + "!!!");
        StartCoroutine(LoadCharacteristics());
        StartCoroutine(LoadCharacters());
    }
}
