using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;
    private ExitTheDungeonGameUI exitTheDungeonGameUI;
    private List<TrapController> activeEnemies = new List<TrapController>();

    public void StartStage(int num)
    {
        exitTheDungeonGameUI = FindObjectOfType<ExitTheDungeonGameUI>();
        exitTheDungeonGameUI.ChangeStage(num);

        for (int i = 0; i < num*7; i++) { SpawnBomb(); }
    }

    public void EraseTrap()
    {
        foreach (var e in activeEnemies)
        {
            if (e != null)
            {
                Destroy(e.gameObject);
            }
        }

        activeEnemies.Clear();
        StopAllCoroutines();
    }

    private void SpawnBomb()
    {
        GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        Vector2 randomPosition = new Vector2(
            Random.Range(13f, 69f),
            Random.Range(-1f, 5f)
        );

        GameObject spawnedEnemy = Instantiate(randomPrefab, new Vector3(randomPosition.x, randomPosition.y), Quaternion.identity);
        TrapController trapController = spawnedEnemy.GetComponent<TrapController>();

        activeEnemies.Add(trapController);
    }

}
