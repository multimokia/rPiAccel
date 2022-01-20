using System;

namespace rPiAccel.Drivers
{
    public class MpuSensorEventArgs : EventArgs
    {
        public byte Status { get; set; }
        public float SamplePeriod { get; set; }
        public MpuSensorValue [] Values { get; set; }
    }
}