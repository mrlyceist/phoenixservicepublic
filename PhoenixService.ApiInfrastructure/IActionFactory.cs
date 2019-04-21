namespace PhoenixService.ApiInfrastructure
{
    public interface IActionFactory
    {
        TAction GetAction<TAction>();
    }
}