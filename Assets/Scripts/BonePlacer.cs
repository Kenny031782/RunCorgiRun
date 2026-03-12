using UnityEngine;

public class BonePlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.BoneMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BoneMaximumSecondsToWait;
    }
    // start timer to countdown to placing the bone

    // place bone
}

