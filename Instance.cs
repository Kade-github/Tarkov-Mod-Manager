using System.Collections.Generic;
using MessagePack;

namespace TarkovModManager
{
    [MessagePackObject]
    public class Instance
    {
        [Key("InstanceName")]
        public string Name { get; set; }

        [Key("ModList")]
        public List<string> Mods { get; set; }
        
        [Key("ServerAddress")]
        public string ServerAddress { get; set; }

        public void Save()
        {
            byte[] data = MessagePackSerializer.Serialize(this);
            System.IO.File.WriteAllBytes(Settings.Instance.InstancePath + "/" + Name + "/instance.msgpack", data);
        }
    }
}