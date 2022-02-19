using APP.DTOS;
using APP.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;

namespace APP;
public class InscritoService: IInscritoService
{
        private readonly IBaseRepository _baseRepository;
        private readonly IInscritoRepository _inscritoRepository;
        private readonly IMapper _mapper;

        public InscritoService(
            IBaseRepository baseRepository,
            IInscritoRepository InscritoRepository,
            IMapper mapper
        )
        {
            this._baseRepository = baseRepository; 
            this._inscritoRepository = InscritoRepository; 
            this._mapper = mapper;         
        }

        public async Task<InscritoDto> Add(InscritoDto model)
        {
            try
            {
                var inscrito = _mapper.Map<InscritoEntity>(model);
                 _baseRepository.Add<InscritoEntity>(inscrito);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<InscritoDto>(await _inscritoRepository.GetByIdAsync(inscrito.id))
                    : throw new Exception("Erro ao inserir o Inscrito."){} ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<InscritoDto> Update(InscritoDto model)
        {
             try
            {
                var inscrito = _mapper.Map<InscritoEntity>(model);
                 _baseRepository.Update<InscritoEntity>(inscrito);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<InscritoDto>(await _inscritoRepository.GetByIdAsync(inscrito.id))
                    : throw new Exception("Erro ao atualizar o Inscrito."){} ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var inscrito = await _inscritoRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Inscrito.");
                 
                 _baseRepository.Delete<InscritoEntity>(inscrito);
                 return await _baseRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeletarOUDesativar(int id){
            if (! await this.Delete(id))
            {
                var inscrito = await _inscritoRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Inscrito.");
                inscrito.ativo = false;
                InscritoDto inscritoDto = _mapper.Map<InscritoDto>(inscrito);
                inscritoDto = await this.Update(inscritoDto);
                return !(inscritoDto == null);
            } else {
                return true;
            }
        }
        
        public async Task<InscritoDto?> GetByIdAsync(int id)
        {
             try
            {
                var inscrito = await _inscritoRepository.GetByIdAsync(id);
                if(inscrito == null)
                    return null;
            
                 return _mapper.Map<InscritoDto>(inscrito);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }

    public async Task<InscritoDto[]?> GetByNomeAsync(string nome)
    {
             try
            {
                var inscrito = await _inscritoRepository.GetByNomeAsync(nome); 
                if(inscrito == null)
                    return null;
            
                return _mapper.Map<InscritoDto[]>(inscrito);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
    }

    public async Task<InscritoDto[]?> GetAllAsync()
    {
        try
        {
                var inscrito = await _inscritoRepository.GetAllAsync();
                if(inscrito == null)
                    return null;
 
        
                return _mapper.Map<InscritoDto[]>(inscrito);

        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }    
    }
}
