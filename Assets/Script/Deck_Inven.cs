using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck_Inven : MonoBehaviour
{
    [SerializeField] GameObject g2;
    GameObject card_bot;
    Inventory inven;
    [SerializeField] Transform scoll;
    Deck deck;
    List<GameObject> inven_obj = new List<GameObject>();
    void Start()
    {
        deck = this.GetComponent<Deck>();
        card_bot = scoll.GetChild(0).gameObject;

        inven = this.GetComponent<Inventory>();

        for (int i = 0; i < deck.Get_Card_count(); i++)
        {
            GameObject g = Instantiate(card_bot, scoll);
            inven_obj.Add(g);
            g.GetComponentInChildren<Text>().text = deck.Get_Card(i);
            g.GetComponentInChildren<Card_Inven>().pos = i;
            g.GetComponentInChildren<Card_Inven>().Card_Index = deck.Get_Card(i);
        }
        Destroy(card_bot);
    }
    public void AddtoInven(string card_index,int pos)
    {
        deck.RemoveCard(pos);
        inven.AddCard(card_index);
        Short_inven(pos);
        inven.Card_form_Deck();
    }

    void Short_inven(int pos)
    {
        inven_obj.RemoveAt(pos);
        for (int x = 0; x < inven_obj.Count; x++)
        {
            inven_obj[x].GetComponent<Card_Inven>().Check_Pos(pos);
        }
    }

    public void Card_form_inven() 
    {
        GameObject g = Instantiate(g2, scoll);
        inven_obj.Add(g);
        g.GetComponentInChildren<Text>().text = deck.Get_Card(inven_obj.Count - 1);
        g.GetComponentInChildren<Card_Inven>().Card_Index = deck.Get_Card(inven_obj.Count - 1);
        g.GetComponentInChildren<Card_Inven>().pos = inven_obj.Count-1;
    }
}

