using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class _0x5b8c286b : MonoBehaviour
{
    private static void ApplySafeAreaToAll()
    {
        for (int _0x4093f722 = 0; _0x4093f722 < _0x54f6b01b.Count; _0x4093f722++)
            _0x54f6b01b[_0x4093f722]._0xaceae90f();
    }

    private static void SafeAreaChanged()
    {
        _0x863f0abf = Screen.safeArea;
        ApplySafeAreaToAll();
    }

    private static Vector2 _0x4a917bb3 = Vector2.zero;
    private static void OrientationChanged()
    {
        _0xaacd9e15 = Screen.orientation;
        _0x4a917bb3.x = Screen.width;
        _0x4a917bb3.y = Screen.height;
        _0x863f0abf = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x08b3db18.Invoke();
    }

    private void Awake()
    {
        if (!_0x54f6b01b.Contains(this))
            _0x54f6b01b.Add(this);
        this._0x6438db49 = this.GetComponent<Canvas>();
        this._0x8639da7f = this.GetComponent<CanvasScaler>();
        if (this._0x8639da7f != null)
            this._0x3b5e1ef4 = this._0x8639da7f.referenceResolution;
        this._0x45d8d841 = this.GetComponent<RectTransform>();
        this._0xd18282a3 = this.transform.Find(_0x03ef6497._0xd810dc43(new byte[8] { 130, 176, 183, 180, 144, 163, 180, 176 }, 209)) as RectTransform;
        if (!_0x05f92346)
        {
            _0xaacd9e15 = Screen.orientation;
            _0x4a917bb3.x = Screen.width;
            _0x4a917bb3.y = Screen.height;
            _0x863f0abf = Screen.safeArea;
            _0x05f92346 = true;
        }

        this._0xaceae90f();
    }

    private static ScreenOrientation _0xaacd9e15 = ScreenOrientation.LandscapeLeft;
    private Canvas _0x6438db49;
    private static bool _0x05f92346;
    private static Rect _0x863f0abf = Rect.zero;
    private CanvasScaler _0x8639da7f;
    private void Update()
    {
        if (_0x54f6b01b.Count == 0 || _0x54f6b01b[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0xaacd9e15)
            OrientationChanged();
        if (Screen.safeArea != _0x863f0abf)
            SafeAreaChanged();
        if (Screen.width != _0x4a917bb3.x || Screen.height != _0x4a917bb3.y)
            ResolutionChanged();
    }

    private RectTransform _0x45d8d841;
    private Vector2 _0x3b5e1ef4;
    private RectTransform _0xd18282a3;
    private static void ResolutionChanged()
    {
        _0x4a917bb3.x = Screen.width;
        _0x4a917bb3.y = Screen.height;
        _0x863f0abf = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x08b3db18.Invoke();
    }

    private void _0xaceae90f()
    {
        if (this._0xd18282a3 == null)
            return;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        if (screenWidth <= 0f || screenHeight <= 0f)
            return;
        Rect _0x1b2a8333 = Screen.safeArea;
        Vector2 _0x90e33f31 = _0x1b2a8333.position;
        Vector2 _0x8899b85b = _0x1b2a8333.position + _0x1b2a8333.size;
        _0x90e33f31.x /= screenWidth;
        _0x90e33f31.y /= screenHeight;
        _0x8899b85b.x /= screenWidth;
        _0x8899b85b.y /= screenHeight;
        this._0xd18282a3.anchorMin = _0x90e33f31;
        this._0xd18282a3.anchorMax = _0x8899b85b;
        this._0xd18282a3.offsetMin = Vector2.zero;
        this._0xd18282a3.offsetMax = Vector2.zero;
        if (this._0x8639da7f == null)
            return;
        Vector2 _0x1b8da825 = _0x8899b85b - _0x90e33f31;
        float _0x033c1f10 = 2f - _0x1b8da825.x;
        float _0x1eac1be8 = 2f - _0x1b8da825.y;
        this._0x8639da7f.referenceResolution = this._0x3b5e1ef4 * new Vector2(_0x033c1f10, _0x1eac1be8);
    }

    private static UnityEvent _0x08b3db18 = new();
    private static readonly List<_0x5b8c286b> _0x54f6b01b = new();
    private void OnDestroy()
    {
        if (_0x54f6b01b != null && _0x54f6b01b.Contains(this))
            _0x54f6b01b.Remove(this);
    }

    private void Start()
    {
    }
}

internal static class _0x03ef6497
{
    internal static string _0xd810dc43(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}