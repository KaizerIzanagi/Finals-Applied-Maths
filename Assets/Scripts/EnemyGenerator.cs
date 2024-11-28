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
    public int impostorCount, waveCount;
    public float spawnTimer, spawnTick, minSpawnTick;

    private void Start()
    {
        spawnTick = 5;
        impostorCount = 10;
        minSpawnTick = 0.3f;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTick)
        {
            StartCoroutine(ImpostorSpawn());
            spawnTimer = 0;
            spawnTick = spawnTick - 0.50f;
        }

        if (spawnTick < minSpawnTick)
        {
            spawnTick = minSpawnTick;
        }

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

    
}
