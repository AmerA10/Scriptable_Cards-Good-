using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newCard", menuName = "Cards/basicTroop")]
public class cardTemplate : ScriptableObject
{
    public new string name;
    public int cost;

    public float attack_Damage;
    public float attack_Speed;
    public float attack_Range;
    public float agro_Range;
    public AttackType_Enum.AttackType attackType;
    public AttackType_Enum.TargetType targetType;
    public float move_Speed;

    public float health;

    public Sprite artWork;
    
}
