﻿namespace Learning.DesignPatterns.BridgePattern
{
    public class StandardFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return $"{key}: {value}";
        }
    }
}
