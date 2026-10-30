using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// The garden map: twelve trees, one per stage, in three states. Tapping an open tree
/// punches it and lights its rim before the puzzle loads, so the tap is acknowledged on
/// screen and not only in the next scene.
public sealed class _0x32bd8421 : MonoBehaviour
{
    private const float CloseSize = 44f;
    private const int Rows = 4;
    private const float TileCaptionSize = 32f;
    private _0x5d1715c7 _0x318f7ca0;
    private void _0x3e7548a5()
    {
        _0xaa3720e7 _0x9bee647e = _0xaa3720e7.Instance;
        if (_0x9bee647e != null)
        {
            _0x9bee647e._0x4fdc6a2f(_0x44bff367._0x7725f086.SCENE_1);
        }
    }

    public void _0x814fabd1()
    {
        if (this._0x318f7ca0 != null)
        {
            this._0x318f7ca0._0xc9623eae();
        }
    }

    /// Visible confirmation first, scene load second.
    private void _0xdc696dab(int _0x637b2577)
    {
        if (_0x637b2577 >= _0x744cf847._0xff09096a)
        {
            return;
        }

        _0x744cf847._0x8ce537ac = _0x637b2577;
        _0x744cf847._0x5fb9f0b9 = 0;
        if (this._0x4e1f9b79[_0x637b2577] != null)
        {
            this._0x4e1f9b79[_0x637b2577].color = _0x47f8534e.Gold;
            Transform _0xab057bb8 = this._0x4e1f9b79[_0x637b2577].transform;
            _0xab057bb8.DOPunchScale(Vector3.one * 0.1f, 0.26f, 6, 0.8f).SetLink(_0xab057bb8.gameObject);
        }

        DOVirtual.DelayedCall(0.3f, () => this._0x3e7548a5()).SetLink(this.gameObject);
    }

