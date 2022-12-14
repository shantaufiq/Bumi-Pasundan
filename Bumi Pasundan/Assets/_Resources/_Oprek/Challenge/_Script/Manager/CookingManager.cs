using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : MonoBehaviour
{
    public bool isPlay;

    [Header("Slider Components")]
    public Slider slider;
    public float setSliderSpeed;
    [SerializeField] float sliderSpeed;
    public float speedDifficulty;

    [Header("Target Area")]
    public GameObject targetArea;
    public AreaStatus StatusResult;

    [Header("PopUp Result")]
    public DisplayCookingProcess _DisplayCookingProcess;

    [Header("Timer Components")]
    public float setDuration;
    float duration;
    string stringTimer = "00:00";

    public AreaStatus GenerateStatusResult
    {
        get
        {
            return StatusResult;
        }
        set
        {
            StatusResult = value;
        }
    }

    protected string GenerateScore(AreaStatus _status)
    {
        return _status switch
        {
            AreaStatus.OverCook => "failed",
            AreaStatus.Raw => "failed",
            AreaStatus.Great => "complete",
            AreaStatus.Perfect => "complete",
            _ => "null"
        };
    }

    private void Awake()
    {
        // ResetChallengeSetting();
    }

    private void Start()
    {
        // ResetChallengeSetting();
    }

    private void OnEnable()
    {
        isPlay = true;

        ResetChallengeSetting();
    }

    public void ResetChallengeSetting()
    {
        //? Reset setting
        duration = setDuration;
        sliderSpeed = setSliderSpeed;
        isPlay = true;
        targetArea.transform.localPosition = new Vector3(Random.Range(0, 30),
        targetArea.transform.localPosition.y,
        targetArea.transform.localPosition.z);
        // nextActionTime = 0f;
    }

    private void Update()
    {
        if (isPlay)
        {
            float speed = Mathf.PingPong(sliderSpeed * Time.time, 10f);
            slider.value = speed;
            // Debug.Log(speed);
        }

        // Debug.Log(GenerateStatusResult);

        Timer();
        SetDinamicdifficulty();
    }

    public void OnClickFinishCook()
    {
        StartCoroutine(DisplayPopUpResult());

        // ResetChallengeSetting();
    }

    public IEnumerator DisplayPopUpResult()
    {
        isPlay = false;

        yield return new WaitForEndOfFrame();

        _DisplayCookingProcess.SetActivePopUpResult(GenerateScore(GenerateStatusResult));
    }

    // ! Timer Method
    private void Timer()
    {
        if (isPlay && duration > 0)
        {
            stringTimer = TimeCalculation();

            _DisplayCookingProcess.SetTimerTextValue(stringTimer);

            if (duration <= 0)
            {
                duration = 0;
                _DisplayCookingProcess.SetTimerTextValue("00:00");

                isPlay = false;
                _DisplayCookingProcess.SetActivePopUpResult("Failed");
                ResetChallengeSetting();
            }
        }
    }

    private string TimeCalculation()
    {
        duration -= Time.deltaTime;

        float minutes = Mathf.FloorToInt((duration / 60));
        float seconds = Mathf.FloorToInt((duration % 60));

        return string.Format("{1:00}", minutes, seconds);
    }

    float DelayAmount = .01f;
    protected float nextHit;
    public void SetDinamicdifficulty()
    {
        if (!isPlay) return;

        nextHit += Time.deltaTime;

        if (nextHit >= DelayAmount)
        {
            nextHit = 0f;
            // sliderSpeed += (speedDifficulty * Time.deltaTime) / 2;
            // Debug.Log("coba");
        }
    }
}
