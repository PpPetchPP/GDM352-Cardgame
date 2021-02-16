using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Minions : MonoBehaviour
{
    public Test_Chess_Map chess_map;
    public Game_Manager gm;
    private void Awake()
    {
        chess_map = GameObject.FindGameObjectWithTag("Chess Map").GetComponent<Test_Chess_Map>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Manager>();
    }
    public void AddHP(int pos, bool this_myEnermy, bool F, bool B , bool L , bool R,int AddHP) 
    {
        try
        {
            if (chess_map.Check_Pos(pos + 1) == false && R == true)
            {
                GameObject min = chess_map.minions[pos + 1];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().HP += AddHP;
                }
            }
            if (chess_map.Check_Pos(pos - 1) == false && L == true)
            {
                GameObject min = chess_map.minions[pos - 1];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().HP += AddHP;
                }
            }
            if (chess_map.Check_Pos(pos + 5) == false && F == true)
            {
                GameObject min = chess_map.minions[pos + 5];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().HP += AddHP;
                }
            }
            if (chess_map.Check_Pos(pos - 5) == false && B == true)
            {
                GameObject min = chess_map.minions[pos - 5];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().HP += AddHP;
                }
            }
        }
        catch { }
    }

    public void DealDamage(int pos, bool this_myEnermy, bool F, bool B, bool L, bool R,int Damage) 
    {
        try
        {
            if (chess_map.Check_Pos(pos + 1) == false && R == true)
            {
                GameObject min = chess_map.minions[pos + 1];
                if (min.GetComponent<Minions>().myEnermy != this_myEnermy)
                {
                    min.GetComponent<Minions>().HP -= Damage;
                }
            }
            if (chess_map.Check_Pos(pos - 1) == false && L == true)
            {
                GameObject min = chess_map.minions[pos - 1];
                if (min.GetComponent<Minions>().myEnermy != this_myEnermy)
                {
                    min.GetComponent<Minions>().HP -= Damage;
                }
            }
            if (chess_map.Check_Pos(pos + 5) == false && F == true)
            {
                GameObject min = chess_map.minions[pos + 5];
                if (min.GetComponent<Minions>().myEnermy != this_myEnermy)
                {
                    min.GetComponent<Minions>().HP -= Damage;
                }
            }
            if (chess_map.Check_Pos(pos - 5) == false && B == true)
            {
                GameObject min = chess_map.minions[pos - 5];
                if (min.GetComponent<Minions>().myEnermy != this_myEnermy)
                {
                    min.GetComponent<Minions>().HP -= Damage;
                }
            }
        }
        catch { }
    }

    public void Move(int pos, bool this_myEnermy, bool F, bool B, bool L, bool R) 
    {
        try
        {
            if (chess_map.Check_Pos(pos + 1) == false && R == true)
            {
                GameObject min = chess_map.minions[pos + 1];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().Move_fome_skill = true;
                    min.GetComponent<Minions>().Check();
                }
            }
            if (chess_map.Check_Pos(pos - 1) == false && L == true)
            {
                GameObject min = chess_map.minions[pos - 1];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().Move_fome_skill = true;
                    min.GetComponent<Minions>().Check();
                }
            }
            if (chess_map.Check_Pos(pos + 5) == false && F == true)
            {
                GameObject min = chess_map.minions[pos + 5];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().Move_fome_skill = true;
                    min.GetComponent<Minions>().Check();
                }
            }
            if (chess_map.Check_Pos(pos - 5) == false && B == true)
            {
                GameObject min = chess_map.minions[pos - 5];
                if (min.GetComponent<Minions>().myEnermy == this_myEnermy)
                {
                    min.GetComponent<Minions>().Move_fome_skill = true;
                    min.GetComponent<Minions>().Check();
                }
            }
        }
        catch { }
    }

    public void Summon(int pos, bool this_myEnermy, bool F, bool B, bool L, bool R, string summon_index)
    {
        Debug.Log(chess_map.Check_Pos(pos + 1));
        if (chess_map.Check_Pos(pos + 1) == true && R == true)
        {
            GameObject min = chess_map.chess_map[pos + 1];
            gm.What_Card_Select = summon_index;
            gm.pos = min;
            gm.Create_minions(0, true);
        }
        if (chess_map.Check_Pos(pos - 1) == true && L == true)
        {
            GameObject min = chess_map.chess_map[pos - 1];
            gm.What_Card_Select = summon_index;
            gm.pos = min;
            gm.Create_minions(0, true);
        }
        if (chess_map.Check_Pos(pos + 5) == true && F == true)
        {
            GameObject min = chess_map.chess_map[pos + 5];
            gm.What_Card_Select = summon_index;
            gm.pos = min;
            gm.Create_minions(0, true);
        }
        if (chess_map.Check_Pos(pos - 5) == true && B == true)
        {
            GameObject min = chess_map.chess_map[pos - 5];
            gm.What_Card_Select = summon_index;
            gm.pos = min;
            gm.Create_minions(0, true);
        }
    }
}
