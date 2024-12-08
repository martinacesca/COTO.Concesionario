namespace COTO.Concesionario.Interfaces.Utils.Logger
{
    public interface ILoggerService
    {
        public void Info(string message);
        public void Warn(string message);
        public void Error(string message);
        public void Error(Exception ex, string message);
    }
}
