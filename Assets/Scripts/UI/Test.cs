using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	
	public void OnStart () {
        Character newChar = CharacterGenerator.GenerateCharacter(false, Character.CharacterSpeciality.Scientist);
       // Debug.Log(newChar.characteristics.Count + "?!");
        newChar.characterName = NameGenerator.Instance.getName();        
        GameManager.Instance.SetPlayerFaction(FactionStorage.Instance.EuropaFaction);
        Faction faction = GameManager.Instance.playerFaction;
        Debug.Log(faction.factionName + ": Fuel: " + faction.fuel.resourceQuantity + " , Food: " + faction.food.resourceQuantity + " , Water: " + faction.water.resourceQuantity + " , Materials: " + faction.material.resourceQuantity);
        foreach (FactionRelationship relation in GameManager.Instance.playerFaction.relationships)
            Debug.Log(GameManager.Instance.playerFaction.factionName + " relationship with: " + relation.faction.factionName + " State: " + relation.RelationState + " trade: " +
                relation.tradeModifier + " info: " + relation.informationModifier + " overall: " + relation.relationshipRating);
	}
	
	
}
