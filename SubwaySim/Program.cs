namespace SubwaySim;

static class Program
{
    public static SubwayEngine Engine;
    
    public static async Task Main(string[] args)
    {
        Engine = new SubwayEngine();
        Engine.Import("subway");
        Engine.Render();

        while (true)
        {
            Engine.Tick();
            Engine.Sleep();
        }
    }
}