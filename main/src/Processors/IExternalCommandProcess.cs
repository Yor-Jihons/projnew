namespace ProjNew.Processors
{
    public interface IExternalCommandProcess
    {
        void Build();
        bool Start();

        string FileName{ get; set; }
        string Argument{ get; set; }
    }
}
