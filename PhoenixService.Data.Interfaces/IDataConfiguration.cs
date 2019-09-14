namespace PhoenixService.Data.Interfaces
{
    public interface IDataConfiguration
    {
        string PhoenixDbPath { get; }
        string DefaultDutyComment { get; }
    }
}