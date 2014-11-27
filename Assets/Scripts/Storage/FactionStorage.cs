using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactionStorage : MonoBehaviour {

    public Faction EuropaFaction;
    public Faction IOFaction;
    public Faction IPPOFaction;
    public Faction DefaultFaction;
    public Faction GanymedeFaction;
    public Faction CallistoFaction;
    public Faction ThebeFaction;
    public Faction AnankeFaction;
    public Faction SinopeFaction;

    public List<Faction> factions;

    private static FactionStorage _instance;

    public static FactionStorage Instance { get { return _instance; } }

	void Start(){
		_instance = this;
	}

    public void MakeFactions()
    {
        //_instance = this;

        factions = new List<Faction>();

        EuropaFaction = new Faction(PlanetStorage.Europa, Faction.FactionNationality.Multinational, Faction.FactionSpeciality.Research, "Europa 7", 5);
        IOFaction = new Faction(PlanetStorage.IO, Faction.FactionNationality.American, Faction.FactionSpeciality.Corporate, "IO Mining Corporation", 7);
        IPPOFaction = new Faction(PlanetStorage.IPPO, Faction.FactionNationality.Multinational, Faction.FactionSpeciality.Trade, "Inter-Planetary Peace Organization", 7);
        DefaultFaction = new Faction(PlanetStorage.Default, Faction.FactionNationality.Russian, Faction.FactionSpeciality.Military, "Pirates", 10);

        GanymedeFaction = new Faction(PlanetStorage.Ganymede, Faction.FactionNationality.Chinese, Faction.FactionSpeciality.Corporate, "Chinese National Drilling", 8);
        SinopeFaction = new Faction(PlanetStorage.Sinope, Faction.FactionNationality.German, Faction.FactionSpeciality.Research, "German Orbital Research Facility", 5);
        AnankeFaction = new Faction(PlanetStorage.Ananke, Faction.FactionNationality.American, Faction.FactionSpeciality.Military, "US Army Space Flight Training Facility", 6);
        ThebeFaction = new Faction(PlanetStorage.Thebe, Faction.FactionNationality.Chinese, Faction.FactionSpeciality.Trade, "Inter-Planetary Emergency Supply Station", 5);
        CallistoFaction = new Faction(PlanetStorage.Callisto, Faction.FactionNationality.Russian, Faction.FactionSpeciality.Corporate, "Russian Mining Compounds", 7);


        factions.Add(EuropaFaction);
        factions.Add(IOFaction);
        factions.Add(IPPOFaction);
        factions.Add(DefaultFaction);

        factions.Add(GanymedeFaction);
        factions.Add(SinopeFaction);
        factions.Add(CallistoFaction);
        factions.Add(ThebeFaction);
        factions.Add(AnankeFaction);

        GenerateFactionRelationships();
       // GameManager.Instance.FactionReady();

        GameManager.Instance.SetPlayerFaction(EuropaFaction);

        GameManager.Instance.SetFactions(factions);

    }

    public void GenerateFactionRelationships()
    {
        foreach (Faction faction in factions)
        {
            foreach (Faction f in factions)
            {
                if (f == faction)
                    continue;
                FactionRelationship relation = new FactionRelationship(f);
                switch (faction.factionName)
                {
                    case "Pirates":
                        if (f.factionName == "Inter-Planetary Peace Organization")
                        {
                            relation.RelationState = FactionRelationship.FactionRelationState.Neutral;
                            relation.relationshipRating = 50;
                            relation.informationModifier = 40;
                            relation.tradeModifier = 50;
                        }
                        else
                        {
                            relation.RelationState = FactionRelationship.FactionRelationState.Hostile;
                            relation.relationshipRating = 25;
                            relation.informationModifier = 25;
                            relation.tradeModifier = 0;
                        }
                        faction.relationships.Add(relation);
                        break;
                    case "Inter-Planetary Peace Organization":
                        if (f.Nationality == Faction.FactionNationality.Multinational)
                        {
                            relation.RelationState = FactionRelationship.FactionRelationState.Friendly;
                            relation.relationshipRating = 75;
                            relation.informationModifier = 60;
                            relation.tradeModifier = 60;
                        }
                        else
                        {
                            relation.RelationState = FactionRelationship.FactionRelationState.Neutral;
                            relation.relationshipRating = 50;
                            relation.informationModifier = 40;
                            relation.tradeModifier = 50;
                        }
                        faction.relationships.Add(relation);
                        break;
                    default:
                        if(f.factionName == "Pirates")
                        {
                            relation.RelationState = FactionRelationship.FactionRelationState.Hostile;
                            relation.relationshipRating = 25;
                            relation.informationModifier = 25;
                            relation.tradeModifier = 0;
                            faction.relationships.Add(relation);
                            break;
                        }
                        if(faction.Nationality == Faction.FactionNationality.Multinational)
                        {
                            if(f.factionName == "Inter-Planetary Peace Organization")
                            {
                                relation.RelationState = FactionRelationship.FactionRelationState.Friendly;
                                relation.relationshipRating = 75;
                                relation.informationModifier = 60;
                                relation.tradeModifier = 60;
                            }
                            else
                            {
                                relation.RelationState = FactionRelationship.FactionRelationState.Neutral;
                                relation.relationshipRating = 50;
                                relation.informationModifier = 40;
                                relation.tradeModifier = 50;
                            }
                        }
                        else if(faction.Nationality != Faction.FactionNationality.Multinational)
                        {
                            if(f.Nationality != faction.Nationality)
                            {
                                relation.RelationState = FactionRelationship.FactionRelationState.Neutral;
                                relation.relationshipRating = 40;
                                relation.informationModifier = 15;
                                relation.tradeModifier = 30;
                            }
                            else
                            {
                                relation.RelationState = FactionRelationship.FactionRelationState.Friendly;
                                relation.relationshipRating = 75;
                                relation.informationModifier = 60;
                                relation.tradeModifier = 60;
                            }
                        }                        
                        faction.relationships.Add(relation);
                        break;
                }
            }
        }
    }

}
