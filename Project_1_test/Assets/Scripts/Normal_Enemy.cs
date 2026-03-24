using UnityEngine;

public class Normal_Enemy : MonoBehaviour
{

    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public float patrolSpeed = 2f;

    private Transform targetPoint;

    public int enemyHp = 100;

    public GameObject attack;
    public float sttackSpeed = 100f;
    public Transform SpawnPoint;
    float realTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = patrolPoint1;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHp <= 0)
        {

            Destroy(gameObject);
        }


        Patrol();

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

    public void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            if (targetPoint == patrolPoint1)
                targetPoint = patrolPoint2;
            else if(targetPoint == patrolPoint2)
                targetPoint = patrolPoint1;

            transform.Rotate(Vector3.up, 180);
        }
        //Debug.Log(targetPoint);

    }

    public void Hits(int damage)
    {
        enemyHp -= damage;
        Debug.Log("Enemy 남은 체력: " + enemyHp);
        if (enemyHp <= 0)
        {
            Debug.Log("적 처치!!");
            Destroy(gameObject);
        }

    }

    public void Attack()
    {
        GameObject AttackBall = Instantiate(attack, SpawnPoint.position, transform.rotation);
        Rigidbody rb = AttackBall.GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.linearVelocity = transform.forward * sttackSpeed;
        }
    }
}
