using ibm_admin.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibm_admin.Contracts
{
    public interface IMenuService
    {
        Task<List<MenuViewModel>> ObtenerItemsConAccesoAsync(int IdUsuario);
    }
}
