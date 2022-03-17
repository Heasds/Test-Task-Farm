using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInventory : MonoBehaviour
{
    public TMP_Text hayCountText;
    public int hayCount;
    public int maxHayCount;
    public Transform hayTarget;

    public List<GameObject> hayStack;

    private void Start()
    {
        hayCountText.SetText(hayCount.ToString() + " / " + maxHayCount.ToString());
    }

    public void AddToStack()
    {
        for (int i = 0; i < hayCount; i++)
        {
            hayStack[i].SetActive(true);
            hayCountText.SetText(hayCount.ToString() + " / " + maxHayCount.ToString());
        }
    }  
}
