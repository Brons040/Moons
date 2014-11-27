using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameQuadrant{

    public List<Faction> currentFactions = new List<Faction>();

    int firstBound, secondBound;
    public int id;

    public GameQuadrant(int first, int second, int id)
    {
        firstBound = first;
        secondBound = second;
        this.id = id;
    }

    public void AddFaction(Faction f)
    {
        currentFactions.Add(f);
    }

    public void RemoveFaction(Faction f)
    {
        currentFactions.Remove(f);
    }

    public bool stillInBounds(int location)
    {
        if (secondBound > location && firstBound < location)
            return true;
        else
            return false;
    }

    public static int GetFactionQuadrant(Faction f)
    {
        if (0 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 1000)
            return 0;
        else if (1000 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 2000)
            return 1;
        else if (2000 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 3000)
            return 2;
        else if (3000 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 4000)
            return 3;
        else if (4000 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 5000)
            return 4;
        else if (5000 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 6000)
            return 5;
        else if (6000 < f.homePlanet.startingLocation && f.homePlanet.startingLocation < 7000)
            return 6;
        else 
            return 7;
    }
	
	
}
