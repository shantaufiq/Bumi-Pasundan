using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCookingProcess : MonoBehaviour
{
    [Header("Cooking Components")]
    public GameObject panelChallenge;
    public CookingManager challengeManager;

    [Header("PopUp Result")]
    // public TextMeshProUGUI title;
    public GameObject popUpDialog;
    public GameObject btn_reset;
    public GameObject btn_confirm;
    public TextMeshProUGUI dialogMessage;

    [Header("Countdown Timer")]
    public TextMeshProUGUI TimeTxt;

    public void SetTimerTextValue(string _time)
    {
        TimeTxt.text = _time;
    }

    public void OnStartCookingProcess()
    {
        panelChallenge.SetActive(true);
    }

    public void CloseDisplay()
    {
        panelChallenge.SetActive(false);
        popUpDialog.SetActive(false);
    }

    public void OnClickResetChallenge()
    {
        popUpDialog.SetActive(false);
        challengeManager.ResetChallengeSetting();
    }

    public void SetActivePopUpResult(string _dialogMessage)
    {
        popUpDialog.SetActive(true);
        dialogMessage.text = _dialogMessage;

        if (_dialogMessage == "failed")
        {
            btn_reset.SetActive(true);
            btn_confirm.SetActive(false);
        }
        else if (_dialogMessage == "complete")
        {
            btn_confirm.SetActive(true);
            btn_reset.SetActive(false);
        }
    }
}
