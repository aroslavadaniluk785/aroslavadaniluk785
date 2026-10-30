using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class _0x44bff367
{
    public static class _0x0ad17af2
    {
        public static int _0x0d1b70b1
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0x4fbd8335._0x546b0480(new byte[5] { 131, 175, 169, 174, 179 }, 192)))
                    PlayerPrefs.SetInt(_0x4fbd8335._0x546b0480(new byte[5] { 163, 143, 137, 142, 147 }, 224), 0);
                return PlayerPrefs.GetInt(_0x4fbd8335._0x546b0480(new byte[5] { 230, 202, 204, 203, 214 }, 165));
            }

            set
            {
                PlayerPrefs.SetInt(_0x4fbd8335._0x546b0480(new byte[5] { 26, 54, 48, 55, 42 }, 89), value);
                _0xaa3720e7.Instance._0x91e7f294();
            }
        }
    }

    public static class _0xc409a710
    {
        public static readonly int PAUSE = 6;
        public static readonly int WIN = 7;
        public static readonly int LOSE = 8;
    }

    public class _0xb7115535
    {
        private static readonly _0xb7115535 _0x42e51036 = new();
        public static readonly _0xb7115535[] ALL_SCENES_SETTING_SINGLETONS =
        {
            _0x42e51036,
            _0x42e51036,
            _0x42e51036,
        };
        private int _0xa8cef069 => 0;
        private int _0x268c17ff => 10;
        private string _0x29182d50 => _0x4fbd8335._0x546b0480(new byte[4] { 239, 199, 204, 215 }, 162);
        private string _0xfad893b8 => _0x4fbd8335._0x546b0480(new byte[8] { 133, 140, 159, 140, 133, 178, 249, 180 }, 201);

        private int _0xd91df387
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0x4fbd8335._0x546b0480(new byte[25] { 102, 80, 87, 87, 64, 75, 81, 98, 73, 74, 71, 68, 73, 102, 77, 68, 85, 81, 64, 87, 108, 75, 65, 64, 93 }, 37)))
                    PlayerPrefs.SetInt(_0x4fbd8335._0x546b0480(new byte[25] { 39, 17, 22, 22, 1, 10, 16, 35, 8, 11, 6, 5, 8, 39, 12, 5, 20, 16, 1, 22, 45, 10, 0, 1, 28 }, 100), 0);
                return PlayerPrefs.GetInt(_0x4fbd8335._0x546b0480(new byte[25] { 132, 178, 181, 181, 162, 169, 179, 128, 171, 168, 165, 166, 171, 132, 175, 166, 183, 179, 162, 181, 142, 169, 163, 162, 191 }, 199));
            }

            set => PlayerPrefs.SetInt(_0x4fbd8335._0x546b0480(new byte[25] { 246, 192, 199, 199, 208, 219, 193, 242, 217, 218, 215, 212, 217, 246, 221, 212, 197, 193, 208, 199, 252, 219, 209, 208, 205 }, 181), value);
        }

        public int _0xb4252322
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0x29182d50}CurrentLevelIndex"))
                    PlayerPrefs.SetInt($"{this._0x29182d50}CurrentLevelIndex", 0);
                return PlayerPrefs.GetInt($"{this._0x29182d50}CurrentLevelIndex");
            }

            set => PlayerPrefs.SetInt($"{this._0x29182d50}CurrentLevelIndex", value);
        }

        public int _0x8c288e96
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0x29182d50}BestScore"))
                    this._0x8c288e96 = 0;
                return PlayerPrefs.GetInt($"{this._0x29182d50}BestScore");
            }

            set => PlayerPrefs.SetInt($"{this._0x29182d50}BestScore", value);
        }

        public bool _0xc67db8a9
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0x29182d50}IsGameTutorPassed"))
                    PlayerPrefs.SetInt($"{this._0x29182d50}IsGameTutorPassed", Convert.ToInt32(false));
                return PlayerPrefs.GetInt($"{this._0x29182d50}IsGameTutorPassed") == 1;
            }

            set => PlayerPrefs.SetInt($"{this._0x29182d50}IsGameTutorPassed", Convert.ToInt32(value));
        }
    }

    public static class _0x9543a72f
    {
        public static readonly int SPLASH = 0;
        public static readonly int DEFAULT = 1;
        public static readonly int EMPTY = 2;
        public static readonly int TUTORIAL0 = 13;
        public static readonly int TUTORIAL1 = 14;
        public static readonly int TUTORIAL2 = 15;
        public static readonly int TUTORIAL3 = 16;
        public static readonly int TUTORIAL4 = 17;
        public static readonly int TUTORIAL5 = 18;
        public static readonly int TUTORIAL6 = 19;
    }

    public static class _0x7725f086
    {
        public static readonly int SCENE_0 = 0;
        public static readonly int SCENE_1 = 1;
    }
}

internal static class _0x4fbd8335
{
    internal static string _0x546b0480(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}