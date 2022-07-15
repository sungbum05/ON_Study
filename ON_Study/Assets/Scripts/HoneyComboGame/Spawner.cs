using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPoints
{
    Left,
    Middle,
    Right
}

public enum ObjKind
{
    SpiderWebTrapObj,
    HornetTrapObj,
    ScoreObj
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private string[] loadSpawnIndex;
    [SerializeField] private string[] loadObjKindIndex;
    [SerializeField] private Vector3[] spawnPoint = new Vector3[3];
    [SerializeField] private GameObject[] Objs;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset txt = Resources.Load<TextAsset>("Spawn");
        TextAsset txt2 = Resources.Load<TextAsset>("SpawnKind");
        loadSpawnIndex = txt.text.Split('\n');
        loadObjKindIndex = txt2.text.Split('\n');
        StartCoroutine(SpawnWave());
    }
    IEnumerator SpawnWave()
    {
        while (true)
        {
            for (int NowSpawnIndex = 0; NowSpawnIndex < loadSpawnIndex.Length; NowSpawnIndex++)
            {
                int NowSpawnObjIndex = Random.Range((int)ObjKind.SpiderWebTrapObj, (int)ObjKind.HornetTrapObj + 1);
                Instantiate(Objs[int.Parse(loadObjKindIndex[NowSpawnIndex])], spawnPoint[int.Parse(loadSpawnIndex[NowSpawnIndex])], Objs[NowSpawnObjIndex].transform.rotation); //Random.Range((int)SpawnPoints.Left, (int)SpawnPoints.Right + 1)
                yield return new WaitForSeconds(3);
            }
        }
    }
}
