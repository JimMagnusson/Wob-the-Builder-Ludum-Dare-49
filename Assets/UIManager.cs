using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image winPopup = null;
    [SerializeField] private Image losePopup = null;
    [SerializeField] private Image timeToWinPopup = null;
    [SerializeField] private TextMeshProUGUI timeToWinText = null;

    private string timeToWinString;

    private void Start()
    {
        if (timeToWinText == null) { Debug.LogError("Time to win text no reference found."); }
    }

    public void ToggleTimeToWinPopup(bool toggle)
    {
        timeToWinPopup.gameObject.SetActive(toggle);
    }

    public void ToggleWinPopup(bool toggle)
    {
        winPopup.gameObject.SetActive(toggle);
    }

    public void ToggleLosePopup(bool toggle)
    {
        losePopup.gameObject.SetActive(toggle);
    }

    public void UpdateTimeToWinText(float timeToWin)
    {
        timeToWinString = ((int)(timeToWin + 1)).ToString();
        timeToWinText.text = timeToWinString;

        // Edit transparancy based on how close to next second it is.
        float diff = timeToWin - (int)timeToWin;
        timeToWinText.alpha = diff / 1f;
    }
}
