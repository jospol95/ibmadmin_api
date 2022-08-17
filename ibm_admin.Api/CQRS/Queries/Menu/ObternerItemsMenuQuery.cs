using ibm_admin.Contracts;
using ibm_admin.Shared.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IBM_Yoda_Admin.CQRS.Queries.Menu
{
    public class ObternerItemsMenuQuery : IRequest<List<MenuViewModel>>
    {
        public int IdUsuario { get; set; }

        public ObternerItemsMenuQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }

    public class ObternerItemsQueryHandler : IRequestHandler<ObternerItemsMenuQuery, List<MenuViewModel>>
    {
        private readonly IMenuService _menuService;

        public ObternerItemsQueryHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }
        async Task<List<MenuViewModel>> IRequestHandler<ObternerItemsMenuQuery, List<MenuViewModel>>.Handle(ObternerItemsMenuQuery request, CancellationToken cancellationToken)
        {
            var menu = await _menuService.ObtenerItemsConAccesoAsync(request.IdUsuario);
            return menu;
        }
    }
}
