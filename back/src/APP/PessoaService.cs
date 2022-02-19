using APP.DTOS;
using APP.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;

namespace APP;
public class PessoaService: IPessoaService
{

        private readonly IBaseRepository _baseRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(
            IBaseRepository baseRepository,
            IPessoaRepository PessoaRepository,
            IMapper mapper
        )
        {
            this._baseRepository = baseRepository; 
            this._pessoaRepository = PessoaRepository; 
            this._mapper = mapper;         
        }

        public async Task<PessoaDto> Add(PessoaDto model)
        {
            try
            {
                var pessoa = _mapper.Map<PessoaEntity>(model);
                 _baseRepository.Add<PessoaEntity>(pessoa);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<PessoaDto>(await _pessoaRepository.GetByIdAsync(pessoa.id))
                    : throw new Exception("Erro ao inserir o Pessoa."){} ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PessoaDto> Update(PessoaDto model)
        {
             try
            {
                var pessoa = _mapper.Map<PessoaEntity>(model);
                 _baseRepository.Update<PessoaEntity>(pessoa);
                 return await _baseRepository.SaveChangeAsync()
                    ?  _mapper.Map<PessoaDto>(await _pessoaRepository.GetByIdAsync(pessoa.id))
                    : throw new Exception("Erro ao atualizar o Pessoa."){} ;
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
                var pessoa = await _pessoaRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Pessoa.");
                 
                 _baseRepository.Delete<PessoaEntity>(pessoa);
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
                var pessoa = await _pessoaRepository.GetByIdAsync(id)
                            ?? throw new Exception("Erro ao excluir o Pessoa.");
                pessoa.ativo = false;
                PessoaDto pessoaDto = _mapper.Map<PessoaDto>(pessoa);
                pessoaDto = await this.Update(pessoaDto);
                return !(pessoaDto == null);
            } else {
                return true;
            }
        }
        
        public async Task<PessoaDto?> GetByIdAsync(int id)
        {
             try
            {
                var pessoa = await _pessoaRepository.GetByIdAsync(id);
                if(pessoa == null )
                    return null; 
            
                 return _mapper.Map<PessoaDto>(pessoa);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }        
        public async Task<PessoaDto[]?> GetAllAsync()
        {
             try
            {
                var pessoa = await _pessoaRepository.GetAllAsync();
                if(pessoa == null )
                   return null; 
 
            
                 return _mapper.Map<PessoaDto[]>(pessoa);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }

    public async Task<PessoaDto?> GetByEmailAsync(string email)
    {
             try
            {
                var pessoa = await _pessoaRepository.GetByEmailAsync(email);
                if(pessoa == null )
                    return null; 

                return _mapper.Map<PessoaDto>(pessoa);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
       }

    public async Task<PessoaDto[]?> GetByNomeAsync(string nome)
    {
             try
            {
                var pessoa = await _pessoaRepository.GetByNomeAsync(nome); 
                if(pessoa == null )
                    return null; 

                return _mapper.Map<PessoaDto[]>(pessoa);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
    }

}
