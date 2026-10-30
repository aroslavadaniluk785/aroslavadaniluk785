using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class _0xf1375d3b : MonoBehaviour
{
    private float _0x5a0cd380 = 4;
    private float _0x9c37ccb0 = 1.5f;
    private List<string> _0x0488a045 = new();
    private float _0x9f8d6270 = 0.6f;
    private float _0xb6937348;
    private void Update()
    {
        int _0x71ea61a3 = 1;
        if (this._0x0488a045.Count > 0)
        {
            string _0x1317734f = this._0x321c2169.text;
            foreach (string _0x8a438903 in this._0x0488a045)
                while (_0x1317734f.Contains(_0x8a438903))
                    _0x1317734f = _0x1317734f.Replace(_0x8a438903, "");
            _0x71ea61a3 = _0x1317734f.Length;
        }
        else
        {
            _0x71ea61a3 = this._0x321c2169.text.Length;
        }

        float _0xaa7a544e = Mathf.Clamp(this._0xb6937348 + this._0x9f8d6270 * _0x71ea61a3, this._0x9c37ccb0, this._0x5a0cd380);
        if (!Mathf.Approximately(this._0x17ef3217.aspectRatio, _0xaa7a544e))
            this._0x17ef3217.aspectRatio = _0xaa7a544e;
    }

    private AspectRatioFitter _0x17ef3217;
    private TMP_Text _0x321c2169;
}