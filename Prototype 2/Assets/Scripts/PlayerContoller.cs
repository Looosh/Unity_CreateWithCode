using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;
    private float xRange = 20;
    private float zRangeLow = 0;
    private float zRangeHigh = 15;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        preventOutBoundMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //Vertical Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    /// <summary>
    /// Checks and prevents the player from moving outside of defined boundaries.
    /// </summary>
    void preventOutBoundMovement()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < zRangeLow)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeLow);
        }
        if (transform.position.z > zRangeHigh)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeHigh);
        }
    }
}
