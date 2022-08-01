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

        public async Task<bool> CreateOrUpdateMiembro(
            int? id, string email, int usuarioCreacion, int idUsuarioModificacion,
            DateTime fechaBautismo, DateTime fechaConversion, DateTime fechaNacimiento,
            DateTime fechaPrimeraVezCongregado, string telefono1, string telefono2,
            string nombre, string apellido, string profesion, string direccion, string genero,
            string estadoCivil
            )
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@email", email);
                parameters.Add("@usuario_creacion", usuarioCreacion);
                parameters.Add("@id_usuario_modificacion", idUsuarioModificacion);
                parameters.Add("@fecha_baustismo", fechaBautismo);
                parameters.Add("@fecha_conversion", fechaConversion);
                parameters.Add("@telefono_1", telefono1);
                parameters.Add("@telefono_2", telefono2);
                parameters.Add("@genero", genero);
                parameters.Add("@estado_civil", estadoCivil);
                parameters.Add("@direcion", direccion);
                parameters.Add("@profesion", profesion);
                parameters.Add("@fecha_primera_vez_congresacion", fechaPrimeraVezCongregado);
                parameters.Add("@fecha_nacimiento", fechaNacimiento);
                parameters.Add("@nombre", nombre);
                parameters.Add("@apellido", email);

                try
                {
                    var miembros = await connection.ExecuteAsync(
                    "dbo.MergeMiembro ",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }

            }
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
                    commandType: CommandType.StoredProcedure);

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
