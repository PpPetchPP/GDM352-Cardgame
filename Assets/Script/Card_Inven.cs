using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card_Inven : MonoBehaviour
{
    [SerializeField] public string Card_Index;
    public int pos;
    public Text mana;
    public Test_Card_Status[] card_Status = new Test_Card_Status[8];
    public Inventory inven;
    public Deck_Inven d_inven;
    void Start()
    {
        inven = GameObject.FindGameObjectWithTag("GM").GetComponent<Inventory>();
        d_inven = GameObject.FindGameObjectWithTag("GM").GetComponent<Deck_Inven>();
        for (int x = 0; x < card_Status.Length;x++) 
        {
            if (Card_Index == "00" + (x+1).ToString())
            {
                mana.text = card_Status[x].Mana.ToString();
            }
        }
    }

    void Update()
    {
        
    }

    public void Check_Pos(int value) 
    {
        if (value < pos) 
        {
            pos -= 1;
        }
    }

    public void AddToDeck() 
    {
        inven.AddtoDeck(Card_Index,pos);
        Destroy(this.gameObject);
    }
    public void AddToInven() 
    {
        d_inven.AddtoInven(Card_Index, pos);
        Destroy(this.gameObject);
    }
}
