namespace SV.Application.Interfaces.Common
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string Nome { get; }
    }
}
