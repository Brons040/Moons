using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CharacterGenerator {


    //stats are 1-25.  Total stat points will be rolled between 40-80, with half being allocated to speciality skills.  Leaders are assigned
    //an extra 5 points to thing like riskAssessment, Diplomacy, and Acumen.  Leaders also roll between 60-80.
    public static Character GenerateCharacter(bool isLeader, Character.CharacterSpeciality speciality)
    {
        Character newChar = new Character();
        int assignPoints = 0;
        int totalPoints = Random.Range(40, 80);
        if (isLeader)
            totalPoints = Random.Range(60, 80);       
        int specialityPoints = totalPoints / 2;
        totalPoints = totalPoints = specialityPoints;
        List<Characteristic> chars = newChar.characteristics;
        List<Characteristic> special = new List<Characteristic>();
        switch (speciality)
        {
            case Character.CharacterSpeciality.Scientist:
                foreach(Characteristic charact in chars){
                    //Debug.Log(charact.type);
                    if (charact.group == Characteristic.CharacteristicGrouping.Scientist) {
                        special.Add(charact);
                        //chars.Remove(charact);
                    }
                }
                foreach (Characteristic charact in special)
                    chars.Remove(charact);
                special = CharacterGenerator.Shuffle(special);
                for (int i = 0; i < special.Count; i++)
                {

                    if (i == special.Count - 1)
                    {
                        special[i].value = specialityPoints;
                        break;
                    }
                    if (specialityPoints > 25)
                        assignPoints = Random.Range(0, 25);
                    else
                        assignPoints = Random.Range(0, specialityPoints);
                    special[i].value = assignPoints;
                    specialityPoints -= assignPoints;
                }                             
                break;
        }
        chars = CharacterGenerator.Shuffle(chars);
        for (int i = 0; i < chars.Count; i++)
        {
            if (totalPoints == 0)
                break;

            if (i == chars.Count - 1)
            {
                chars[i].value = totalPoints;
                break;
            }
            if (totalPoints > 10)
                assignPoints = Random.Range(0, 10);
            else
                assignPoints = Random.Range(0, totalPoints);
            chars[i].value = assignPoints;
            totalPoints -= assignPoints;
        }   
		chars.AddRange (special);
		newChar.characteristics = chars;
        newChar.characterName = NameGenerator.Instance.getName();
        return newChar;
    }

    public static List<Characteristic> Shuffle(List<Characteristic> characts)
    {
        List<Characteristic> newCharacts = new List<Characteristic>();
        for (int i = characts.Count - 1; i >= 0; i--)
        {
            Characteristic charact = characts[Random.Range(0, i)];
            characts.Remove(charact);
            newCharacts.Add(charact);
        }
        return newCharacts;
    }
}
