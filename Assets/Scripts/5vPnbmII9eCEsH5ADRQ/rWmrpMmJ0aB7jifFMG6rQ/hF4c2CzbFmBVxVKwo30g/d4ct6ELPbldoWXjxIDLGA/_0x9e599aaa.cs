using UnityEngine;
using UnityEngine.UI;

public class _0x9e599aaa : MonoBehaviour
{
    private Button _0x052ce506;
    private void Awake()
    {
        if (this._0x052ce506 == null)
            if (!this.TryGetComponent(out this._0x052ce506))
                this._0x052ce506 = this.GetComponentInChildren<Button>();
    }

    private int _0xceacdd42;
    private bool _0xbeadd29c;
    private void Start()
    {
        if (this._0xbeadd29c)
            this._0x052ce506.onClick.AddListener(() => _0x2f4dab23.Instance._0x10e698c6());
        else
            this._0x052ce506.onClick.AddListener(() => _0x2f4dab23.Instance._0x6918b989(this._0xceacdd42));
    }
}