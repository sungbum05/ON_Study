using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrap : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Damage;
    [SerializeField] private GameObject managerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    private void Moving()
    {
        transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            managerObj.GetComponent<HoneyComboGameManager>().Hit(Damage);
        }
        else if (collision.gameObject.CompareTag("ObjDestroy"))
            Destroy(this.gameObject);
    }
}