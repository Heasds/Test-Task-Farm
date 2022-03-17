using UnityEngine;

public class PlantCollect : MonoBehaviour
{
    private Growing growing;

    public GameObject plantPrefab;
    public GameObject hayPrefab;

    private void Start()
    {
        growing = GetComponent<Growing>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sickle" && growing.growTime <= 0) Collect();
    }

    private void Collect()
    {
        Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));

        Instantiate(hayPrefab, transform.position + offset, Quaternion.identity);

        growing.RestartGrowing();
    }
}
