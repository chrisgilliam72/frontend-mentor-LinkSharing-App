namespace LinkSharing_App.Services
{
    public interface IlocalStorageService
    {
        public Task Write(string key, string value);
        public Task<string> Read(string key);
    }
}
