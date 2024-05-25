namespace DigitalSchoolApi.Core.Repositories
{
    public interface IDigitalSchoolApiRepository
    {
        Task<string> GetTestNameAsync();
    }
}
