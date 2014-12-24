using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Faction playerFaction;

    float gameTime;

    float gameHour;

    float gameDay;

    public UILabel timeLabel;

    public bool waitOnUser = false;

    bool ready;

    public List<GameQuadrant> Quadrants = new List<GameQuadrant>
    {
        new GameQuadrant(0, 1000, 0),
        new GameQuadrant(1000, 2000, 1),
        new GameQuadrant(2000, 3000, 2),
        new GameQuadrant(3000, 4000, 3),
        new GameQuadrant(4000, 5000, 4),
        new GameQuadrant(5000, 6000, 5),
        new GameQuadrant(6000, 7000, 6),
        new GameQuadrant(7000, 8000, 7)
    };

    public List<Faction> Factions = new List<Faction>();

    void Awake()
    {
        _instance = this;
        waitOnUser = true;
    }   

    public void FactionReady()
    {  
		
        //GetComponent<Test>().OnStart();
    }

    public void SetPlayerFaction(Faction faction) {
        playerFaction = faction;
    }


    public void SetFactions(List<Faction> factions)
    {
        Factions = factions;
    }

    void Update()
    {
        if (waitOnUser)
        {
            return;
        }
        gameTime += Time.deltaTime;
        if (gameTime > 3)
        {
            gameHour++;
            gameTime = 0;
            foreach (Faction faction in Factions)
            {
                faction.homePlanet.startingLocation += faction.homePlanet.hourlySpeed;
                if (faction.homePlanet.startingLocation > 8000)
                    faction.homePlanet.startingLocation = faction.homePlanet.startingLocation % 8000;
                GameQuadrant temp = GetCurrentQuadrant(faction);
                if(faction.currQuadrant != temp)
                    faction.currQuadrant = temp;
            }
            //Mission Time
            if (gameHour == 2)
            {
                List<Mission> m = MissionManager.GenerateMissions(playerFaction);
                if (m == null)
                    Debug.Log("No Mission");
                else
                {
                    foreach (Mission miss in m){
                        miss.print();
						UIManager.Instance.ShowMission(miss);
					}

                    //Herro
                }
            }
        }
        if (gameHour >= 3)
        {
            gameDay++;
            gameHour = 0;
        }
        timeLabel.text = "Day " + (gameDay + 1) + " Time " + gameHour + ":" + gameTime.ToString("##.#");
        
    }

    public GameQuadrant GetCurrentQuadrant(Faction f)
    {
        return Quadrants[GameQuadrant.GetFactionQuadrant(f)];
    }

    public void MissionSent(Faction f, Mission m)
    {

    }

    public void MissionSent(Mission m)
    {
        UIManager.Instance.ShowMission(m);
        waitOnUser = true;
    }

    public void MissionAccepted(bool accepted)
    {
        if (accepted)
            waitOnUser = true;
        else
            waitOnUser = false;
    }


}
