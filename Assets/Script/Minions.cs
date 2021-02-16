using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minions : MonoBehaviour
{
    public Minions min;
    public Game_Manager gm;
    public Test_Card_Status card_status;
    public Test_Turn_Base trur_event;
    public GameObject target;
    public Skill_Minions skill_min;
    Test_Chess_Map chess_map_sc;
    public Text hp_text;
    public int pos = 0;
    public int pos_attack = 0;
    public bool can_use_b, can_use_d, can_use_a = false;
    public bool addHP,DealDamage,Move_skill,Move_fome_skill,Summon_skill,F,B,L,R = false;
    public string summon_index;
    int x = 0;
    int How_Many_Add,Damage;

    [SerializeField] public bool myEnermy;
    [SerializeField] public int HP = 1;

    private void Awake()
    {
        HP = card_status.HP;
        can_use_a = card_status.When_Attack;
        can_use_b = card_status.Battlecry;
        can_use_d = card_status.Death;
        addHP = card_status.can_AddHP_Skill;
        DealDamage = card_status.can_DealDamage_Skill;
        Move_skill = card_status.can_Move_Skill;
        Summon_skill = card_status.summon_Skill;
        F = card_status.F;
        B = card_status.B;
        L = card_status.L;
        R = card_status.R;
        summon_index = card_status.summon_index;
        How_Many_Add = card_status.AddHP;
        Damage = card_status.Damage;
    }
    void Start()
    {
        trur_event = GameObject.FindGameObjectWithTag("GM").GetComponent<Test_Turn_Base>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Manager>();
        chess_map_sc = GameObject.FindGameObjectWithTag("Chess Map").GetComponent<Test_Chess_Map>();
        target = chess_map_sc.chess_map[pos];
        chess_map_sc.Add_Pos(pos, this.gameObject);
        Battle_Cry(pos, can_use_b);
        trur_event.AddEndTurnEvent(When_end_turn);
    }
    void Update()
    {
        hp_text.text = HP.ToString();
        move();
        //When_end_turn();
        if (HP <= 0)
        {
            Die();
        }
    }

    public void When_end_turn() 
    {
        if (/*Input.GetKeyDown(KeyCode.L) && */myEnermy == false && gm.this_myTurn == false)
        {
            Check();
        }
        if (/*Input.GetKeyDown(KeyCode.K) && */myEnermy == true && gm.this_myTurn == true)
        {
            Check();
        }
    }
    public void Check()
    {
        if (myEnermy == true)
        {
            x = 5;
        }
        else if (myEnermy == false) 
        {
            x = -5;
        }
        if (chess_map_sc.Check_Pos(pos+x) == true)
        {
            Move_after_end_trun();
        }
        else if (chess_map_sc.Check_Pos(pos+x) == false) 
        {
            pos_attack = pos + x;
            Attack_Minion(HP);
        }
    }
    void move()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        float dis_f = Vector2.Distance(this.transform.position, target.transform.position);
        if (dis_f > 0.1) 
        {
            transform.Translate(dir.normalized * Time.deltaTime, Space.World);
        }
    }
    public void Move_after_end_trun() 
    {
        chess_map_sc.Remove_Pos(pos);
        try
        {
            if (myEnermy == true)
            {
                target = chess_map_sc.chess_map[pos += 5];
            }
            else if (myEnermy == false) 
            {
                target = chess_map_sc.chess_map[pos -= 5];
            }

            if (pos<25) 
            {
                chess_map_sc.Add_Pos(pos, this.gameObject);
            }
        }
        catch 
        {
            Attack_Base();
        }
    }

    void Die() 
    {
        Death(pos, can_use_d);
        chess_map_sc.Remove_Pos(pos);
        Destroy(this.gameObject);
    }

    void Attack_Base()
    {
        if (pos > 25 || pos < 0)
        {
            if (myEnermy == true)
            {
                gm.EnermyBase_GetDamage(HP);
            }
            else if (myEnermy == false)
            {
                gm.MyBase_GetDamage(HP);
            }
        }
        Destroy(this.gameObject);
    }
    void Attack_Minion(int Damage) 
    {
        min = chess_map_sc.minions[pos_attack].GetComponent<Minions>();
        if (min.myEnermy != this.myEnermy) 
        {
            When_attack(pos, can_use_a);
            HP -= min.HP;
            min.Get_Damage(Damage);
            
        }
        if (HP <= 0)
        {
            Die();
        }
        if (Move_fome_skill == false) 
        {
            Move_after_end_trun();
        }
        Move_fome_skill = false;
    }
    public void Get_Damage(int Damage)
    {
        HP -= Damage;
        When_attack(pos, can_use_a);
        if (HP <= 0)
        {
            Die();
        }
    }

    //skill
    void Battle_Cry(int pos,bool can_use)
    {
        if (can_use == true) 
        {
            if (addHP == true) { skill_min.AddHP(pos, myEnermy,F,B,L,R,How_Many_Add); }
            if (DealDamage == true) { skill_min.DealDamage(pos, myEnermy, F, B, L, R,Damage); }
            if (Move_skill == true) { skill_min.Move(pos, myEnermy, F, B, L, R); }
            if (Summon_skill == true) { skill_min.Summon(pos, myEnermy, F, B, L, R,summon_index); }
        }
    }
    void Death(int pos, bool can_use)
    {
        if (can_use == true)
        {
            if (addHP == true) { skill_min.AddHP(pos, myEnermy, F, B, L, R, How_Many_Add); }
            if (DealDamage == true) { skill_min.DealDamage(pos, myEnermy, F, B, L, R, Damage); }
            if (Move_skill == true) { skill_min.Move(pos, myEnermy, F, B, L, R); }
            if (Summon_skill == true) { skill_min.Summon(pos, myEnermy, F, B, L, R, summon_index); }
        }
    }
    void When_attack(int pos, bool can_use)
    {
        if (can_use == true)
        {
            if (addHP == true) { skill_min.AddHP(pos, myEnermy, F, B, L, R, How_Many_Add); }
            if (DealDamage == true) { skill_min.DealDamage(pos, myEnermy, F, B, L, R, Damage); }
            if (Move_skill == true) { skill_min.Move(pos, myEnermy, F, B, L, R); }
            if (Summon_skill == true) { skill_min.Summon(pos, myEnermy, F, B, L, R, summon_index); }
        }
    }
}
