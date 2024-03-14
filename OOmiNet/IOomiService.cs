using OOmiNet.Models;

namespace OOmiNet;

public interface IOomiService
{
	Task<OomiResponse<T>> GetApiResponse<T>(OomiGetRequest request) where T : OomiRecord;
}
