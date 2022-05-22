using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    [SerializeField] private Image gaugeBarImage;
    [SerializeField] private Text progressText;

    private float curProgress = 0;

    public void StartLoadingGauge(string msg = null)
    {
        this.gaugeBarImage.fillAmount = 0;
        this.curProgress = -1;

        if (!string.IsNullOrEmpty(msg)) progressText.text = msg;
    }

    public void UpdateLoadingGauge(float progress)
    {
        progress = Mathf.Clamp01(progress);
        if (this.curProgress < progress)
        {
            this.curProgress = progress;
        }

        this.progressText.text = this.curProgress.ToString("0.#%");
        this.gaugeBarImage.fillAmount = progress;
    }
}
