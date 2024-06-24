﻿
using XYZ.BOUTIQUE.Domain.Entity;
namespace XYZ.BOUTIQUE.Infrastructure.Interface
{
    public interface IPedidosRepository
    {
        #region Métodos Síncronos
        bool Insert(Pedidos pedido);
        bool Update(Pedidos pedido);
        bool Delete(int pedidoId);
        Pedidos Get(int pedidoId);
        IEnumerable<Pedidos> GetAll();
        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Pedidos pedido);
        Task<bool> UpdateAsync(Pedidos pedido);
        Task<bool> DeleteAsync(int pedidoId);
        Task<Pedidos> GetAsync(int pedidoId);
        Task<IEnumerable<Pedidos>> GetAllAsync();
        #endregion
    }
}
