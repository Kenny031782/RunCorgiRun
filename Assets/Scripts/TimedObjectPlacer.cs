using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    public float minimumSecondsToWait;
    public float maximumSecondsToWait;
    
    private bool isOkToCreate = true;
    void Update()
    {
        if (isOkToCreate) 
        {
            StartCoroutine(CountDownUntilCreation());
        }
    }

    IEnumerator CountDownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        
        isOkToCreate = true;
    }

    public virtual void Place()    // virtuals says its ok to have 2 place methods
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
