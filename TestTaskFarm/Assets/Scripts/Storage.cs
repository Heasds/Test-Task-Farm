using UnityEngine;

public class Storage : MonoBehaviour
{
    private CharacterInventory characterInventory;
    private GameObject hay;

    public CoinsCollect coinsCollect;
    public GameObject hayPrefab;
    public Transform storage;

    private void OnTriggerEnter(Collider other)
    {
        characterInventory = other.GetComponent<CharacterInventory>();
    }
    private void OnTriggerExit(Collider other)
    {
        characterInventory = null;
        Destroy(hay);
    }

    private void Update()
    {
        if (characterInventory != null && characterInventory.hayCount > 0)
        {
            if (hay == null)
            {
                hay = Instantiate(hayPrefab, characterInventory.gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                if (Vector3.Distance(hay.transform.position, storage.position) > 0)
                {
                    hay.transform.position = Vector3.MoveTowards(hay.transform.position, storage.position, 10f * Time.deltaTime);

                }
                else
                {
                    characterInventory.hayCount -= 1;
                    characterInventory.hayStack[characterInventory.hayCount].SetActive(false);
                    characterInventory.hayCountText.SetText(characterInventory.hayCount.ToString() + " / " + characterInventory.maxHayCount.ToString());
                    coinsCollect.Test();
                    Destroy(hay);
                }
            }
        }
    }

 
}
