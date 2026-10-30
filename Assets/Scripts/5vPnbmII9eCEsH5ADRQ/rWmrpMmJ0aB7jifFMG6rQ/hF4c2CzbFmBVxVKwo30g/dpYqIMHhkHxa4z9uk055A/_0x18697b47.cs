using UnityEngine;
using UnityEngine.UI;

public class _0x18697b47 : MonoBehaviour
{
    private void Start()
    {
        if (this.NextTutorialButton != null)
        {
            if (this.IsTutorialEndPanel)
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x2f4dab23.Instance._0x6918b989(this.EndTutorialPanelIndex));
                this.NextTutorialButton.onClick.AddListener(() => _0xaa3720e7.Instance._0xb6c5e67a());
            }
            else
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x2f4dab23.Instance._0x6918b989(this.NextTutorialPanelIndex));
            }
        }

        if (this.TutorialEndButton != null)
        {
            this.TutorialEndButton.onClick.AddListener(() => _0x2f4dab23.Instance._0x6918b989(this.EndTutorialPanelIndex));
            this.TutorialEndButton.onClick.AddListener(() => _0xaa3720e7.Instance._0xb6c5e67a());
        }
    }

    public Button NextTutorialButton;
    public bool IsTutorialEndPanel;
    public Button TutorialEndButton;
    public int NextTutorialPanelIndex;
    public int EndTutorialPanelIndex = 1;
}