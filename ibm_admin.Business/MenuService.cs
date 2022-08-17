
using Dapper;
using ibm_admin.Contracts;
using ibm_admin.Dapper;
using ibm_admin.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ibm_admin.Business
{
    public class MenuService : IMenuService
    {
        private readonly DapperContext _dbContext;

        public MenuService(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MenuViewModel>> ObtenerItemsConAccesoAsync(int IdUsuario)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new
                {
                    id_usuario = IdUsuario
                };
                try
                {
                    var modulos = await connection.QueryAsync<MenuViewModel>(
                    "dbo.ModulosUsuario",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
                    return modulos.ToList();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }

            //return new List<MenuViewModel>()
            //{
            //    new MenuViewModel()
            //    {
            //        ModuloId = 1,
            //        MenuFAIcono = "fa-user-gear",
            //        Titulo = "Usuarios"
            //    },
            //    new MenuViewModel()
            //    {
            //        ModuloId = 1,
            //        MenuFAIcono = "fa-users",
            //        Titulo = "Miembros"
            //    },
            //    new MenuViewModel()
            //    {
            //        ModuloId = 1,
            //        MenuFAIcono = "fa-user-lock",
            //        Titulo = "Modulos"
            //    }
            //};
        }


    }
}