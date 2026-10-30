using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x75955c9b : MonoBehaviour
{
    public bool IsScaledDownOnAwake = true;
    public TMP_Text MainText;
    public void Show()
    {
        this._0xb5770b42();
        if (this.Content != null)
        {
            DOTween.Kill(this.Content.transform, true);
            this.Content.SetActive(true);
            this.Content.transform.DOScale(1f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
            {
                _0x2f4dab23.Instance._0x42658892(_0x2f4dab23.Instance.CurrentPanelIndex);
            });
        }
    }

    public Ease Ease = Ease.OutSine;
    private bool _0x9524a1e0 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    public void _0x78140573()
    {
        this._0x4c8e31f8();
        this.Content.SetActive(true);
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.localScale = Vector3.one;
        _0x2f4dab23.Instance._0x42658892(_0x2f4dab23.Instance.CurrentPanelIndex);
    }

    public float ScaleDuration = 0.4f;
    private void _0xcbb35e26()
    {
        if (this.OuterBackground != null)
        {
            Image _0xb08d9c10 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xb08d9c10, true);
            _0xb08d9c10.DOFade(0f, this.ScaleDuration);
        }
    }

    public void _0x4c5c7f81()
    {
        this._0xcbb35e26();
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
        {
            this.Content.SetActive(false);
        });
    }

    public GameObject OuterBackground;
    public TMP_Text HeaderText;
    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.OuterBackground != null)
            this.OuterBackground.gameObject.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0x093760a8();
    }

    private void _0xb5770b42()
    {
        if (this.OuterBackground != null)
        {
            Image _0x60e63ef6 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x60e63ef6, true);
            _0x60e63ef6.DOFade(1f, this.ScaleDuration / 2f);
        }
    }

    private void _0x4c8e31f8()
    {
        if (this.OuterBackground != null)
        {
            Image _0xe2fe272c = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xe2fe272c, true);
            _0xe2fe272c.DOFade(1f, 0f);
        }
    }

    private void _0x093760a8()
    {
        if (this.OuterBackground != null)
        {
            Image _0x7b32b5a0 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x7b32b5a0, true);
            _0x7b32b5a0.DOFade(0f, 0.01f);
        }

        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, 0.01f);
    }

    public GameObject Content;
}