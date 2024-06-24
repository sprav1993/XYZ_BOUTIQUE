using System;
using AutoMapper;
using XYZ.BOUTIQUE.Application.Dto;
using XYZ.BOUTIQUE.Application.Interface;
using XYZ.BOUTIQUE.Domain.Entity;
using XYZ.BOUTIQUE.Domain.Interface;
using XYZ.BOUTIQUE.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace XYZ.BOUTIQUE.Application.Main
{
    public class PedidossApplication:IPedidosApplication
    {
        private readonly IPedidosDomain _pedidosDomain;
        private readonly IMapper _mapper;

        public PedidossApplication(IPedidosDomain pedidosDomain, IMapper mapper)
        {
            _pedidosDomain = pedidosDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos
        public Response<bool> Insert(PedidosDto pedidosDto)
        {
            var response = new Response<bool>();
            try
            {
                var pedidos = _mapper.Map<Pedidos>(pedidosDto);
                response.Data = _pedidosDomain.Insert(pedidos);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex) { 
            response.Message= ex.Message;
            }
            return response;
        }
        public Response<bool> Update(PedidosDto pedidosDto)
        {
            var response= new Response<bool>();
            try
            {
                var pedidos = _mapper.Map<Pedidos>(pedidosDto);
                response.Data = _pedidosDomain.Update(pedidos);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(int pedidosId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _pedidosDomain.Delete(pedidosId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<PedidosDto> Get(int pedidosId)
        {
            var response = new Response<PedidosDto>();
            try
            {   var pedidos=_pedidosDomain.Get(pedidosId);
                response.Data=_mapper.Map<PedidosDto>(pedidos);
                 if (response.Data!=null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<IEnumerable<PedidosDto>> GetAll()
        {
            var response = new Response<IEnumerable<PedidosDto>>();
            try
            {
                var pedidos = _pedidosDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<PedidosDto>>(pedidos);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(PedidosDto pedidosDto)
        {
            var response = new Response<bool>();
            try
            {
                var pedidos = _mapper.Map<Pedidos>(pedidosDto);
                response.Data = await _pedidosDomain.InsertAsync(pedidos);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(PedidosDto pedidosDto)
        {
            var response = new Response<bool>();
            try
            {
                var pedidos = _mapper.Map<Pedidos>(pedidosDto);
                response.Data = await _pedidosDomain.UpdateAsync(pedidos);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int pedidosId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _pedidosDomain.DeleteAsync(pedidosId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<PedidosDto>> GetAsync(int pedidosId)
        {
            var response = new Response<PedidosDto>();
            try
            {
                var pedidos = await _pedidosDomain.GetAsync(pedidosId);
                response.Data = _mapper.Map<PedidosDto>(pedidos);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<PedidosDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<PedidosDto>>();
            try
            {
                var pedidos = await _pedidosDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<PedidosDto>>(pedidos);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion
    }
}
