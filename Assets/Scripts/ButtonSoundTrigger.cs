using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundTrigger : MonoBehaviour
{
    private void ClickSound(BaseEventData eventData)
    {
        SoundManager.Instance.PlaySound2D("Click");
    }
    private void HoverSound(BaseEventData eventData)
    {
        SoundManager.Instance.PlaySound2D("Hover");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventTrigger evTrig = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry clickEvent = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerClick
        };
        EventTrigger.Entry hoverEvent = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerEnter
        };
        clickEvent.callback.AddListener(ClickSound);
        hoverEvent.callback.AddListener(HoverSound);
        evTrig.triggers.Add(clickEvent);
        evTrig.triggers.Add(hoverEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
