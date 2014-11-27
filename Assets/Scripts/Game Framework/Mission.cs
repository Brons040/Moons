using UnityEngine;
using System.Collections;

public class Mission {

    public int actualRisk;

    public string missionDescription;

    public GameResource[] resourceCosts;

    public int missionLength;

    public int perceivedRisk;

    public GameResource[] possibleResources;

    public GameResource availableResource;

    public bool hasShips;

    public bool hasScrap;

    public bool hasWeapons;

    public bool hasResearch;

    public int diplomaticVolatility;

    public int fuelCost;

    public Mission(string missionDescrip, GameResource available, bool hasShips, bool hasWeapons, bool hasResearch, int diplomaticVolatility, int missionLength,
        int actualRisk, int perceivedRisk, int fuelCost)
    {
        availableResource = available;
        this.hasShips = hasShips;
        this.hasWeapons = hasWeapons;
        this.hasResearch = hasResearch;
        this.diplomaticVolatility = diplomaticVolatility;
        this.missionLength = missionLength;
        this.actualRisk = actualRisk;
        missionDescription = missionDescrip;
        this.perceivedRisk = perceivedRisk;
        this.fuelCost = fuelCost;
    }

    public void print(){
        Debug.Log(missionDescription + " " + availableResource.resourceName + ": " + availableResource.resourceQuantity
                        + " Risk: " + perceivedRisk + " Length: " + missionLength + " Fuel Cost: " + fuelCost);
    }
}
