using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int Health = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Compute_Damage(int damage)
    {
        Health -= damage;
        Debug.Log("Player 남은 체력 : " + Health);
        if (Health <= 0)
        {
           
            return false;
        }
        return true;
    }

    public void PlayerHeal(int healAmount)
    {
        Health += healAmount;
        Debug.Log("Player Heal 현재 체력 : " + Health);
    }
}
