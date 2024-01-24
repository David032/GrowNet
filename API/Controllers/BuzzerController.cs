using Iot.Device.GrowHat;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Buzzer")]
    [ApiController]
    public class BuzzerController(ILogger<BuzzerController> logger, IGrowHat Board) : ControllerBase
    {
        ILogger<BuzzerController> logger = logger;
        IGrowHat Board = Board;

        [HttpPost("PlayBuzzerTone")]
        public void PlayBuzzerTone(double frequency, int seconds)
        {
            Board.GetBuzzer().PlayTone(frequency, seconds);
        }

        [HttpPost("TurnBuzzerOn")]
        public void TurnBuzzerOn(double frequency)
        {
            Board.GetBuzzer().StartPlaying(frequency);
        }

        [HttpPost("TurnBuzzerOff")]
        public void TurnBuzzerOff()
        {
            Board.GetBuzzer().StopPlaying();
        }
    }
}
