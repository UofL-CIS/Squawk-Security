using System.Collections.Generic;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IRuleSet
    {
        Dictionary<string, bool> DestinationPortBlacklist { get; }
        Dictionary<string, bool> InboundPortBlacklist { get; }
    }

    public class RuleSet : IRuleSet
    {
        public Dictionary<string, bool> DestinationPortBlacklist { get; set; } = new Dictionary<string, bool>();
        public Dictionary<string, bool> InboundPortBlacklist { get; set; } = new Dictionary<string, bool>();
    }
}
