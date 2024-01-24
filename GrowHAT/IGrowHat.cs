// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Iot.Device.GrowHat
{
    public interface IGrowHat
    {
        public List<GrowHatSoilSensor> GetSoilSensors();
        public GrowHatSoilSensor GetSoilSensor(SoilSensorPin Sensor);

    }
}