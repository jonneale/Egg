namespace LiveNation.Testing.Domain.Framework
{
    public interface IProcess
    {
        System.Diagnostics.ProcessStartInfo StartInfo { get; set; }
        bool Start();
    }
}