using UnityEngine;
using System.Collections;

public class Characteristic {

    public enum CharacteristicType
    {
        Biology,
        Chemistry,
        Physics,
        Geology,
        Pilot,
        Firefight,
        GroundDefense,
        Acumen,
        Barter,
        RiskAssessment,
        Diplomacy,
        StealthFlight,
        Gadget,
        Translation,
        Psychology
    }

    public CharacteristicType type;

    public enum CharacteristicGrouping
    {
        Scientist,
        Combatant,
        Trade,
        Spy,
        Generic
    }

    public CharacteristicGrouping group;

    public int value;

    public Characteristic(CharacteristicType type, CharacteristicGrouping group, int value)
    {
        this.value = value;
        this.type = type;
        this.group = group;
    }
	
}
