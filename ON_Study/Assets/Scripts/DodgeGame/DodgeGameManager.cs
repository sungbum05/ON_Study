using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeGameManager : MonoBehaviour
{
    public float Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime * 100;
    }
}
