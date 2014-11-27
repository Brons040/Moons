using UnityEngine;
using System.Collections;

public class GetSliderValue : MonoBehaviour 
{
	public UILabel lbl;
	public string addChar = "%";
	
	void Awake()
	{
		this.lbl = (UILabel)this.gameObject.GetComponent<UILabel>();			
	}
	
	void OnSliderChange (float val) 
	{
		Debug.Log("aaa");
		int vali = (int)Mathf.Round(val*100.0f);
		this.lbl.text = vali.ToString()+this.addChar;
	}
}
