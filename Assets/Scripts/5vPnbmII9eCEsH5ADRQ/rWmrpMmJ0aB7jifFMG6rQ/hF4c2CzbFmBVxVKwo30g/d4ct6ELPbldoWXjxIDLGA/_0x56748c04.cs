using UnityEngine;
using UnityEngine.UI;

public class _0x56748c04 : MonoBehaviour
{
    public bool IsHideAllPops;
    private void Start()
    {
        if (this.IsShowLastPop)
            this.Button.onClick.AddListener(() =>
            {
                _0x9285dd47.Instance._0xd1016de0();
            });
        else if (this.IsHideAllPops)
            this.Button.onClick.AddListener(() => _0x9285dd47.Instance._0x63373e5a());
        else
            this.Button.onClick.AddListener(() => _0x9285dd47.Instance._0x77e745d1(this.PopToShowIndex));
    }

    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    public int PopToShowIndex;
    public Button Button;
    public bool IsShowLastPop;
}