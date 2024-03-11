using Domain.Enums;

namespace Application.Interfaces
{
    public interface ILoggingService
    {
        void Log(LogLevel level, string messageID, string message);
    }
}