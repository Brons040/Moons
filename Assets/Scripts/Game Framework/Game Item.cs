using UnityEngine;
using System.Collections;

public class GameItem {

    public GameResource cost;
    public GameResource secondaryCost;

    public GameResource upkeep;
    public GameResource production;
    public GameResource secondaryProduction;

    public string itemName;

    public int itemId;

    public int productionModifier = 1;

    public enum SpecialAbilityType
    {
        Default,
        Sensors,
        Rover        
    }

    public SpecialAbilityType Ability = SpecialAbilityType.Default;

    public GameItem(string name, int id, GameResource cost, GameResource secondaryCost, GameResource upkeep, GameResource production, GameResource secondaryProduction)    
    {

        itemName = name;
        itemId = id;
        this.cost = cost;
        this.secondaryCost = secondaryCost;
        this.upkeep = upkeep;
        this.production = production;
        this.secondaryProduction = secondaryProduction;

    }
}
