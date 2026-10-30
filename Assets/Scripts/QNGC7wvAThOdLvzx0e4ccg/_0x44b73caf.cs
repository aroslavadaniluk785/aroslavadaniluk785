using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// The single place that builds runtime UGUI for both scenes.
/// Keeping every label and plate behind these calls is what makes the text contract
/// (no auto-wrap, autosize on, readable floor) hold everywhere instead of per call site.
public static class _0x44b73caf
{
    /// Applies the text contract. A label built under an INACTIVE parent has not run its
    /// own Awake yet, so the font and its shared material are assigned here by hand - and
    /// the instanced fontMaterial is never read, which is what throws in that state.
    public static void Dress(TMP_Text _0x492e63e3, TMP_FontAsset _0xd4e2fb44, string _0xfe0ac8dc, float _0x9a828522, Color _0x36994634, TextAlignmentOptions _0x24fdb8f9)
    {
        if (_0x492e63e3 == null)
        {
            return;
        }

        if (_0xd4e2fb44 != null)
        {
            _0x492e63e3.font = _0xd4e2fb44;
        }

        if (_0x492e63e3.font != null && _0x492e63e3.fontSharedMaterial == null)
        {
            _0x492e63e3.fontSharedMaterial = _0x492e63e3.font.material;
        }

        _0x492e63e3.text = _0xfe0ac8dc;
        _0x492e63e3.color = _0x36994634;
        _0x492e63e3.alignment = _0x24fdb8f9;
        _0x492e63e3.textWrappingMode = TextWrappingModes.NoWrap;
        _0x492e63e3.overflowMode = TextOverflowModes.Overflow;
        _0x492e63e3.enableAutoSizing = true;
        _0x492e63e3.fontSizeMin = MinFontSize;
        _0x492e63e3.fontSizeMax = _0x9a828522;
        _0x492e63e3.raycastTarget = false;
    }

    /// A captioned button. The plate is the button's own graphic, the caption is a CHILD,
    /// so the caption is drawn after - and therefore on top of - its own backing.
    public static Button Action(RectTransform _0x59fa7be6, TMP_FontAsset _0x6ced2796, string _0x95c09570, Sprite _0x7d53f1e6, Color _0xfea5f45a, string _0x2c6926b6, float _0x542764b9, Color _0xc8e3030d, Vector2 _0x809f7d0d, Vector2 _0xac86878b, Vector2 _0xe8749094)
    {
        RectTransform _0xca200c48 = Node(_0x59fa7be6, _0x95c09570, _0x809f7d0d, _0xac86878b, _0xe8749094);
        Image _0x62ab6690 = _0xca200c48.gameObject.AddComponent<Image>();
        _0x62ab6690.sprite = _0x7d53f1e6;
        _0x62ab6690.color = _0xfea5f45a;
        _0x62ab6690.type = _0x7d53f1e6 == null ? Image.Type.Simple : Image.Type.Sliced;
        _0x62ab6690.raycastTarget = true;
        Button _0xee646daf = _0xca200c48.gameObject.AddComponent<Button>();
        _0xee646daf.targetGraphic = _0x62ab6690;
        ColorBlock _0xacf155f2 = _0xee646daf.colors;
        _0xacf155f2.normalColor = Color.white;
        _0xacf155f2.highlightedColor = Color.white;
        _0xacf155f2.pressedColor = new Color(0.82f, 0.82f, 0.82f, 1f);
        _0xacf155f2.selectedColor = Color.white;
        _0xacf155f2.disabledColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
        _0xacf155f2.fadeDuration = 0.08f;
        _0xee646daf.colors = _0xacf155f2;
        if (!string.IsNullOrEmpty(_0x2c6926b6))
        {
            Label(_0xca200c48, _0x6ced2796, _0x323fd657._0x9e84defc(new byte[7] { 70, 100, 117, 113, 108, 106, 107 }, 5), _0x2c6926b6, _0x542764b9, _0xc8e3030d, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(_0xe8749094.x - 48f, _0xe8749094.y - 28f), TextAlignmentOptions.Center);
        }

        return _0xee646daf;
    }

    /// Re-dresses a label that already exists in a scene or a template prefab.
    public static void Retext(TMP_Text _0xc770d796, string _0x5fe54553, float _0xc583b5a3, Color _0x451139aa)
    {
        if (_0xc770d796 == null)
        {
            return;
        }

        if (_0xc770d796.font != null && _0xc770d796.fontSharedMaterial == null)
        {
            _0xc770d796.fontSharedMaterial = _0xc770d796.font.material;
        }

        _0xc770d796.text = _0x5fe54553;
        _0xc770d796.color = _0x451139aa;
        _0xc770d796.textWrappingMode = TextWrappingModes.NoWrap;
        _0xc770d796.overflowMode = TextOverflowModes.Overflow;
        _0xc770d796.enableAutoSizing = true;
        _0xc770d796.fontSizeMin = MinFontSize;
        _0xc770d796.fontSizeMax = _0xc583b5a3;
    }

    /// A stretchable 9-slice plate: panels, bars, button bodies.
    public static Image Plate(RectTransform _0xde433631, string _0x26172012, Sprite _0x2e77274b, Color _0x688bb0e2, Vector2 _0xf97758ca, Vector2 _0xb3efeda9, Vector2 _0x7f205b91)
    {
        RectTransform _0x327481fc = Node(_0xde433631, _0x26172012, _0xf97758ca, _0xb3efeda9, _0x7f205b91);
        Image _0x29132374 = _0x327481fc.gameObject.AddComponent<Image>();
        _0x29132374.sprite = _0x2e77274b;
        _0x29132374.color = _0x688bb0e2;
        _0x29132374.type = _0x2e77274b == null ? Image.Type.Simple : Image.Type.Sliced;
        _0x29132374.raycastTarget = false;
        return _0x29132374;
    }

