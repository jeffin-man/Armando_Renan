using UnityEngine;

public class Bancada : MonoBehaviour
{
    [SerializeField] public GameObject tomatePrefab;
    public Vector3 offset = Vector3.up;
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(tomatePrefab, transform.position + offset, Quaternion.identity);
    }

}
