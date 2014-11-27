using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    public string characterName;   

    public enum CharacterNationality
    {
        American,
        Russian,
        Chinese,
        German,
        Japanese
    }

    public CharacterNationality Nationality = CharacterNationality.American;

    public enum CharacterSpeciality
    {
        Scientist,
        Combatant,
        Trader,
        Spy,
        Default
    }

    public CharacterSpeciality Speciality = CharacterSpeciality.Default;

    public enum CharacterRank
    {
        Leader,
        Officer,
        Default
    }

    public List<Characteristic> characteristics = new List<Characteristic>();

    //Science Characteristics    

    public Characteristic Biology = new Characteristic(Characteristic.CharacteristicType.Biology, Characteristic.CharacteristicGrouping.Scientist, 0);
    public Characteristic Physics = new Characteristic(Characteristic.CharacteristicType.Physics, Characteristic.CharacteristicGrouping.Scientist, 0);
    public Characteristic Chemistry = new Characteristic(Characteristic.CharacteristicType.Chemistry, Characteristic.CharacteristicGrouping.Scientist, 0);
    public Characteristic Geology = new Characteristic(Characteristic.CharacteristicType.Geology, Characteristic.CharacteristicGrouping.Scientist, 0);   

    //Combatant Characteristics
    public Characteristic Pilot = new Characteristic(Characteristic.CharacteristicType.Pilot, Characteristic.CharacteristicGrouping.Combatant, 0);
    public Characteristic Firefight = new Characteristic(Characteristic.CharacteristicType.Firefight, Characteristic.CharacteristicGrouping.Combatant, 0);
    public Characteristic GroundDefense = new Characteristic(Characteristic.CharacteristicType.GroundDefense, Characteristic.CharacteristicGrouping.Combatant, 0);     

    //Trader Characteristics
    public Characteristic Acumen = new Characteristic(Characteristic.CharacteristicType.Acumen, Characteristic.CharacteristicGrouping.Trade, 0);
    public Characteristic Barter = new Characteristic(Characteristic.CharacteristicType.Barter, Characteristic.CharacteristicGrouping.Trade, 0);
    public Characteristic RiskAssessment = new Characteristic(Characteristic.CharacteristicType.RiskAssessment, Characteristic.CharacteristicGrouping.Trade, 0);
    public Characteristic Diplomacy = new Characteristic(Characteristic.CharacteristicType.Diplomacy, Characteristic.CharacteristicGrouping.Trade, 0);   

    //Spy Characteristics
    public Characteristic StealthFlight = new Characteristic(Characteristic.CharacteristicType.StealthFlight, Characteristic.CharacteristicGrouping.Spy, 0);
    public Characteristic Gadget = new Characteristic(Characteristic.CharacteristicType.Gadget, Characteristic.CharacteristicGrouping.Spy, 0);
    public Characteristic Translation = new Characteristic(Characteristic.CharacteristicType.Translation, Characteristic.CharacteristicGrouping.Spy, 0);
    public Characteristic Psychology = new Characteristic(Characteristic.CharacteristicType.Psychology, Characteristic.CharacteristicGrouping.Spy, 0);
    
    // Use this for initialization
	public Character() {
        characteristics.Add(Biology);
        characteristics.Add(Chemistry);
        characteristics.Add(Geology);
        characteristics.Add(Physics);
        characteristics.Add(StealthFlight);
        characteristics.Add(Gadget);
        characteristics.Add(Translation);
        characteristics.Add(Psychology);
        characteristics.Add(Acumen);
        characteristics.Add(Barter);
        characteristics.Add(RiskAssessment);
        characteristics.Add(Diplomacy);
        characteristics.Add(Pilot);
        characteristics.Add(Firefight);
        characteristics.Add(GroundDefense);
	}
	
}
