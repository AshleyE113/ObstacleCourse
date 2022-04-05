using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class spawns some of the obstacles (logs and leaves) in the level over a certain amount of time. */
public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float wfsVal = 1f;
    [SerializeField] GameObject spawner;
    bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (isSpawning) //continuosly spawns items as the game runs.
        {
            Instantiate(prefab, new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.Euler(0, 90, 90));
            yield return new WaitForSeconds(wfsVal);
        }
    }
}
