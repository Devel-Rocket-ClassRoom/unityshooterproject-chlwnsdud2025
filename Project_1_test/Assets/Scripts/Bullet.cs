using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player != null)
            {
                if (!player.Compute_Damage(damage))
                {
                    Debug.Log("»ç¸Á!");
                }
            }
            Destroy(gameObject);
        }
    }
}
