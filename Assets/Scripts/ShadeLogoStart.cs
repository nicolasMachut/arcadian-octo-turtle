using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadeLogoStart : MonoBehaviour
{
    public float timerBeforeFade;
    private float timeStartFade = 0;
    private Image imageLogo;
    // Use this for initialization
    void Start()
    {
        this.imageLogo = this.gameObject.GetComponent<Image>();
        this.timeStartFade = Time.time + timerBeforeFade;
    }

    // Update is called once per frame


    void Update()
    {
        if (Time.time > timeStartFade)
        {
            this.imageLogo.CrossFadeAlpha(0f, 0.5f, false);
            
        }
    }
}
