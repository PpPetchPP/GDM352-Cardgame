using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enerny", menuName = "EIEI/Charactor/Enermy")]
public class Test_Card_Status : ScriptableObject
{
    public string name;
    public int HP;
    public int Mana , AddHP,Damage;
    public bool Battlecry, Death, When_Attack; //use skill when ...
    public bool can_AddHP_Skill, can_DealDamage_Skill, can_Move_Skill,summon_Skill; //what skill can use 
    public bool F, B, L, R;
    public string summon_index;
    public string Ability_Text;
}
