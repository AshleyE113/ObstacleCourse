using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject log;
    [SerializeField] float wfsVal = 1f;
    [SerializeField] GameObject spawner;
    bool isSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        //spawner = GameObject.Find("Spawner");
        StartCoroutine(SpawnLogs());
    }

    IEnumerator SpawnLogs()
    {
        while (isSpawning)
        {
            Instantiate(log, new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.Euler(0, 90, 90));
            yield return new WaitForSeconds(wfsVal);
        }
    }
}
