namespace App2;

public static class Messages
{
    public static class CarEvents
    {
        public record CarEngineStarted
        {
            public DateTimeOffset At { get; init; }
        }

        public record CarStartedDriving
        {
            public DateTimeOffset At { get; init; }
        }

        public record CarDroveOverSpeedLimit
        {
            public DateTimeOffset At { get; init; }
            public int SpeedLimit { get; init; }
        }

        public record CarCrashed
        {
            public DateTimeOffset At { get; init; }
        }
    }

    public record App1Started
    {
        public DateTimeOffset At { get; init; } 
    }
}