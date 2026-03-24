using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject BlockPrefabs;

    public int raw = 50;
    public int col = 20;

    Vector3 blockPosition = new Vector3(-75, 3.01f, 50);
    public Transform blockTransform;


    public GameObject enemyPrefabs;
    public GameObject bossPrefabs;
    public Transform enemySpawn;

    public bool enemyExist = false;
    void Start()
    {


        Vector3 pos = blockTransform.position;
        for (int i=0; i< col; i++)
        {
            for(int j=0; j< raw; j++)
            {

                //Instantiate(BlockPrefabs, blockPosition, BlockPrefabs.transform.rotation);
                //blockPosition += new Vector3(3.15f, 0, 0);

                

                pos.x = blockTransform.position.x + j * 3.2f;

                pos.y = (i + 1) * 3.2f;
                   

                Instantiate(BlockPrefabs, pos, BlockPrefabs.transform.rotation);

            }
            //blockPosition.x = -75;
            //blockPosition += new Vector3(0, 3.1f, 0);
        }

        
    }

    void Update()
    {
        if (enemyExist == false)
        {
            Vector3 randompos = new Vector3(Random.Range(-100,100), enemySpawn.position.y, enemySpawn.position.z);
            Instantiate(enemyPrefabs, randompos, enemyPrefabs.transform.rotation);
            enemyExist = true;
        }

    }

}
