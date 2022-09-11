namespace SubwaySim.Components.Basic
{
    public class Train : Component
    {
        public virtual uint MaxSpeed => 5u;

        public virtual uint Acceleration => 2u;

        public double CurrentSpeed { get; set; } = 0;
        
        public virtual TrainStation LastStation { get; set; }
        
        public float DeltaDistance { get; set; }
    }
}