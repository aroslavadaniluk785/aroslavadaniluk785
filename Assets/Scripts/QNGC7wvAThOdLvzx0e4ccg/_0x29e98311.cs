using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Dresses the three result popups (pause 6, win 7, lose 8) in this game's own words,
/// art and colours - including the close cross, which the template leaves without a
/// sprite and which Unity therefore paints as a plain white rectangle.
public sealed class _0x29e98311 : MonoBehaviour
{
    private readonly TextMeshProUGUI[] _0xdabf2267 = new TextMeshProUGUI[3];
    private const float HeaderSize = 84f;
    /// Shared by every close cross: leave the popup and hand the board back.
    private void _0x7c44385b()
    {
        _0x9285dd47 _0x8229cdc0 = _0x9285dd47.Instance;
        if (_0x8229cdc0 != null)
        {
            _0x8229cdc0._0x63373e5a();
        }

        _0xaa3720e7 _0xa8b953ff = _0xaa3720e7.Instance;
        if (_0xa8b953ff != null)
        {
            _0xa8b953ff._0xfcdfb188(true);
        }
    }

    /// Built on demand so no popup depends on the order of Start calls.
    public void _0xfd32591f()
    {
        if (this._0x0073bf67)
        {
            return;
        }

        this._0x0073bf67 = true;
        this._0x7dac533d(0, PausePop, this._pauseArt, _0x7828e014._0x1eedeca2(new byte[14] { 146, 135, 141, 143, 136, 129, 230, 135, 230, 132, 148, 131, 135, 141 }, 198), _0x7828e014._0x1eedeca2(new byte[21] { 168, 180, 185, 220, 187, 189, 174, 184, 185, 178, 220, 171, 181, 176, 176, 220, 171, 189, 181, 168, 210 }, 252), "");
        this._0x7dac533d(1, WinPop, this._winArt, _0x7828e014._0x1eedeca2(new byte[17] { 245, 233, 228, 129, 245, 243, 228, 228, 129, 232, 242, 129, 227, 224, 226, 234, 128 }, 161), _0x7828e014._0x1eedeca2(new byte[20] { 60, 32, 45, 72, 39, 58, 44, 45, 58, 72, 33, 59, 72, 46, 33, 36, 36, 45, 44, 70 }, 104), "");
        this._0x7dac533d(2, LosePop, this._loseArt, _0x7828e014._0x1eedeca2(new byte[12] { 154, 128, 129, 245, 154, 147, 245, 129, 128, 135, 155, 134 }, 213), _0x7828e014._0x1eedeca2(new byte[26] { 254, 226, 239, 138, 230, 235, 249, 254, 138, 238, 239, 230, 227, 252, 239, 248, 243, 138, 239, 242, 250, 227, 248, 239, 238, 132 }, 170), "");
    }

