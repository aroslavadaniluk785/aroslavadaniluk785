using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x56185aa7 : MonoBehaviour
{
    [HideInInspector]
    public bool IsGameEnd;
    [HideInInspector]
    public int CurrentGameIndex;
    public void _0xb8ba043a()
    {
        if (_0x484b54e4.Instance.IsOnlyWinGameEndEnabled)
            this._0x6208b615();
        if (!this.IsGameEnd)
        {
            this._0x7280cd71();
            _0xaa3720e7.IsAfterLevelComplete = false;
            _0xaa3720e7.IsAfterLevelFailed = true;
            _0x20303544 _0x575da27b = _0x9285dd47.Instance._0xa8994a5b(_0x44bff367._0xc409a710.LOSE).GetComponent<_0x20303544>();
            if (_0x484b54e4.Instance.IsCheckScoreEnabled)
                _0x575da27b.ContentMainText.text = $"{this.ScoreCurrent}/{this._0xb27d0bac}";
            else
                _0x575da27b.ContentMainText.text = $"{this.ScoreCurrent}";
            _0x575da27b.ContentAdditionalText.text = $"{0}";
            _0x44bff367._0x0ad17af2._0x0d1b70b1 += 0;
            _0x9285dd47.Instance._0x77e745d1(_0x44bff367._0xc409a710.LOSE);
        }
    }

    public void _0x58f011c1()
    {
        _0xaa3720e7.Instance._0xfcdfb188(true);
        _0xaa3720e7.Instance._0x4fdc6a2f(_0x44bff367._0x7725f086.SCENE_0);
    }

    private void _0x5ebbb04b()
    {
        if (this.ScoreCurrent >= this._0xb27d0bac)
            this._0x6208b615();
        else
            this._0xb8ba043a();
    }

    private int _0x43a269c6 => this.CustomTimeInitial + _0xaa3720e7._0xa5b3545e._0xb4252322 * 10;

    private void _0x9f6d6c7f()
    {
        this.TimerText.ForEach(_0xd2d23949 => _0xd2d23949.text = TimeSpan.FromSeconds(this.TimeLeft).ToString(_0x7d47476c._0xe1297e51(new byte[6] { 92, 92, 109, 11, 66, 66 }, 49)));
    }

    public List<Button> PauseButtons = new();
    public List<TMP_Text> LevelNumberText = new();
    private IEnumerator _0xc20e3513()
    {
        this._0x9f6d6c7f();
        while (!this.IsGameEnd && this.TimeLeft > 0 && _0xaa3720e7.Instance._0x49720ba9 == this.CurrentGameIndex)
        {
            yield return new WaitForSeconds(1f);
            if (_0xaa3720e7.Instance._0xa4675a86)
            {
                if (this.IsGameEnd)
                    break;
                this.TimeLeft--;
                this._0x9f6d6c7f();
            }
        }

        if (!this.IsGameEnd)
            this._0xb8ba043a();
    }

    public List<TMP_Text> SubtitleText = new();
    public void _0x6208b615()
    {
        if (!this.IsGameEnd)
        {
            this._0x7280cd71();
            _0xaa3720e7.IsAfterLevelComplete = true;
            _0xaa3720e7.IsAfterLevelFailed = false;
            _0x20303544 _0x3ffedb2c = _0x9285dd47.Instance._0xa8994a5b(_0x44bff367._0xc409a710.WIN).GetComponent<_0x20303544>();
            if (_0x484b54e4.Instance.IsCheckScoreEnabled)
                _0x3ffedb2c.ContentMainText.text = $"{this.ScoreCurrent}/{this._0xb27d0bac}";
            else
                _0x3ffedb2c.ContentMainText.text = $"{this.ScoreCurrent}";
            if (_0x484b54e4.Instance.IsBestScoreEnabled)
            {
                if (this.ScoreCurrent > _0x44bff367._0x0ad17af2._0x0d1b70b1)
                    _0x44bff367._0x0ad17af2._0x0d1b70b1 = this.ScoreCurrent;
                _0x3ffedb2c.ContentAdditionalText.text = $"{_0x44bff367._0x0ad17af2._0x0d1b70b1}";
            }
            else
            {
                _0x3ffedb2c.ContentAdditionalText.text = $"{this._0x7b608e81}";
                _0x44bff367._0x0ad17af2._0x0d1b70b1 += this._0x7b608e81;
            }

            if (_0x484b54e4.Instance.IsLevelIncrementOnWin)
                ++_0xaa3720e7._0xa5b3545e._0xb4252322;
            _0x9285dd47.Instance._0x77e745d1(_0x44bff367._0xc409a710.WIN);
        }
    }

    private void _0xec2c6558()
    {
        if (_0x484b54e4.Instance.IsCheckScoreEnabled)
            this.ScoreText.ForEach(_0xd2d23949 => _0xd2d23949.text = $"{this.ScoreCurrent}/{this._0xb27d0bac}");
        else
            this.ScoreText.ForEach(_0xd2d23949 => _0xd2d23949.text = $"{this.ScoreCurrent}");
    }

    private static _0x56185aa7 _0x170776e1;
    private void _0x125eae1b()
    {
        if (this.ScoreCurrent > _0xaa3720e7._0xa5b3545e._0x8c288e96)
            _0xaa3720e7._0xa5b3545e._0x8c288e96 = this.ScoreCurrent;
        if (_0x484b54e4.Instance.IsCheckScoreEnabled)
            if (this.ScoreCurrent >= this._0xb27d0bac)
                this._0x6208b615();
    }

    public List<TMP_Text> ScoreText = new();
    private void Start()
    {
        this.IsGameEnd = false;
        this.TimeLeft = this._0x43a269c6;
        this.CurrentGameIndex = _0xaa3720e7.Instance._0x49720ba9;
        foreach (Button _0x76495c0b in this.HomeButtons)
            _0x76495c0b.onClick.AddListener(() =>
            {
                this._0x58f011c1();
            });
        foreach (Button _0x08b4271e in this.PauseButtons)
            _0x08b4271e.onClick.AddListener(() =>
            {
                _0xaa3720e7.Instance._0xfcdfb188(false);
                _0x9285dd47.Instance._0x77e745d1(_0x44bff367._0xc409a710.PAUSE);
            });
        this._0xec2c6558();
        this.LevelNumberText.ForEach(_0xd2d23949 => _0xd2d23949.text = $"LVL {_0xaa3720e7._0xa5b3545e._0xb4252322 + 1}");
        if (_0x484b54e4.Instance.IsTimerEnabled)
        {
            this._0x9f6d6c7f();
            this.StartCoroutine(this._0xc20e3513());
        }
    }

    public List<TMP_Text> TimerText = new();
    public int CustomTargetScore = 10;
    private void Awake()
    {
        _0x170776e1 = this.gameObject.GetComponent<_0x56185aa7>();
    }

    public List<Button> HomeButtons = new();
    public int CustomTimeInitial = 30;
    public void _0xde3c61e8(int scoreToAdd)
    {
        if (!this.IsGameEnd)
        {
            this.ScoreCurrent += scoreToAdd;
            this._0xec2c6558();
            this._0x125eae1b();
        }
    }

    [HideInInspector]
    public int TimeLeft;
    private void _0x7280cd71()
    {
        this.IsGameEnd = true;
        _0xaa3720e7.IsAfterLevelComplete = true;
    }

    private int _0x7b608e81 => this.ScoreCurrent;

    [HideInInspector]
    public int ScoreCurrent;
    private int _0xb27d0bac => this.CustomTargetScore + _0xaa3720e7._0xa5b3545e._0xb4252322 * 10;
}

internal static class _0x7d47476c
{
    internal static string _0xe1297e51(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}