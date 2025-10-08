using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Two camera positions relative to the player
    private Vector3 thirdPersonOffset = new Vector3(0, 5.5f, -7.5f);
    private Vector3 firstPersonOffset = new Vector3(0, 2.5f, 1.3f);

    private Vector3 currentOffset;
    private bool isFirstPerson = false;

    void Start()
    {
        currentOffset = thirdPersonOffset;
    }

    void Update()
    {
        // Toggle between first- and third-person when you press C
        if (Input.GetKeyDown(KeyCode.T))
        {
            isFirstPerson = !isFirstPerson;
            currentOffset = isFirstPerson ? firstPersonOffset : thirdPersonOffset;
        }
    }

    void LateUpdate()
    {
        if (isFirstPerson)
        {
            // Position relative to the car
            transform.position = player.transform.position + player.transform.TransformDirection(firstPersonOffset);
            // Rotate with the car
            transform.rotation = player.transform.rotation;
        }
        else
        {
            // Third-person: offset behind the car, no rotation
            transform.position = player.transform.position + thirdPersonOffset;
        }
    }
}
