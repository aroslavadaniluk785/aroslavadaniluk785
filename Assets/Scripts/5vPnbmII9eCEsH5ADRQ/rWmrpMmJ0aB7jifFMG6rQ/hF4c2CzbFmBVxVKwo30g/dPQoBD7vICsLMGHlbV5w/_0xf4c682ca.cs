using TMPro;
using UnityEngine;
using static _0x44bff367;

public class _0xf4c682ca : MonoBehaviour
{
    private void Start()
    {
        if (this.MoneyCountText == null)
        {
            TMP_Text _0xbc490ea0;
            if (this.gameObject.TryGetComponent(out _0xbc490ea0))
                this.MoneyCountText = _0xbc490ea0;
        }

        this._0x1b2cf3a9();
    }

    public void _0x1b2cf3a9()
    {
        this.MoneyCountText.text = _0x0ad17af2._0x0d1b70b1.ToString();
    }

    public TMP_Text MoneyCountText;
}