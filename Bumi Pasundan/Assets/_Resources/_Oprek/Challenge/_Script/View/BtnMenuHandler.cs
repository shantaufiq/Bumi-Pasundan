using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMenuHandler : MonoBehaviour
{
    [Header("Components")]
    public int _btnIndex;
    public Image _image;
    [Header("Flow Manager")]
    public FlowManager _FlowManager;

    private void Start()
    {
        _FlowManager = FindObjectOfType<FlowManager>();
    }

    public void SetMenuIndex()
    {
        // Debug.Log($"Button Index: {_btnIndex}");
        _FlowManager.ShowFoodDescription(_btnIndex);
    }
}
