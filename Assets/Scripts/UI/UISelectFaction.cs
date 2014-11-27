using UnityEngine;
using System.Collections;

public class UISelectFaction : MonoBehaviour {

    public UIGrid grid;

    public GameObject prefabButtonFaction;

    public UILabel factionName;
    //public UILabel factionDescription;
    public UILabel factionType;
    public UILabel factionNationality;
    public UILabel factionPlanet;
    public UILabel factionStartingChars;

    Faction factionSelected;

	
	void Start () {
        factionName.text = FactionStorage.Instance.EuropaFaction.factionName;
        //factionDescription = FactionStorage.Instance.EuropaFaction.description;
        factionType.text = "Speciality: " + FactionStorage.Instance.EuropaFaction.Speciality.ToString();
        factionNationality.text = "Nationality:" + FactionStorage.Instance.EuropaFaction.Nationality.ToString();
        factionPlanet.text = "Home: " + FactionStorage.Instance.EuropaFaction.homePlanet.planetName;
        factionStartingChars.text = "Characters: " + FactionStorage.Instance.EuropaFaction.startCharacters.ToString();        
        StartCoroutine(LoadButtons());
	}

    IEnumerator LoadButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = NGUITools.AddChild(grid.gameObject, prefabButtonFaction);
            UIButtonFaction button = go.GetComponent<UIButtonFaction>();
            button.factionId = i;
            button.selectFaction = this;

        }
        //grid.Reposition();
        yield return null;
    }

    public void ButtonClicked(Faction faction)
    {
        factionName.text = faction.factionName;
        //factionDescription = FactionStorage.Instance.EuropaFaction.description;
        factionType.text = "Speciality: " + faction.Speciality.ToString();
        factionNationality.text = "Nationality:" + faction.Nationality.ToString();
        factionPlanet.text = "Planet: " + faction.homePlanet.planetName;
        factionStartingChars.text = "Characters: " + faction.startCharacters.ToString();
        factionSelected = faction;
    }

    public void SetPlayerFaction()
    {
        GameManager.Instance.SetPlayerFaction(factionSelected);
        this.gameObject.SetActive(false);
    }
	
}
