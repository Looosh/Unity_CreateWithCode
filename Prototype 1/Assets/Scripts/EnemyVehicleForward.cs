using UnityEngine;

public class EnemyVehicleForward : MonoBehaviour
{
    private float speed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move enemy vehicles forward automatically
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
