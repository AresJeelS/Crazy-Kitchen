using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;

    private IHasProgress _hasProgress;
    private void Start()
    {
        _hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (_hasProgress == null)
        {
            Debug.LogError("Game Object " + hasProgressGameObject + "no component");

        }
        _hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.ProgressNormalized;
        if (e.ProgressNormalized == 0f || e.ProgressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
