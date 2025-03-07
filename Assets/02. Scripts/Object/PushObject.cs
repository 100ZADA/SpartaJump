using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStool : MonoBehaviour
{
    public int pushPower;              // 밀리는 힘
    public float pushInterval;         // 호출 간격

    public List<ISObject> things = new List<ISObject>();

    void Start()
    {
        InvokeRepeating("PushPower", 0, pushInterval);
    }

    void PushPower()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalPush(pushPower);
        }
    }

    // 만약 트리거에서 접근하게 되면
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISObject pushAmount))
        {
            things.Add(pushAmount);
        }
    }

    // 만약 트리거에서 벗어나게 되면
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISObject pushAmount))
        {
            things.Remove(pushAmount);
        }
    }
}

