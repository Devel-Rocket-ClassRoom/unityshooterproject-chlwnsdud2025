using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float power = 50f;
    public float jumpForce = 100f;
    public bool gravity = true;

    public GameObject canon;
    public Transform rotationPoint;

    public GameObject PalyerObject;


    public float rotationSpeed = 100.0f;
    public float moveSpeed = 30.0f;

    public GameObject mainCamera;

    public Transform camPoint;
    public Transform zoomPoint;


    void Start()
    {
        
    }

    void Update()
    {

       

        // 발사
        if (Input.GetMouseButtonDown(0))
        {
            GameObject canonBall = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = canonBall.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.useGravity = gravity;
                rb.linearVelocity = canonBall.transform.up * power;
            }

        }
        if (Input.GetMouseButton(1))
        {
            //GameObject canonBall = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            //Rigidbody rb = canonBall.GetComponent<Rigidbody>();

            //if (rb != null)
            //{
            //    rb.useGravity = !gravity;
            //    rb.linearVelocity = canonBall.transform.up * power;
            //}

            mainCamera.transform.position = zoomPoint.position;
        }
        else if (Input.GetMouseButtonUp(1)){
            mainCamera.transform.position = camPoint.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody Prb = GetComponent<Rigidbody>();

            if (Prb)
            {
                Prb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }


        //포신 상하 좌우 회전
        //float rotDir = 0;

        float HorizontalM = Input.GetAxis("Mouse X");
        float VerticalM = Input.GetAxis("Mouse Y");


        
        canon.transform.RotateAround(rotationPoint.position, rotationPoint.right, -rotationSpeed * VerticalM * Time.deltaTime);
        
        transform.Rotate(Vector3.up, HorizontalM * rotationSpeed * Time.deltaTime);



        /*
        //좌우 이동 방법-1
        if (Input.GetKey(KeyCode.D))
        {
            PalyerObject.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PalyerObject.transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }


        //좌우이동 방법-2
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = PalyerObject.transform.position;
            //Debug.Log("D입력" + transform.position);
           
            PalyerObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A입력" + transform.position);
            Vector3 pos = PalyerObject.transform.position;

           
            PalyerObject.transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = PalyerObject.transform.position;
            //Debug.Log("D입력" + transform.position);
            
            PalyerObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("A입력" + transform.position);
            Vector3 pos = PalyerObject.transform.position;

            
            PalyerObject.transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            
        }
        */


        float movwHor = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float movwVer = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        PalyerObject.transform.Translate(Vector3.right * movwHor);
        PalyerObject.transform.Translate(Vector3.forward * movwVer);



    }

    //private void OnTriggerEnter(Collider other)
    //{
      
    //    if (other.gameObject.CompareTag("Item"))
    //    {
    //        Destroy(other.gameObject);
    //    }

    //}
}
