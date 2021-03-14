using System.Collections.Generic;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IRuleSet
    {
        Dictionary<string, bool> AllowedOutboundDestinationPorts { get; }
        Dictionary<string, bool> AllowedInboundDestinationPorts { get; }
    }

    public class RuleSet : IRuleSet
    {
        public Dictionary<string, bool> AllowedOutboundDestinationPorts { get; set; } = new Dictionary<string, bool>();
        public Dictionary<string, bool> AllowedInboundDestinationPorts { get; set; } = new Dictionary<string, bool>();
    }
}
