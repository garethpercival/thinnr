namespace thinnr.Components
{
    public interface IUrlRepository
    {
        ShortenedUrl Load(int id);
        ShortenedUrl Save(string url);
    }
}