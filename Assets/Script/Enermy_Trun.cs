using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_Trun : MonoBehaviour
{
    bool Delay = false;
    bool End_Trun = false;
    Test_Turn_Base turn_base;
    public bool myEnermy = false;
    public GameObject[] pos = new GameObject[10];
    public Test_Card_Status[] card_Status = new Test_Card_Status[10];
    Game_Manager gm;
    static List<string> Deck_List = new List<string>();
    public List<string> Deck_List_swap = new List<string>();
    [SerializeField] List<string> Hand = new List<string>();
    public string[] Name_Card = new string[] { "001", "002", "003" };
    void Start()
    {
        turn_base = GetComponent<Test_Turn_Base>();
        gm = this.GetComponent<Game_Manager>();
        First_start();
        Add_Deck_for_Shuffle();
        Shuffle_Deck();
        Draw_Start();
        gm.this_myTurn = true;
    }

    void Update()
    {
        Start_enermy_Trun();
    }

    void Start_enermy_Trun()
    {
        if (gm.this_myTurn == false && gm.Mana_Enerrmy > 1 && Hand.Count > 0 && Delay == false)
        {
            Delay = true;
            StartCoroutine(Delay_Med());
            Debug.Log("My_Turn");
        }
        else if (gm.this_myTurn == false && Delay == false /* && (gm.Mana_Enerrmy <= 1 || Hand.Count <= 0)*/)
        {
            turn_base.End_Enermy_Trun();
            Debug.Log("Your_Turn");
        }
    }

    IEnumerator Delay_Med ()
    {
        for (int x = 0; x < gm.Mana_Enerrmy; x++)
        {
            Debug.Log("eiei");
            yield return new WaitForSeconds(1.5f);
            Use_card(Random.Range(0, Hand.Count - 1));
            if (gm.Mana_Enerrmy < 1 || Hand.Count <= 0) 
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.5f);
        Delay = false;
    }

    void First_start() 
    {
        Deck_List.Add("001");
        Deck_List.Add("001");
        Deck_List.Add("001");
        Deck_List.Add("001");
        Deck_List.Add("002");
        Deck_List.Add("002");
        Deck_List.Add("002");
        Deck_List.Add("002");
        Deck_List.Add("003");
        Deck_List.Add("003");
        Deck_List.Add("003");
        Deck_List.Add("003");
        Deck_List.Add("001");
        Deck_List.Add("002");
        Deck_List.Add("003");
    }
    void Draw_Start()
    {
        for (int x = 0; x < 5; x++)
        {
            DrawCard();
        }
    }
    public void Add_Deck_for_Shuffle()
    {
        for (int i = 0; i < Deck_List.Count; i++)
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
        if (Hand.Count < 5)
        {
            Hand.Add(Deck_List_swap[0]);
            Deck_List_swap.RemoveAt(0);
        }
    }
    public void Use_card(int pos)
    {
        if (Hand.Count>0) 
        {
            gm.What_Card_Select = Hand[pos];
            gm.pos = this.pos[Random.Range(0, 10)];
            if (Deck_List_swap[0] == "001")
            {
                if (gm.Create_minions(card_Status[0].Mana, false) == true)
                {
                    Hand.RemoveAt(pos);
                }
            }
            else if (Deck_List_swap[0] == "002") 
            {
                if (gm.Create_minions(card_Status[1].Mana, false) == true)
                {
                    Hand.RemoveAt(pos);
                }
            }
            else if (Deck_List_swap[0] == "003")
            {
                if (gm.Create_minions(card_Status[2].Mana, false) == true)
                {
                    Hand.RemoveAt(pos);
                }
            }
            else if (Deck_List_swap[0] == "004")
            {
                if (gm.Create_minions(card_Status[2].Mana, false) == true)
                {
                    Hand.RemoveAt(pos);
                }
            }
            else if (Deck_List_swap[0] == "005")
            {
                if (gm.Create_minions(card_Status[2].Mana, false) == true)
                {
                    Hand.RemoveAt(pos);
                }
            }

        }
    }
}
