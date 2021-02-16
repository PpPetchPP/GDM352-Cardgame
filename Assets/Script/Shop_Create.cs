using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Create : MonoBehaviour
{
    Scene_manage scene_;
    GameObject card_bot;
    GameObject g;
    [SerializeField] GameObject g2;
    [SerializeField] Transform scoll;
    List<GameObject> inven_obj = new List<GameObject>();
    void Start()
    {
        scene_ = GameObject.FindGameObjectWithTag("GM").GetComponent<Scene_manage>();
        Create();
    }

    public void Create() 
    {
        card_bot = scoll.GetChild(0).gameObject;
        for (int i = 0; i < 3; i++)
        {
            g = Instantiate(card_bot, scoll);
            inven_obj.Add(g);
            //g.GetComponentInChildren<Card_Inven>().pos = i;
            //g.GetComponentInChildren<Card_Inven>().Card_Index = inven[i];
        }
        Destroy(card_bot);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReShop() 
    {      
        if (scene_.Get_Coin() >= 50) 
        {
            Create();
            scene_.Set_Coin(scene_.Get_Coin() - 50);
            for (int i = 0; i < 3; i++)
            {
                Destroy(inven_obj[0]);
                inven_obj.RemoveAt(0);
            }
        }
    }
}
