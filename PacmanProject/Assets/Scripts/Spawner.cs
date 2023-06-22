using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int spawnObjectCount;
    private int randomIndex;
    private Vector2 randomPosition;
    private List<int> spawnPosY = new List<int>();
    private List<Vector2> spawnPos = new List<Vector2>();


    // Start is called before the first frame update
    void Start()
    {
        spawnPosY.Add(-3);
        spawnPosY.Add(0);
        spawnPosY.Add(3);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < spawnObjectCount; i++)
        {
            randomIndex = Random.Range(0, enemies.Length);
            randomPosition = GetRandomPoint();
            yield return new WaitForSeconds(.2f);
            GameObject spawnObject = Instantiate(enemies[randomIndex], randomPosition,enemies[randomIndex].transform.rotation);
        }
    }

    private Vector2 GetRandomPoint()
    {
        var randomXIndex = Random.Range(PacmanController.Instance.transform.position.x, 50);
        var randomYindex = Random.Range(0, spawnPosY.Count);
        
        randomPosition = new Vector2(randomXIndex, spawnPosY[randomYindex]);
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, 10f);
        bool hasCollisions = false;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Item"))
            {
                hasCollisions = true;
                break;
            }
        }

        if (!hasCollisions)
        {
            return randomPosition;
        }
        else
        {
            Debug.Log("1");
            return new Vector2(randomPosition.x + 3, randomPosition.y);
        }    
    }
}
