using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static _0x44bff367;

public class _0xaa3720e7 : MonoBehaviour
{
    public void _0xb6c5e67a()
    {
        _0xa5b3545e._0xc67db8a9 = true;
    }

    private void _0x5324dde8()
    {
        IsAfterLevelComplete = true;
        Instance._0x4fdc6a2f(_0x7725f086.SCENE_0);
    }

    private static void MakeGrid(List<RectTransform> _0x8cdbd66e, AspectRatioFitter _0x551210e0, float _0xcaa64512, int _0x40b5e774, int _0x725b9b3c)
    {
        _0x551210e0.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
        _0x551210e0.aspectRatio = _0xcaa64512;
        foreach (RectTransform _0x49c4b0c2 in _0x8cdbd66e)
        {
            int _0x14e8a8fe = _0x49c4b0c2.transform.GetSiblingIndex();
            _0x49c4b0c2.anchorMin = new Vector3(Mathf.FloorToInt((float)_0x14e8a8fe % _0x40b5e774) * (1f / _0x40b5e774), (_0x725b9b3c - (Mathf.FloorToInt((float)_0x14e8a8fe / _0x40b5e774) % _0x725b9b3c + 1f)) * (1f / _0x725b9b3c));
            _0x49c4b0c2.anchorMax = new Vector3(Mathf.FloorToInt((float)_0x14e8a8fe % _0x40b5e774 + 1f) * (1f / _0x40b5e774), (_0x725b9b3c - Mathf.FloorToInt((float)_0x14e8a8fe / _0x40b5e774) % _0x725b9b3c) * (1f / _0x725b9b3c));
            _0x49c4b0c2.offsetMin = Vector2.zero;
            _0x49c4b0c2.offsetMax = Vector2.zero;
        }
    }

    [HideInInspector]
    public List<_0xf4c682ca> MoneyCountContainers = new();
    public static bool IsAfterLevelComplete;
    private static _0xb7115535 _0x25a7ae9b => _0xb7115535.ALL_SCENES_SETTING_SINGLETONS[0];

    public void _0x809ea51c()
    {
        this._0x4fdc6a2f(SceneManager.GetActiveScene().buildIndex);
    }

    private void _0xb5437866(bool _0xdd14b6a5)
    {
        Rigidbody2D[] _0x6eb7aba7 = this.RootGameObject.GetComponentsInChildren<Rigidbody2D>(true);
        foreach (Rigidbody2D _0x9063c0b6 in _0x6eb7aba7)
            if (_0xdd14b6a5)
                _0x9063c0b6.constraints = RigidbodyConstraints2D.FreezeAll;
            else
                _0x9063c0b6.constraints = RigidbodyConstraints2D.None;
    }

    [HideInInspector]
    public GameObject RootGameObject; // tag - "Root"
    public Transform Environment;
    private static void ExitGame()
    {
        Application.Quit();
    }

    public bool _0xa4675a86 { get; private set; }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0xaa3720e7>();
        this.RootGameObject = GameObject.FindWithTag(_0x55c7c984._0x4cf51720(new byte[4] { 14, 51, 51, 40 }, 92));
        if (this._0x49720ba9 == _0x7725f086.SCENE_0)
            this._0xfcdfb188(true);
        else
            this._0xfcdfb188(false);
        this.MoneyCountContainers = this.RootGameObject.GetComponentsInChildren<_0xf4c682ca>(true).ToList();
    }

    private static _0xb7115535 GAME_INDEX_SETTINGS(int _0x4730be48)
    {
        return _0xb7115535.ALL_SCENES_SETTING_SINGLETONS[_0x4730be48];
    }

    public static _0xaa3720e7 Instance;
    public void _0x4fdc6a2f(int _0x4645949a)
    {
        //if (SceneManager.GetActiveScene().buildIndex == sceneIndex)
        //    AdsInitializer.Instance?.ShowAd();
        this.StartCoroutine(this._0x192ecaa1(_0x4645949a));
    }

    public Transform EnvironmentWithTweensToToggle;
    private IEnumerator _0xe554675b(string _0x59e567b9)
    {
        _0x2f4dab23.Instance._0x6918b989(_0x9543a72f.SPLASH);
        //AudioController.Instance.SaveLastMusicTimes();
        AsyncOperation _0x719f5f6d = SceneManager.LoadSceneAsync(_0x59e567b9);
        while (!_0x719f5f6d.isDone)
            yield return null;
    }

    private void _0xb499e379(Transform _0x710b84dd)
    {
        Transform[] _0xa1b30e43 = _0x710b84dd.GetComponentsInChildren<Transform>();
        foreach (Transform _0xc4118b29 in _0xa1b30e43)
            if (_0xc4118b29 != null && DOTween.IsTweening(_0xc4118b29))
            {
                if (this._0xa4675a86)
                    DOTween.Play(_0xc4118b29);
                else
                    DOTween.Pause(_0xc4118b29);
            }
    }

    private IEnumerator _0x192ecaa1(int _0x4f8ad726)
    {
        _0x2f4dab23.Instance._0x6918b989(_0x9543a72f.SPLASH);
        AsyncOperation _0xa3a91ed7 = SceneManager.LoadSceneAsync(_0x4f8ad726);
        while (!_0xa3a91ed7.isDone)
            yield return null;
    }

    public static bool IsAfterLevelFailed = false;
    private void Start()
    {
        if (this._0x49720ba9 != _0x7725f086.SCENE_0)
            Screen.orientation = ScreenOrientation.Portrait;
        this.DeleteProgressDataButton?.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            //AudioController.Instance.UpdateMusics();
            //AudioController.Instance.UpdateSfxes();
            Instance._0x4fdc6a2f(_0x7725f086.SCENE_0);
        });
        this.ShowResetTutorialButton?.onClick.AddListener(() =>
        {
            _0xa5b3545e._0xc67db8a9 = false;
            _0x9285dd47.Instance._0x63373e5a();
            _0x2f4dab23.Instance._0x6918b989(_0x9543a72f.TUTORIAL0);
        });
    }

    public Button DeleteProgressDataButton;
    public Canvas MainCanvas;
    public void _0x91e7f294()
    {
        foreach (_0xf4c682ca _0x85a09b5a in this.MoneyCountContainers)
            _0x85a09b5a._0x1b2cf3a9();
    }

    public static _0xb7115535 _0xa5b3545e => _0xb7115535.ALL_SCENES_SETTING_SINGLETONS[Instance._0x49720ba9];
    public int _0x49720ba9 => SceneManager.GetActiveScene().buildIndex;

    public void _0xfcdfb188(bool _0xfb1cfb41)
    {
        this._0xa4675a86 = _0xfb1cfb41;
        this._0xb5437866(!this._0xa4675a86);
        Physics2D.simulationMode = this._0xa4675a86 ? SimulationMode2D.FixedUpdate : SimulationMode2D.Script;
        if (this.EnvironmentWithTweensToToggle != null)
            this._0xb499e379(this.EnvironmentWithTweensToToggle);
    }

    public Button ShowResetTutorialButton;
}

internal static class _0x55c7c984
{
    internal static string _0x4cf51720(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}