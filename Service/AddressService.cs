using Dapper;
using Microsoft.Data.SqlClient;
using BlzApp.Data;
using BlzApp.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlzApp.Interfaces;

namespace BlzApp.Service
{
    public class AddressService : IAddressService
    {
        //Database Connection
        private readonly SqlConnectionConfiguration _configuration;
        public AddressService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Insert
        public async Task<bool> InsertCommand(Address addres)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("AddressCode", addres.AddressCode, DbType.String);
                parameters.Add("AddressName", addres.AddressName, DbType.String);

                //SQL Command
                const string query = @"INSERT INTO tblAddress (AddressCode, AddressName) VALUES (@AddressCode, @AddressName)";
                await conn.ExecuteAsync(query, new { addres.AddressCode, addres.AddressName }, commandType: CommandType.Text);
            }
            return true;
        }

        public async Task<IEnumerable<Address>> SelectCommand()
        {
            IEnumerable<Address> _address_list;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                _address_list = await conn.QueryAsync<Address>("select * from tblAddress", commandType: CommandType.Text);
            }
            return _address_list;
        }

        public async Task<Address> SelectCommandById(int id)
        {
            Address _address = new Address();
            var parameters = new DynamicParameters();
            parameters.Add("AddressId", id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                _address = await conn.QueryFirstOrDefaultAsync<Address>("select * from tblAddress where AddressId=@AddressId", parameters, commandType: CommandType.Text);
            }
            return _address;
        }

        public async Task<bool> UpdateCommand(Address address)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("AddressId", address.AddressId, DbType.Int32);
                parameters.Add("AddressCode", address.AddressCode, DbType.String);
                parameters.Add("AddressName", address.AddressName, DbType.String);

               //SQL Command
                const string query = @"UPDATE tblAddress SET AddressCode=@AddressCode,AddressName=@AddressName where AddressId=@AddressId";
                await conn.ExecuteAsync(query, new { address.AddressId, address.AddressCode, address.AddressName }, commandType: CommandType.Text);
            }
            return true;
        }

        public async Task<bool> DeleteCommand(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("AddressId", id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("delete from tblAddress where AddressId=@AddressId", parameters, commandType: CommandType.Text);
            }
            return true;
        }

    }
}
