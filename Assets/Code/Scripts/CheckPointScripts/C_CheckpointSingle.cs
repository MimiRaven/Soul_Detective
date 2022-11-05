using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CheckpointSingle : MonoBehaviour
{
    private C_TrackCheckPoint trackCheckpoints;
 

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<C_PlayerController>(out C_PlayerController player))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
            
        }
    }

    public void SetTrackCheckPoints(C_TrackCheckPoint trackCheckPoints)
    {
        this.trackCheckpoints = trackCheckPoints;
    }
}
