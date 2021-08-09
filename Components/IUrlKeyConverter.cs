namespace thinnr.Components
{
    public interface IUrlKeyConverter
    {
        public int GetIdFromKey(string key);
        public string GetKeyFromId(int id);
    }
}