using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Deck_Inven d_inven;
    static bool First_Run = true;
    GameObject card_bot;
    GameObject g;
    [SerializeField]GameObject g2;
    [SerializeField] Transform scoll;
    Deck deck;
    static List<string> inven_static = new List<string>();
    List<string> inven = new List<string>();
    List<GameObject> inven_obj = new List<GameObject>();
    void Start()
    {
        d_inven = this.GetComponent<Deck_Inven>();
        deck = this.GetComponent<Deck>();

        if (First_Run == true)
        {
            inven.Add("001");
            inven.Add("001");
            inven.Add("002");
            inven.Add("002");
            inven.Add("003");
            inven.Add("003");
            inven.Add("004");
            inven.Add("004");
            inven.Add("005");
            inven.Add("005");
            inven.Add("006");
            inven.Add("006");
            inven.Add("007");
            inven.Add("007");
            inven.Add("008");
            inven.Add("008");
            inven_static.Add("001");
            inven_static.Add("001");
            inven_static.Add("002");
            inven_static.Add("002");
            inven_static.Add("003");
            inven_static.Add("003");
            inven_static.Add("004");
            inven_static.Add("004");
            inven_static.Add("005");
            inven_static.Add("005");
            inven_static.Add("006");
            inven_static.Add("006");
            inven_static.Add("007");
            inven_static.Add("007");
            inven_static.Add("008");
            inven_static.Add("008");

            card_bot = scoll.GetChild(0).gameObject;
            for (int i = 0; i < inven.Count; i++)
            {
                g = Instantiate(card_bot, scoll);
                inven_obj.Add(g);
                g.GetComponentInChildren<Text>().text = inven[i];
                g.GetComponentInChildren<Card_Inven>().pos = i;
                g.GetComponentInChildren<Card_Inven>().Card_Index = inven[i];
            }
            Destroy(card_bot);

            First_Run = false;
        }
        else if(First_Run == false)
        {
            Set_to_static();

            card_bot = scoll.GetChild(0).gameObject;
            for (int i = 0; i < inven_static.Count; i++)
            {
                g = Instantiate(card_bot, scoll);
                inven_obj.Add(g);
                Debug.Log(inven_obj);
                g.GetComponentInChildren<Text>().text = inven_static[i];
                g.GetComponentInChildren<Card_Inven>().pos = i;
                g.GetComponentInChildren<Card_Inven>().Card_Index = inven_static[i];
            }
            Destroy(card_bot);
        }
    }

    void Set_to_static() 
    {
        foreach (string x in inven_static) 
        {
            inven.Add(x);
        }
    }

    public void AddCard(string card_index) 
    {
        Debug.Log("run");
        inven.Add(card_index);
        inven_static.Add(card_index);
    }
    public void AddtoDeck(string card_index,int pos) 
    {
        Debug.Log("card_index (inven) " + card_index);
        deck.AddCard(card_index);
        inven.RemoveAt(pos);
        inven_static.RemoveAt(pos);
        Short_inven(pos);
        d_inven.Card_form_inven();
    }

    void Short_inven(int pos) 
    {
        inven_obj.RemoveAt(pos);      
        for (int x = 0; x< inven_obj.Count;x++) 
        {
            inven_obj[x].GetComponent<Card_Inven>().Check_Pos(pos);
        }
    }

    public void Card_form_Deck()
    {
        GameObject g = Instantiate(g2, scoll);
        inven_obj.Add(g);
        g.GetComponentInChildren<Text>().text = inven[inven_obj.Count - 1];
        g.GetComponentInChildren<Card_Inven>().Card_Index = inven[inven_obj.Count - 1];
        g.GetComponentInChildren<Card_Inven>().pos = inven_obj.Count-1;
    }
}
