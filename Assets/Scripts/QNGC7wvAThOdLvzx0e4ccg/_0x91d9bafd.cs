using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TmpContrastGuard.cs — staged into every Unity app by approve-pipeline-unity.sh
// (stage 5c3, rule C.14 in CLAUDE-unity.md). Do not edit the copy inside a project;
// edit scripts/lib/unity/TmpContrastGuard.cs.
//
// WHY: every TMP label gets an outline (C.10), and by default that outline is dark.
// A dark face colour on a dark outline merges into a smudge — the label is not
// readable on any backing (ANDROID-3627: PLAY drawn Deep #12151E on the #12151E
// outline read as a black blob). enforce-text-contrast.sh fixes colours SERIALISED
// in scenes/prefabs, but labels built at runtime from C# (UiKit.Cta, VaultUi.Caption,
// label.color = Palette.X ...) never reach a scene file, so that pass cannot see them.
//
// WHAT: after any TMP text is regenerated, compare its face colour with the outline
// colour of the material it actually renders with. Below WCAG 4.5:1 the face is
// blended toward white (dark outline) or black (light outline) until it reaches 7:1.
// Hue is kept; alpha is kept. A label whose outline was deliberately switched to a
// light colour (TextReadability-style per-label material) is measured against THAT
// outline, so intentionally dark text on a light rim is left alone. Labels without
// an outline are left alone too.
public sealed class _0x91d9bafd : MonoBehaviour
{
    private readonly List<TMP_Text> _0x8492c4f6 = new List<TMP_Text>();
    private void OnDisable()
    {
        if (this._0x89a3606f != null)
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(this._0x89a3606f);
    }

    private static float Linear(float _0x131e18eb)
    {
        _0x131e18eb = Mathf.Clamp01(_0x131e18eb);
        return _0x131e18eb <= 0.03928f ? _0x131e18eb / 12.92f : Mathf.Pow((_0x131e18eb + 0.055f) / 1.055f, 2.4f);
    }

    private const float TargetRatio = 7f;
    private static void Fix(TMP_Text _0x54c093a2)
    {
        if (_0x54c093a2 == null || !_0x54c093a2.isActiveAndEnabled)
            return;
        Material _0xa6184294 = _0x54c093a2.fontSharedMaterial;
        if (_0xa6184294 == null || !_0xa6184294.HasProperty(ShaderUtilities.ID_OutlineColor) || !_0xa6184294.HasProperty(ShaderUtilities.ID_OutlineWidth))
            return;
        if (_0xa6184294.GetFloat(ShaderUtilities.ID_OutlineWidth) < MinOutlineWidth)
            return;
        Color _0x1054b169 = _0x54c093a2.color;
        if (_0x1054b169.a <= 0f)
            return;
        Color _0xaad2baf6 = _0xa6184294.GetColor(ShaderUtilities.ID_OutlineColor);
        if (Ratio(_0x1054b169, _0xaad2baf6) >= MinRatio)
            return;
        Color _0xc36f0772 = Luminance(_0xaad2baf6) < 0.5f ? Color.white : Color.black;
        Color _0x3cebf518;
        if (Ratio(_0xc36f0772, _0xaad2baf6) < TargetRatio)
        {
            _0x3cebf518 = _0xc36f0772;
        }
        else
        {
            // Smallest blend that reaches the target: contrast grows monotonically
            // with t, so a short bisection keeps as much of the hue as possible.
            float _0x656a55be = 0f;
            float _0x7ef8f11a = 1f;
            for (int _0x156a53e4 = 0; _0x156a53e4 < 20; _0x156a53e4++)
            {
                float _0x2ea8d43d = (_0x656a55be + _0x7ef8f11a) * 0.5f;
                if (Ratio(Color.Lerp(_0x1054b169, _0xc36f0772, _0x2ea8d43d), _0xaad2baf6) >= TargetRatio)
                    _0x7ef8f11a = _0x2ea8d43d;
                else
                    _0x656a55be = _0x2ea8d43d;
            }

            _0x3cebf518 = Color.Lerp(_0x1054b169, _0xc36f0772, _0x7ef8f11a);
        }

        _0x3cebf518.a = _0x1054b169.a;
        _0x54c093a2.color = _0x3cebf518;
    }

    // WCAG relative luminance of an sRGB colour, and the contrast ratio of two.
    private static float Luminance(Color _0x3f60ddb0)
    {
        return 0.2126f * Linear(_0x3f60ddb0.r) + 0.7152f * Linear(_0x3f60ddb0.g) + 0.0722f * Linear(_0x3f60ddb0.b);
    }

    private readonly HashSet<TMP_Text> _0xe925529c = new HashSet<TMP_Text>();
    private const float MinRatio = 4.5f;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        if (_0x7621cdfe != null)
            return;
        GameObject _0x9d3410a8 = new GameObject(_0xab078859._0x085db167(new byte[16] { 244, 205, 208, 227, 207, 206, 212, 210, 193, 211, 212, 231, 213, 193, 210, 196 }, 160));
        _0x9d3410a8.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(_0x9d3410a8);
        _0x7621cdfe = _0x9d3410a8.AddComponent<_0x91d9bafd>();
    }

    private static _0x91d9bafd _0x7621cdfe;
    private const float MinOutlineWidth = 0.01f;
    private void OnEnable()
    {
        if (this._0x89a3606f == null)
            this._0x89a3606f = _0xd4c8d664 => this._0x65b5e1e6(_0xd4c8d664);
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(this._0x89a3606f);
    }

    private void LateUpdate()
    {
        if (this._0xe925529c.Count == 0)
            return;
        this._0x8492c4f6.Clear();
        this._0x8492c4f6.AddRange(this._0xe925529c);
        this._0xe925529c.Clear();
        for (int _0x15fe100c = 0; _0x15fe100c < this._0x8492c4f6.Count; _0x15fe100c++)
            Fix(this._0x8492c4f6[_0x15fe100c]);
    }

    // The event fires from inside the canvas rebuild. Changing the colour right there
    // would re-dirty the graphic mid-rebuild, which Unity rejects — so queue it and
    // apply in LateUpdate, which runs before the next frame's rebuild.
    private void _0x65b5e1e6(Object _0xe26193e6)
    {
        TMP_Text _0xc35d874b = _0xe26193e6 as TMP_Text;
        if (_0xc35d874b != null)
            this._0xe925529c.Add(_0xc35d874b);
    }

    private static float Ratio(Color _0x4e4490ec, Color _0x1b115c9c)
    {
        float _0x4afa5b5c = Luminance(_0x4e4490ec);
        float _0x403ccac4 = Luminance(_0x1b115c9c);
        return (Mathf.Max(_0x4afa5b5c, _0x403ccac4) + 0.05f) / (Mathf.Min(_0x4afa5b5c, _0x403ccac4) + 0.05f);
    }

    // A lambda held in a field, never the bare method group: Plana renames the method
    // declaration but not a method-group reference (verify-unity-buttons.sh, CS0103).
    // The field keeps Add and Remove on the same delegate instance.
    private System.Action<Object> _0x89a3606f;
}

internal static class _0xab078859
{
    internal static string _0x085db167(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}