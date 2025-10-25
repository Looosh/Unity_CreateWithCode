using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeXTop = 10;
    private float spawnRangeZTop = 20;
    private float spawnRangeXSide = 25;
    private float spawnRangeZSideLower = -1;
    private float spawnRangeZSideUpper = 17;

    private float startDelay = 2;
    private float spawnInterval = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    /// <summary>
    /// Spawns a random animal at a random location within defined ranges.
    /// </summary>
    void SpawnRandomAnimal()
    {
        //Randomly generate animal type 
        int animalIndexTop = Random.Range(0, animalPrefabs.Length);
        int animalIndexRight = Random.Range(0, animalPrefabs.Length);
        int animalIndexLeft = Random.Range(0, animalPrefabs.Length);
        //Generate 3 random spawn locations on top, left, and right of the screen
        Vector3 spawnPosTop = new Vector3(Random.Range(-spawnRangeXTop, spawnRangeXTop), 0, spawnRangeZTop);
        Vector3 spawnPosRight = new Vector3(spawnRangeXSide, 0, Random.Range(spawnRangeZSideLower, spawnRangeZSideUpper));
        Vector3 spawnPosLeft = new Vector3(-spawnRangeXSide, 0, Random.Range(spawnRangeZSideLower, spawnRangeZSideUpper));

        Instantiate(animalPrefabs[animalIndexTop], spawnPosTop, animalPrefabs[animalIndexTop].transform.rotation);
        Instantiate(animalPrefabs[animalIndexRight], spawnPosRight, animalPrefabs[animalIndexRight].transform.rotation * Quaternion.Euler(0, 90, 0));
        Instantiate(animalPrefabs[animalIndexLeft], spawnPosLeft, animalPrefabs[animalIndexLeft].transform.rotation * Quaternion.Euler(0, -90, 0));
    }
}