    [SerializeField]
    private Sprite _loseArt;
    /// Buttons are told apart by the template driver each one carries, never by traversal
    /// order: the first button a search returns is usually the close cross.
    private void _0x001666ec(_0x20303544 _0x8cfe45f3, int _0x21afd5c7)
    {
        Button[] _0xc6310716 = _0x8cfe45f3.Content.GetComponentsInChildren<Button>(true);
        for (int _0xf6bbd86d = 0; _0xf6bbd86d < _0xc6310716.Length; _0xf6bbd86d++)
        {
            Button _0x13cfe07f = _0xc6310716[_0xf6bbd86d];
            if (_0x13cfe07f == null)
            {
                continue;
            }

            TMP_Text _0xfeec4a95 = _0x13cfe07f.GetComponentInChildren<TMP_Text>(true);
            _0x98551277 _0xe34ae66a = _0x13cfe07f.GetComponent<_0x98551277>();
            _0x56748c04 _0x42783df4 = _0x13cfe07f.GetComponent<_0x56748c04>();
            Image _0x45842736 = _0x13cfe07f.targetGraphic as Image;
            if (_0xe34ae66a == null && _0x42783df4 == null)
            {
                // No driver: this is the close cross (and the unused spare slots beside
                // it). It gets the real icon instead of the template white plate, and no
                // caption at all.
                if (_0x45842736 != null)
                {
                    _0x45842736.sprite = this._closeIcon;
                    _0x45842736.type = Image.Type.Simple;
                    _0x45842736.preserveAspect = true;
                    _0x45842736.color = _0x47f8534e.Cream;
                }

                _0x44b73caf.Retext(_0xfeec4a95, "", CaptionSize, _0x47f8534e.Cream);
                // The template leaves this one without a handler, so it ships as a cross
                // that does nothing. It closes the popup and lets the run continue.
                _0x13cfe07f.onClick.AddListener(() => this._0x7c44385b());
                continue;
            }

            string _0x9dbe4fcf;
            Color _0x7074d5b4;
            if (_0x42783df4 != null)
            {
                _0x9dbe4fcf = _0x7828e014._0x1eedeca2(new byte[6] { 104, 127, 105, 111, 119, 127 }, 58);
                _0x7074d5b4 = _0x47f8534e.Gold;
            }
            else if (_0xe34ae66a.IsLoadCurrentScene)
            {
                _0x9dbe4fcf = _0x21afd5c7 == WinPop ? _0x7828e014._0x1eedeca2(new byte[10] { 217, 204, 209, 201, 190, 223, 217, 223, 215, 208 }, 158) : _0x7828e014._0x1eedeca2(new byte[9] { 253, 251, 240, 137, 232, 238, 232, 224, 231 }, 169);
                _0x7074d5b4 = _0x47f8534e.Gold;
            }
            else
            {
                _0x9dbe4fcf = _0x7828e014._0x1eedeca2(new byte[4] { 202, 194, 201, 210 }, 135);
                _0x7074d5b4 = _0x47f8534e.Leaf;
            }

            if (_0x45842736 != null)
            {
                _0x45842736.color = _0x7074d5b4;
            }

            _0x44b73caf.Retext(_0xfeec4a95, _0x9dbe4fcf, CaptionSize, _0x47f8534e.Cream);
        }
    }

    private const int LosePop = 8;
    public void _0xf298aad1(int _0xe3384bea)
    {
        this._0xfd32591f();
        _0x44b73caf.Retext(this._0x5702d2ab[2], _0x7828e014._0x1eedeca2(new byte[45] { 47, 51, 62, 91, 63, 62, 55, 50, 45, 62, 41, 34, 91, 62, 35, 43, 50, 41, 62, 63, 85, 113, 47, 51, 62, 91, 47, 41, 62, 62, 91, 50, 40, 91, 40, 47, 50, 55, 55, 91, 57, 58, 41, 62, 85 }, 123), BodySize, _0x47f8534e.Cream);
        _0x44b73caf.Retext(this._0xdabf2267[2], _0x7828e014._0x1eedeca2(new byte[7] { 164, 167, 181, 173, 163, 178, 198 }, 230) + _0xe3384bea, StatSize, _0x47f8534e.LeafLight);
        _0x9285dd47 _0xdb9e6eb1 = _0x9285dd47.Instance;
        if (_0xdb9e6eb1 != null)
        {
            _0xdb9e6eb1._0x77e745d1(LosePop);
        }
    }

    private const int WinPop = 7;
    [SerializeField]
    private Sprite _closeIcon;
    private const float StatSize = 40f;
    private const int PausePop = 6;
    [SerializeField]
    private Sprite _pauseArt;
    [SerializeField]
    private Sprite _winArt;
    private readonly TextMeshProUGUI[] _0x5702d2ab = new TextMeshProUGUI[3];
    private _0x20303544 _0xb2ccb979(int _0x07254ab0)
    {
        _0x9285dd47 _0x17f085e4 = _0x9285dd47.Instance;
        return _0x17f085e4 == null ? null : _0x17f085e4._0xa8994a5b(_0x07254ab0);
    }

