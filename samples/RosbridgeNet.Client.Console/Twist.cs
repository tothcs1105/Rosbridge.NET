namespace RosbridgeNet.Client.Console
{
    using RosbridgeNet.RosbridgeClient.Common.Attributes;

    [RosMessageType("geometry_msgs/Twist")]
    public class Twist
    {
        public Vector linear { get; set; }
        public Vector angular { get; set; }
    }

    public class Vector
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
}
