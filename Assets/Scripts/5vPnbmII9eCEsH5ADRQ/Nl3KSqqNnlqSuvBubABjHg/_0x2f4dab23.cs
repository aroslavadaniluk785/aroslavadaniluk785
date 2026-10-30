using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0x44bff367;

public class _0x2f4dab23 : MonoBehaviour
{
    public int CurrentPanelIndex;
    public List<_0x75955c9b> Panels;
    public void _0x10e698c6()
    {
        this.LastPanelIndexes.RemoveAll(_0x7d96f8eb => _0x7d96f8eb == this.CurrentPanelIndex);
        int _0x48e7ee65 = this.LastPanelIndexes.Last();
        this._0x8291ac8a(_0x48e7ee65);
        this._0x06c24437(_0x48e7ee65);
        this.CurrentPanelIndex = _0x48e7ee65;
        this.Panels[_0x48e7ee65].Show();
    }

    public void _0x42658892(int _0x8b39c96d)
    {
        if (_0x8b39c96d == _0x9543a72f.SPLASH && _0xaa3720e7.Instance._0x49720ba9 != _0x7725f086.SCENE_0)
            _0x4ccc2a9a.Instance._0xe2e63494();
        if (_0xaa3720e7.Instance._0x49720ba9 != _0x7725f086.SCENE_0)
        {
            if (_0x8b39c96d == _0x9543a72f.SPLASH || _0x8b39c96d == _0x9543a72f.TUTORIAL0)
                _0xaa3720e7.Instance._0xfcdfb188(false);
            else if (_0x8b39c96d == _0x9543a72f.DEFAULT)
                _0xaa3720e7.Instance._0xfcdfb188(true);
        }
    }

    private void _0xf1aa516e(int _0x56d023b7)
    {
        this.LastPanelIndexes.Add(_0x56d023b7);
        this.CurrentPanelIndex = _0x56d023b7;
        for (int _0x567571a3 = 0; _0x567571a3 < this.Panels.Count; _0x567571a3++)
            if (_0x567571a3 != _0x56d023b7 && this.Panels[_0x567571a3] != null)
                this.Panels[_0x567571a3]._0x4c5c7f81();
    }

    private void _0x06c24437(int _0x0fea2b11)
    {
        this.LastPanelIndexes.Add(_0x0fea2b11);
        this.CurrentPanelIndex = _0x0fea2b11;
        for (int _0x7a5800d0 = 0; _0x7a5800d0 < this.Panels.Count; _0x7a5800d0++)
            if (_0x7a5800d0 != _0x0fea2b11 && this.Panels[_0x7a5800d0] != null)
                this.Panels[_0x7a5800d0]._0x4c5c7f81();
    }

    private void _0x8291ac8a(int _0x4b94f53e)
    {
        if (_0x4b94f53e == _0x9543a72f.SPLASH)
            _0x4ccc2a9a.Instance._0xa8030761();
        if (_0xaa3720e7.Instance._0x49720ba9 == _0x7725f086.SCENE_0)
        {
        }
    }

    private _0x75955c9b _0xae9e6f08(int _0xc06eff94)
    {
        return this.Panels[_0xc06eff94];
    }

    private void _0x4e0f868f()
    {
        this._0x2ad66a9e(_0x9543a72f.SPLASH);
        if (_0xaa3720e7.Instance._0x49720ba9 == _0x7725f086.SCENE_0)
        {
        }
        else
        {
            this.Invoke(nameof(this.SwitchSplash), _0x4ccc2a9a.Instance.DefaultAnimationTime);
        }
    }

    [HideInInspector]
    public List<int> LastPanelIndexes = new()
    {
        1
    };
    public void _0x6918b989(int _0x15ee43c8)
    {
        this._0xf1aa516e(_0x15ee43c8);
        this._0x8291ac8a(_0x15ee43c8);
        this.CurrentPanelIndex = _0x15ee43c8;
        this.Panels[_0x15ee43c8].Show();
    }

    private void _0x2ad66a9e(int _0x87e33327)
    {
        this._0xf1aa516e(_0x87e33327);
        this._0x8291ac8a(_0x87e33327);
        this.CurrentPanelIndex = _0x87e33327;
        this.Panels[_0x87e33327]._0x78140573();
    }

    public static _0x2f4dab23 Instance;
    public bool IsShowSplashOnStart = true;
    private void SwitchSplash()
    {
        if (_0x484b54e4.Instance.IsTutorialEnabled && !_0xaa3720e7._0xa5b3545e._0xc67db8a9)
            this._0x6918b989(_0x9543a72f.TUTORIAL0);
        else
            this._0x6918b989(_0x9543a72f.DEFAULT);
    }

    public float StaticBlurMaterialInitialValue;
    private void Start()
    {
        this._0x4e0f868f();
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x2f4dab23>();
    }

    public float ScaleDuration = 0.4f;
}