using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    private int coinCount;
    public TMP_Text coinCountText;
    public RectTransform startPos;
    public RectTransform endPos;

    public Transform canvas;
    public GameObject coinPrefab;

    private void Start()
    {
        coinCountText.SetText(coinCount.ToString());
    }

    public void Test()
    {
        RectTransform coinRect = Instantiate(coinPrefab, canvas).GetComponent<RectTransform>();
        coinRect.position = startPos.position;
        coinRect.DOMove(endPos.position, 0.5f);
        Destroy(coinRect.gameObject, 0.3f);
        coinCount++;
        coinCountText.SetText(coinCount.ToString());
    }
}
