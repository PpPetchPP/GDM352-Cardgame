using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward_Card : MonoBehaviour
{
    [SerializeField] bool free = true;
    [SerializeField] GameObject canvas;
    public string This_Card_index;
    public Sprite pic;
    int pos;
    Deck deck;
    Inventory inven;
    Scene_manage scene_;
    [SerializeField] Text text, prize;
    int prize_int;
    void Start()
    {
        Create_Card();
    }
    public void Create_Card() 
    {
        scene_ = GameObject.FindGameObjectWithTag("GM").GetComponent<Scene_manage>();
        deck = GameObject.FindGameObjectWithTag("GM").GetComponent<Deck>();
        inven = GameObject.FindGameObjectWithTag("GM").GetComponent<Inventory>();
        pos = Random.Range(0, deck.Name_Card.Length);
        This_Card_index = deck.Name_Card[pos];
        text.text = This_Card_index;
        if (free == false)
        {
            prize_int = Random.Range(80, 200);
            prize.text = prize_int.ToString();
        }
    }

    void Update()
    {
        
    }

    public void Select_this_card() 
    {
        if (free == true)
        {
            scene_.Set_Reward(false);
            inven.AddCard(This_Card_index);
            inven.Card_form_Deck();
            Destroy(canvas);
        }
        else if (free == false && scene_.Get_Coin() >= prize_int) 
        {
            scene_.Set_Coin(scene_.Get_Coin() - prize_int);
            scene_.Set_Reward(false);
            inven.AddCard(This_Card_index);
            inven.Card_form_Deck();
            Destroy(canvas);
        }
    }
}
