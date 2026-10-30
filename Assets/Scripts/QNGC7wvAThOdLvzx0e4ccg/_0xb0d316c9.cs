using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// The bottom sheet of the menu: mark, tagline, two counters and the button row.
/// The sheet also gives the template scene button its visible face, so the tap target and
/// the artwork are the same object and the press can never miss.
public sealed class _0xb0d316c9 : MonoBehaviour
{
    public void _0x66b89a25(_0xf6b95e08 _0x692f120c, RectTransform _0xbcaa6ecf, RectTransform _0x9fe97819)
    {
        Image _0x02f406be = _0x44b73caf.Picture(_0xbcaa6ecf, _0xb3d85421._0x68ae0395(new byte[8] { 85, 115, 96, 118, 119, 124, 119, 96 }, 18), _0x692f120c._0x4cd1b832, new Vector2(0.5f, 0f), new Vector2(300f, 1430f), new Vector2(460f, 540f));
        _0x44b73caf.Plate(_0xbcaa6ecf, _0xb3d85421._0x68ae0395(new byte[9] { 46, 6, 13, 22, 48, 11, 6, 6, 23 }, 99), _0x692f120c._0xd759b031, _0x47f8534e.Pine, new Vector2(0.5f, 0f), new Vector2(0f, 565f), new Vector2(1182f, 1130f));
        _0x44b73caf.Picture(_0xbcaa6ecf, _0xb3d85421._0x68ae0395(new byte[9] { 0, 59, 54, 54, 39, 30, 50, 33, 56 }, 83), _0x692f120c._0xfa51635f, new Vector2(0.5f, 0f), new Vector2(0f, 1010f), new Vector2(170f, 170f));
        _0x44b73caf.Label(_0xbcaa6ecf, _0x692f120c._0x9e093146, _0xb3d85421._0x68ae0395(new byte[7] { 121, 76, 74, 65, 68, 67, 72 }, 45), _0xb3d85421._0x68ae0395(new byte[20] { 211, 198, 219, 195, 180, 192, 220, 209, 180, 211, 213, 198, 208, 209, 218, 180, 214, 213, 215, 223 }, 148), TaglineSize, _0x47f8534e.Cream, new Vector2(0.5f, 0f), new Vector2(0f, 880f), new Vector2(940f, 66f), TextAlignmentOptions.Center);
        _0x44b73caf.Plate(_0xbcaa6ecf, _0xb3d85421._0x68ae0395(new byte[7] { 203, 230, 249, 230, 235, 234, 253 }, 143), _0x692f120c._0xd759b031, _0x47f8534e.Fade(_0x47f8534e.Gold, 0.75f), new Vector2(0.5f, 0f), new Vector2(0f, 820f), new Vector2(860f, 8f));
        this._0x85f57f75 = this._0x2388e55d(_0x692f120c, _0xbcaa6ecf, _0xb3d85421._0x68ae0395(new byte[9] { 1, 56, 61, 61, 5, 35, 52, 52, 34 }, 81), -250f, _0x692f120c._0xd8c787b7);
        this._0x424bdd40 = this._0x2388e55d(_0x692f120c, _0xbcaa6ecf, _0xb3d85421._0x68ae0395(new byte[10] { 44, 21, 16, 16, 62, 29, 15, 23, 25, 8 }, 124), 250f, _0x692f120c._0x90cd8602);
        this._0x03214a13(_0x692f120c, _0x9fe97819);
        Button _0x069ea312 = _0x44b73caf.Action(_0xbcaa6ecf, _0x692f120c._0x9e093146, _0xb3d85421._0x68ae0395(new byte[12] { 2, 52, 46, 7, 33, 50, 36, 37, 46, 13, 33, 48 }, 64), _0x692f120c._0x13661abf, _0x47f8534e.Leaf, _0xb3d85421._0x68ae0395(new byte[10] { 128, 134, 149, 131, 130, 137, 231, 138, 134, 151 }, 199), SecondarySize, _0x47f8534e.Cream, new Vector2(0.5f, 0f), new Vector2(-295f, 400f), new Vector2(540f, 132f));
        _0x069ea312.onClick.AddListener(() => _0x692f120c._0x45dd8f9f());
        Button _0xac2d5bc3 = _0x44b73caf.Action(_0xbcaa6ecf, _0x692f120c._0x9e093146, _0xb3d85421._0x68ae0395(new byte[11] { 138, 188, 166, 155, 173, 188, 188, 161, 166, 175, 187 }, 200), _0x692f120c._0x13661abf, _0x47f8534e.Leaf, _0xb3d85421._0x68ae0395(new byte[8] { 156, 138, 155, 155, 134, 129, 136, 156 }, 207), SecondarySize, _0x47f8534e.Cream, new Vector2(0.5f, 0f), new Vector2(295f, 400f), new Vector2(540f, 132f));
        _0xac2d5bc3.onClick.AddListener(() => _0x692f120c._0x77df0c28());
        Button _0x36946287 = _0x44b73caf.Action(_0xbcaa6ecf, _0x692f120c._0x9e093146, _0xb3d85421._0x68ae0395(new byte[8] { 71, 113, 107, 77, 106, 114, 81, 106 }, 5), _0x692f120c._0x13661abf, _0x47f8534e.PineDeep, _0xb3d85421._0x68ae0395(new byte[11] { 166, 161, 185, 206, 186, 161, 206, 190, 162, 175, 183 }, 238), SecondarySize, _0x47f8534e.Cream, new Vector2(0.5f, 0f), new Vector2(0f, 240f), new Vector2(640f, 132f));
        _0x36946287.onClick.AddListener(() => _0x692f120c._0x532c024b());
        this._0x50bd6d8a();
        this._0x5435bd02(_0x02f406be);
    }

