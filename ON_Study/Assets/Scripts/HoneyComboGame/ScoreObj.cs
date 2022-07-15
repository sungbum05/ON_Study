using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObj : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float score;
    [SerializeField] private GameObject managerObj;

    // Start is called before the first frame update
    void Start()
    {
        managerObj = GameObject.Find("HoneyComboGameManager");
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
            managerObj.GetComponent<HoneyComboGameManager>().score += score;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("ObjDestroy"))
            Destroy(this.gameObject);
    }
}
