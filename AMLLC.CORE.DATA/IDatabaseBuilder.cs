namespace AMLLC.CORE.DATA
{
    public interface IDatabaseBuilder
    {
        void BuildConnection();
        void BuildCommand(string sStoredProcedure);
        void SetSettings();
        void AddParameters(params object[] arrobjParameters);
        void GetDataReader();
        //solo de lectura por lo tanto solo se implementa el get
        Database Database { get; }
    }
}
