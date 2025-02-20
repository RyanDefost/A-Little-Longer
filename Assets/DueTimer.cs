using TMPro;
using UnityEngine;

public class DueTimer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public TextMeshProUGUI InfoText;
    public TextMeshProUGUI timeText;

    private bool _isNegative = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        SetInfoText();

        if (timerIsRunning)
        {
            if (timeRemaining > 0 && !_isNegative)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining, true);
            }
            else
            {
                _isNegative = true;
                timeText.color = Color.red;

                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining, false);
            }
        }
    }

    void DisplayTime(float timeToDisplay, bool isMinus)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //

        if (isMinus)
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeText.text = string.Format("-{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void SetInfoText()
    {
        if (_isNegative)
        {

            InfoText.text = "YOU LOST\r\nGET BACK TO WORK!\r\n\r\nDEADLINE DUE IN:";
        }
        else
        {
            InfoText.text = "CONGRATULATIONS!\r\nYOU STILL GOT TIME TO WORK\r\n\r\nDEADLINE DUE IN:";
        }
    }
}
