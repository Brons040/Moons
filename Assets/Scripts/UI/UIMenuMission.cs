using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMenuMission : MonoBehaviour {

	public UILabel description;
	public UILabel cost;
	public UILabel reward;

	// Use this for initialization
	void Start () {

	}

	public void SetLabels(Mission m){
		description.text = m.missionDescription;
		cost.text = "Fuel Cost: " + m.fuelCost;
		reward.text = m.availableResource.resourceName + " " + m.availableResource.resourceQuantity;
	}
	


	// Update is called once per frame
	void Update () {
	
	}

	public void CloseWindow(){
		this.gameObject.SetActive (false);
	}
}
