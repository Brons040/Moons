using UnityEngine;
using System.Collections;

public class FactionRelationship {

    public Faction faction;    

    public FactionRelationship(Faction faction)
    {
        this.faction = faction;
    }

    public enum FactionRelationState
    {
        Hostile,
        Neutral,
        Friendly
    }

    public FactionRelationState RelationState = FactionRelationState.Neutral;

    public int relationshipRating;

    public int tradeModifier;

    public int informationModifier;
}
