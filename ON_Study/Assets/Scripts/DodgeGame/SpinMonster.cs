using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpinDirection
{
    Left = 1, Right = -1
}

public class SpinMonster : Monster
{
    [Header("SpinMonster_개인 속성")]
    [SerializeField] Quaternion RotationValue;

    [SerializeField] private float SpinValue = 0;
    [SerializeField] private float SpinSpeed = 0;
    [SerializeField] private float AttackSpeed = 0;
    [SerializeField] private int AttackNumber = 0;

    [SerializeField] private SpinDirection SpinDir;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override IEnumerator AttckPatton()
    {
        yield return null;

        while(true)
        {
            yield return null;

            SpinValue += (int)SpinDir * (SpinSpeed * Time.deltaTime);
            RotationValue = Quaternion.Euler(0, 0, SpinValue);

            this.gameObject.transform.rotation = RotationValue;

            FireBullet();
        }
    }

    void FireBullet()
    {
        int AttackAngle = 0;
        CurAttakDelay -= Time.deltaTime;

        if(CurAttakDelay < 0)
        {
            CurAttakDelay = MaxAttakDelay;

            for (int i = 0; i < AttackNumber; i++)
            {
                GameObject Bullet = Instantiate(EnemyBullet, this.gameObject.transform.position, Quaternion.Euler(0, 0, AttackAngle));
                Debug.Log("Attack");
                Bullet.gameObject.GetComponent<Rigidbody2D>().velocity = Bullet.gameObject.transform.up * 10.0f;

                AttackAngle += 360 / AttackNumber;
            }
        }
    }
}
