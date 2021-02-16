using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TURN : MonoBehaviour
{
    Game_Manager gm;
    public Sprite my, en;
    public Test_Turn_Base trur_event;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Manager>();
        trur_event = GameObject.FindGameObjectWithTag("GM").GetComponent<Test_Turn_Base>();
        trur_event.AddEndTurnEvent(check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void check() 
    {
        if (gm.this_myTurn == true)
        {
            this.gameObject.GetComponent<Image>().sprite = my;
        }
        else if (gm.this_myTurn == false)
        {
            this.gameObject.GetComponent<Image>().sprite = en;
        }
    }
}
