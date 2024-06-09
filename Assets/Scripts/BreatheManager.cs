using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Ui states
public enum breatheState{
    start,
    breathein,
    hold,
    breatheout,
    wait
}
public class BreatheManager : MonoBehaviour
{
    // Actual UI references
    [SerializeField]
    public Slider breatheSlider;
    public TMP_Text sliderText;
    public Image sliderFill;

    // UI State
    public breatheState state = breatheState.start;

    // Beginning countdown
    private float countdown = 3f;

    // Value that the timer goes up to i.e. timer goes up to 4 seconds
    private float breatheMax = 4f;

    // actual timer value
    private float breatheCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        state = breatheState.start;
        sliderText.text = string.Format("{0}",countdown);
        breatheSlider.maxValue = breatheMax;
        breatheSlider.minValue = 0;
        sliderText.color = new Color(255f,255f,255f);
    }

    // Update is called once per frame
    void Update()
    {
        switch(state) {
            // Starting countdown before loop
            case breatheState.start:
                countdown -= Time.deltaTime;
                if (countdown <= 0) {
                    state = breatheState.breathein;
                } else {
                    sliderText.text = string.Format("{0:0}", countdown);
                }
                break;
            // Change text to Breathe IN and set timer values and colors
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
            // Change text to hold breathe and set timer values and colors
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
            // Change text to breathe out and set timer values and colors
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
            // Intermediate state waiting for timer to complete
            case breatheState.wait:
                break;
            default:
                Debug.LogError("Unhandled breathe state");
                break;
        }
    }
    /* Coroutine that essentially counts up to breatheMax 
     * then changes state once breatheMax is reached
     * Param: takes in previous state before entering waiting state
     * This allows it to jump to the correct next state
     */
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
