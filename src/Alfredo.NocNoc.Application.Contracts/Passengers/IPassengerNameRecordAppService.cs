using System.Threading.Tasks;

namespace Alfredo.NocNoc.Passengers
{
	public interface IPassengerNameRecordAppService
	{
		Task<PassengerNameRecordDto?> CreateAsync(CreatePassengerNameRecordDto request);
	}
}
