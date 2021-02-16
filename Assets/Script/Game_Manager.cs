using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    int MyBaseHP = 10;
    int EnermyBaseHP = 10;
    int Mana = 1;
    public int Mana_Enerrmy = 1;
    int MaxMana = 1;
    public bool this_myTurn = true;
    public GameObject pos;
    public string What_Card_Select;
    public Text myBaseHP_text, EnermyBaseHP_text,Mana_Text;
    public Test_Turn_Base trun_event;
    public Scene_manage scene_;
    // Start is called before the first frame update
    void Start()
    {
        scene_ = GetComponent<Scene_manage>();
        trun_event = GetComponent<Test_Turn_Base>();
        trun_event.AddEndTurnEvent(Reset_Mana);
    }

    // Update is called once per frame
    void Update()
    {
        myBaseHP_text.text = MyBaseHP.ToString();
        EnermyBaseHP_text.text = EnermyBaseHP.ToString();
        Mana_Text.text = Mana.ToString();
        if (MyBaseHP <= 0) 
        {
            Debug.Log("Lose");
        }
        else if (EnermyBaseHP <= 0) 
        {
            scene_.Set_Reward(true);
            scene_.Set_Coin(Random.Range(20, 51));
            SceneManager.LoadSceneAsync(0);
        }
    }
    
    public bool MyTurn()
    {
        if (this_myTurn == true) 
        {
            return true;
        }
        return false;
    }

    public void Reset_Mana()
    {
        if (this_myTurn == true) 
        {
            if (MaxMana < 10)
            {
                MaxMana++;
            }
            Mana = MaxMana;
        }
    }
    public void Reset_Mana_Enermy()
    {
        if (this_myTurn == false)
        {
            Mana_Enerrmy = MaxMana;
        }
    }

    public void MyBase_GetDamage(int damage) 
    {
        MyBaseHP -= damage;
    }
    public void EnermyBase_GetDamage(int damage)
    {
        EnermyBaseHP -= damage;
    }
    //public void Select_Card(int card_index) 
    //{
    //    What_Card_Select = card_index;
    //}

    public bool Create_minions(int NeedMana, bool myEnermy) 
    {
        try
        {
            Debug.Log(pos);
            if ((myEnermy == true && Mana >= NeedMana) || NeedMana == 0)
            {
                if (pos.GetComponent<Test_Create_Minion>().Check(myEnermy) == true)
                {
                    Mana -= NeedMana;
                    return true;
                }
            }
            else if (myEnermy == false && Mana_Enerrmy >= NeedMana) 
            {
                if (pos.GetComponent<Test_Create_Minion>().Check(myEnermy) == true)
                {
                    Mana_Enerrmy -= NeedMana;
                    return true;
                }
            }
            else { return false; }
        }
        catch { }
        return false;
    }
}
