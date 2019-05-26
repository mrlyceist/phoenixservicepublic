namespace PhoenixService.Application.Interfaces
{
    public interface IBuilder<in TDomain, out TDto>
    {
        TDto Build(TDomain entity);
    }
}