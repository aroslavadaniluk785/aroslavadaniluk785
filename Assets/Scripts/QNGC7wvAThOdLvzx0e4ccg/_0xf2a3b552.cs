using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// TemplatePlaceholderGuard.cs — staged into every Unity app by approve-pipeline-unity.sh
// (stage 5c3b, rule C.15 in CLAUDE-unity.md). Do not edit the copy inside a project;
// edit scripts/lib/unity/TemplatePlaceholderGuard.cs.
//
// WHY (19.10.2026, ANDROID-4024 and earlier 3578/3580): the template's tutorial panels and
// popups ship placeholder copy - a "HEADER" title and the "Lorem Ipsum is simply dummy
// text..." body. Codegen is told to rewrite or blank every one of them (C.15/C.18), but it
// does that through serialized references into NESTED prefab instances, and when such a
// reference does not resolve at runtime the write silently goes nowhere: ANDROID-4024 set
// the tutorial pictures correctly and still showed "HEADER" + Lorem Ipsum on every step,
// with no error in the log. Static gates cannot prove these references resolve.
//
// WHAT: a last line of defence that does not depend on any reference. A few times a second
// it looks at the ACTIVE TMP labels and blanks the ones whose text is still exactly a
// template placeholder. Real game text is never touched: only the stock strings match.
// Matched by content, not by object name (the obfuscator renames objects).
public sealed class _0xf2a3b552 : MonoBehaviour
{
    private float _0xb7a36f18;
    private void OnDisable()
    {
        if (this._0x98ebff31 != null)
            SceneManager.sceneLoaded -= this._0x98ebff31;
    }

    private static _0xf2a3b552 _0xc6fafedc;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        if (_0xc6fafedc != null)
            return;
        GameObject _0x89c9b657 = new GameObject(_0x71b6daee._0x1f949dbb(new byte[24] { 245, 196, 204, 209, 205, 192, 213, 196, 241, 205, 192, 194, 196, 201, 206, 205, 197, 196, 211, 230, 212, 192, 211, 197 }, 161));
        _0x89c9b657.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(_0x89c9b657);
        _0xc6fafedc = _0x89c9b657.AddComponent<_0xf2a3b552>();
    }

    private const float ScanInterval = 0.25f;
    private static readonly HashSet<string> _0x4eab2a75 = new HashSet<string>
    {
        _0x71b6daee._0x1f949dbb(new byte[6] { 17, 28, 24, 29, 28, 11 }, 89),
        _0x71b6daee._0x1f949dbb(new byte[6] { 121, 84, 80, 85, 84, 67 }, 49),
        _0x71b6daee._0x1f949dbb(new byte[6] { 49, 60, 56, 61, 60, 43 }, 89),
        _0x71b6daee._0x1f949dbb(new byte[5] { 61, 32, 61, 37, 44 }, 105),
        _0x71b6daee._0x1f949dbb(new byte[5] { 210, 239, 242, 234, 227 }, 134)
    };
    // A lambda held in a field, never a bare method group: Plana renames the method
    // declaration but not a method-group reference (see TmpContrastGuard).
    private void OnEnable()
    {
        if (this._0x98ebff31 == null)
            this._0x98ebff31 = (_0xe0aa6905, _0x62171634) =>
            {
                this._0xb7a36f18 = 0f;
            };
        SceneManager.sceneLoaded += this._0x98ebff31;
    }

    private void LateUpdate()
    {
        if (Time.unscaledTime < this._0xb7a36f18)
            return;
        this._0xb7a36f18 = Time.unscaledTime + ScanInterval;
        TMP_Text[] _0x6071d832 = Object.FindObjectsByType<TMP_Text>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        for (int _0xcb09e4b9 = 0; _0xcb09e4b9 < _0x6071d832.Length; _0xcb09e4b9++)
        {
            TMP_Text _0xe799fc1f = _0x6071d832[_0xcb09e4b9];
            if (_0xe799fc1f != null && IsPlaceholder(_0xe799fc1f.text))
                _0xe799fc1f.text = "";
        }
    }

    private static bool IsPlaceholder(string _0xcf72e8bb)
    {
        if (string.IsNullOrEmpty(_0xcf72e8bb))
            return false;
        string _0x02e59d3d = _0xcf72e8bb.Trim();
        if (_0x4eab2a75.Contains(_0x02e59d3d))
            return true;
        string _0x7175312b = _0x02e59d3d.ToLowerInvariant();
        for (int _0x114373d4 = 0; _0x114373d4 < _0xcf89292b.Length; _0x114373d4++)
        {
            if (_0x7175312b.StartsWith(_0xcf89292b[_0x114373d4]))
                return true;
        }

        return false;
    }

    // Split on purpose: the C.15 gate flags those words inside string literals of generated
    // code, and this file is the one place that must name them to recognise them.
    private static readonly string[] _0xcf89292b =
    {
        _0x71b6daee._0x1f949dbb(new byte[3] { 146, 145, 140 }, 254) + _0x71b6daee._0x1f949dbb(new byte[6] { 242, 250, 183, 254, 231, 228 }, 151) + _0x71b6daee._0x1f949dbb(new byte[2] { 184, 160 }, 205),
        _0x71b6daee._0x1f949dbb(new byte[6] { 186, 171, 179, 179, 167, 254 }, 222) + _0x71b6daee._0x1f949dbb(new byte[4] { 227, 242, 239, 227 }, 151)
    };
    private UnityEngine.Events.UnityAction<Scene, LoadSceneMode> _0x98ebff31;
}

internal static class _0x71b6daee
{
    internal static string _0x1f949dbb(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}