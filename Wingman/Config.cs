﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wingman
{
    class Config
    {
        public enum ValidationType
        {
            Regex,
            Substring
        }

        public class Param
        {
            [JsonProperty(PropertyName = "key")]
            public string Key { get; set; }

            [JsonProperty(PropertyName = "value")]
            public string Value { get; set; }

            [JsonProperty(PropertyName = "use_plugin")]
            public bool UsePlugin { get; set; }

            [JsonProperty(PropertyName = "plugin_key")]
            public string PluginKey { get; set; }
        }

        public class Header
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "value")]
            public string Value { get; set; }

            [JsonProperty(PropertyName = "use_plugin")]
            public bool UsePlugin { get; set; }

            [JsonProperty(PropertyName = "plugin_key")]
            public string PluginKey { get; set; }
        }

        public class ResponseValidate
        {
            private ValidationType _type;

            [JsonProperty(PropertyName = "type")]
            public ValidationType Type
            {
                get => _type;
                set
                {
                    Enum.TryParse(value.ToString(), out ValidationType type);
                    _type = type;
                }
            }

            [JsonProperty(PropertyName = "value")]
            public string Value { get; set; }
        }

        public class RootObject
        {
            [JsonProperty(PropertyName = "host")]
            public string Host { get; set; }

            [JsonProperty(PropertyName = "endpoint")]
            public string Endpoint { get; set; }

            [JsonProperty(PropertyName = "params")]
            public List<Param> Params { get; set; }

            [JsonProperty(PropertyName = "method")]
            public string Method { get; set; }

            [JsonProperty(PropertyName = "headers")]
            public List<Header> Headers { get; set; }

            [JsonProperty(PropertyName = "timeout")]
            public int Timeout { get; set; }

            [JsonProperty(PropertyName = "plugin_name")]
            public string PluginName { get; set; }

            [JsonProperty(PropertyName = "response_validate")]
            public List<ResponseValidate> Validate { get; set; }
        }
    }
}
