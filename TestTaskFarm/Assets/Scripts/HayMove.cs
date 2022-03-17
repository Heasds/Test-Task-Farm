using UnityEngine;

public class HayMove : MonoBehaviour
{
    private CharacterInventory characterInventory;
    public float speed;

    private void Start()
    {
        characterInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventory>();
    }

    private void Update()
    {
        if (characterInventory.hayCount < characterInventory.maxHayCount)
        {
            if (Vector3.Distance(transform.position, characterInventory.hayTarget.position) < 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, characterInventory.hayTarget.position, speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, characterInventory.hayTarget.position) < 0.1f)
            {

                characterInventory.hayCount++;
                characterInventory.AddToStack();
                Destroy(gameObject);
            }
        }
    }
}