    private const float EmptySize = 44f;
    private const float HeaderSize = 64f;
    private readonly Image[] _0x4e1f9b79 = new Image[_0x744cf847.TreeCount];
    public void _0xfa2bb7bc(_0xf6b95e08 _0x8281dc92, RectTransform _0x112e5811)
    {
        this._0xc42726ee = _0x8281dc92;
        RectTransform _0x4505dfe2 = _0x44b73caf.Full(_0x112e5811, _0x75b25e37._0x10865273(new byte[10] { 150, 186, 171, 148, 173, 190, 169, 183, 186, 162 }, 219));
        _0x44b73caf.Scrim(_0x4505dfe2, _0x75b25e37._0x10865273(new byte[8] { 67, 111, 126, 93, 109, 124, 103, 99 }, 14), _0x47f8534e.Fade(_0x47f8534e.Bark, 0.78f), true);
        RectTransform _0xf7924518 = _0x44b73caf.Plate(_0x4505dfe2, _0x75b25e37._0x10865273(new byte[7] { 153, 181, 164, 151, 181, 166, 176 }, 212), _0x8281dc92._0xd759b031, _0x47f8534e.Pine, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1100f, 1700f)).rectTransform;
        _0x44b73caf.Label(_0xf7924518, _0x8281dc92._0x9e093146, _0x75b25e37._0x10865273(new byte[9] { 16, 60, 45, 21, 56, 60, 57, 56, 47 }, 93), _0x75b25e37._0x10865273(new byte[10] { 3, 5, 22, 0, 1, 10, 100, 9, 5, 20 }, 68), HeaderSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, 770f), new Vector2(820f, 80f), TextAlignmentOptions.Center);
        this._0x1a824611 = _0x44b73caf.Node(_0xf7924518, _0x75b25e37._0x10865273(new byte[7] { 65, 109, 124, 75, 126, 101, 104 }, 12), new Vector2(0.5f, 0.5f), new Vector2(0f, 60f), new Vector2(938f, 1262f));
        for (int _0x8c234a20 = 0; _0x8c234a20 < _0x744cf847.TreeCount; _0x8c234a20++)
        {
            int _0x2270bf50 = _0x8c234a20 % Columns;
            int _0x2a101f73 = _0x8c234a20 / Columns;
            float _0xd0c0e075 = (_0x2270bf50 - 1) * 324f;
            float _0x94d20873 = 486f - _0x2a101f73 * 324f;
            this._0xc2a4db02(_0x8281dc92, _0x8c234a20, _0xd0c0e075, _0x94d20873);
        }

        this._0xc8d8f62b = _0x44b73caf.Label(_0xf7924518, _0x8281dc92._0x9e093146, _0x75b25e37._0x10865273(new byte[8] { 176, 156, 141, 184, 144, 141, 137, 132 }, 253), _0x75b25e37._0x10865273(new byte[34] { 112, 113, 30, 106, 108, 123, 123, 109, 30, 103, 123, 106, 16, 52, 110, 108, 123, 109, 109, 30, 110, 114, 127, 103, 30, 106, 113, 30, 124, 123, 121, 119, 112, 16 }, 62), EmptySize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, 60f), new Vector2(900f, 200f), TextAlignmentOptions.Center);
        this._0xc8d8f62b.gameObject.SetActive(false);
        Button _0xe9e6170a = _0x44b73caf.Action(_0xf7924518, _0x8281dc92._0x9e093146, _0x75b25e37._0x10865273(new byte[8] { 209, 253, 236, 223, 240, 243, 239, 249 }, 156), _0x8281dc92._0x13661abf, _0x47f8534e.PineDeep, _0x75b25e37._0x10865273(new byte[5] { 197, 202, 201, 213, 195 }, 134), CloseSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, -760f), new Vector2(440f, 132f));
        _0xe9e6170a.onClick.AddListener(() => this._0x814fabd1());
        this._0x318f7ca0 = _0x4505dfe2.gameObject.AddComponent<_0x5d1715c7>();
        this._0x318f7ca0._0x342297fa(_0x4505dfe2.gameObject);
        _0x4505dfe2.gameObject.SetActive(false);
        this._0x42ed82b3();
    }

    private readonly Image[] _0x01a4889c = new Image[_0x744cf847.TreeCount];
    private void OnDestroy()
    {
        DOTween.Kill(this.gameObject);
        for (int _0x97cd2b2e = 0; _0x97cd2b2e < this._0x4e1f9b79.Length; _0x97cd2b2e++)
        {
            if (this._0x4e1f9b79[_0x97cd2b2e] != null)
            {
                DOTween.Kill(this._0x4e1f9b79[_0x97cd2b2e].transform);
            }
        }
    }

    private _0xf6b95e08 _0xc42726ee;
    private void _0xc2a4db02(_0xf6b95e08 _0xd8fe7beb, int _0x4b01aca4, float _0xe7e1cbb0, float _0x9cd40e18)
    {
        RectTransform _0xe6e1336b = _0x44b73caf.Node(this._0x1a824611, _0x75b25e37._0x10865273(new byte[7] { 2, 46, 63, 27, 38, 35, 42 }, 79), new Vector2(0.5f, 0.5f), new Vector2(_0xe7e1cbb0, _0x9cd40e18), new Vector2(290f, 290f));
        this._0x4e1f9b79[_0x4b01aca4] = _0x44b73caf.Plate(_0xe6e1336b, _0x75b25e37._0x10865273(new byte[9] { 166, 155, 158, 151, 180, 128, 147, 159, 151 }, 242), _0xd8fe7beb._0xd759b031, _0x47f8534e.PineDeep, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(290f, 290f));
        this._0x01a4889c[_0x4b01aca4] = _0x44b73caf.Picture(_0xe6e1336b, _0x75b25e37._0x10865273(new byte[7] { 207, 242, 247, 254, 218, 233, 239 }, 155), _0xd8fe7beb._0x5f4b4c5c, new Vector2(0.5f, 0.5f), new Vector2(0f, 28f), new Vector2(210f, 210f));
        this._0x8dabbf20[_0x4b01aca4] = _0x44b73caf.Label(_0xe6e1336b, _0xd8fe7beb._0x9e093146, _0x75b25e37._0x10865273(new byte[11] { 97, 92, 89, 80, 118, 84, 69, 65, 92, 90, 91 }, 53), "", TileCaptionSize, _0x47f8534e.LeafLight, new Vector2(0.5f, 0.5f), new Vector2(0f, -112f), new Vector2(270f, 48f), TextAlignmentOptions.Center);
        Image _0x6bb00999 = _0x44b73caf.Plate(_0xe6e1336b, _0x75b25e37._0x10865273(new byte[7] { 95, 98, 103, 110, 67, 98, 127 }, 11), null, _0x47f8534e.Fade(Color.white, 0f), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(290f, 290f));
        _0x6bb00999.raycastTarget = true;
        Button _0x2f00890e = _0x6bb00999.gameObject.AddComponent<Button>();
        _0x2f00890e.targetGraphic = _0x6bb00999;
        int _0x68d57241 = _0x4b01aca4;
        _0x2f00890e.onClick.AddListener(() => this._0xdc696dab(_0x68d57241));
    }

    private RectTransform _0x1a824611;
    private const int Columns = 3;
    private TextMeshProUGUI _0xc8d8f62b;
    public void _0x19887fea()
    {
        this._0x42ed82b3();
        if (this._0x318f7ca0 != null)
        {
            this._0x318f7ca0._0xc75fde18();
        }
    }

    public void _0x42ed82b3()
    {
        int _0xbc5b95aa = _0x744cf847._0xff09096a;
        int _0xcfcb6aad = _0x744cf847._0x5f18a4d3;
        for (int _0x0a45faee = 0; _0x0a45faee < _0x744cf847.TreeCount; _0x0a45faee++)
        {
            bool _0x045855a9 = _0x0a45faee < _0xbc5b95aa;
            bool _0xd7d5eddb = _0x0a45faee < _0xcfcb6aad;
            if (this._0x01a4889c[_0x0a45faee] != null)
            {
                this._0x01a4889c[_0x0a45faee].sprite = _0xd7d5eddb ? this._0xc42726ee._0xd8c787b7 : (_0x045855a9 ? this._0xc42726ee._0x982957fd : this._0xc42726ee._0x5f4b4c5c);
            }

            if (this._0x4e1f9b79[_0x0a45faee] != null)
            {
                this._0x4e1f9b79[_0x0a45faee].color = _0x045855a9 ? _0x47f8534e.PineDeep : _0x47f8534e.Fade(_0x47f8534e.Bark, 0.9f);
            }

            _0x44b73caf.Retext(this._0x8dabbf20[_0x0a45faee], _0xd7d5eddb ? _0x75b25e37._0x10865273(new byte[5] { 140, 153, 132, 156, 133 }, 203) : (_0x045855a9 ? _0x75b25e37._0x10865273(new byte[5] { 146, 148, 131, 131, 230 }, 198) + (_0x0a45faee + 1) : _0x75b25e37._0x10865273(new byte[14] { 85, 73, 68, 92, 37, 81, 74, 37, 80, 75, 73, 74, 70, 78 }, 5)), TileCaptionSize, _0xd7d5eddb ? _0x47f8534e.Gold : _0x47f8534e.LeafLight);
        }

        bool _0x7e220343 = _0xbc5b95aa > 0;
        if (this._0x1a824611 != null)
        {
            this._0x1a824611.gameObject.SetActive(_0x7e220343);
        }

        if (this._0xc8d8f62b != null)
        {
            this._0xc8d8f62b.gameObject.SetActive(!_0x7e220343);
        }
    }

    private readonly TextMeshProUGUI[] _0x8dabbf20 = new TextMeshProUGUI[_0x744cf847.TreeCount];
}

internal static class _0x75b25e37
{
    internal static string _0x10865273(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}