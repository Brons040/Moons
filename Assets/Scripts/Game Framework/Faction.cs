using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Faction {

    public string factionName;

    public enum FactionSpeciality
    {
        Corporate,
        Research,
        Military,
        Trade
    }

    public FactionSpeciality Speciality = FactionSpeciality.Corporate;

    public enum FactionNationality
    {
        American,
        Russian,
        Chinese,
        Japanese,
        German,
        Multinational
    }

    public FactionNationality Nationality = FactionNationality.Multinational;

    public List<Character> characters;
    public Character leader;

    public int startCharacters;

    public List<FactionRelationship> relationships;

    public Planet homePlanet;

    private GameQuadrant _currQuadrant;
    public GameQuadrant currQuadrant {
        get {return _currQuadrant;} 
        set {
            if (_currQuadrant == null)
            {
                _currQuadrant = value;
                //Debug.Log(factionName + " Starting Quadrant: " + _currQuadrant.id);
                GameManager.Instance.Quadrants[currQuadrant.id].AddFaction(this);
            }
            else
            {
                GameManager.Instance.Quadrants[currQuadrant.id].RemoveFaction(this);
                _currQuadrant = value;
                //Debug.Log(factionName + " Moving to new Quadrant: " + _currQuadrant.id);
                GameManager.Instance.Quadrants[currQuadrant.id].AddFaction(this);
            }
        }
    }

    public GameResource fuel = new GameResource(GameResource.ResourceType.Fuel);
    public GameResource food = new GameResource(GameResource.ResourceType.Food);
    public GameResource water = new GameResource(GameResource.ResourceType.Water);
    public GameResource material = new GameResource(GameResource.ResourceType.Material);

    public Faction(Planet home, FactionNationality nation, FactionSpeciality speciality, string factionName, int startingCharacters)
    {
        this.homePlanet = home;       
        this.Nationality = nation;
        this.Speciality = speciality;
        this.factionName = factionName;
        this.startCharacters = startingCharacters;
        characters = new List<Character>(startCharacters);
        relationships = new List<FactionRelationship>();
        Debug.Log(characters.Capacity);
        GenerateStartingResources();
        GenerateStartingCharacters();
       // foreach (Character c in characters)
       //     Debug.Log(factionName + " " + c.characterName);
        SetQuadrant();        
    }

    public void SetQuadrant()
    {        
        this.currQuadrant = GameManager.Instance.GetCurrentQuadrant(this);
    }
    public void GenerateStartingResources()
    {
        fuel.resourceQuantity = 20 + homePlanet.fuelQuantity;
        food.resourceQuantity = 50;
        water.resourceQuantity = 20 + homePlanet.waterQuantity;
        material.resourceQuantity = 20 + homePlanet.materialQuantity;
       // Debug.Log(factionName + ": Fuel: " + fuel.resourceQuantity + " , Food: " + food.resourceQuantity + " , Water: " + water.resourceQuantity + " , Materials: " + material.resourceQuantity);

    }

    public void GenerateStartingCharacters()
    {
        for (int i = 0; i < startCharacters; i++)
        {
            if (i == 0)
            {
                Character newChar = CharacterGenerator.GenerateCharacter(true, Character.CharacterSpeciality.Scientist);                
                leader = newChar;
                characters.Add(newChar);
            }
            else
            {
                Character newChar = CharacterGenerator.GenerateCharacter(false, Character.CharacterSpeciality.Scientist);
                characters.Add(newChar);
            }
        }
    }
}