    public static RectTransform Full(RectTransform _0x681f0927, string _0xbd0bbf26)
    {
        GameObject _0x74a5b4b2 = new GameObject(_0xbd0bbf26, typeof(RectTransform));
        RectTransform _0x0d8b3381 = _0x74a5b4b2.GetComponent<RectTransform>();
        _0x0d8b3381.SetParent(_0x681f0927, false);
        _0x0d8b3381.anchorMin = Vector2.zero;
        _0x0d8b3381.anchorMax = Vector2.one;
        _0x0d8b3381.pivot = new Vector2(0.5f, 0.5f);
        _0x0d8b3381.offsetMin = Vector2.zero;
        _0x0d8b3381.offsetMax = Vector2.zero;
        _0x0d8b3381.localScale = Vector3.one;
        return _0x0d8b3381;
    }

    /// The readability floor from the rules: 24 px of the 1242x2688 reference canvas.
    public const float MinFontSize = 24f;
    /// Content art: aspect preserved, never stretched.
    public static Image Picture(RectTransform _0xce3cd432, string _0x5c432441, Sprite _0x29e91889, Vector2 _0x3b346e04, Vector2 _0x6bb37d98, Vector2 _0xd6eefe59)
    {
        RectTransform _0x4e0e0dee = Node(_0xce3cd432, _0x5c432441, _0x3b346e04, _0x6bb37d98, _0xd6eefe59);
        Image _0xd32eb861 = _0x4e0e0dee.gameObject.AddComponent<Image>();
        _0xd32eb861.sprite = _0x29e91889;
        _0xd32eb861.color = Color.white;
        _0xd32eb861.type = Image.Type.Simple;
        _0xd32eb861.preserveAspect = true;
        _0xd32eb861.raycastTarget = false;
        return _0xd32eb861;
    }

    public static TextMeshProUGUI Label(RectTransform _0x6a612b4e, TMP_FontAsset _0xaf55454f, string _0x03a26ce2, string _0x77fe666f, float _0x950d1e03, Color _0x3ceb3232, Vector2 _0x9c718d53, Vector2 _0x7d35601e, Vector2 _0x2f59ff8c, TextAlignmentOptions _0xe0849c9f)
    {
        RectTransform _0xd6d39f05 = Node(_0x6a612b4e, _0x03a26ce2, _0x9c718d53, _0x7d35601e, _0x2f59ff8c);
        TextMeshProUGUI _0xa71e457c = _0xd6d39f05.gameObject.AddComponent<TextMeshProUGUI>();
        Dress(_0xa71e457c, _0xaf55454f, _0x77fe666f, _0x950d1e03, _0x3ceb3232, _0xe0849c9f);
        return _0xa71e457c;
    }

    /// A square icon button: plate first, icon second, so the icon sits on top.
    public static Button IconAction(RectTransform _0x1dc66a87, string _0x29a077d1, Sprite _0x90153f87, Color _0xae0e6cca, Sprite _0xc1423e4e, float _0xd9c6e31e, Vector2 _0x882fd38b, Vector2 _0x0f5334bf, Vector2 _0x7aefc585)
    {
        Button _0x6e04cb40 = Action(_0x1dc66a87, null, _0x29a077d1, _0x90153f87, _0xae0e6cca, null, MinFontSize, Color.white, _0x882fd38b, _0x0f5334bf, _0x7aefc585);
        RectTransform _0x5cd84753 = _0x6e04cb40.transform as RectTransform;
        Picture(_0x5cd84753, _0x323fd657._0x9e84defc(new byte[4] { 229, 207, 195, 194 }, 172), _0xc1423e4e, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(_0xd9c6e31e, _0xd9c6e31e));
        return _0x6e04cb40;
    }

    public static RectTransform Node(RectTransform _0x0ac9ed65, string _0x0f518b6a, Vector2 _0x794164de, Vector2 _0x1876c3e0, Vector2 _0xa7a02bb9)
    {
        GameObject _0x0b33c923 = new GameObject(_0x0f518b6a, typeof(RectTransform));
        RectTransform _0x8b941326 = _0x0b33c923.GetComponent<RectTransform>();
        _0x8b941326.SetParent(_0x0ac9ed65, false);
        _0x8b941326.anchorMin = _0x794164de;
        _0x8b941326.anchorMax = _0x794164de;
        _0x8b941326.pivot = new Vector2(0.5f, 0.5f);
        _0x8b941326.anchoredPosition = _0x1876c3e0;
        _0x8b941326.sizeDelta = _0xa7a02bb9;
        _0x8b941326.localScale = Vector3.one;
        return _0x8b941326;
    }

    /// A full-rect scrim or flat fill that owns no sprite.
    public static Image Scrim(RectTransform _0xa7683f81, string _0x89d5776d, Color _0x90dca2c3, bool _0xea6e600d)
    {
        RectTransform _0x28f8fa7e = Full(_0xa7683f81, _0x89d5776d);
        Image _0x3f58e3d5 = _0x28f8fa7e.gameObject.AddComponent<Image>();
        _0x3f58e3d5.color = _0x90dca2c3;
        _0x3f58e3d5.raycastTarget = _0xea6e600d;
        return _0x3f58e3d5;
    }
}

internal static class _0x323fd657
{
    internal static string _0x9e84defc(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}