    private const float TaglineSize = 46f;
    private Transform _0x56b2b349;
    private void _0x5435bd02(Image _0x81677f1c)
    {
        if (_0x81677f1c == null)
        {
            return;
        }

        this._0x413acaa9 = _0x81677f1c.transform;
        this._0x413acaa9.DOLocalMoveY(16f, 1.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetRelative(true).SetLink(_0x81677f1c.gameObject);
    }

    /// Icon gutter and text column never share an x band, so the caption can never slide
    /// under the icon however long the value grows.
    private TextMeshProUGUI _0x2388e55d(_0xf6b95e08 _0xb649e9ff, RectTransform _0x74950cef, string _0xf5b46108, float _0x8b4052fd, Sprite _0x0ee91c04)
    {
        RectTransform _0x036b2c10 = _0x44b73caf.Plate(_0x74950cef, _0xf5b46108, _0xb649e9ff._0xd759b031, _0x47f8534e.Fade(_0x47f8534e.PineDeep, 0.95f), new Vector2(0.5f, 0f), new Vector2(_0x8b4052fd, 735f), new Vector2(470f, 112f)).rectTransform;
        _0x44b73caf.Picture(_0x036b2c10, _0xb3d85421._0x68ae0395(new byte[8] { 90, 99, 102, 102, 67, 105, 101, 100 }, 10), _0x0ee91c04, new Vector2(0.5f, 0.5f), new Vector2(-150f, 0f), new Vector2(64f, 64f));
        return _0x44b73caf.Label(_0x036b2c10, _0xb649e9ff._0x9e093146, _0xb3d85421._0x68ae0395(new byte[8] { 65, 120, 125, 125, 69, 116, 105, 101 }, 17), "", PillSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(62f, 0f), new Vector2(260f, 56f), TextAlignmentOptions.Left);
    }

    private const float PlaySize = 56f;
    public void _0x50bd6d8a()
    {
        _0x44b73caf.Retext(this._0x85f57f75, _0xb3d85421._0x68ae0395(new byte[6] { 121, 127, 104, 104, 126, 13 }, 45) + _0x744cf847._0x5f18a4d3 + _0xb3d85421._0x68ae0395(new byte[3] { 210, 221, 210 }, 242) + _0x744cf847.TreeCount, PillSize, _0x47f8534e.Cream);
        _0x44b73caf.Retext(this._0x424bdd40, _0xb3d85421._0x68ae0395(new byte[7] { 118, 117, 103, 127, 113, 96, 20 }, 52) + _0x744cf847._0x90fc7e1b, PillSize, _0x47f8534e.Cream);
    }

    private Transform _0x413acaa9;
    private const float SecondarySize = 44f;
    private TextMeshProUGUI _0x85f57f75;
    private const float PillSize = 36f;
    private TextMeshProUGUI _0x424bdd40;
    private void OnDestroy()
    {
        if (this._0x413acaa9 != null)
        {
            DOTween.Kill(this._0x413acaa9);
        }

        if (this._0x56b2b349 != null)
        {
            DOTween.Kill(this._0x56b2b349);
        }
    }

    /// The template button that loads the puzzle ships invisible. Its face is added as a
    /// child here, so the raycast lands on artwork that belongs to the same button.
    private void _0x03214a13(_0xf6b95e08 _0xf6bcd84d, RectTransform _0xf5dc8d7c)
    {
        if (_0xf5dc8d7c == null)
        {
            return;
        }

        RectTransform _0xf0de4df6 = _0x44b73caf.Full(_0xf5dc8d7c, _0xb3d85421._0x68ae0395(new byte[8] { 153, 165, 168, 176, 143, 168, 170, 172 }, 201));
        Image _0x3daca83f = _0xf0de4df6.gameObject.AddComponent<Image>();
        _0x3daca83f.sprite = _0xf6bcd84d._0x65660cd1;
        _0x3daca83f.type = Image.Type.Sliced;
        _0x3daca83f.color = _0x47f8534e.Gold;
        _0x3daca83f.raycastTarget = true;
        _0x44b73caf.Label(_0xf0de4df6, _0xf6bcd84d._0x9e093146, _0xb3d85421._0x68ae0395(new byte[11] { 58, 6, 11, 19, 41, 11, 26, 30, 3, 5, 4 }, 106), _0xb3d85421._0x68ae0395(new byte[4] { 222, 194, 207, 215 }, 142), PlaySize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(600f, 110f), TextAlignmentOptions.Center);
        this._0x56b2b349 = _0xf0de4df6;
        _0xf0de4df6.DOScale(1.03f, 1.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetLink(_0xf0de4df6.gameObject);
    }
}

internal static class _0xb3d85421
{
    internal static string _0x68ae0395(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}