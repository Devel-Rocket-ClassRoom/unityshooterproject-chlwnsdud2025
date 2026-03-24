using UnityEngine;

public class Check_Colision : MonoBehaviour
{
    

    public int damage = 30;
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("충돌 시작: " + other.gameObject.name);
        if(other.gameObject.CompareTag("Block"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.Hits(damage);
           

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("NEnemy"))
        {
            Normal_Enemy NenemyScript = other.gameObject.GetComponent<Normal_Enemy>();
            NenemyScript.Hits(damage);
            

            Destroy(gameObject);
        }
        
        
    }
    //void OnCollisionStay(Collision other)
    //{
    //    Debug.Log("충돌 중: " + other.gameObject.name);
    //}
    //void OnCollisionExit(Collision other)
    //{
    //    Debug.Log("충돌 끝: " + other.gameObject.name);
    //}
}


