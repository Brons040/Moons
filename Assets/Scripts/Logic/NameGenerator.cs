using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NameGenerator : MonoBehaviour {

    public List<string> maleFirst = new List<string>();
    public List<string> femaleFirst = new List<string>();
    public List<string> Last = new List<string>();

    public string getName()
    {
        return maleFirst[Random.Range(0, maleFirst.Count)] + " " + Last[Random.Range(0, Last.Count)];
    }

    private static NameGenerator _instance;
    public static NameGenerator Instance { get{return _instance;}}
	
    void Awake(){
		_instance = this;
	}
    void Start () {        
        string line = "";
        TextAsset csv = (TextAsset)Resources.Load("Male Names");
        string[] values = new string[32];

        string[] lines = csv.text.Split(new char[] { '\n' });
        //Debug.Log("#Lines:" + lines.Length);
        foreach (string currLines in lines)
        {
            values = currLines.Split (new char[]{','});
            for(int i = 3; i < 32; i+=3){
                maleFirst.Add(values[i]);
            }            
        }

        csv = (TextAsset)Resources.Load("Female Names");
        values = new string[32];

        lines = csv.text.Split(new char[] { '\n' });
       // Debug.Log("#Lines:" + lines.Length);
        foreach (string currLines in lines)
        {
            values = currLines.Split(new char[] { ',' });
            for (int i = 3; i < 32; i += 3)
            {
                femaleFirst.Add(values[i]);
            }
        }

        csv = (TextAsset)Resources.Load("Last Names Game");
        values = new string[3];

        lines = csv.text.Split(new char[] { '\n' });
       // Debug.Log("#Lines:" + lines.Length);
        foreach (string currLines in lines)
        {
           values = currLines.Split(new char[] { ',' });
           Last.Add(values[0]);
        }

		GameManager.Instance.FactionReady ();

        //Debug.Log("Done");
	}

   
	
}
