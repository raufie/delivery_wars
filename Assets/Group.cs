using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public EnemyManager enemyManager;
    public Transform [] spawnPoints;
    public GameObject [] Enemies;
    public bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = transform.parent.gameObject.GetComponent<EnemyManager>();
    }

    public void SpawnGroup(){
        hasSpawned = true;
        for(int i =0; i < Enemies.Length; i++){
            Instantiate(Enemies[i], spawnPoints[i].position, Quaternion.identity);
        }
    }
}
