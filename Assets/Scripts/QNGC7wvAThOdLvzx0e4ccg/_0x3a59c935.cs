using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Three illustrated steps that explain the control scheme before the first run.
/// The puzzle is driven by a DRAG, so the gesture and its result are spelled out here as
/// well as on the permanent hint inside the puzzle itself.
public sealed class _0x3a59c935 : MonoBehaviour
{
    public void _0x1adbf993()
    {
        this._0x0e7223d3 = 0;
        this._0x232c251c();
        if (this._0x43813ae9 != null)
        {
            this._0x43813ae9._0xc75fde18();
        }
    }

    public void _0x77601200(_0xf6b95e08 _0x9b2d7096, RectTransform _0x2c035a05)
    {
        this._0x6093a173 = _0x9b2d7096;
        RectTransform _0xc0c10040 = _0x44b73caf.Full(_0x2c035a05, _0x6c48e482._0x94752be0(new byte[12] { 68, 99, 123, 88, 99, 67, 122, 105, 126, 96, 109, 117 }, 12));
        _0x44b73caf.Scrim(_0xc0c10040, _0x6c48e482._0x94752be0(new byte[10] { 238, 201, 209, 242, 201, 245, 197, 212, 207, 203 }, 166), _0x47f8534e.Fade(_0x47f8534e.Bark, 0.80f), true);
        RectTransform _0xe309c667 = _0x44b73caf.Plate(_0xc0c10040, _0x6c48e482._0x94752be0(new byte[9] { 10, 45, 53, 22, 45, 1, 35, 48, 38 }, 66), _0x9b2d7096._0xd759b031, _0x47f8534e.Pine, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1100f, 1500f)).rectTransform;
        _0x44b73caf.Label(_0xe309c667, _0x9b2d7096._0x9e093146, _0x6c48e482._0x94752be0(new byte[11] { 247, 208, 200, 235, 208, 247, 218, 222, 219, 218, 205 }, 191), _0x6c48e482._0x94752be0(new byte[11] { 89, 94, 70, 49, 69, 94, 49, 65, 93, 80, 72 }, 17), HeaderSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, 640f), new Vector2(880f, 80f), TextAlignmentOptions.Center);
        this._0xd63e95a6 = _0x44b73caf.Picture(_0xe309c667, _0x6c48e482._0x94752be0(new byte[8] { 242, 213, 205, 238, 213, 251, 200, 206 }, 186), _0x9b2d7096._0xad238d11, new Vector2(0.5f, 0.5f), new Vector2(0f, 280f), new Vector2(420f, 420f));
        this._0x529dfb29 = _0x44b73caf.Label(_0xe309c667, _0x9b2d7096._0x9e093146, _0x6c48e482._0x94752be0(new byte[15] { 6, 33, 57, 26, 33, 29, 58, 43, 62, 6, 43, 47, 42, 43, 60 }, 78), "", StepHeaderSize, _0x47f8534e.Gold, new Vector2(0.5f, 0.5f), new Vector2(0f, 40f), new Vector2(900f, 80f), TextAlignmentOptions.Center);
        this._0xf0c80cf5 = _0x44b73caf.Label(_0xe309c667, _0x9b2d7096._0x9e093146, _0x6c48e482._0x94752be0(new byte[9] { 36, 3, 27, 56, 3, 46, 3, 8, 21 }, 108), "", BodySize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, -90f), new Vector2(940f, 190f), TextAlignmentOptions.Center);
        this._0x3db0534b = _0x44b73caf.Label(_0xe309c667, _0x9b2d7096._0x9e093146, _0x6c48e482._0x94752be0(new byte[12] { 77, 106, 114, 81, 106, 70, 106, 112, 107, 113, 96, 119 }, 5), "", CounterSize, _0x47f8534e.LeafLight, new Vector2(0.5f, 0.5f), new Vector2(0f, -250f), new Vector2(520f, 56f), TextAlignmentOptions.Center);
        Button _0xbe73fd9e = _0x44b73caf.Action(_0xe309c667, _0x9b2d7096._0x9e093146, _0x6c48e482._0x94752be0(new byte[9] { 148, 179, 171, 136, 179, 146, 185, 164, 168 }, 220), _0x9b2d7096._0x65660cd1, _0x47f8534e.Gold, _0x6c48e482._0x94752be0(new byte[4] { 73, 66, 95, 83 }, 7), ButtonSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, -430f), new Vector2(520f, 132f));
        this._0xbc30893a = _0xbe73fd9e.GetComponentInChildren<TextMeshProUGUI>(true);
        _0xbe73fd9e.onClick.AddListener(() => this._0xf312e608());
        Button _0xa90a39a6 = _0x44b73caf.Action(_0xe309c667, _0x9b2d7096._0x9e093146, _0x6c48e482._0x94752be0(new byte[10] { 136, 175, 183, 148, 175, 131, 172, 175, 179, 165 }, 192), _0x9b2d7096._0x13661abf, _0x47f8534e.PineDeep, _0x6c48e482._0x94752be0(new byte[5] { 232, 231, 228, 248, 238 }, 171), ButtonSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, -610f), new Vector2(420f, 124f));
        _0xa90a39a6.onClick.AddListener(() => this._0x0bbd9a36());
        this._0x43813ae9 = _0xc0c10040.gameObject.AddComponent<_0x5d1715c7>();
        this._0x43813ae9._0x342297fa(_0xc0c10040.gameObject);
        _0xc0c10040.gameObject.SetActive(false);
    }

    private int _0x0e7223d3;
    private const int StepCount = 3;
    private const float StepHeaderSize = 56f;
    private TextMeshProUGUI _0x3db0534b;
    private void _0xf312e608()
    {
        if (this._0x0e7223d3 >= StepCount - 1)
        {
            this._0x0bbd9a36();
            return;
        }

        this._0x0e7223d3++;
        this._0x232c251c();
        if (this._0xd63e95a6 == null)
        {
            return;
        }

        Transform _0x0911a37e = this._0xd63e95a6.transform;
        _0x0911a37e.DOPunchScale(Vector3.one * 0.08f, 0.26f, 6, 0.8f).SetLink(_0x0911a37e.gameObject);
    }

    private const float BodySize = 44f;
    private _0xf6b95e08 _0x6093a173;
    private const float ButtonSize = 44f;
    private TextMeshProUGUI _0xf0c80cf5;
    public void _0x0bbd9a36()
    {
        _0x744cf847._0x856f0ab8 = true;
        if (this._0x43813ae9 != null)
        {
            this._0x43813ae9._0xc9623eae();
        }
    }

    private void OnDestroy()
    {
        if (this._0xd63e95a6 != null)
        {
            DOTween.Kill(this._0xd63e95a6.transform);
        }
    }

    /// Line breaks are placed by hand so the layout is identical on every device.
    private void _0x232c251c()
    {
        string _0xeecee5e9 = _0x6c48e482._0x94752be0(new byte[11] { 142, 143, 136, 148, 250, 155, 250, 136, 147, 148, 157 }, 218);
        string _0xf3492234 = _0x6c48e482._0x94752be0(new byte[52] { 124, 106, 121, 127, 24, 121, 24, 106, 113, 118, 127, 24, 116, 125, 126, 108, 24, 119, 106, 24, 106, 113, 127, 112, 108, 22, 50, 119, 118, 125, 24, 118, 119, 108, 123, 112, 24, 123, 119, 107, 108, 107, 24, 119, 118, 125, 24, 108, 109, 106, 118, 22 }, 56);
        Sprite _0x40402126 = this._0x6093a173._0xad238d11;
        if (this._0x0e7223d3 == 1)
        {
            _0xeecee5e9 = _0x6c48e482._0x94752be0(new byte[12] { 24, 20, 30, 16, 117, 20, 117, 6, 5, 26, 30, 16 }, 85);
            _0xf3492234 = _0x6c48e482._0x94752be0(new byte[42] { 33, 36, 35, 40, 77, 56, 61, 77, 57, 37, 63, 40, 40, 77, 34, 43, 77, 57, 37, 40, 77, 62, 44, 32, 40, 103, 44, 33, 34, 35, 42, 77, 34, 35, 40, 77, 62, 61, 34, 38, 40, 67 }, 109);
            _0x40402126 = this._0x6093a173._0x8827b646;
        }
        else if (this._0x0e7223d3 >= 2)
        {
            _0xeecee5e9 = _0x6c48e482._0x94752be0(new byte[14] { 96, 111, 106, 106, 6, 114, 110, 99, 6, 105, 116, 98, 99, 116 }, 38);
            _0xf3492234 = _0x6c48e482._0x94752be0(new byte[57] { 26, 27, 18, 23, 8, 27, 12, 126, 27, 8, 27, 12, 7, 126, 23, 10, 27, 19, 126, 17, 16, 126, 10, 22, 27, 126, 28, 17, 31, 12, 26, 84, 28, 27, 24, 17, 12, 27, 126, 10, 22, 27, 126, 10, 11, 12, 16, 13, 126, 12, 11, 16, 126, 17, 11, 10, 112 }, 94);
            _0x40402126 = this._0x6093a173._0x7a65e18c;
        }

        if (this._0xd63e95a6 != null)
        {
            this._0xd63e95a6.sprite = _0x40402126;
        }

        _0x44b73caf.Retext(this._0x529dfb29, _0xeecee5e9, StepHeaderSize, _0x47f8534e.Gold);
        _0x44b73caf.Retext(this._0xf0c80cf5, _0xf3492234, BodySize, _0x47f8534e.Cream);
        _0x44b73caf.Retext(this._0x3db0534b, _0x6c48e482._0x94752be0(new byte[5] { 147, 148, 133, 144, 224 }, 192) + (this._0x0e7223d3 + 1) + _0x6c48e482._0x94752be0(new byte[3] { 211, 220, 211 }, 243) + StepCount, CounterSize, _0x47f8534e.LeafLight);
        _0x44b73caf.Retext(this._0xbc30893a, this._0x0e7223d3 >= StepCount - 1 ? _0x6c48e482._0x94752be0(new byte[5] { 216, 223, 202, 217, 223 }, 139) : _0x6c48e482._0x94752be0(new byte[4] { 175, 164, 185, 181 }, 225), ButtonSize, _0x47f8534e.Cream);
    }

    private _0x5d1715c7 _0x43813ae9;
    private TextMeshProUGUI _0x529dfb29;
    private const float HeaderSize = 64f;
    private Image _0xd63e95a6;
    private TextMeshProUGUI _0xbc30893a;
    private const float CounterSize = 32f;
}

internal static class _0x6c48e482
{
    internal static string _0x94752be0(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}