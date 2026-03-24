using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemyHp = 100;

    public GameObject attack;
    public float sttackSpeed = 100f;
    public Transform SpawnPoint;
    float realTime;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHp <= 0)
        {

            Destroy(gameObject);
        }

        if (realTime < 0.5)
        {
            realTime += Time.deltaTime;
        }
        else
        {
            realTime = 0;
            Attack();
        }

    }


    public void Hits(int damage)
    {
        enemyHp -= damage;
        Debug.Log("Boss 남은 체력: " + enemyHp);
        if (enemyHp <= 0)
        {
            Debug.Log("보스 처치!!");
            SpawnManager spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            spawn.enemyExist = false;
            Destroy(gameObject);
        }

    }

    public void Attack()
    {
        GameObject AttackBall = Instantiate(attack, SpawnPoint.position, attack.transform.rotation);
        Rigidbody rb = AttackBall.GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.linearVelocity = AttackBall.transform.forward * sttackSpeed * -1;
        }
    }


}