
using UnityEngine;
using UnityEngine.EventSystems;

namespace BumiPasundan
{
    public enum ButtonIdentity
    {
        RightButton, LeftButton, JumpButton
    }
    public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public ButtonIdentity _ButtonIdentity;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClickCondition();
            // Debug.Log("on pointer down");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            InputController.instance.input = Vector2.zero;
            // Debug.Log("on pointer up");
        }

        public void OnClickCondition()
        {
            switch (_ButtonIdentity)
            {
                case ButtonIdentity.LeftButton:
                    InputController.instance.input.x = -1f;
                    break;
                case ButtonIdentity.RightButton:
                    InputController.instance.input.x = 1f;
                    break;
            }

            if (_ButtonIdentity == ButtonIdentity.JumpButton) InputController.instance.input.y = 1f;
        }
    }
}
