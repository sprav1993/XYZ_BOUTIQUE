using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZ.BOUTIQUE.Application.Dto;
using XYZ.BOUTIQUE.Transversal.Common;

 namespace XYZ.BOUTIQUE.Application.Interface
{
    public interface IPedidosApplication
    {

        #region Métodos Síncronos
        Response<bool> Insert(PedidosDto pedidoDto);
        Response<bool> Update(PedidosDto pedidoDto);
        Response<bool> Delete(int pedidoId);
        Response<PedidosDto> Get(int pedidoId);
        Response<IEnumerable<PedidosDto>> GetAll();
        #endregion


        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(PedidosDto pedidoDto);
        Task<Response<bool>> UpdateAsync(PedidosDto pedidoDto);
        Task<Response<bool>> DeleteAsync(int pedidoId);
        Task<Response<PedidosDto>> GetAsync(int pedidoId);
        Task<Response<IEnumerable<PedidosDto>>> GetAllAsync();
        #endregion
    }
}
