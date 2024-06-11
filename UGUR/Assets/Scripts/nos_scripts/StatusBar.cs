using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Image barSprite;

    private Camera cam;

    public void UpdateHealthBar(int current,int max)
    {
        barSprite.fillAmount = (float)current / max;
        /*float state = (float)current;
        state /= max;
        if (state < 0f)
        {
            state = 0f;
        }

        Bar.transform.localScale = new Vector3(state, 1f, 1f);*/
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((transform.position - cam.transform.position));
    }
}
