using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Settings. There is no audio in this game, so there is no sound row and no speaker
/// icon: a toggle that mutes silence confirms nothing. Both rows here change something
/// the player can see in the same frame.
public sealed class _0x0556c6af : MonoBehaviour
{
    public void _0x5720d840()
    {
        this._0x25fb43a2();
        _0x44b73caf.Retext(this._0x420f74f8, "", NoteSize, _0x47f8534e.LeafLight);
        if (this._0xa55328f0 != null)
        {
            this._0xa55328f0._0xc75fde18();
        }
    }

    private _0xf6b95e08 _0x870c0913;
    private TextMeshProUGUI _0x420f74f8;
    private void _0x25fb43a2()
    {
        bool _0x3a5ff42a = _0x744cf847._0x4d7aec3d;
        if (this._0x69b5c054 != null)
        {
            this._0x69b5c054.color = _0x3a5ff42a ? _0x47f8534e.Gold : _0x47f8534e.PineDeep;
        }

        _0x44b73caf.Retext(this._0x6f4df72f, _0x3a5ff42a ? _0x1c6b875d._0x5c41b9ac(new byte[2] { 174, 175 }, 225) : _0x1c6b875d._0x5c41b9ac(new byte[3] { 2, 11, 11 }, 77), ButtonSize, _0x47f8534e.Cream);
    }

    private Image _0x69b5c054;
    private const float RowSize = 40f;
    private const float HeaderSize = 64f;
    private _0x5d1715c7 _0xa55328f0;
    private void _0x30971352()
    {
        _0x44b73caf.Retext(this._0x420f74f8, "", NoteSize, _0x47f8534e.LeafLight);
    }

    private void _0x26d58de0()
    {
        _0x744cf847.ResetGarden();
        _0x44b73caf.Retext(this._0x420f74f8, _0x1c6b875d._0x5c41b9ac(new byte[13] { 75, 77, 94, 72, 73, 66, 44, 94, 73, 95, 73, 88, 34 }, 12), NoteSize, _0x47f8534e.LeafLight);
        if (this._0x870c0913 != null)
        {
            this._0x870c0913._0xd826e288();
        }

        DOVirtual.DelayedCall(1.4f, () => this._0x30971352()).SetLink(this.gameObject);
    }

    /// Three visible confirmations at once: the pill swaps colour, the caption swaps word
    /// and the pill punches.
    private void _0x8b95ee3c()
    {
        _0x744cf847._0x4d7aec3d = !_0x744cf847._0x4d7aec3d;
        this._0x25fb43a2();
        if (this._0x5b856bd7 != null)
        {
            this._0x5b856bd7.DOPunchScale(Vector3.one * 0.12f, 0.26f, 6, 0.8f).SetLink(this._0x5b856bd7.gameObject);
        }

        if (_0x744cf847._0x4d7aec3d)
        {
            Handheld.Vibrate();
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.gameObject);
        if (this._0x5b856bd7 != null)
        {
            DOTween.Kill(this._0x5b856bd7);
        }
    }

    private Transform _0x5b856bd7;
    public void _0xeaabfbcc()
    {
        if (this._0xa55328f0 != null)
        {
            this._0xa55328f0._0xc9623eae();
        }
    }

