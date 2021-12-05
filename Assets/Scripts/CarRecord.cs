using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRecord : MonoBehaviour
{ 
    public List<ActionReplayRecord>[] ActionReplayRecords = new List<ActionReplayRecord>[7];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            ActionReplayRecords[i] = new List<ActionReplayRecord>();
        }
    }
}
