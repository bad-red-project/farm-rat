using BayatGames.SaveGameFree;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameTime : MonoBehaviour
{
    private TimeSpan clock = new TimeSpan(1,12,20,0);

    private Text clockLabel;

    private int dayBegin = 6;
    private int dayEnd = 21;
    private Color colorDay = new Color(0.8f, 0.8f, 1);
    private Color colorNight = new Color(0.2f, 0.2f, 0.2f);
    private Boolean abc = false;

    private const int TimeActionMultiplier = 20;
    public enum TimeActionEnum
    {
        ExtraShort,
        Short,
        Medium,
        Long,
        ExtraLong
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
        clockLabel = GetComponent<Text>();
        UpdateDayTime();
        ShowInGUI();
    }

    void Update()
    {
        if (!abc) {
            abc = true;
            TimeAction(TimeActionEnum.ExtraLong);
        }
        // no auto update
    }

    private void UpdateTime(int minutesToAdd)
    {
        clock += new TimeSpan(0, 0, minutesToAdd, 0);

        UpdateDayTime();
        ShowInGUI();
        Save();
    }

    void ShowInGUI()
    {
        clockLabel.text = clock.Hours.ToString().PadLeft(2, '0') + ":" + clock.Minutes.ToString().PadRight(2, '0');
    }

    void UpdateDayTime()
    {
        bool isDay = clock.Hours >= dayBegin && clock.Minutes < dayEnd;
        if (isDay)
        {
            clockLabel.color = colorDay;
            return;
        }
        clockLabel.color = colorNight;
    }

    public void Load()
    {
        clock = SaveGame.Load<TimeSpan>("clock");
    }

    public void Save()
    {
        SaveGame.Save<TimeSpan>("clock", clock);
    }

    /// <summary>
    /// Perfroms a time action incrementing the in-game time
    /// </summary>
    /// <param name="eventDuration">Defines the value of the time increment</param>
    public void TimeAction(TimeActionEnum eventDuration)
    {
        int minutesDuration = TimeActionMultiplier * ((int)eventDuration + 1);
        UpdateTime(minutesDuration);
    }

    public void SkipADay()
    {
        int dayMinutes = 60*24;
        UpdateTime(dayMinutes);
    }

    public void SkipToMorning()
    {
        throw new NotImplementedException();
    }
}
