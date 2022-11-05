using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TrackCheckPoint : MonoBehaviour
{

    private void Awake()
    {
        Transform checkpointsTransfrom = transform.Find("CheckPoints");

        foreach (Transform checkpointSingleTransfrom in checkpointsTransfrom)
        {
            C_CheckpointSingle checkpointSingle = checkpointSingleTransfrom.GetComponent<C_CheckpointSingle>();
            checkpointSingle.SetTrackCheckPoints(this);
        }
    }

    public void PlayerThroughCheckpoint(C_CheckpointSingle checkpointSingle)
    {
        Debug.Log(checkpointSingle.transform.name);
    }
}
