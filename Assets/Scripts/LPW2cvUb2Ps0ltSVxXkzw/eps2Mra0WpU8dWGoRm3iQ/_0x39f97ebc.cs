using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x39f97ebc : MonoBehaviour
{
    private TMP_Text _0xd126c5c1;
    private Image _0x82ec4583;
    private void _0xf0c5f455()
    {
        if (this._0x82ec4583.canvasRenderer.GetColor() != this._0xd126c5c1.canvasRenderer.GetColor())
            this._0xd126c5c1.canvasRenderer.SetColor(this._0x82ec4583.canvasRenderer.GetColor());
    }

    private void Update()
    {
        this._0xf0c5f455();
    }
}