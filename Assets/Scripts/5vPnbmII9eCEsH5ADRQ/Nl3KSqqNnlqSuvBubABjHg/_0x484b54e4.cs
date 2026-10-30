using UnityEngine;

public class _0x484b54e4 : MonoBehaviour
{
    private void _0x03920a2a()
    {
    }

    public bool IsLevelSelectorEnabled;
    public bool IsStoryEnabled;
    public bool IsSkipSplashEnabled;
    public bool IsBestScoreEnabled;
    public bool IsOnlyWinGameEndEnabled;
    public bool IsCheckScoreEnabled;
    public bool IsLevelIncrementOnWin;
    public bool IsTimerEnabled;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject.GetComponent<_0x484b54e4>();
            DontDestroyOnLoad(this.gameObject);
            this._0x28a89ee6();
        }
        else
        {
            this._0x03920a2a();
            Destroy(this.gameObject);
        }
    }

    private void _0x28a89ee6()
    {
        {
#if !B_LOGS
        {
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        }
#endif
        }

        QualitySettings.vSyncCount = 1;
        Application.runInBackground = true;
    //Application.targetFrameRate = 60;
    // Time.fixedDeltaTime = 0.03f; // USE CUSTOM PHYSICS TIME FOR OPTIMIZATION IF NEEDED
    // Add this once at startup to silence the specific assertion
    }

    public static _0x484b54e4 Instance;
    public bool IsTutorialEnabled;
}