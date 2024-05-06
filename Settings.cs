using System;
using System.Collections.Generic;
using MessagePack;

namespace TarkovModManager
{
    [MessagePackObject]
    public class Settings
    {
        public static Settings Instance = null;
        [Key("InstancePath")]
        public string InstancePath { get; set; }
        [Key("SPTPath")]
        public string SPTPath { get; set; }
        [Key("ModPath")]
        public string ModPath { get; set; }
        
        [Key("Instances")]
        public List<string> Instances { get; set; }
    }
}