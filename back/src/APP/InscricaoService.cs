using APP.DTOS;
using APP.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;

namespace APP;
public class InscricaoService: IInscricaoService
{
        private readonly IBaseRepository _baseRepository;
        private readonly IInscricaoRepository _inscricaoRepository;
        private readonly IMapper _mapper;

        public InscricaoService(
            IBaseRepository baseRepository,
            IInscricaoRepository InscricaoRepository,
            IMapper mapper
        )
        {
            this._baseRepository = baseRepository; 
            this._inscricaoRepository = InscricaoRepository; 
            this._mapper = mapper;         
        }

        public async Task<InscricaoDto> Add(InscricaoDto model)
        {
            try
            {
                var inscricao = _mapper.Map<InscricaoEntity>(model);
                 _baseRepository.Add<InscricaoEntity>(inscricao);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<InscricaoDto>(await _inscricaoRepository.GetByIdAsync(inscricao.id))
                    : throw new Exception("Erro ao inserir o Inscricao."){} ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<InscricaoDto> Update(InscricaoDto model)
        {
             try
            {
                var inscricao = _mapper.Map<InscricaoEntity>(model);
                 _baseRepository.Update<InscricaoEntity>(inscricao);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<InscricaoDto>(await _inscricaoRepository.GetByIdAsync(inscricao.id))
                    : throw new Exception("Erro ao atualizar o Inscricao."){} ;
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
                var inscricao = await _inscricaoRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Inscricao.");
                 
                 _baseRepository.Delete<InscricaoEntity>(inscricao);
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
                var inscricao = await _inscricaoRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Inscricao.");
                inscricao.ativo = false;
                InscricaoDto inscricaoDto = _mapper.Map<InscricaoDto>(inscricao);
                inscricaoDto = await this.Update(inscricaoDto);
                return !(inscricaoDto == null);
            } else {
                return true;
            }
        }
        
        public async Task<InscricaoDto?> GetAllAsync()
        {
             try
            {
                 var inscricao = await _inscricaoRepository.GetAllAsync();
                 if(inscricao == null)
                    return null; 
            
                 return _mapper.Map<InscricaoDto>(inscricao);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }
        public async Task<InscricaoDto?> GetByIdAsync(int id)
        {
             try
            {
                var inscricao = await _inscricaoRepository.GetByIdAsync(id);
                if(inscricao == null)
                    return null;
            
                return _mapper.Map<InscricaoDto>(inscricao);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }

    public async Task<InscricaoDto[]?> GetByInscritoAsync(int idInscrito)
    {
        try
        {
                var inscricao = await _inscricaoRepository.GetByInscritoAsync(idInscrito);
                if(inscricao == null)
                    return null;
        
                return _mapper.Map<InscricaoDto[]>(inscricao);

        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<InscricaoDto[]?> GetByLiveAsync(int idLive)
    {
        try
        {
            var inscricao = await _inscricaoRepository.GetByLiveAsync(idLive);
            if(inscricao == null)
                return null;
    
            return _mapper.Map<InscricaoDto[]>(inscricao);

        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }
}
