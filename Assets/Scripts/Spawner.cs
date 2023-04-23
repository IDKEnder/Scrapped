using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Bottle;
    public float delay = 2f;
    public void SpawnObject()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    IEnumerator SpawnObjectWithDelay()
    {
        Destroy(Instantiate(ObjectToSpawn, transform.position, transform.rotation), delay);
        yield return new WaitForSeconds(delay);
        GameObject Bottlee = Instantiate(Bottle, transform.position, transform.rotation);
        Bottlee.AddComponent<Bottle>();
    }
}
