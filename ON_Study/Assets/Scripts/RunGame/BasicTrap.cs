using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrap : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float Damage;
    [SerializeField] protected GameObject managerObj;
    // Start is called before the first frame update
    void Start()
    {
        managerObj = GameObject.Find("HoneyComboGameManager");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Moving();
    }
    protected virtual void Moving()
    {
        transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            managerObj.GetComponent<HoneyComboGameManager>().Hit(Damage);
        }
        else if (collision.gameObject.CompareTag("ObjDestroy"))
            Destroy(this.gameObject);
    }
}
