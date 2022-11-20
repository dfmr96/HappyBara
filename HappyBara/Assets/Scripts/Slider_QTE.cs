using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CGTespy.UI;
public class Slider_QTE : MonoBehaviour
{
    public Slider feedSlider;
    [SerializeField] RectTransform successZone;
    [SerializeField] RectTransform rectTransform;
    public int minValue = 0;
    public int maxValue = 100;
    public float sliderSpeed = 1.0f;
    public int randomNumber;
    public float minSuccess;
    public float maxSuccess;
    public float minError = 0.10f;
    private void Start()
    {
        FeedSliderInit();
        GetRandomNumber();
        GetSuccessZone();
        rectTransform.ApplyAnchorPreset(TextAnchor.LowerCenter,false, true);
    }

    public void MoveUI()
    {
        rectTransform.position = new Vector3 (0,-155,0);
    }

    void FeedSliderInit()
    {
        feedSlider = GetComponent<Slider>();
        feedSlider.minValue = minValue;
        feedSlider.maxValue = maxValue;
        feedSlider.value = minValue;
    }
    public void GetRandomNumber()
    {
        randomNumber = Random.Range(minValue, maxValue);
        minSuccess = randomNumber - minError;
        maxSuccess = randomNumber + minError;
    }
    public void ReInitQTE()
    {
        GetRandomNumber();
        GetSuccessZone();
    }

    public void GetSuccessZone()
    {
        successZone.anchorMin = new Vector2(minSuccess / 100, 0);
        successZone.anchorMax = new Vector2(maxSuccess / 100, 1);
    }

    public bool SuccessAction()
    {
        if (feedSlider.value >= minSuccess && feedSlider.value <= maxSuccess)
        {
            return true;    
        } else
        {
            return false;
        }
    }

    private void Update()
    {
        feedSlider.value += sliderSpeed * Time.deltaTime;

        if (feedSlider.value == maxValue || feedSlider.value == minValue)
        {
            sliderSpeed = -sliderSpeed;
        }
    }
}
