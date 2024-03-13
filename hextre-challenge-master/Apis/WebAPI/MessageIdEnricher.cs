
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Application.Utils
{
	public class MessageIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var messageId = logEvent.Level switch
            {
                LogEventLevel.Debug => 000,
                LogEventLevel.Error => 001,
                LogEventLevel.Warning => 002,
                LogEventLevel.Information => 003,
                _ => 0,
            };

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MessageId", messageId));
        }
    }
}

