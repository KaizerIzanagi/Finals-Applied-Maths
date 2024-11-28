using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Objective;
    [SerializeField]
    private GameObject Impostor;
    [SerializeField]
    public int xPos;
    public int zPos;
    public int waveCount;
    public float waveTimer;
    public float spawnTimer, spawnTick, minSpawnTick, spawnTickReducer;
    

    private void Start()
    {
        spawnTick = 4f;
        spawnTickReducer = 0.1f;
        minSpawnTick = 0.15f;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTick)
        {
            StartCoroutine(ImpostorSpawn());
            spawnTimer = 0;
            spawnTick = spawnTick - spawnTickReducer;
        }

        if (spawnTick < minSpawnTick)
        {
            spawnTick = minSpawnTick;
        }

        WaveScript();
    }

    IEnumerator ImpostorSpawn()
    {
        xPos = Random.Range(-48, 48);
        zPos = Random.Range(-48, 48);

        if (xPos == Mathf.Clamp(xPos, -17, 17))
        {
            if (zPos == Mathf.Clamp(zPos, -17, 17))
            {
                Debug.Log("Spawn Prevented");
                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            Instantiate(Impostor, new Vector3(xPos, 1.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

    }

    public void WaveScript()
    {
        waveTimer += Time.deltaTime;

        if (waveTimer > 60f)
        {
            waveCount++;
            waveTimer = 0;
            spawnTick = 4;
            spawnTickReducer = spawnTickReducer + 0.1f;
            if (spawnTickReducer < minSpawnTick)
            {
                spawnTickReducer = 3.9f;
            }
        }

    }

}
