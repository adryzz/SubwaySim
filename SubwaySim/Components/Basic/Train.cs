namespace SubwaySim.Components.Basic
{
    public class Train : Component
    {
        public virtual uint MaxSpeed => 5u;

        public virtual uint Acceleration => 2u;

        public double CurrentSpeed { get; set; } = 0;

        public string RouteDisplay { get; set; } = "Train Line";
        
        public virtual UniqueId LastStationId { get; set; }

        public TrainStation LastStation => Engine.Stations[LastStationId];

        public float DeltaDistance { get; set; } = 0;

        public TrainLine Line => Engine.Lines.Values.SingleOrDefault(x => x.Trains.Contains(Id))!;
    }
}