using UnityEngine;
using UnityEngine.UI;

public class InGameTime : MonoBehaviour
{
    public double minuteDurationInSeconds = 5.0;
    // can be used to reduce time needed for the day time to last shorter or longer
    private double dayTimeBias = 0;

    private double lastChange = 0.0;

    // represents hours from 0 to 23
    private int hour = 5;
    // represents minutes from 0 to 5 e.g. meaning 0 and 50 minutes 
    private int minutes = 4;

    private Text clockLabel;

    private int dayBegin = 6;
    private int dayEnd = 21;
    private Color colorDay = new Color(0.8f, 0.8f, 1);
    private Color colorNight = new Color(0.2f, 0.2f, 0.2f);

    // Start is called before the first frame update
    void Start()
    {
        clockLabel = GetComponent<Text>();
        UpdateDayTime();
        ShowInGUI();
    }


    void Update()
    {
        if ((Time.time - lastChange) < minuteDurationInSeconds + dayTimeBias) 
        {
            return;
        }
             
        minutes++;
        if (minutes == 6)
        {
            minutes = 0;
            hour++;
            if (hour == 24)
            {
                hour = 0;
            }
        }

        UpdateDayTime();
        ShowInGUI();
        lastChange = Time.time;
    }

    void ShowInGUI()
    {
        clockLabel.text = hour.ToString().PadLeft(2,'0') + ":" + minutes.ToString().PadRight(2, '0');
    }

    void UpdateDayTime() 
    {
        bool isDay = hour >= dayBegin && hour < dayEnd;
        if (isDay)
        {
            clockLabel.color = colorDay;
            dayTimeBias = 0;
        }
        else
        {
            clockLabel.color = colorNight;
            // makes night shorter
            dayTimeBias = -minuteDurationInSeconds*0.8;
        }
    }
}
