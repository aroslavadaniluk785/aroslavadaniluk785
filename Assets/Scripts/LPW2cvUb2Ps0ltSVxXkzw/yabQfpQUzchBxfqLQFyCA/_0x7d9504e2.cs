using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class _0x7d9504e2 : MonoBehaviour
{
    private static void SafeAreaChanged()
    {
        _0xa6a19d26 = Screen.safeArea;
        for (int _0x1dd9a88f = 0; _0x1dd9a88f < _0x0b03261e.Count; _0x1dd9a88f++)
            _0x0b03261e[_0x1dd9a88f]._0xc5cf6a81();
    }

    private RectTransform _0x2101471a;
    private static UnityEvent _0xc190b865 = new();
    private static void ResolutionChanged()
    {
        _0x93e8d920.x = Screen.width;
        _0x93e8d920.y = Screen.height;
        _0xc190b865.Invoke();
    }

    private static bool _0xa31ea951;
    private RectTransform _0xf832d4b9;
    private void _0xc5cf6a81()
    {
        if (this._0x2101471a == null)
            return;
        Rect _0x33bfc6d6 = Screen.safeArea;
        Vector2 _0x2f0ec65b = _0x33bfc6d6.position;
        Vector2 _0x261d66f7 = _0x33bfc6d6.position + _0x33bfc6d6.size;
        _0x2f0ec65b.x /= this._0x1c4f7e51.pixelRect.width;
        _0x2f0ec65b.y /= this._0x1c4f7e51.pixelRect.height;
        _0x261d66f7.x /= this._0x1c4f7e51.pixelRect.width;
        _0x261d66f7.y /= this._0x1c4f7e51.pixelRect.height;
        this._0x2101471a.anchorMin = _0x2f0ec65b;
        this._0x2101471a.anchorMax = _0x261d66f7;
    }

    private void Update()
    {
        if (_0x0b03261e[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x9917be92)
            OrientationChanged();
        if (Screen.safeArea != _0xa6a19d26)
            SafeAreaChanged();
        if (Screen.width != _0x93e8d920.x || Screen.height != _0x93e8d920.y)
            ResolutionChanged();
    }

    private static readonly List<_0x7d9504e2> _0x0b03261e = new();
    private void OnDestroy()
    {
        if (_0x0b03261e != null && _0x0b03261e.Contains(this))
            _0x0b03261e.Remove(this);
    }

    private static Vector2 _0x93e8d920 = Vector2.zero;
    private static Rect _0xa6a19d26 = Rect.zero;
    private static ScreenOrientation _0x9917be92 = ScreenOrientation.LandscapeLeft;
    private Canvas _0x1c4f7e51;
    private void Awake()
    {
        if (!_0x0b03261e.Contains(this))
            _0x0b03261e.Add(this);
        this._0x1c4f7e51 = this.GetComponent<Canvas>();
        this._0xf832d4b9 = this.GetComponent<RectTransform>();
        this._0x2101471a = this.transform.Find(_0xe1d0b773._0x5e986fea(new byte[8] { 139, 185, 190, 189, 153, 170, 189, 185 }, 216)) as RectTransform;
        if (!_0xa31ea951)
        {
            _0x9917be92 = Screen.orientation;
            _0x93e8d920.x = Screen.width;
            _0x93e8d920.y = Screen.height;
            _0xa6a19d26 = Screen.safeArea;
            _0xa31ea951 = true;
        }

        this._0xc5cf6a81();
    }

    private static void OrientationChanged()
    {
        _0x9917be92 = Screen.orientation;
        _0x93e8d920.x = Screen.width;
        _0x93e8d920.y = Screen.height;
        _0xc190b865.Invoke();
    }
}

internal static class _0xe1d0b773
{
    internal static string _0x5e986fea(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}