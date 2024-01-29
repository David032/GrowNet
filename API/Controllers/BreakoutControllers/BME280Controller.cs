using Iot.Device.Bmxx80;
using Iot.Device.GrowHat;
using Microsoft.AspNetCore.Mvc;
using System.Device.I2c;

namespace API.Controllers.BreakoutControllers
{
    [Route("api/Environment")]
    [ApiController]
    public class BME280Controller : ControllerBase
    {
        ILogger<BuzzerController> logger;
        IGrowHat Board;
        Bmp280 sensor;
        public BME280Controller(ILogger<BuzzerController> logger, IGrowHat Board)
        {
            this.logger = logger;
            this.Board = Board;

            try
            {
                const int busId = 1;
                I2cConnectionSettings i2cSettings = new(busId, Bme280.DefaultI2cAddress);
                Console.WriteLine("24: " + i2cSettings.DeviceAddress.ToString());
                I2cDevice i2cDevice = I2cDevice.Create(i2cSettings);
                Console.WriteLine("26: " + i2cDevice.QueryComponentInformation().Name);
                this.sensor = new Bmp280(i2cDevice);
                sensor.PressureSampling = Sampling.Standard;
                sensor.TemperatureSampling = Sampling.Standard;
                Console.WriteLine("30: " + sensor.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("I2C device errored!");
                Console.WriteLine(e.Message);
            }

        }

        [HttpGet("GetTemperature")]
        public double GetTemperature()
        {
            if (sensor != null)
            {
                sensor.TryReadTemperature(out var temperature);
                return temperature.DegreesCelsius;
            }
            else
            {
                Console.WriteLine("No sensor!");
                return double.NaN;
            }

        }
        [HttpGet("GetPressure")]
        public double GetPressure()
        {
            if (sensor != null)
            {
                sensor.TryReadPressure(out var pressure);
                return pressure.Atmospheres;
            }
            else
            {
                Console.WriteLine("No sensor!");
                return double.NaN;
            }
        }
        [HttpGet("GetAltitude")]
        public double GetAltitude()
        {
            if (sensor != null)
            {
                sensor.TryReadAltitude(out var altitude);
                return altitude.Meters;
            }
            else
            {
                Console.WriteLine("No sensor!");
                return double.NaN;
            }
        }
    }
}
