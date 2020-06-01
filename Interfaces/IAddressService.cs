using BlzApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlzApp.Interfaces
{
    public interface IAddressService
    {
        Task<bool> DeleteCommand(int id);
        Task<bool> InsertCommand(Address addres);
        Task<IEnumerable<Address>> SelectCommand();
        Task<Address> SelectCommandById(int id);
        Task<bool> UpdateCommand(Address address);
    }
}