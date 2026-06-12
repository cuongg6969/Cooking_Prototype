using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventBus.Publish(new TestEvent
        {
            message = "hello eventbus"
        });
    }
}
