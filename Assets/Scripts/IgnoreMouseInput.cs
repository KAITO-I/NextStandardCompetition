using UnityEngine;
using UnityEngine.EventSystems;

class IgnoreMouseInput : StandaloneInputModule
{
    public override void Process()
    {
        bool usedEvent = SendUpdateEventToSelectedObject();

        if (eventSystem.sendNavigationEvents)
        {
            if (!usedEvent) usedEvent |= SendMoveEventToSelectedObject();
            if (!usedEvent) SendSubmitEventToSelectedObject();
        }
    }
}