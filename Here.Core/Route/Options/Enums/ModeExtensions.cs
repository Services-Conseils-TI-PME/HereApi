using System;

namespace Here.Options.Route
{
    public static class ModeExtensions
    {
        public static string ToValueString(this Mode mode)
        {
            switch (mode)
            {
                case Mode.fastest:
                    return "fastest";

                case Mode.truck:
                    return "truck";

                case Mode.trafficDisabled:
                    return "traffic:disabled";

                case Mode.trafficEnabled:
                    return "traffic:disabled";

                default:
                    throw new NotImplementedException(nameof(mode));
            }
        }
    }
}
