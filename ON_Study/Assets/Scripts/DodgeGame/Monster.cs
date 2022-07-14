using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyTierList // ���� Ƽ��
{
    Common = 4, 
    Rare = 3, 
    Epic = 2, 
    Legendary = 1
}

[System.Serializable]
public class Monster : MonoBehaviour
{
    [SerializeField] private int hp; // ������Ƽ���� Ȯ���ϱ� ����
    public int HP { 
        get 
        { 
            return hp; 
        }

        set
        {
            hp = value;

            if(hp <= 0)
                Debug.Log("Die");
        }
    }

    [SerializeField] private EnemyTierList EnemyTier;

    [SerializeField] protected int AttackPower = 0;
    [SerializeField] protected float AttakDelay = 0f;

    protected virtual void Awake()
    {
        UnitSetting();
    }

    protected virtual void UnitSetting()
    {
        HP = 100 / (int)EnemyTier;
        AttackPower = 100 / (int)EnemyTier;
    }
}
