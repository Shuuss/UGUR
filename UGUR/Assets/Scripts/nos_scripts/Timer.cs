using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;

    public float time;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);

        text.text = minutes.ToString() + ":" + seconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        UpdateTime(time);
        if ((int)(time / 60f)>=5)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
