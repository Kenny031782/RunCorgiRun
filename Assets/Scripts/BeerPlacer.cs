using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BeerPlacer : MonoBehaviour
{
    public GameObject BeerPrefab;
    
    void Update()
    {
        StartCoroutine(CountDownUntilCreation());
    }

    IEnumerator CountDownUntilCreation()
    {
        yield return new WaitForSeconds(3f);
        Place();
    }

    private void Place()
    {
        Instantiate(BeerPrefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
