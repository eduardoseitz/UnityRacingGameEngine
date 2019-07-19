using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.Math
{
    /* Collections of function used to convert common type of values */
    // Should be instantiated when needed
    public class DataConverter
    {
        const float _meterBySecondsFactor = 0.2778f;

        // Convert and return Km/h to M/s
        public float KilometersByHoursToMetersBySecond(float kilometers)
        {
            return kilometers * _meterBySecondsFactor;
        }

        // Convert and return M/s to Km/h
        public float MetersBySecondToKilometersByHours(float kilometers)
        {
            return kilometers / _meterBySecondsFactor;
        }

        /*
            Force N (Newton) = m.kg/s2
            Power W (Watt) = N.m/s = J/s = m2
            kg / s3
            Torque N.m (Newton meter)
            Speed m/s
            Angular velocity rad/s
            Acceleration m/s2
            Mass kg
            Distance m
            Angle rad =360 degrees/ 2 pi
            Here are some handy unit conversions to S.I. units.
            1 mile = 1.6093 km
            1 ft (foot) = 0.3048 m
            1 in (inch) = 0.0254 m = 2.54 cm
            1 km/h = 0.2778 m/s
            1 mph = 1.609 km/h = .447 m/s
            1 rpm (revolution per minute) = 0.105 rad/s
            1 G = 9.8 m/s2 = 32.1 lb/s2
            1 lb (pound) = 4.45 N
            1 lb (pound) = 0.4536 kg 1) = 1 lb/1G
            1 lb.ft (foot pounds) = 1.356 N.m
            1 lb.ft/s (foot pound per second) = 1.356 W
            1 hp (horsepower) = 550 ft.lb/s = 745.7 W
            1 metric hp = 0.986 hp = 735.5 W
        */
    }
}