    private const float ButtonSize = 40f;
    public void _0x8ab4770c(_0xf6b95e08 _0xe1e5f352, RectTransform _0x34aa9f2f)
    {
        this._0x870c0913 = _0xe1e5f352;
        RectTransform _0xb8898f5f = _0x44b73caf.Full(_0x34aa9f2f, _0x1c6b875d._0x5c41b9ac(new byte[15] { 59, 13, 28, 28, 1, 6, 15, 27, 39, 30, 13, 26, 4, 9, 17 }, 104));
        _0x44b73caf.Scrim(_0xb8898f5f, _0x1c6b875d._0x5c41b9ac(new byte[13] { 141, 187, 170, 170, 183, 176, 185, 173, 141, 189, 172, 183, 179 }, 222), _0x47f8534e.Fade(_0x47f8534e.Bark, 0.78f), true);
        RectTransform _0xc8f67e19 = _0x44b73caf.Plate(_0xb8898f5f, _0x1c6b875d._0x5c41b9ac(new byte[12] { 160, 150, 135, 135, 154, 157, 148, 128, 176, 146, 129, 151 }, 243), _0xe1e5f352._0xd759b031, _0x47f8534e.Pine, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1100f, 900f)).rectTransform;
        _0x44b73caf.Label(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[14] { 95, 105, 120, 120, 101, 98, 107, 127, 68, 105, 109, 104, 105, 126 }, 12), _0x1c6b875d._0x5c41b9ac(new byte[8] { 168, 190, 175, 175, 178, 181, 188, 168 }, 251), HeaderSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, 340f), new Vector2(760f, 80f), TextAlignmentOptions.Center);
        _0x44b73caf.Label(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[12] { 157, 180, 165, 161, 188, 182, 166, 153, 180, 183, 176, 185 }, 213), _0x1c6b875d._0x5c41b9ac(new byte[7] { 146, 155, 138, 142, 147, 153, 137 }, 218), RowSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(-240f, 150f), new Vector2(440f, 64f), TextAlignmentOptions.Left);
        Button _0x9791e8a6 = _0x44b73caf.Action(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[11] { 212, 253, 236, 232, 245, 255, 239, 204, 245, 240, 240 }, 156), _0xe1e5f352._0x13661abf, _0x47f8534e.Gold, _0x1c6b875d._0x5c41b9ac(new byte[2] { 207, 206 }, 128), ButtonSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(290f, 150f), new Vector2(300f, 110f));
        this._0x69b5c054 = _0x9791e8a6.targetGraphic as Image;
        this._0x6f4df72f = _0x9791e8a6.GetComponentInChildren<TextMeshProUGUI>(true);
        this._0x5b856bd7 = _0x9791e8a6.transform;
        _0x9791e8a6.onClick.AddListener(() => this._0x8b95ee3c());
        _0x44b73caf.Label(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[10] { 150, 161, 183, 161, 176, 136, 165, 166, 161, 168 }, 196), _0x1c6b875d._0x5c41b9ac(new byte[12] { 58, 45, 59, 45, 60, 72, 47, 41, 58, 44, 45, 38 }, 104), RowSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(-240f, -10f), new Vector2(520f, 64f), TextAlignmentOptions.Left);
        Button _0x9ec16903 = _0x44b73caf.Action(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[11] { 127, 72, 94, 72, 89, 111, 88, 89, 89, 66, 67 }, 45), _0xe1e5f352._0x13661abf, _0x47f8534e.Coral, _0x1c6b875d._0x5c41b9ac(new byte[5] { 80, 71, 81, 71, 86 }, 2), ButtonSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(290f, -10f), new Vector2(300f, 110f));
        _0x9ec16903.onClick.AddListener(() => this._0x26d58de0());
        this._0x420f74f8 = _0x44b73caf.Label(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[12] { 39, 17, 0, 0, 29, 26, 19, 7, 58, 27, 0, 17 }, 116), "", NoteSize, _0x47f8534e.LeafLight, new Vector2(0.5f, 0.5f), new Vector2(0f, -170f), new Vector2(940f, 60f), TextAlignmentOptions.Center);
        Button _0x163891d8 = _0x44b73caf.Action(_0xc8f67e19, _0xe1e5f352._0x9e093146, _0x1c6b875d._0x5c41b9ac(new byte[13] { 158, 168, 185, 185, 164, 163, 170, 190, 142, 161, 162, 190, 168 }, 205), _0xe1e5f352._0x13661abf, _0x47f8534e.PineDeep, _0x1c6b875d._0x5c41b9ac(new byte[5] { 156, 147, 144, 140, 154 }, 223), ButtonSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, -330f), new Vector2(420f, 124f));
        _0x163891d8.onClick.AddListener(() => this._0xeaabfbcc());
        this._0xa55328f0 = _0xb8898f5f.gameObject.AddComponent<_0x5d1715c7>();
        this._0xa55328f0._0x342297fa(_0xb8898f5f.gameObject);
        _0xb8898f5f.gameObject.SetActive(false);
        this._0x25fb43a2();
    }

    private const float NoteSize = 36f;
    private TextMeshProUGUI _0x6f4df72f;
}

internal static class _0x1c6b875d
{
    internal static string _0x5c41b9ac(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}