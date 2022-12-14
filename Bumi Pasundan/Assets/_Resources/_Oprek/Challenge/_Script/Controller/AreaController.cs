using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AreaStatus
{
    Raw, Great, Perfect, OverCook
}

public class AreaController : MonoBehaviour
{
    public CookingManager _CookingManager;
    public AreaStatus _AreaStatus;
    bool OnArea;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Handle" && _CookingManager.isPlay)
            StartCoroutine(OnColliderBehaviour(other, true));
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Handle" && _CookingManager.isPlay)
            StartCoroutine(OnColliderBehaviour(other, false));
    }

    public IEnumerator OnColliderBehaviour(Collider2D col, bool status)
    {
        OnArea = status;

        yield return new WaitForEndOfFrame();

        if (OnArea)
        {
            switch (_AreaStatus)
            {
                case AreaStatus.Perfect:
                    _CookingManager.GenerateStatusResult = AreaStatus.Perfect;
                    break;
                case AreaStatus.Great:
                    _CookingManager.GenerateStatusResult = AreaStatus.Great;
                    break;
                case AreaStatus.Raw:
                    _CookingManager.GenerateStatusResult = AreaStatus.Raw;
                    break;
                case AreaStatus.OverCook:
                    _CookingManager.GenerateStatusResult = AreaStatus.OverCook;
                    break;
            }
        }
    }
}
