using Iot.Device.GrowHat;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/SoilSensor")]
    [ApiController]
    public class SoilSensorController(ILogger<SoilSensorController> logger, IGrowHat Board) : ControllerBase
    {
        ILogger<SoilSensorController> logger = logger;
        IGrowHat Board = Board;

        [HttpGet("MoistureValue")]
        public double GetMoistureValue(SoilSensorPin soilSensor)
        {
            return Board.GetSoilSensor(soilSensor).MoistureValue;
        }

        [HttpGet("Active")]
        public bool IsActive(SoilSensorPin soilSensor)
        {
            return Board.GetSoilSensor(soilSensor).Active;
        }

        [HttpGet("NewData")]
        public bool IsNewDataAvailable(SoilSensorPin soilSensor)
        {
            return Board.GetSoilSensor(soilSensor).NewData;
        }

        [HttpGet("Saturation")]
        public double GetSaturation(SoilSensorPin soilSensor)
        {
            return Board.GetSoilSensor(soilSensor).Saturation;
        }

        [HttpGet("History")]
        public List<double> GetHistory(SoilSensorPin soilSensor)
        {
            return Board.GetSoilSensor(soilSensor).History;
        }

        [HttpPost("WetPoint")]
        public void SetWetPoint(SoilSensorPin sensorPin, double value)
        {
            Board.GetSoilSensor(sensorPin).SetWetPoint(value);
        }

        [HttpPost("DryPoint")]
        public void SetDryPoint(SoilSensorPin sensorPin, double value)
        {
            Board.GetSoilSensor(sensorPin).SetDryPoint(value);
        }

        [HttpGet("WetPoint")]
        public void GetWetPoint(SoilSensorPin sensorPin)
        {
            Board.GetSoilSensor(sensorPin).GetWetPoint();
        }

        [HttpGet("DryPoint")]
        public void GetDryPoint(SoilSensorPin sensorPin)
        {
            Board.GetSoilSensor(sensorPin).GetDryPoint();
        }
    }
}
