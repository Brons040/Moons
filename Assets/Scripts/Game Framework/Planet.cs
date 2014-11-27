using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public string planetName;

    public bool isAHomePlanet = false;

    public enum PlanetActual
    {
        IO,
        Europa,
        IPPO,
        Default,
        Ganymede,
        Thebe,
        Ananke,
        Callisto,
        Sinope
    }

    public PlanetActual MoonActual = PlanetActual.Default;

    public int naturalDistasterRating;

    public int qualityRating;

    public int fuelQuantity;

    public int waterQuantity;

    public int materialQuantity;

    public bool isInhabited;

    public Faction inhabitingFaction;

    public int startingLocation;

    public int hourlySpeed;

    public Planet(string planetName, PlanetActual planetActual, int disaster, int quality, int fuel, int water, int material, int start, int speed)
    {
        this.planetName = planetName;
        this.MoonActual = planetActual;
        this.naturalDistasterRating = disaster;
        this.qualityRating = quality;
        this.fuelQuantity = fuel;
        this.waterQuantity = water;
        this.materialQuantity = material;
        this.startingLocation = start;
        this.hourlySpeed = speed;
    }

}
