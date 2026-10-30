using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Dresses the loading screen: a deep wash over the garden art, an abstract mark and a
/// readable progress bar. The splash script itself is never touched - only colours,
/// sprites and objects added next to it.
public sealed class _0xdf723253 : MonoBehaviour
{
    private Transform _0xe5bc8532;
    [SerializeField]
    private Sprite _emblem;
    private const float LoadingSize = 36f;
    private void OnDestroy()
    {
        if (this._0xe5bc8532 != null)
        {
            DOTween.Kill(this._0xe5bc8532);
        }
    }

    private void Start()
    {
        _0x4ccc2a9a _0xa22d077d = _0x4ccc2a9a.Instance;
        if (_0xa22d077d == null)
        {
            return;
        }

        this._0x38c087ee(_0xa22d077d);
        this._0x35d20d30(_0xa22d077d);
        this._0x337ca692(_0xa22d077d);
    }

    [SerializeField]
    private Sprite _trackSprite;
    /// The template ships the bar white-on-white at alpha 0.004, which renders as nothing.
    /// The fill takes the palette accent and the track a dark palette colour with real
    /// alpha, so progress actually reads.
    private void _0x337ca692(_0x4ccc2a9a _0x478c9695)
    {
        Slider _0xe5be8fdd = _0x478c9695.AnimationSlider;
        if (_0xe5be8fdd == null)
        {
            _0xe5be8fdd = _0x478c9695.GetComponentInChildren<Slider>(true);
        }

        if (_0xe5be8fdd == null)
        {
            return;
        }

        RectTransform _0xb05d6c99 = _0xe5be8fdd.fillRect;
        if (_0xb05d6c99 != null)
        {
            Image _0x994c9f24 = _0xb05d6c99.GetComponent<Image>();
            if (_0x994c9f24 != null)
            {
                _0x994c9f24.sprite = this._fillSprite;
                _0x994c9f24.type = Image.Type.Sliced;
                _0x994c9f24.color = _0x47f8534e.Gold;
            }

            RectTransform _0xe73d8f4e = _0xb05d6c99.parent as RectTransform;
            Image _0x694c0fce = _0xe73d8f4e != null ? _0xe73d8f4e.GetComponent<Image>() : null;
            if (_0x694c0fce != null)
            {
                _0x694c0fce.sprite = this._trackSprite;
                _0x694c0fce.type = Image.Type.Sliced;
                _0x694c0fce.color = _0x47f8534e.Fade(_0x47f8534e.Bark, 0.78f);
            }
        }
    }

    [SerializeField]
    private Sprite _fillSprite;
    private void _0x35d20d30(_0x4ccc2a9a _0xc3a4a1a7)
    {
        _0x75955c9b _0x139e6722 = _0xc3a4a1a7.GetComponent<_0x75955c9b>();
        RectTransform _0x1c0ec723 = _0x139e6722 != null && _0x139e6722.Content != null ? _0x139e6722.Content.transform as RectTransform : _0xc3a4a1a7.transform as RectTransform;
        if (_0x1c0ec723 == null)
        {
            return;
        }

        Image _0x9648813a = _0x44b73caf.Picture(_0x1c0ec723, _0x922b59f9._0x1c9d20f3(new byte[10] { 26, 57, 37, 40, 58, 33, 4, 40, 59, 34 }, 73), this._emblem, new Vector2(0.5f, 0.60f), Vector2.zero, new Vector2(420f, 420f));
        this._0xe5bc8532 = _0x9648813a.transform;
        this._0xe5bc8532.localScale = Vector3.one * 0.88f;
        this._0xe5bc8532.DOScale(Vector3.one, 0.55f).SetEase(Ease.OutBack).SetLink(_0x9648813a.gameObject);
        this._0xe5bc8532.DOScale(Vector3.one * 1.04f, 1.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(0.6f).SetLink(_0x9648813a.gameObject);
        _0x44b73caf.Label(_0x1c0ec723, this._font, _0x922b59f9._0x1c9d20f3(new byte[13] { 114, 81, 77, 64, 82, 73, 98, 64, 81, 85, 72, 78, 79 }, 33), _0x922b59f9._0x1c9d20f3(new byte[7] { 251, 248, 246, 243, 254, 249, 240 }, 183), LoadingSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.17f), Vector2.zero, new Vector2(620f, 56f), TextAlignmentOptions.Center);
    }

    /// The splash shows the same artwork as the menu, so without this wash the two
    /// screens are indistinguishable.
    private void _0x38c087ee(_0x4ccc2a9a _0x282d3ca9)
    {
        _0x75955c9b _0xfca96a19 = _0x282d3ca9.GetComponent<_0x75955c9b>();
        if (_0xfca96a19 == null || _0xfca96a19.OuterBackground == null)
        {
            return;
        }

        Image _0xa4505896 = _0xfca96a19.OuterBackground.GetComponent<Image>();
        if (_0xa4505896 != null)
        {
            _0xa4505896.color = _0x47f8534e.PineDeep;
        }
    }

    [SerializeField]
    private TMP_FontAsset _font;
}

internal static class _0x922b59f9
{
    internal static string _0x1c9d20f3(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}