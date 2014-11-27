using UnityEngine;
using System.Collections;

public class UITooltipCharacteristic : MonoBehaviour {

    public Characteristic characteristic;
    public UILabel label;


	void Start () {
        label.text = characteristic.type.ToString() + ": " + characteristic.value;
	}

    //Later will add OnHover functionality.
	
	
}
