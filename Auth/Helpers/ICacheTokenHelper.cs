namespace ToDoListCodeFirst.Auth.Helpers
{
    public interface ICacheTokenHelper
    {
        public TimeSpan CacheTimeCalc(DateTime validTo);
    }
}
