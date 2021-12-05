using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplay : MonoBehaviour
{
    private Rigidbody rigidbody;
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();

    private bool isInReplayMode;
    private int currentReplayIndex;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isInReplayMode = !isInReplayMode;

            if (isInReplayMode)
            {
                SetTransform(0);
                rigidbody.isKinematic = true;
            }
            else
            {
                SetTransform(actionReplayRecords.Count - 1);
                rigidbody.isKinematic=false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (!isInReplayMode)
            actionReplayRecords.Add(new ActionReplayRecord { Position = transform.position, Rotation = transform.rotation });
        else
        {
            int nextIndex = currentReplayIndex + 1;
            if (nextIndex<actionReplayRecords.Count)
            {
                SetTransform(nextIndex);
            }
        }
    }

    private void SetTransform(int index)
    {
        currentReplayIndex = index;
        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.Position;
        transform.rotation = actionReplayRecord.Rotation;
    }
}
