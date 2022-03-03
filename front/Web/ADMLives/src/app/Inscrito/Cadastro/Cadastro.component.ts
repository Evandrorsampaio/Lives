import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Inscrito } from 'src/app/model/Inscrito';
import { InscritoService } from 'src/app/service/Inscrito/InscritoService.service';
import { Constants } from 'src/app/util/constants';

@Component({
  selector: 'app-Cadastro',
  templateUrl: './Cadastro.component.html',
  styleUrls: ['./Cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  private readonly ModoInsercao = 'post';
  private readonly ModoAtualizacao = 'put';

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private inscritoService: InscritoService,
    private snackBar: MatSnackBar,
    private router: Router
    ) { }

    public inscrito!: any;
    public id = 0;
    public idParameter = '';
    public modo = 'post';
    public form!: FormGroup;

    get isAtualizacao(): boolean{
      return (this.modo === this.ModoAtualizacao);
    }

    get isInsercao(): boolean{
      return (this.modo === this.ModoInsercao);
    }

    get f(): any{
      return this.form.controls['pessoa'];
    }

    ngOnInit(): void{
      this.id = this.getIdParamenter();
      if(this.idParamIsValid()){
        this.modo = this.ModoAtualizacao;
        this.carregaInscrito(this.id);
      }else{
        this.modo = this.ModoInsercao;
        this.carregaFormInclusao();
      }
    }

    public getIdParamenter(): number{

      if (this.activatedRoute.snapshot.firstChild !== null ){
        return  +this.activatedRoute.snapshot.firstChild?.params.id;
      } else {
        return 0;
      }

    }

    public idParamIsValid(): boolean{
      return  (this.id !== null && this.id !== 0);
    }

    public getForm(): FormGroup{
      return this.fb.group({
        ativo: [true, [ Validators.required ]],
        pessoa: this.fb.group({
          nome  : ['', [ Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
          email  : ['', [ Validators.required, Validators.email]],
          instagram  : ['', [ Validators.required, Validators.pattern(Constants.REGEX_INSTAGRAM)]],
          dtNascimento  : ['', [ Validators.required ]],
        })
      });
    }

    public getInscritoVazio(): Inscrito{
      return {
        id: 0,
        ativo: true,
        pessoaId: 0,
        pessoa: {
          id: 0,
          ativo: true,
          nome: '' ,
          email: '' ,
          instagram: '' ,
          dtNascimento: new Date('01-01-1900')
        },
        inscricoes: []
      } as Inscrito;
    }

    public carregaInscrito(id: number): void{
        this.inscritoService.getById(this.id).subscribe(
          {
            next: (inscrito: Inscrito) => {
              this.inscrito = {... inscrito},

              this.form = this.getForm();
              this.form.patchValue(this.inscrito);
            },
            error: (erro: any) => {
              this.Mensagem('Erro ao recuperar inscrito. \n' + erro.message);
              console.error(erro);
            },
            complete: () => {

            }
          }
        );
    }

    public carregaFormInclusao(): void{
      this.id = 0;
      this.inscrito = this.getInscritoVazio();
      this.form = this.getForm();
    }

    public Salvar(): void{
      if(this.form.valid){
        if( this.isInsercao ){
          this.InserirInscrito();
        } else {
          this.AtualizarInscrito();
        }
      }

    }

    public AtualizarInscrito(): void{
      this.inscrito = {id: this.id, ... this.form.value}
      this.inscritoService.put( this.inscrito ).subscribe({
        next : () => {
          this.Mensagem('Inscrito atualizado.');
        },
        error : (error: any) => {
          this.erroAtualizacao(error);
        },
        complete : () => {

        }
      });
    }

    public InserirInscrito(): void{
      this.inscrito = {id: this.id, ... this.form.value}
      this.inscritoService.post( this.inscrito ).subscribe({
        next : () => {
          this.Mensagem('Inscrito inserido.');
        },
        error : (error: any) => {
          this.erroAtualizacao(error);
        },
        complete : () => {

        }
      });
    }

    public goToCadastro(id: number ): void{
      this.router.navigate([id], {relativeTo: this.activatedRoute});
    }

    public erroAtualizacao(error : any): void{
      console.error(error);
      this.Mensagem('Erro na atualização de inscrito.\n' + error.message );
    }

    public Mensagem(texto: string): void{
      this.snackBar.open(texto, 'Fechar');
    }
}
