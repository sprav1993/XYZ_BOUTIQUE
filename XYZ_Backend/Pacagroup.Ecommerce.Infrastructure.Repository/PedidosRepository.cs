using Dapper;
using XYZ.BOUTIQUE.Domain.Entity;
using XYZ.BOUTIQUE.Infrastructure.Interface;
using XYZ.BOUTIQUE.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace XYZ.BOUTIQUE.Infrastructure.Repository
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PedidosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #region Métodos Síncronos
        public bool Insert(Pedidos pedido)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosInsert";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedido.pedido_id);
                parameters.Add("FECHA_PEDIDO", pedido.fecha_pedido);
                parameters.Add("FECHA_RECEPCION", pedido.fecha_recepcion);
                parameters.Add("FECHA_DESPACHO", pedido.fecha_despacho);
                parameters.Add("FECHA_ENTREGA", pedido.fecha_entrega);
                parameters.Add("VENDEDOR", pedido.vendedor);
                parameters.Add("REPARTIDOR", pedido.repartidor);
                parameters.Add("ESTADO_PEDIDO", pedido.estado_pedido);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Pedidos pedido)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedido.pedido_id);
                parameters.Add("FECHA_PEDIDO", pedido.fecha_pedido);
                parameters.Add("FECHA_RECEPCION", pedido.fecha_recepcion);
                parameters.Add("FECHA_DESPACHO", pedido.fecha_despacho);
                parameters.Add("FECHA_ENTREGA", pedido.fecha_entrega);
                parameters.Add("VENDEDOR", pedido.vendedor);
                parameters.Add("REPARTIDOR", pedido.repartidor);
                parameters.Add("ESTADO_PEDIDO", pedido.estado_pedido);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(int pedidoId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosDelete";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedidoId);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Pedidos Get(int pedidoId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedidoId);
                var pedido = connection.QueryFirstOrDefault<Pedidos>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return pedido;
            }
        }

        public IEnumerable<Pedidos> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "[USP_GET_PEDIDO_LISTA]";
                var pedidos = connection.Query<Pedidos>(query, commandType: CommandType.StoredProcedure);
                return pedidos;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Pedidos pedido)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosInsert";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedido.pedido_id);
                parameters.Add("FECHA_PEDIDO", pedido.fecha_pedido);
                parameters.Add("FECHA_RECEPCION", pedido.fecha_recepcion);
                parameters.Add("FECHA_DESPACHO", pedido.fecha_despacho);
                parameters.Add("FECHA_ENTREGA", pedido.fecha_entrega);
                parameters.Add("VENDEDOR", pedido.vendedor);
                parameters.Add("REPARTIDOR", pedido.repartidor);
                parameters.Add("ESTADO_PEDIDO", pedido.estado_pedido);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Pedidos pedido)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedido.pedido_id);
                parameters.Add("FECHA_PEDIDO", pedido.fecha_pedido);
                parameters.Add("FECHA_RECEPCION", pedido.fecha_recepcion);
                parameters.Add("FECHA_DESPACHO", pedido.fecha_despacho);
                parameters.Add("FECHA_ENTREGA", pedido.fecha_entrega);
                parameters.Add("VENDEDOR", pedido.vendedor);
                parameters.Add("REPARTIDOR", pedido.repartidor);
                parameters.Add("ESTADO_PEDIDO", pedido.estado_pedido);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int pedidoId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosDelete";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedidoId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Pedidos> GetAsync(int pedidoId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PedidosGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("PEDIDO_ID", pedidoId);
                var pedido = await connection.QueryFirstOrDefaultAsync<Pedidos>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return pedido;
            }
        }

        public async Task<IEnumerable<Pedidos>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "[USP_GET_PEDIDO_LISTA]";
                var pedidos = await connection.QueryAsync<Pedidos>(query, commandType: CommandType.StoredProcedure);
                return pedidos;
            }
        }

        #endregion
    }
}
