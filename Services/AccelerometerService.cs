using System;
using System.Threading;
using System.Threading.Tasks;
using rPiAccel.Drivers;

namespace rPiAccel.Services
{
    public class AccelerometerService
    {
        private CancellationTokenSource _cts;
        private int _scanRate;
        private readonly Mpu6050 _mpu6050;
        private bool _running;
        public EventHandler<MpuSensorEventArgs> MeasurementTaken;

        public AccelerometerService(int scanRate, int busId, int address)
        {
            _scanRate = scanRate;
            _mpu6050 = new Mpu6050();
            _cts = new CancellationTokenSource();
        }

        public void Start()
        {
            if (_running) return;

            _mpu6050.InitHardware();
            _mpu6050.SensorInterruptEvent += _mpu6050_SensorInterruptEvent;

            Task.Run(Listen);
            _running = true;
        }

        private MpuSensorEventArgs _lastEvent;

        private void _mpu6050_SensorInterruptEvent(object sender, MpuSensorEventArgs e)
        {
            _lastEvent = e;
        }

        public async Task Listen()
        {
            while (!_cts.IsCancellationRequested)
            {
                if (_lastEvent != null)
                {
                    MeasurementTaken?.Invoke(this, _lastEvent);
                }
                _lastEvent = null;
                await Task.Delay(_scanRate);
            }
        }

        public void Stop()
        {
            _cts.Cancel();
            _running = false;
        }

    }
}