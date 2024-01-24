using Iot.Device.GrowHat;
using System.Device.Gpio;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var gpioController = new GpioController();

            // Add services to the container.
            builder.Services.AddSingleton<IGrowHat>(x => new GrowHAT(s1: new GrowHatSoilSensor(SoilSensorPin.S1, gpioController),
                        d2: new GrowHatPump(LvDevicePin.P2, gpioController), onboardDevices: true));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.WebHost.UseUrls("http://*:5000;https://*:5001");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
