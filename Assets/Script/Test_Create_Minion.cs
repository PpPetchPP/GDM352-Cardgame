using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Create_Minion : MonoBehaviour
{
    [SerializeField] int pos = 0;
    public Test_Turn_Base trur_event;
    public bool can_create;
    public bool can_create_defalt;
    public Minions minions_sc;
    public GameObject minions1, minions2, minions3, minions4, minions5, minions6, minions7, minions8;
    public Sprite origin;
    public Sprite when_select;
    public Test_Chess_Map chess_Map;
    public Game_Manager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Manager>();
        trur_event = GameObject.FindGameObjectWithTag("GM").GetComponent<Test_Turn_Base>();
        trur_event.AddEndTurnEvent(Check_Who_Trun);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Check_Who_Trun() 
    {
        if (gm.this_myTurn == true && can_create_defalt == true)
        {
            can_create = true;
        }
        else if (gm.this_myTurn == false && can_create_defalt == true)
        {
            can_create = false;
        }
    }

    private void OnMouseEnter()
    {
        if (can_create_defalt == true && gm.this_myTurn == true) 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = when_select;
            gm.pos = this.gameObject;
        }
    }
    private void OnMouseExit()
    {
        if (can_create_defalt == true && gm.this_myTurn == true) 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = origin;
            gm.pos = null;
        }
    }

    public bool Check(bool myEnermy)
    {
        if (chess_Map.Check_Pos(pos) == true) 
        {
            Create_Minion(myEnermy);
            return true;
        }
        return false;
    }
    public void Create_Minion(bool myEnermy) 
    {
        Debug.Log("Create");
        if (gm.What_Card_Select == "001")
        {
            GameObject this_min = Instantiate(minions1, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "002")
        {
            GameObject this_min = Instantiate(minions2, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "003")
        {
            GameObject this_min = Instantiate(minions3, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "004")
        {
            GameObject this_min = Instantiate(minions4, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "005")
        {
            GameObject this_min = Instantiate(minions5, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "006")
        {
            GameObject this_min = Instantiate(minions6, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "007")
        {
            GameObject this_min = Instantiate(minions7, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
        else if (gm.What_Card_Select == "008")
        {
            GameObject this_min = Instantiate(minions8, this.transform.position, this.transform.rotation);
            this_min.GetComponent<Minions>().pos = this.pos;
            this_min.GetComponent<Minions>().myEnermy = myEnermy;
        }
    }

    public GameObject Get_this()
    {
        return this.gameObject;
    }
    //private void OnMouseDown()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        if (gm.What_Card_Select == 0) 
    //        {
    //            GameObject this_min = Instantiate(minions1, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //        }
    //        else if (gm.What_Card_Select == 1)
    //        {
    //            GameObject this_min = Instantiate(minions2, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //        }
    //        else if (gm.What_Card_Select == 2)
    //        {
    //            GameObject this_min = Instantiate(minions3, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //        }
    //    }
    //    else 
    //    {
    //        if (gm.What_Card_Select == 0)
    //        {
    //            GameObject this_min = Instantiate(minions1, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //            this_min.GetComponent<Minions>().myEnermy = false;
    //        }
    //        else if (gm.What_Card_Select == 1)
    //        {
    //            GameObject this_min = Instantiate(minions2, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //            this_min.GetComponent<Minions>().myEnermy = false;
    //        }
    //        else if (gm.What_Card_Select == 2)
    //        {
    //            GameObject this_min = Instantiate(minions3, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //            this_min.GetComponent<Minions>().myEnermy = false;
    //        }
    //    }
    //}
    //private void OnMouseUp()
    //{
    //    Debug.Log("run");
    //    if (Input.GetMouseButton(1))
    //    {
    //        if (gm.What_Card_Select == 0)
    //        {
    //            GameObject this_min = Instantiate(minions1, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //        }
    //        else if (gm.What_Card_Select == 1)
    //        {
    //            GameObject this_min = Instantiate(minions2, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //        }
    //        else if (gm.What_Card_Select == 2)
    //        {
    //            GameObject this_min = Instantiate(minions3, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //        }
    //    }
    //    else
    //    {
    //        if (gm.What_Card_Select == 0)
    //        {
    //            GameObject this_min = Instantiate(minions1, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //            this_min.GetComponent<Minions>().myEnermy = false;
    //        }
    //        else if (gm.What_Card_Select == 1)
    //        {
    //            GameObject this_min = Instantiate(minions2, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //            this_min.GetComponent<Minions>().myEnermy = false;
    //        }
    //        else if (gm.What_Card_Select == 2)
    //        {
    //            GameObject this_min = Instantiate(minions3, this.transform.position, this.transform.rotation);
    //            this_min.GetComponent<Minions>().pos = this.pos;
    //            this_min.GetComponent<Minions>().myEnermy = false;
    //        }
    //    }
    //}
}
