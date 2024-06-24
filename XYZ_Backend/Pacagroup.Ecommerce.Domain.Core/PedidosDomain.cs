using XYZ.BOUTIQUE.Domain.Entity;
using XYZ.BOUTIQUE.Domain.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using XYZ.BOUTIQUE.Infrastructure.Interface;

namespace XYZ.BOUTIQUE.Domain.Core
{
    public class PedidosDomain : IPedidosDomain
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosDomain(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        #region Métodos Síncronos

        public bool Insert(Pedidos pedidos)
        {
            return _pedidosRepository.Insert(pedidos);
        }
        public bool Update(Pedidos pedidos)
        {
            return _pedidosRepository.Update(pedidos);
        }
        public bool Delete(int pedidoId)
        {
            return _pedidosRepository.Delete(pedidoId);
        }
        public Pedidos Get(int pedidoId)
        {
            return _pedidosRepository.Get(pedidoId);
        }
        public IEnumerable<Pedidos> GetAll()
        {
            return _pedidosRepository.GetAll();
        }
        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Pedidos pedidos)
        {
            return await _pedidosRepository.InsertAsync(pedidos);
        }
        public async Task<bool> UpdateAsync(Pedidos pedidos)
        {
            return await _pedidosRepository.UpdateAsync(pedidos);
        }
        public async Task<bool> DeleteAsync(int pedidoId)
        {
            return await _pedidosRepository.DeleteAsync(pedidoId);
        }
        public async Task<Pedidos> GetAsync(int pedidoId)
        {
            return await _pedidosRepository.GetAsync(pedidoId);
        }
        public async Task<IEnumerable<Pedidos>> GetAllAsync()
        {
            return await _pedidosRepository.GetAllAsync();
        }
        #endregion
    }
}
