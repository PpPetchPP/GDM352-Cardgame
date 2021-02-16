using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public string card_index;
    private Vector3 mousePosition;
    Game_Manager gm;
    SpriteRenderer sprite_ren,pic;
    Collider2D col;
    Deck deck;
    public Text Mana_t, Hp_t,ability_t;
    public Test_Card_Status card_Status;
    public Sprite min1,min2,min3;
    public float moveSpeed = 0.1f;
    public GameObject pos1, pos2;
    int Hand_pos;
    bool mouse_on_card = false;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Manager>();
        sprite_ren = this.GetComponent<SpriteRenderer>();
        pic = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<PolygonCollider2D>();
        deck = GameObject.FindGameObjectWithTag("GM").GetComponent<Deck>();
        Mana_t.text = card_Status.Mana.ToString();
        Hp_t.text = card_Status.HP.ToString();
        ability_t.text = card_Status.Ability_Text;
    }

    // Update is called once per frame
    void Update()
    {
        float dis_f = Vector2.Distance(this.transform.position, pos1.transform.position);
        float dis_f2 = Vector2.Distance(this.transform.position, pos2.transform.position);
        if (dis_f2 > 1 && Input.GetMouseButton(0))
        {
            sprite_ren.GetComponent<SpriteRenderer>().enabled = false;
            col.GetComponent<PolygonCollider2D>().enabled = false;
            Mana_t.GetComponent<Text>().enabled = false;
            Hp_t.GetComponent<Text>().enabled = false;
            ability_t.GetComponent<Text>().enabled = false;
        }
        else if ((dis_f < 2) || (dis_f2 < 2))
        {
            sprite_ren.GetComponent<SpriteRenderer>().enabled = true;
            col.GetComponent<PolygonCollider2D>().enabled = true;
            Mana_t.GetComponent<Text>().enabled = true;
            Hp_t.GetComponent<Text>().enabled = true;
            ability_t.GetComponent<Text>().enabled = true;
        }
        if (Input.GetMouseButton(0) && mouse_on_card == true)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        if (Input.GetMouseButtonUp(0) && mouse_on_card == true)
        {
            gm.What_Card_Select = card_index;
            if (gm.Create_minions(card_Status.Mana,true) == true)
            {
                deck.Use_card(Hand_pos);
                Destroy(this.gameObject);
            }
            this.gameObject.transform.position = pos1.transform.position;
            mouse_on_card = false;
        }
        if (mouse_on_card == false) 
        {
            Move1();
        }
    }

    public void Chang_Pos(int pos) 
    {
        //Debug.Log(pos);
        if (pos == 0) 
        {
            pos1 = GameObject.FindGameObjectWithTag("pos1_1");
            pos2 = GameObject.FindGameObjectWithTag("pos1_2");          
        }
        else if (pos == 1)
        {
            pos1 = GameObject.FindGameObjectWithTag("pos2_1");
            pos2 = GameObject.FindGameObjectWithTag("pos2_2");
        }
        else if (pos == 2)
        {
            pos1 = GameObject.FindGameObjectWithTag("pos3_1");
            pos2 = GameObject.FindGameObjectWithTag("pos3_2");
        }
        else if (pos == 3)
        {
            pos1 = GameObject.FindGameObjectWithTag("pos4_1");
            pos2 = GameObject.FindGameObjectWithTag("pos4_2");
        }
        else if (pos == 4)
        {
            pos1 = GameObject.FindGameObjectWithTag("pos5_1");
            pos2 = GameObject.FindGameObjectWithTag("pos5_2");
        }
        //this.gameObject.transform.position = pos1.transform.position;
        //Move(pos1);
        Hand_pos = pos;
    }

    private void OnMouseEnter()
    {
        if (!Input.GetMouseButton(0)) 
        {
            this.gameObject.transform.position = pos2.transform.position;
            //Move(pos2);
            mouse_on_card = true;
        }
    }

    private void OnMouseExit()
    {
        if (!Input.GetMouseButton(0))
        {
            this.gameObject.transform.position = pos1.transform.position;
            //Move(pos1);
            mouse_on_card = false;
        }   
    }

    void Move1() 
    {
        Vector3 dir = pos1.transform.position - this.transform.position;
        float dis_f = Vector2.Distance(this.transform.position, pos1.transform.position);
        if (dis_f > 0.1)
        {
            transform.Translate(dir.normalized *5* Time.deltaTime, Space.World);
        }
    }
}
