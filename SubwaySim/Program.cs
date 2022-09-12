namespace SubwaySim;

static class Program
{
    public static SubwayEngine Engine;
    
    public static async Task Main(string[] args)
    {
        Engine = new SubwayEngine();
        Engine.Tick();
        Engine.Render();
        Engine.Export("subway");
    }
}