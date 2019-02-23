using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Vector2[] spawnPoints;
    public GameObject[] monsterPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = loadSpawnPoints();

        for (int i = 0; i < 50; i++)
        {
            Vector2 point = spawnPoints[Random.Range(0, spawnPoints.Length-1)];
            GameObject monsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length-1)];
            Instantiate(monsterPrefab, point, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2[] loadSpawnPoints()
    {
        Vector2[] sp = {
            new Vector2(-43.85f, 8.5f),
            new Vector2(-40.8f, 8.2f),
            new Vector2(-36.8f, 8.15f),
            new Vector2(-41.75f, 15.2f),
            new Vector2(-34.75f, 16.25f),
            new Vector2(-31.9f, 16f),
            new Vector2(-28.8f, 17.5f),
            new Vector2(-31.3f, 10.3f),
            new Vector2(-21.7f, 14.2f),
            new Vector2(-14.7f, 14.2f),
            new Vector2(-5.25f, 17.85f),
            new Vector2(-9.9f, 19.9f),
            new Vector2(-5.25f, 11.75f),
            new Vector2(-2.75f, 20.2f),
            new Vector2(6.65f, 21.85f),
            new Vector2(-22.8f, 5.2f),
            new Vector2(-16.95f, 5.35f),
            new Vector2(-8.9f, -.75f),
            new Vector2(-5.65f, 5f),
            new Vector2(-18.3f, -1.75f),
            new Vector2(-9.75f, -7.85f),
            new Vector2(-23.55f, -8.55f),
            new Vector2(-16.6f, -14.6f),
            new Vector2(-2.8f, -14f),
            new Vector2(-.2f, -8.1f),
            new Vector2(3.15f, -6.7f),
            new Vector2(-4.75f, -.7f),
            new Vector2(15f, -5f),
            new Vector2(12.65f, -9.8f),
            new Vector2(14f, -2.35f),
            new Vector2(5.35f, -10.6f),
            new Vector2(23.1f, -10.85f),
            new Vector2(24.3f, -3.45f),
            new Vector2(23.9f, -8.2f),
            new Vector2(27.8f, -10.8f),
            new Vector2(13.2f, 6.45f),
            new Vector2(9.75f, 21.6f),
            new Vector2(14.9f, 21.7f),
            new Vector2(18.6f, 21.2f),
            new Vector2(35f, 21.95f),
            new Vector2(38.7f, 21.9f),
            new Vector2(38.45f, 15.3f),
            new Vector2(41.5f, 22f),
            new Vector2(46.4f, 18.95f),
            new Vector2(60.6f, 18.9f),
            new Vector2(53f, 15.85f),
            new Vector2(73.2f, 22.15f),
            new Vector2(73.8f, 20.5f),
            new Vector2(78.2f, 22.3f),
            new Vector2(73.85f, 18f),
            new Vector2(71.6f, 16.3f),
            new Vector2(73.9f, 14.1f),
            new Vector2(70.4f, 14.2f),
            new Vector2(80.45f, 12.2f),
            new Vector2(68.3f, 9.25f),
            new Vector2(70.4f, 6.3f),
            new Vector2(77.1f, 8.25f),
            new Vector2(80.35f, 6.3f),
            new Vector2(83f, .4f),
            new Vector2(78.2f, .25f),
            new Vector2(78.35f, -6.75f),
            new Vector2(82.3f, -5.75f),
            new Vector2(59f, 6.5f),
            new Vector2(61.25f, 8.35f),
            new Vector2(68.15f, 1.15f),
            new Vector2(63.3f, -3.5f),
            new Vector2(65.95f, -3.65f),
            new Vector2(65.1f, -8.7f),
            new Vector2(67.15f, -11.95f),
            new Vector2(68.22f, -14.7f),
            new Vector2(65.15f, -17.7f),
            new Vector2(57.3f, -8.65f),
            new Vector2(59.2f, -17.3f),
            new Vector2(48.9f, -17.3f),
            new Vector2(47.35f, -14.7f),
            new Vector2(46.3f, -10.9f),
            new Vector2(56f, -10.9f),
            new Vector2(39.3f, -17.6f),
            new Vector2(36.4f, -9.8f),
            new Vector2(37.2f, -17.6f),
            new Vector2(33.35f, -17.65f),
            new Vector2(33.2f, -9.8f),
            new Vector2(31.25f, -9.85f),
            new Vector2(31.1f, -17.65f),
            new Vector2(28.15f, -17.75f),
            new Vector2(28.25f, -9.75f),
            new Vector2(23.2f, -14.8f),
            new Vector2(49.15f, -5.8f),
            new Vector2(44.2f, -2.75f),
            new Vector2(42.25f, -4.75f),
            new Vector2(41.2f, 3.2f),
            new Vector2(46.1f, 3.15f),
            new Vector2(46.45f, -.8f),
            new Vector2(49.25f, 4.2f),
            new Vector2(49.25f, 6.35f),
            new Vector2(42.2f, 5.2f),
            new Vector2(42.2f, 7.15f),
            new Vector2(38.35f, 7.15f),
            new Vector2(29.31f, 13.15f),
            new Vector2(30.35f, 7.25f),
            new Vector2(34.13f, 13.1f)
        };
        return sp;
    }
}
