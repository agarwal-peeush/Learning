using System.Linq;

namespace Learning.DesignPatterns.BridgePattern
{
    public class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return $"{key}: {new string(value.Reverse().ToArray())}";
        }
    }
}
