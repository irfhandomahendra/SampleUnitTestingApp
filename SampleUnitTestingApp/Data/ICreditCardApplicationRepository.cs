using SampleUnitTestingApp.Models;
using System.Threading.Tasks;

namespace SampleUnitTestingApp.Data
{
    public interface ICreditCardApplicationRepository
    {
        public Task AddAsync(CreditCardApplication application);
    }
}
