using APP.DTOS;
using APP.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;

namespace APP;
public class InstrutorService: IInstrutorService
{
        private readonly IBaseRepository _baseRepository;
        private readonly IInstrutorRepository _InstrutorRepository;
        private readonly IMapper _mapper;

        public InstrutorService(
            IBaseRepository baseRepository,
            IInstrutorRepository InstrutorRepository,
            IMapper mapper
        )
        {
            this._baseRepository = baseRepository; 
            this._InstrutorRepository = InstrutorRepository; 
            this._mapper = mapper;         
        }

        public async Task<InstrutorDto> Add(InstrutorDto model)
        {
            try
            {
                var instrutor = _mapper.Map<InstrutorEntity>(model);
                 _baseRepository.Add<InstrutorEntity>(instrutor);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<InstrutorDto>(await _InstrutorRepository.GetByIdAsync(instrutor.id))
                    : throw new Exception("Erro ao inserir o Instrutor."){} ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<InstrutorDto> Update(InstrutorDto model)
        {
             try
            {
                var instrutor = _mapper.Map<InstrutorEntity>(model);
                 _baseRepository.Update<InstrutorEntity>(instrutor);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<InstrutorDto>(await _InstrutorRepository.GetByIdAsync(instrutor.id))
                    : throw new Exception("Erro ao atualizar o Instrutor."){} ;
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
                var instrutor = await _InstrutorRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Instrutor.");
                 
                 _baseRepository.Delete<InstrutorEntity>(instrutor);
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
                var instrutor = await _InstrutorRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Instrutor.");
                instrutor.ativo = false;
                InstrutorDto instrutorDto = _mapper.Map<InstrutorDto>(instrutor);
                instrutorDto = await this.Update(instrutorDto);
                return !(instrutorDto == null);
            } else {
                return true;
            }
        }
        
        public async Task<InstrutorDto?> GetByIdAsync(int id)
        {
             try
            {
                var instrutor = await _InstrutorRepository.GetByIdAsync(id); 
                if(instrutor == null)
                    return null;

                return _mapper.Map<InstrutorDto>(instrutor);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }

        public async Task<InstrutorDto[]?> GetByNomeAsync(string nome)
        {
            try
            {
                var instrutor = await _InstrutorRepository.GetByNomeAsync(nome);
                if(instrutor == null)
                return null;
                
            
                return _mapper.Map<InstrutorDto[]>(instrutor);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<InstrutorDto[]?> GetAllAsync()
        {
            try
            {
                var instrutor = await _InstrutorRepository.GetAllAsync();
                if(instrutor == null)
                    return null;
        
                return _mapper.Map<InstrutorDto[]>(instrutor);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }    
        }
}
