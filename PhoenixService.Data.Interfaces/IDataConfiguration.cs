namespace PhoenixService.Data.Interfaces
{
    public interface IDataConfiguration
    {
        string PhoenixExecutablePath { get; }
        string DefaultDutyComment { get; }
    }
}