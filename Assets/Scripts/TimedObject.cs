using System.Collections;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public float secondsOnScreen = 1f;
    
    public void Start()
    {
        // start timer to remove us
        StartCoroutine(CountDownUntilDeath());
    }
    
    IEnumerator CountDownUntilDeath()
    {
        // timer that counts down and then removes us
        yield return new WaitForSeconds(secondsOnScreen);
        Destroy(gameObject);
    }
}
