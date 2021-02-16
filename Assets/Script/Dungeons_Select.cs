using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeons_Select : MonoBehaviour
{
    Event_Create ec;
    Button this_but;
    public Image eiei;
    Scene_manage scene_;
    Menu menu;
    public Create_Dungeons CD;
    public int Dungeons_Pos;
    public int Dungeons_Type;
    public int This_Lv;
    public bool Can_Select = false;
    public Sprite[] type = new Sprite[4];
    void Start()
    {
        this_but = this.gameObject.GetComponent<Button>();
        scene_ = GameObject.FindGameObjectWithTag("GM").GetComponent<Scene_manage>();
        menu = GameObject.FindGameObjectWithTag("GM").GetComponent<Menu>();
        ec = GameObject.FindGameObjectWithTag("GM").GetComponent<Event_Create>();
        Chang_Pic();
    }
    public void Chang_Pic()
    {
        if (Dungeons_Type == 1)
        {
            this_but.image.sprite = type[0];
        }
        else if (Dungeons_Type == 2)
        {
            this_but.image.sprite = type[1];
        }
        else if (Dungeons_Type == 3)
        {
            this_but.image.sprite = type[2];
        }
    }

    void Update()
    {
        if (Can_Select == true) 
        {
            this_but.enabled = true;
            eiei.color = new Color(135, 135, 135);
        }
        else if (Can_Select == false)
        {
            this_but.enabled = false;         
        }
    }

    public void Click() 
    {
        CD.Chang_Lv(This_Lv - 1, false);
        CD.Chang_Lv(This_Lv, true);
        //CD.Lv[This_Lv-1] = false;
        //CD.Lv[This_Lv] = true;
        CD.Set_player_select(Dungeons_Pos);
        CD.Check_Dun();
        if (Dungeons_Type == 1) 
        {
            scene_.GoGo();
        }
        else if (Dungeons_Type == 2)
        {
            menu.Open_Shop_Canvas();
        }
        else if (Dungeons_Type == 3)
        {
            menu.Open_Event_Canvas();
            ec.first_time = false;
            ec.Reset_Slot();
        }
    }

    public void Check(int pos) 
    {
        if (Dungeons_Pos > 63)
        {
            if (CD.Get_Lv(This_Lv-1)== true)
            {
                Can_Select = true;            
            }
            else if (CD.Get_Lv(This_Lv - 1) == false)
            {
                Can_Select = false;
            }
        }
        else if (Dungeons_Pos <= 63) 
        {
            if ((CD.Get_Lv(This_Lv - 1) == true) && ((Dungeons_Pos - (pos-7) <= 1) && (Dungeons_Pos - (pos - 7) >= -1)))
            {
                Can_Select = true;
            }
            else if (CD.Get_Lv(This_Lv - 1) == false)
            {
                Can_Select = false;
            }
        }

        

    }
}
