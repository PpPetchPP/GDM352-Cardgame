using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject pos;
    public string[] Name_Card = new string[] { "001", "002", "003","004","005","006","007","008" };
    static List<string> Deck_List = new List<string>();
    public List<GameObject> Hand_obj = new List<GameObject>();
    public List<string> Deck_List_swap = new List<string>();
    List<string> Hand = new List<string>();
    List<GameObject> Card_On_Hand = new List<GameObject>();
    void Start()
    {
        Add_Deck_for_Shuffle();
        Shuffle_Deck();
        Draw_Start();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R)) 
        //{
        //    DrawCard();
        //}
    }

    //public int Get_Deck_count() 
    //{
    //    return Deck_List.Count;
    //}
    //public string Get_Deck_string(int pos) 
    //{
    //    return Deck_List[pos];
    //}
    void Draw_Start() 
    {
        for (int x = 0;x<5;x++) 
        {
            DrawCard();
        }
    }
    public void AddCard(string card_index) 
    {
        Deck_List.Add(card_index);
    }
    public void RemoveCard(int pos)
    {
        Deck_List.RemoveAt(pos);
    }

    public string Get_Card(int pos) 
    {
        return Deck_List[pos];
    }
    public int Get_Card_count()
    {
        return Deck_List.Count;
    }

    public void Reset_Deck() 
    {
        Deck_List_swap.Clear();
    }

    public void Add_Deck_for_Shuffle() 
    {
        for (int i = 0 ; i<Deck_List.Count ; i++) 
        {
            Deck_List_swap.Add(Deck_List[i]);
        }
    }

    public void Shuffle_Deck() 
    {
        for (int i = 0; i < Deck_List_swap.Count; i++)
        {
            string temp = Deck_List_swap[i];
            int randomIndex = Random.Range(i, Deck_List_swap.Count);
            Deck_List_swap[i] = Deck_List_swap[randomIndex];
            Deck_List_swap[randomIndex] = temp;
        }
    }

    public void DrawCard()
    {
        if (Hand.Count < 5 && Deck_List_swap.Count > 0) 
        {
            Hand.Add(Deck_List_swap[0]);
            Deck_List_swap.RemoveAt(0);
            for (int x = 0;x < Hand_obj.Count;x++) 
            {
                if (Hand[Hand.Count-1] == Name_Card[x]) 
                {
                    GameObject create_card = Instantiate(Hand_obj[x], pos.transform.position, pos.transform.rotation);
                    Card_On_Hand.Add(create_card);
                    create_card.GetComponent<Card>().Chang_Pos(Hand.Count - 1);
                    create_card.GetComponent<Card>().card_index = Hand[Hand.Count - 1];
                    break;
                }
            }
        }
    }

    public void Use_card(int pos) 
    {
        Hand.RemoveAt(pos);
        Short_Card(pos);
    }

    public void Short_Card(int pos) 
    {
        if (pos == 0) 
        {
            for (int x = 0; x < Hand.Count;x++) 
            {
                Card_On_Hand[x+1].GetComponent<Card>().Chang_Pos(pos+x);
            }
            Card_On_Hand.RemoveAt(pos);
        }
        else if (pos == 1)
        {          
            for (int x = 1; x < Hand.Count; x++)
            {
                Card_On_Hand[x + 1].GetComponent<Card>().Chang_Pos(pos + x-1);
            }
            Card_On_Hand.RemoveAt(pos);
        }
        else if (pos == 2)
        {
            for (int x = 2; x < Hand.Count; x++)
            {
                Card_On_Hand[x + 1].GetComponent<Card>().Chang_Pos(pos + x-2);
            }
            Card_On_Hand.RemoveAt(pos);
        }
        else if (pos == 3)
        {
            for (int x = 3; x < Hand.Count; x++)
            {
                Card_On_Hand[x + 1].GetComponent<Card>().Chang_Pos(pos + x-3);
            }
            Card_On_Hand.RemoveAt(pos);
        }
        else if (pos == 4)
        {
            for (int x = 4; x < Hand.Count; x++)
            {
                Card_On_Hand[x + 1].GetComponent<Card>().Chang_Pos(pos + x-4);
            }
            Card_On_Hand.RemoveAt(pos);
        }
    }
}
