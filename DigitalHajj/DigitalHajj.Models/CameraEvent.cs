using System;

namespace DigitalHajj.Models
{
    public class CameraEvent
    {
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string event_id { get; set; }
        public string object_id { get; set; }
        public string origin { get; set; }
        public string rule_id { get; set; }
        public string rule_name { get; set; }
        public string snapshot_path { get; set; }
        public string time { get; set; }
        public string timestamp { get; set; }
        public string type { get; set; }
        public string video_file_name { get; set; }
        public string video_file_time { get; set; }

    }
}
