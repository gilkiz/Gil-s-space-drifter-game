using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 10f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        if (! FindObjectOfType<GameManager>().isFivePoints())
        {
            InvokeRepeating(nameof(Spawn), spawnRate*30000, spawnRate*30000);
        }
        else if(! FindObjectOfType<GameManager>().isTenPoints())
        {
            InvokeRepeating(nameof(Spawn), spawnRate*500, spawnRate*5);
        }
        else if(! FindObjectOfType<GameManager>().isFifteenPoints())
        {
            InvokeRepeating(nameof(Spawn), spawnRate*7, spawnRate*7);
        }
        else if(! FindObjectOfType<GameManager>().isTwentyPoints())
        {
            InvokeRepeating(nameof(Spawn), spawnRate*9, spawnRate*9);
        }
        else if(! FindObjectOfType<GameManager>().isTwentyFivePoints())
        {
            InvokeRepeating(nameof(Spawn), spawnRate*11, spawnRate*11);
        }

    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject enemy1 = Instantiate(prefab, new Vector3(437.6780f+10f, 164.064f+Random.Range(minHeight, maxHeight), 0), Quaternion.identity);
        enemy1.transform.position += Vector3.up * Random.Range(minHeight, maxHeight) * 10;
}
}
