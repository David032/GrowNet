// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Device.Gpio;
using System.Device.Pwm;
using System.Device.Pwm.Drivers;

namespace Iot.Device.GrowHat
{
    /// <summary>
    /// An lv pump
    /// </summary>
    public class GrowHatPump : IGrowHatDevice, IDisposable
    {
        private static readonly int s_pwmFreq = 10000;
        private static readonly int s_maxDuty = 90;

        private int _pin;
        private PwmChannel _pwmChannel;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrowHatPump"/> class.
        /// </summary>
        /// <param name="pin">Which slot is it plugged into</param>
        /// <param name="controller">GPIO controller</param>
        public GrowHatPump(LvDevicePin pin, GpioController controller)
        {
            _pin = (int)pin;
            controller.OpenPin(_pin, PinMode.Output);
            _pwmChannel = new SoftwarePwmChannel(_pin);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
