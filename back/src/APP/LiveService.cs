using APP.DTOS;
using APP.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;

namespace APP;
public class LiveService: ILiveService
{
        private readonly IBaseRepository _baseRepository;
        private readonly ILiveRepository _LiveRepository;
        private readonly IMapper _mapper;

        public LiveService(
            IBaseRepository baseRepository,
            ILiveRepository LiveRepository,
            IMapper mapper
        )
        {
            this._baseRepository = baseRepository; 
            this._LiveRepository = LiveRepository; 
            this._mapper = mapper;         
        }

        public async Task<LiveDto> Add(LiveDto model)
        {
            try
            {
                var Live = _mapper.Map<LiveEntity>(model);
                 _baseRepository.Add<LiveEntity>(Live);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<LiveDto>(await _LiveRepository.GetByIdAsync(Live.id))
                    : throw new Exception("Erro ao inserir live."){} ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<LiveDto> Update(LiveDto model)
        {
             try
            {
                var Live = _mapper.Map<LiveEntity>(model);
                 _baseRepository.Update<LiveEntity>(Live);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<LiveDto>(await _LiveRepository.GetByIdAsync(Live.id))
                    : throw new Exception("Erro ao atualizar live."){} ;
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
                var Live = await _LiveRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir live.");
                 
                 _baseRepository.Delete<LiveEntity>(Live);
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
                var Live = await _LiveRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir live.");
                Live.ativo = false;
                LiveDto LiveDto = _mapper.Map<LiveDto>(Live);
                LiveDto = await this.Update(LiveDto);
                return !(LiveDto == null);
            } else {
                return true;
            }
        }
        
        public async Task<LiveDto?> GetByIdAsync(int id)
        {
             try
            {
                 var live = await _LiveRepository.GetByIdAsync(id);
                 if(live == null)
                    return null; 
            
                 return _mapper.Map<LiveDto>(live);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }

    public async Task<LiveDto[]?> GetByNomeAsync(string nome)
    {
             try
            {
                 var live = await _LiveRepository.GetByNomeAsync(nome);
                 if(live == null)
                    return null; 

                 return _mapper.Map<LiveDto[]>(live);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
    }


    public async Task<LiveDto[]?> GetAllAsync()
    {
             try
            {
                 var live = await _LiveRepository.GetAllAsync();
                 if(live == null)
                    return null; 

                 return _mapper.Map<LiveDto[]>(live);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
    }
}
