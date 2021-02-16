using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Short_Deck_Canvas;
    public GameObject Map_Canvas;
    public GameObject Reward_Canvas;
    public GameObject Exits_Canvas;
    public GameObject Shop_Canvas;
    public GameObject Event_Canvas;
    public Text coin;
    [SerializeField] Scene_manage scene_;
    GameObject card_bot;
    GameObject g;
    [SerializeField] Transform scoll;
    List<GameObject> inven_obj = new List<GameObject>();
    bool Open_SDC , Open_Map ,Open_Exits,Open_Shop,Open_Event= false;
    void Start()
    {
        scene_ = GetComponent<Scene_manage>();
        Map_Canvas.SetActive(true);
        Open_Map = true;


        if (scene_.Get_Reward() == true) 
        {
            card_bot = scoll.GetChild(0).gameObject;
            for (int i = 0; i < 3; i++)
            {
                g = Instantiate(card_bot, scoll);
                inven_obj.Add(g);
            }
            Destroy(card_bot);
            Reward_Canvas.SetActive(true);           
        }
    }

    public void Set_Got_Reward() 
    {
        scene_.Set_Reward(true);
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = "Coin : "+scene_.Get_Coin().ToString();
    }

    public void Open_Short_Deck_Canvas() 
    {
        if (Open_SDC == false)
        {
            Short_Deck_Canvas.SetActive(true);
            Open_SDC = true;
            if (Open_Map == true)
            {
                Map_Canvas.SetActive(false);
                Open_Map = false;
            }
            if (Open_Exits == true)
            {
                Exits_Canvas.SetActive(false);
                Open_Exits = false;
            }
            if (Open_Shop == true)
            {
                Shop_Canvas.SetActive(false);
                Open_Shop = false;
            }
            if (Open_Event == true)
            {
                Event_Canvas.SetActive(false);
                Open_Event = false;
            }
        }
    }

    public void Open_Map_Canvas()
    {
        if (Open_Map == false)
        {
            Map_Canvas.SetActive(true);
            Open_Map = true;
            if (Open_SDC == true)
            {
                Short_Deck_Canvas.SetActive(false);
                Open_SDC = false;
            }
            if (Open_Exits == true)
            {
                Exits_Canvas.SetActive(false);
                Open_Exits = false;
            }
            if (Open_Shop == true)
            {
                Shop_Canvas.SetActive(false);
                Open_Shop = false;
            }
            if (Open_Event == true)
            {
                Event_Canvas.SetActive(false);
                Open_Event = false;
            }
        }
    }

    public void Open_Exit_Canvas() 
    {
        if (Open_Exits == false)
        {
            Exits_Canvas.SetActive(true);
            Open_Exits = true;
            if (Open_SDC == true)
            {
                Short_Deck_Canvas.SetActive(false);
                Open_SDC = false;
            }
            if (Open_Map == true)
            {
                Map_Canvas.SetActive(false);
                Open_Map = false;
            }
            if (Open_Shop == true)
            {
                Shop_Canvas.SetActive(false);
                Open_Shop = false;
            }
            if (Open_Event == true)
            {
                Event_Canvas.SetActive(false);
                Open_Event = false;
            }
        }
    }

    public void Open_Shop_Canvas()
    {
        if (Open_Shop == false)
        {
            Shop_Canvas.SetActive(true);
            Open_Shop = true;
            if (Open_Exits == true)
            {
                Exits_Canvas.SetActive(false);
                Open_Exits = false;
            }
            if (Open_SDC == true)
            {
                Short_Deck_Canvas.SetActive(false);
                Open_SDC = false;
            }
            if (Open_Map == true)
            {
                Map_Canvas.SetActive(false);
                Open_Map = false;
            }
            if (Open_Event == true)
            {
                Event_Canvas.SetActive(false);
                Open_Event = false;
            }
        }
    }

    public void Open_Event_Canvas()
    {
        if (Open_Event == false)
        {
            Event_Canvas.SetActive(true);
            Open_Event = true;
            if (Open_Exits == true)
            {
                Exits_Canvas.SetActive(false);
                Open_Exits = false;
            }
            if (Open_SDC == true)
            {
                Short_Deck_Canvas.SetActive(false);
                Open_SDC = false;
            }
            if (Open_Map == true)
            {
                Map_Canvas.SetActive(false);
                Open_Map = false;
            }
            if (Open_Shop == true)
            {
                Shop_Canvas.SetActive(false);
                Open_Shop = false;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
