using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum breatheState{
    start,
    breathein,
    hold,
    breatheout,
    wait
}
public class BreatheManager : MonoBehaviour
{
    [SerializeField]
    public Slider breatheSlider;
    public TMP_Text sliderText;
    public Image sliderFill;

    public breatheState state = breatheState.start;
    private float countdown = 3f;
    private float breatheMax = 4f;
    private float breatheCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        state = breatheState.start;
        sliderText.text = string.Format("{0}",countdown);
        breatheSlider.maxValue = breatheMax;
        breatheSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state) {
            case breatheState.start:
                countdown -= Time.deltaTime;
                if (countdown <= 0) {
                    state = breatheState.breathein;
                } else {
                    sliderText.text = string.Format("{0:0}", countdown);
                }
                break;
            case breatheState.breathein:
                breatheCounter = 0;
                breatheSlider.value = 0;
                sliderText.text = "Breathe\nin";
                breatheMax = 5f;
                breatheSlider.maxValue = breatheMax;
                sliderFill.color = new Color32(56, 255, 152, 162);
                StartCoroutine(timer(breatheState.breathein));
                state = breatheState.wait;
                break;
            case breatheState.hold:
                breatheCounter = 0;
                breatheSlider.value = 0;
                sliderText.text = "Hold\nBreathe";
                breatheMax = 5f;
                breatheSlider.maxValue = breatheMax;
                sliderFill.color = new Color32(255, 152, 56, 162);
                StartCoroutine(timer(breatheState.hold));
                state = breatheState.wait;
                break;
            case breatheState.breatheout:
                breatheCounter = 0;
                breatheSlider.value = 0;
                sliderText.text = "Breathe\nout";
                breatheMax = 6f;
                breatheSlider.maxValue = breatheMax;
                sliderFill.color = new Color32(152, 56, 255, 162);
                StartCoroutine(timer(breatheState.breatheout));
                state = breatheState.wait;
                break;
            case breatheState.wait:
                break;
            default:
                Debug.LogError("Unhandled breathe state");
                break;
        }
    }
    IEnumerator timer(breatheState prevState) {
        while (breatheCounter < breatheMax)
        {
            breatheCounter += Time.deltaTime;
            breatheSlider.value = breatheCounter % breatheMax;
            yield return null;
        }
        switch(prevState) {
            case breatheState.breathein:
                state = breatheState.hold;
                break;
            case breatheState.hold:
                state = breatheState.breatheout;
                break;
            case breatheState.breatheout:
                state = breatheState.breathein;
                break;
        }
    }
}
