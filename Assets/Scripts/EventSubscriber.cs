using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.Subscribe<TestEvent>(OnTestEvent);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<TestEvent>(OnTestEvent);
    }

    private void OnTestEvent(TestEvent data)
    {
        Debug.Log(data.message);
    }
}