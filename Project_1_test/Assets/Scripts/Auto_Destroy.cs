using UnityEngine;

public class Auto_Destroy : MonoBehaviour
{
    float realTime = 0;
    public float destroyTime = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;

        if(realTime > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
