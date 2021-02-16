using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Dungeons : MonoBehaviour
{
    static public int Player_Select_pos = 63;
    static bool First_Run_bool = true;
    static public bool[] Lv = new bool[10] { true, false, false, false, false, false, false, false, false, false };
    GameObject Dungeons_bot;
    GameObject g;
    [SerializeField] Transform scoll;
    List<GameObject> Dungeons = new List<GameObject>();
    static List<int> Dungeons_Type = new List<int>();
    void Start()
    {
        if (First_Run_bool == true)
        {
            First_Run();
        }
        else if (First_Run_bool == false) 
        {
            Dungeons_bot = scoll.GetChild(0).gameObject;
            int z = 10;
            for (int i = 1; i < 71; i++)
            {
                g = Instantiate(Dungeons_bot, scoll);
                g.GetComponent<Dungeons_Select>().Dungeons_Pos = i;
                g.GetComponent<Dungeons_Select>().This_Lv = z;
                if (z == 10)
                {
                    g.GetComponent<Dungeons_Select>().Dungeons_Type = 4;
                }
                else { g.GetComponent<Dungeons_Select>().Dungeons_Type = Dungeons_Type[i-1]; }
                if (i % 7 == 0)
                {
                    z--;
                }
                Dungeons.Add(g);
            }
            Destroy(Dungeons_bot);
            Check_Dun();
            First_Run_bool = false;
        }
    }

    void First_Run() 
    {
        Dungeons_bot = scoll.GetChild(0).gameObject;
        int z = 10;
        for (int i = 1; i < 71; i++)
        {
            g = Instantiate(Dungeons_bot, scoll);
            g.GetComponent<Dungeons_Select>().Dungeons_Pos = i;
            g.GetComponent<Dungeons_Select>().This_Lv = z;
            if (z == 10)
            {
                g.GetComponent<Dungeons_Select>().Dungeons_Type = 4;
            }
            else if (z == 1) 
            {
                g.GetComponent<Dungeons_Select>().Dungeons_Type = 1;
            }
            else
            {
                float R = Random.value;
                if (R < 0.7)
                {
                    g.GetComponent<Dungeons_Select>().Dungeons_Type = 1;
                }
                else if (R > 0.7 && R < 0.85)
                {
                    g.GetComponent<Dungeons_Select>().Dungeons_Type = 2;
                }
                else if (R > 0.85)
                {
                    g.GetComponent<Dungeons_Select>().Dungeons_Type = 3;
                }
            }
            Dungeons_Type.Add(g.GetComponent<Dungeons_Select>().Dungeons_Type);
            if (i % 7 == 0)
            {
                z--;
            }
            Dungeons.Add(g);
        }
        Destroy(Dungeons_bot);
        Check_Dun();
        First_Run_bool = false;
    }
    public void Check_Dun() 
    {
        for (int x = 0; x < Dungeons.Count; x++)
        {
            Dungeons[x].GetComponent<Dungeons_Select>().Check(Player_Select_pos);
        }
    }

    public void Chang_Lv(int pos,bool can) 
    {
        Lv[pos] = can;
    }

    public bool Get_Lv(int pos) 
    {
        if (Lv[pos] == true) 
        {
            return true;
        }
        return false;
    }

    public void Set_player_select(int pos) 
    {
        Player_Select_pos = pos;
    }
}
