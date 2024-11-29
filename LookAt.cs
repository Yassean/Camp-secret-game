using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform target;
    Transform Enemy;
    public Transform e;
   // public Transform mount;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Enemy = enemyManager.instance.enemy.transform;
        target = playerManager.instance.player.transform;
        //target.LookAt(e);
        //Enemy.position = e.position;
    }

    // Update is called once per frame
    void Update()
    {
       // target.LookAt(e);
    }
}
