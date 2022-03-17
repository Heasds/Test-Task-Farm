using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public float growTime;
    public float startGrowTime;

    public List<GameObject> growObjectSteps;
    public int growStep;

    private void Start()
    {
        startGrowTime = growTime;
        StartCoroutine(Grow());
    }

    private void Update()
    {
        if (growTime > 0) growTime -= Time.deltaTime;
    }

    public void RestartGrowing()
    {
        for (int i = 0; i < growObjectSteps.Count; i++)
        {
            growObjectSteps[i].SetActive(false);
        }

        growTime = startGrowTime;
        growStep = 0;
        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        if (growTime > 0)
        {
            yield return new WaitForSeconds(startGrowTime / growObjectSteps.Count);

            for (int i = 0; i < growObjectSteps.Count; i++)
            {
                growObjectSteps[i].SetActive(false);
            }

            growObjectSteps[growStep].SetActive(true);

            growStep++;

            StartCoroutine(Grow());
        }
        else StopCoroutine(Grow());

    }
}
