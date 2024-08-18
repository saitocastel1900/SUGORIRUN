using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] RawImage _backgroundRawImage;
    [SerializeField] private float _scrollSpeedX = 0.04f;
    [SerializeField] private float _scrollSpeedY = 0.0f;

    void Start()
    {
        Observable
            .EveryUpdate()
            .Subscribe(_ => Scroll())
            .AddTo(this);
    }

    private void Scroll()
    {
        var rect = _backgroundRawImage.uvRect;
        rect.x = (rect.x + _scrollSpeedX * Time.unscaledDeltaTime) % 1.0f;
        rect.y = (rect.y + _scrollSpeedY * Time.unscaledDeltaTime) % 1.0f;
        _backgroundRawImage.uvRect = rect;
    }
}