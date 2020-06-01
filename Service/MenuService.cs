using BlzApp.Data;
using BlzApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzApp.Service
{
    public class MenuService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public MenuService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<MenuInfo>> GetMenuData()
        {
            IEnumerable<MenuInfo> menuinfos;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"select * from MenuInfo";
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                try
                {
                    menuinfos = await conn.QueryAsync<MenuInfo>(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
                
            }
            return menuinfos;
        }
    }
}
