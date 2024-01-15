// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.GrowHat
{
    /// <summary>
    /// Pinout for the lv devices
    /// </summary>
    public enum LvDevicePin
    {
        /// <summary>
        /// LV device 1
        /// </summary>
        P1 = 17,

        /// <summary>
        /// LV device 2
        /// </summary>
        P2 = 27,

        /// <summary>
        /// LV device 3
        /// </summary>
        P3 = 22
    }

    /// <summary>
    /// Interface for any LV device such as a pump(See GrowHatPump), LED(Not implemented), etc.
    /// </summary>
    public interface IGrowHatDevice
    {
        void Dispose();
    }
}
