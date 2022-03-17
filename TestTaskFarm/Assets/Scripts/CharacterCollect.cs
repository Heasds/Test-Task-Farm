using UnityEngine;

public class CharacterCollect : MonoBehaviour
{
    private CharacterMove characterMove;
    private CharacterInventory characterInventory;

    private void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        characterInventory = GetComponent<CharacterInventory>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wheat" && other.GetComponent<Growing>().growTime <= 0 
            && characterInventory.hayCount < characterInventory.maxHayCount) characterMove.animator.SetTrigger("Hit");
    }
    private void OnTriggerExit(Collider other)
    {
        characterMove.animator.SetBool("Run", true);
    }
}
