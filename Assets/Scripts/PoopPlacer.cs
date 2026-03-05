using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public GameObject PoopPrefab;
    
    // place poop in game
    public void Place(Vector3 corgiPosition)
    {
        Instantiate(PoopPrefab, corgiPosition, Quaternion.identity);
    }
}
