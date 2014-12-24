using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	//Prefabs
    public GameObject prefabMission;
    public GameObject prefabAlert;
    public GameObject prefabConfirm;
    public GameObject prefabCharacter;
    public GameObject prefabPlanet;
    public GameObject prefabFactionRelationship;
	//public GameObject prefabMissionMenu;
	public UIMenuMission missionMenu;

    public enum UIState
    {
        MainMenu,
        Game,
        Mission,
        Trade
    }

    public UIState State = UIState.MainMenu;

    private static UIManager _instance;

    public static UIManager Instance {get {return _instance;} }


    void Awake()
    {
        _instance = this;
    }
   
	void Start () {
	
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			Debug.Log ("Eat a dick ms. saddat");
		}
	}

    public void NewGame()
    {
        //FactionStorage.Instance.MakeFactions();
        GameManager.Instance.waitOnUser = false;
    }

    public void Alert(string message)
    {

    }

    public void Confirm(string message)
    {

    }

    public void ShowMission(Mission mission)
    {
		//prefabMissionMenu.gameObject.SetActive (true);
		missionMenu.gameObject.SetActive (true);
		missionMenu.SetLabels (mission);
    }

    public void SetLocalWidgetActive(GameObject go)
    {
        go.SetActive(true);

    }
}
