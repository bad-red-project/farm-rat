using UnityEngine;
using UnityEngine.UI;

public class InGameTime : MonoBehaviour
{
    public double minuteDurationInSeconds = 5.0;

    private double lastChange = 0.0;

    // represents hours from 0 to 23
    private int hour = 5;
    // represents minutes from 0 to 5 e.g. meaning 0 and 50 minutes 
    private int minutes = 5;

    private Text clockLabel;
    private Color colorDay = new Color(0, 0.5f, 1);
    private Color colorNight = new Color(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        clockLabel = GetComponent<Text>();
        ShowInGUI();
    }


    void Update()
    {
        if ((Time.time - lastChange) < minuteDurationInSeconds) 
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

        if (hour > 22 && hour < 6)
        {
            clockLabel.color = colorNight;
        }
        else
        {
            clockLabel.color = colorDay;
        }

        ShowInGUI();
        lastChange = Time.time;
    }

    void ShowInGUI()
    {
        clockLabel.text = hour.ToString().PadLeft(2,'0') + ":" + minutes.ToString().PadRight(2, '0');
    }
}
