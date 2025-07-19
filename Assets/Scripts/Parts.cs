using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPart", menuName = "RocketPart")]
public class Part : ScriptableObject
{
    int weight;  // 부품의 무게
    int durability;  // 부품의 내구도
    PartAbility ability;  // 부품의 능력
}

public enum PartAbility
{
    None,       // 능력 없음
    Fuel,       // 연료 능력
    Booster,    // 부스터 능력
    Gun         // 총
}
