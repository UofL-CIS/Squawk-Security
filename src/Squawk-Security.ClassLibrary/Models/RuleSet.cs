using System;
using System.Collections.Generic;
using System.Text;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IRuleSet
    {
        Dictionary<string, bool> DestinationPortBlacklist { get; }
    }

    public class RuleSet : IRuleSet
    {
        public Dictionary<string, bool> DestinationPortBlacklist { get; set; }
    }
}
