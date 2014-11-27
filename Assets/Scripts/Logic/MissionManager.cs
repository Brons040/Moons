using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour {

    /// <summary>
    /// Generates a list of mission based on the chance of a random mission, and the other factions within the quadrant.
    /// Random Mission Modifier for now is 40% because I'm not sure how often the factions will lie in the same quadrant, it's very likely
    /// this will be much higher in the future.
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
	public static List<Mission> GenerateMissions(Faction f)
    {
        bool random = false;
        List<Mission> missions = new List<Mission>();
        List<Faction> factionsInQuadrant = GameManager.Instance.Quadrants[f.currQuadrant.id].currentFactions;
       
        if (Random.Range(0, 10) <= 4)
        {
            random = true;
            //Mission newMission = MissionManager.GenerateRandomMission(f)
            missions.Add(MissionManager.GenerateRandomMission(f));
        }

        foreach (Faction opp in factionsInQuadrant)
        {
            string missionDescrip = opp.factionName + " is available for trade.";
            int fuelCost = 5 * Random.Range(1, 4);
            int actualRisk = 2 * Random.Range(1, 10);
            int perceivedRisk = actualRisk + Random.Range(1, 50 - f.leader.RiskAssessment.value);
            int missionLength = 1 * Random.Range(1, 8);
            Food resource = new Food();
            resource.resourceQuantity = (10 * Random.Range(1, 10));
            missions.Add(new Mission(missionDescrip, resource, false, false, false, 0, missionLength, actualRisk, perceivedRisk, fuelCost));     
        }
        
        if (factionsInQuadrant.Count == 0 && !random)
            return null;        
       
        return missions;
    }

    public static Mission GenerateRandomMission(Faction f)
    {
        int actualRisk = 0;
        int perceivedRisk = 0;
        int missionLength = 0;
        int fuelCost = 0;
        string missionDescrip = "";
        int missionType = Random.Range(0, 5);
        GameResource resource;
        switch (missionType)
        {
            case 0:
                //Food Mission
                missionDescrip = "A small asteroid is flying within our sensor range, plant life is detected within deep craters on the surface.";
                fuelCost = 5 * Random.Range(1, 4);
                actualRisk = 2 * Random.Range(1, 10);
                perceivedRisk = actualRisk + Random.Range(1, 50 - f.leader.RiskAssessment.value);
                missionLength = 1 * Random.Range(1, 8);
                resource = new Food();
                resource.resourceQuantity = (10 * Random.Range(1, 10));
                return new Mission(missionDescrip, resource, false, false, false, 0, missionLength, actualRisk, perceivedRisk, fuelCost);               
            case 1:
                //Water Mission
                 missionDescrip = "A large asteroid is flying within our sensor range, ice has been detected on the surface.";
                fuelCost = 5 * Random.Range(1, 4);
                actualRisk = 2 * Random.Range(1, 10);
                perceivedRisk = actualRisk + Random.Range(1, 50 - f.leader.RiskAssessment.value);
                missionLength = 1 * Random.Range(1, 8);
                resource = new Water();
                resource.resourceQuantity = (10 * Random.Range(1, 10));
                return new Mission(missionDescrip, resource, false, false, false, 0, missionLength, actualRisk, perceivedRisk, fuelCost);                
            case 2:
                //Materials Mission
                 missionDescrip = "Heat signatures have been detected by long range sensors, it has been determined that a ship was recently destroyed in this area.";
                fuelCost = 5 * Random.Range(1, 4);
                actualRisk = 5 * Random.Range(1, 10);
                perceivedRisk = actualRisk + Random.Range(1, 50 - f.leader.RiskAssessment.value);
                missionLength = 1 * Random.Range(1, 8);
                resource = new Materials();
                resource.resourceQuantity = (10 * Random.Range(1, 10));
                return new Mission(missionDescrip, resource, false, false, false, 0, missionLength, actualRisk, perceivedRisk, fuelCost);                
            case 3:
                //Fuel Mission
                 missionDescrip = "Recent excursions by our planetside rovers have revealed large pockets of methane reserves in nearby craters, these reserves could be used to replenish our fuel supply";
                fuelCost = 1 * Random.Range(1, 4);
                actualRisk = 1 * Random.Range(1, 10);
                perceivedRisk = actualRisk + Random.Range(1, 50 - f.leader.RiskAssessment.value);
                missionLength = 1 * Random.Range(1, 4);
                resource = new Fuel();
                resource.resourceQuantity = (10 * Random.Range(1, 10));
                return new Mission(missionDescrip, resource, false, false, false, 0, missionLength, actualRisk, perceivedRisk, fuelCost);                
            case 4:
                missionDescrip = "Poop in the pants";
                fuelCost = 1 * Random.Range(1, 4);
                actualRisk = 1 * Random.Range(1, 10);
                perceivedRisk = actualRisk + Random.Range(1, 50 - f.leader.RiskAssessment.value);
                missionLength = 1 * Random.Range(1, 4);
                resource = new GameResource(GameResource.ResourceType.Material);
                resource.resourceQuantity = (10 * Random.Range(1, 10));
                return new Mission(missionDescrip, resource, false, false, false, 0, missionLength, actualRisk, perceivedRisk, fuelCost);  
                
        }
        return null;
    }


}
