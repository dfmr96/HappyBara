using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_QTE : MonoBehaviour
{
    public Slider feedSlider;
    [SerializeField] RectTransform successZone;

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
    }

    void FeedSliderInit()
    {
        feedSlider = GetComponent<Slider>();
        feedSlider.minValue = minValue;
        feedSlider.maxValue = maxValue;
        feedSlider.value = minValue;
    }
    void GetRandomNumber()
    {
        randomNumber = Random.Range(minValue, maxValue);
        minSuccess = randomNumber * (1 - minError);
        maxSuccess = randomNumber * (1 + minError);
    }

    void GetSuccessZone()
    {
        successZone.anchorMin = new Vector2(minSuccess / 100, 0);
        successZone.anchorMax = new Vector2(maxSuccess / 100, 1);
    }

    void SuccessAction()
    {

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
