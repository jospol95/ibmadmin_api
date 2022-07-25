using Dapper;
using ibm_admin.Contracts;
using ibm_admin.Dapper;
using ibm_admin.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ibm_admin.Business
{
    public class MiembrosService : IMiembrosService
    {
        private readonly DapperContext _dbContext;

        public MiembrosService(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<PaginationResultViewModel<List<MiembroViewModel>>> ObtenerMiembrosConPaginacion(int pag, int tamPag)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@pag", pag);
                parameters.Add("@TamPag", tamPag);
                parameters.Add("@tt", dbType: DbType.Int32, direction: ParameterDirection.Output);

                try
                {
                    var miembros = await connection.QueryAsync<MiembroViewModel>(
                    "dbo.ObtenerInfoMiembroPaginacion ",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

                    var PaginationResultViewModel = 
                        new PaginationResultViewModel<List<MiembroViewModel>>(){
                        ResultsCount = parameters.Get<int>("@tt"),
                        Results = miembros.ToList()
                    };
                    return PaginationResultViewModel;
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }

            }
        }
    }
}
