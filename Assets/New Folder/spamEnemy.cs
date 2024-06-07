using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spamEnemy : MonoBehaviour
{
    // Danh sách các Prefab của enemy
    public GameObject[] enemyPrefabs;

    //loai enemy1
    public GameObject[] enemy1Prefabs;

    //loai enemy2
    public GameObject[] enemy2Prefabs;

    //loai enemy3
    public GameObject[] enemy3Prefabs;

    //loai enemy4
    public GameObject[] enemy4Prefabs;

    // Vị trí để sinh ra enemy
    public Transform spawnPoint;

    // Khoảng thời gian giữa mỗi lần spawn
    public float spawnInterval = 0.5f;

    // Biến để đếm số lượng enemy đã spawn
    private int enemy1Count = 0;
    private int enemy2Count = 0;
    private int enemy3Count = 0;
    private int enemy4Count = 0;

    // Biến để lưu trạng thái hiện tại
    private int currentEnemyIndex = 0;

    // Biến để xác định trạng thái của việc spawn Enemy 2
    private bool spawnEnemy2Independently = false;
    private bool spawnEnemy3Independently = false;

    private void Start()
    {
        // Gọi hàm SpawnEnemy sau mỗi khoảng thời gian spawnInterval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        if (currentEnemyIndex == 0) // Spawn Enemy 1
        {
            GameObject selectedPrefab = enemy1Prefabs[Random.Range(0, enemy1Prefabs.Length)];
            Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy1Count++;
            /*
            Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation);
            enemy1Count++;*/
            if (enemy1Count >= 5)
            {
                currentEnemyIndex = 1; // Chuyển sang spawn Enemy 2
                enemy1Count = 0; // Reset enemy1 count
            }
        }

        else if (currentEnemyIndex == 1) // Spawn Enemy 2
        {
            GameObject selectedPrefab = enemy2Prefabs[Random.Range(0, enemy2Prefabs.Length)];
            Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
            //Instantiate(enemyPrefabs[1], spawnPoint.position, spawnPoint.rotation);
            enemy2Count++;
            if (enemy2Count >= 5)
            {
                currentEnemyIndex = 2; // Chuyển sang spawn Enemy 3
                enemy2Count = 0; // Reset enemy2 count
            }
            else if (!spawnEnemy2Independently)
            {
                currentEnemyIndex = 0; // Quay lại spawn Enemy 1
            }
        }

        else if (currentEnemyIndex == 2) // Spawn Enemy 3
        {
            GameObject selectedPrefab = enemy3Prefabs[Random.Range(0, enemy3Prefabs.Length)];
            Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
            //Instantiate(enemyPrefabs[2], spawnPoint.position, spawnPoint.rotation);
            enemy3Count++;
            if (enemy3Count >= 5)
            {
                currentEnemyIndex = 3; // Chuyển sang spawn Enemy 4
                enemy3Count = 0; // Reset enemy3 count
            }
            else if(!spawnEnemy3Independently)
            {
                spawnEnemy2Independently = true; // Cho phép spawn Enemy 2 mà không cần điều kiện của Enemy 1
                currentEnemyIndex = 1; // Quay lại spawn Enemy 2
            }
        }

        else if (currentEnemyIndex == 3) // Spawn Enemy 4
        {
            GameObject selectedPrefab = enemy4Prefabs[Random.Range(0, enemy4Prefabs.Length)];
            Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
            //Instantiate(enemyPrefabs[3], spawnPoint.position, spawnPoint.rotation);
            enemy4Count++;
            if (enemy4Count >= 5)
            {
                CancelInvoke("SpawnEnemy"); // Dừng lại sau khi đủ 5 Enemy 4
            }
            else
            {
                spawnEnemy3Independently = true;
                currentEnemyIndex = 2; // Quay lại spawn Enemy 3
            }
        }
    }
}
