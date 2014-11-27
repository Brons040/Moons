using UnityEngine;
using System.Collections;

public class GameResource {

    public string resourceName;

    public int resourceQuantity;

    public string resourceUse;

    public enum ResourceType
    {
        Fuel,
        Material,
        Food,
        Water
    }

   public GameResource(GameResource.ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Fuel:
                resourceName = "Fuel";
                resourceUse = "Can be used to power ships, bases, and machines";
                break;
            case ResourceType.Water:
                resourceName = "Water";
                resourceUse = "Can be used in horticulture as well as an alternative power source given the proper research.  Primarily to keep your people from dying.";
                break;
            case ResourceType.Food:
                resourceName = "Food";
                resourceUse = "Used to feed your people, can also be used as fertilizer for horticulture.";
                break;
            case ResourceType.Material:
                resourceName = "Material";
                resourceUse = "Used to build things and to further research";
                break;               
        }
    }
}
