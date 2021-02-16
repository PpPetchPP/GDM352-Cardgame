using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test_Turn_Base : MonoBehaviour
{
    Deck deck;
    Enermy_Trun et;
    Game_Manager gm;
    UnityEvent End_Trun = new UnityEvent();
    void Start()
    {
        et = GetComponent<Enermy_Trun>();
        gm = GetComponent<Game_Manager>();
        deck = GetComponent<Deck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End_My_Trun() 
    {
        gm.this_myTurn = false;
        End_Trun.Invoke();
        gm.pos = null;
        et.DrawCard();
        gm.Reset_Mana_Enermy();
    }
    public void End_Enermy_Trun()
    {
        gm.this_myTurn = true;
        End_Trun.Invoke();
        deck.DrawCard();
    }
    public void AddEndTurnEvent(UnityAction listener)
    {
        End_Trun.AddListener(listener);      
    }
}
