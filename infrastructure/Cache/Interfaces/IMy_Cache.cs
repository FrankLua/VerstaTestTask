

namespace Infrastructure.Cache.Interfaces
{
    public interface IMy_Cache
    {
        object GetObject(string key);

        void SetObject(string key, object value,int timeMinute);

        void DeleteObject(string key);
        
    }
}
