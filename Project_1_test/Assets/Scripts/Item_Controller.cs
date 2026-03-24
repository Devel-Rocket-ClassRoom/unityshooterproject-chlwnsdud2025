using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    int heal = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 2f);
        

    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.PlayerHeal(heal);
               
            }
            Destroy(gameObject);
        }
    }
}
