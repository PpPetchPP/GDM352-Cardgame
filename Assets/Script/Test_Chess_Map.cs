using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Chess_Map : MonoBehaviour
{
    public GameObject[] chess_map = new GameObject[25];
    public GameObject[] minions = new GameObject[25];
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public bool Check_Pos(int pos)
    {
        try
        {
            if (minions[pos] == null)
            {
                return true;
            }
            else if (minions[pos] != null)
            {
                return false;
            }
        }
        catch { }
        return true;
    }
    public void Add_Pos(int pos,GameObject minion) 
    {
        minions[pos] = minion;
    }
    public void Remove_Pos(int pos)
    {
        minions[pos] = null;
    }
}
