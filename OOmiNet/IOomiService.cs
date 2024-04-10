using OOmiNet.Models;

namespace OOmiNet;

public interface IOomiService
{
	Task<OomiResponse<T>> GetAsync<T>(OomiGetRequest request) where T : OomiRecord, new();
	Task<OomiResponse<T>> InsertAsync<T>(T request) where T : OomiInsertRecord, new();
	Task<OomiResponse<TResult>> InsertAsync<TRequest, TResult>(TRequest request)
		where TRequest : OomiInsertRecord, new()
		where TResult : OomiRecord, new();
}