    /// One popup: header, body, stat line, illustration, button captions and close icon.
    private void _0x7dac533d(int _0x43aa3702, int _0xcd3aa56f, Sprite _0xeeb83a10, string _0xd2f784e7, string _0xddbb9a64, string _0x16e4cc4c)
    {
        _0x20303544 _0x15921553 = this._0xb2ccb979(_0xcd3aa56f);
        if (_0x15921553 == null || _0x15921553.Content == null)
        {
            return;
        }

        RectTransform _0xb45b2341 = _0x15921553.Content.transform as RectTransform;
        if (_0xb45b2341 == null)
        {
            return;
        }

        _0x44b73caf.Retext(_0x15921553.ContentHeaderText, _0xd2f784e7, HeaderSize, _0x47f8534e.Cream);
        // The template parks its own metrics in these two labels. This game has no score
        // and no reward, so they are blanked and the result is told in the block below.
        _0x44b73caf.Retext(_0x15921553.ContentMainText, "", BodySize, _0x47f8534e.Cream);
        _0x44b73caf.Retext(_0x15921553.ContentAdditionalText, "", StatSize, _0x47f8534e.LeafLight);
        RectTransform _0xa56644fe = _0x44b73caf.Full(_0xb45b2341, _0x7828e014._0x1eedeca2(new byte[11] { 235, 220, 202, 204, 213, 205, 251, 213, 214, 218, 210 }, 185));
        // Right after the card background and before the header, so nothing of this block
        // can ever be drawn over the caption it belongs to.
        _0xa56644fe.SetSiblingIndex(1);
        _0x44b73caf.Picture(_0xa56644fe, _0x7828e014._0x1eedeca2(new byte[9] { 130, 181, 163, 165, 188, 164, 145, 162, 164 }, 208), _0xeeb83a10, new Vector2(0.5f, 0.845f), Vector2.zero, new Vector2(300f, 300f));
        this._0x5702d2ab[_0x43aa3702] = _0x44b73caf.Label(_0xa56644fe, this._font, _0x7828e014._0x1eedeca2(new byte[10] { 11, 60, 42, 44, 53, 45, 27, 54, 61, 32 }, 89), _0xddbb9a64, BodySize, _0x47f8534e.Cream, new Vector2(0.5f, 0.60f), Vector2.zero, new Vector2(880f, 130f), TextAlignmentOptions.Center);
        this._0xdabf2267[_0x43aa3702] = _0x44b73caf.Label(_0xa56644fe, this._font, _0x7828e014._0x1eedeca2(new byte[10] { 215, 224, 246, 240, 233, 241, 214, 241, 228, 241 }, 133), _0x16e4cc4c, StatSize, _0x47f8534e.LeafLight, new Vector2(0.5f, 0.505f), Vector2.zero, new Vector2(880f, 66f), TextAlignmentOptions.Center);
        this._0x001666ec(_0x15921553, _0xcd3aa56f);
    }

    private const float CaptionSize = 48f;
    public void _0x02be0408()
    {
        this._0xfd32591f();
        _0x9285dd47 _0x3e70c8ca = _0x9285dd47.Instance;
        if (_0x3e70c8ca != null)
        {
            _0x3e70c8ca._0x77e745d1(PausePop);
        }
    }

    public void _0x29fb7cc2(int _0xe14f4c9d, int _0x6deb615e, int _0xc30906eb)
    {
        this._0xfd32591f();
        _0x44b73caf.Retext(this._0x5702d2ab[1], _0x7828e014._0x1eedeca2(new byte[23] { 159, 131, 142, 235, 132, 153, 143, 142, 153, 235, 130, 152, 235, 141, 130, 135, 135, 142, 143, 193, 130, 133, 235 }, 203) + _0xe14f4c9d + _0x7828e014._0x1eedeca2(new byte[7] { 8, 124, 125, 122, 102, 123, 6 }, 40), BodySize, _0x47f8534e.Cream);
        _0x44b73caf.Retext(this._0xdabf2267[1], _0x7828e014._0x1eedeca2(new byte[5] { 191, 185, 174, 174, 203 }, 235) + _0xc30906eb + _0x7828e014._0x1eedeca2(new byte[4] { 129, 238, 231, 129 }, 161) + _0x744cf847.TreeCount + _0x7828e014._0x1eedeca2(new byte[10] { 90, 90, 90, 56, 59, 41, 49, 63, 46, 90 }, 122) + _0x6deb615e, StatSize, _0x47f8534e.LeafLight);
        _0x9285dd47 _0x5b05dd2d = _0x9285dd47.Instance;
        if (_0x5b05dd2d != null)
        {
            _0x5b05dd2d._0x77e745d1(WinPop);
        }
    }

    private bool _0x0073bf67;
    private const float BodySize = 44f;
    [SerializeField]
    private TMP_FontAsset _font;
}

internal static class _0x7828e014
{
    internal static string _0x1eedeca2(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}