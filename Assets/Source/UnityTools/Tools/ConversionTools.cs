namespace Assets.Source.Tools
{
    public static class ConversionTools
    {
        public const float MetresPerUnit = 1;
        public const float MetresPerMile = 1609.34f;

        public static float UnitsToMetres(float units)
        {
            return units*MetresPerUnit;
        }

        public static float UnitsToMiles(float units)
        {
            return units*MetresPerUnit/MetresPerMile;
        }

        public static float PerSecondToPerMinute(float value)
        {
            return value*60f;
        }

        public static float PerSecondToPerHour(float value)
        {
            return value*60f*60f;
        }

        public static float UnitsPerSecondToMph(float value)
        {
            return PerSecondToPerHour(UnitsToMiles(value));
        }

        public static float MphToUnitsPerSecond(float value)
        {
            return value/60f/60f*MetresPerMile/MetresPerUnit;
        }
    }
}