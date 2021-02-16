using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Create : MonoBehaviour
{
    public GameObject roll;
    bool End_Roll = false;
    public float this_x,x;
    int z;
    float y;
    public bool first_time = true;
    GameObject card_bot;
    GameObject g;
    Scene_manage scene_;
    Inventory inven;
    [SerializeField] GameObject g2;
    [SerializeField] Transform scoll;
    List<GameObject> inven_obj = new List<GameObject>();
    List<int> check_name = new List<int>();
    public string[] name = new string[6];
    public Sprite[] pic = new Sprite[6];
    void Start()
    {
        scene_ = GetComponent<Scene_manage>();
        inven = GetComponent<Inventory>();
        GOGO();
    }

    public void GOGO() 
    {
        card_bot = scoll.GetChild(0).gameObject;
        for (int i = 0; i < 45; i++)
        {
            y = Random.value;
            if (y < 0.4)
            {
                z = 0;
            }
            else if (y >= 0.4 && y < 0.7)
            {
                z = 1;
            }
            else if (y >= 0.7 && y < 0.8)
            {
                z = 2;
            }
            else if (y >= 0.8 && y < 0.95)
            {
                z = 3;
            }
            else if (y >= 0.95 && y < 0.99)
            {
                z = 4;
            }
            else if (y >= 0.99)
            {
                z = 5;
            }
            g = Instantiate(card_bot, scoll);
            g.GetComponent<Image>().sprite = pic[z];
            check_name.Add(z);
            inven_obj.Add(g);
        }
        Destroy(card_bot);
    }

    void Update()
    {
        x = -950;
        if (End_Roll == false) 
        {
            this_x = roll.transform.position.x;
            if (this_x > -500)
            {
                roll.transform.Translate(-1000*Time.deltaTime, 0, 0);
            }
            else if (this_x <= -500 && this_x > -700)
            {
                roll.transform.Translate(-750f * Time.deltaTime, 0, 0);
            }
            else if (this_x <= -700 && this_x > -800)
            {
                roll.transform.Translate(-300f * Time.deltaTime, 0, 0);
            }
            else if (this_x <= -800 && this_x > x)
            {
                roll.transform.Translate(-200f * Time.deltaTime, 0, 0);
            }
            else if (this_x <= x)
            {
                roll.transform.position = new Vector2(x, roll.transform.position.y);
                inven_obj[inven_obj.Count - 6].name = "EIEI";
                End_Roll = true;
                Get_Item();
            }
        }
    }

    public void Get_Item() 
    {
        if (first_time == false) 
        {
            if (check_name[inven_obj.Count - 6] == 0)
            {
                Debug.Log(name[0]);
                scene_.Set_Coin(scene_.Get_Coin() + 50);
            }
            else if (check_name[inven_obj.Count - 6] == 1)
            {
                Debug.Log(name[1]);
                scene_.Set_Coin(scene_.Get_Coin() + 100);
            }
            else if (check_name[inven_obj.Count - 6] == 2)
            {
                Debug.Log(name[2]);
                scene_.Set_Coin(scene_.Get_Coin() - 50);
            }
            else if (check_name[inven_obj.Count - 6] == 3)
            {
                Debug.Log(name[3]);
                inven.AddCard("00" + Random.Range(1, 5).ToString());
                inven.Card_form_Deck();
            }
            else if (check_name[inven_obj.Count - 6] == 4)
            {
                Debug.Log(name[4]);
                inven.AddCard("00"+Random.Range(5,9).ToString());
                inven.Card_form_Deck();
            }
            else if (check_name[inven_obj.Count - 6] == 5)
            {
                Debug.Log(name[5]);
            }          
        }
        first_time = false;
    }

    public void Reset_Slot() 
    {
        GOGO();
        for (int x = 0; x < 45; x++) 
        {
            Destroy(inven_obj[0]);
            inven_obj.RemoveAt(0);
            check_name.RemoveAt(0);
        }
        roll.transform.position = new Vector2(3400, roll.transform.position.y);
        End_Roll = false;
    }
}
