namespace PhoenixService.Domain
{
    public enum VoiceServiceTaskStage
    {
        NewTask = 0,
        TaskInProgress = 1,
        WaitForStatus = 2,
        StatusInProgress = 3,
        WaitForResult = 4,
        ResultInProgress = 5,
        WaitForFile = 6,
        FileInProgress = 7,
        NeedSmsNotify = 8,
        SmsInProgress = 9,
        Done = 10,
    }
}