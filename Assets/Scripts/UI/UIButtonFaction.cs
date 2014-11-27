using UnityEngine;
using System.Collections;

public class UIButtonFaction : MonoBehaviour {

    public Faction faction;

    public UILabel label;

    public int factionId;

    public UISelectFaction selectFaction;
    
    // Use this for initialization
	void Start () {
        faction = FactionStorage.Instance.factions[factionId];
        label.text = faction.factionName;
	}

    void OnClick()
    {
        //This will alert UISelectFaction to populate a full faction prefab
        selectFaction.ButtonClicked(faction);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
