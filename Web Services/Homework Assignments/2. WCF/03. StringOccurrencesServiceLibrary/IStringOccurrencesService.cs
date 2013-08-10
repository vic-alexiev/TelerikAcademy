using System.ServiceModel;

namespace StringOccurrencesServiceLibrary
{
    [ServiceContract]
    public interface IStringOccurrencesService
    {
        [OperationContract]
        int GetOccurrences(string source, string target);
    }
}
