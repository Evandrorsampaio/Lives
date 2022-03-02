import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { DateFormatPipe } from 'src/app/helpers/DateFormat.pipe';
import { Instrutor } from 'src/app/model/Instrutor';
import { InstrutorService } from 'src/app/service/Instrutor/InstrutorService.service';
import { Constants } from '../../util/constants';

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
    private instrutorService: InstrutorService,
    private snackBar: MatSnackBar,
    private router: Router
    ) { }

    public instrutor!: any;
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
      //alert((this.form.controls['pessoa'] as FormGroup).controls['nome']);
      return this.form.controls['pessoa'];
    }

    ngOnInit(): void{
      this.id = this.getIdParamenter();

      if(this.idParamIsValid()){
        this.modo = this.ModoAtualizacao;
        this.carregaInstrutor(this.id);
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

    public getInstrutorVazio(): Instrutor{
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
        lives: [],
      } as Instrutor;
    }

    public carregaInstrutor(id: number): void{
        this.instrutorService.getById(this.id).subscribe(
          {
            next: (instrutor: Instrutor) => {
              this.instrutor = {... instrutor},

              this.form = this.getForm();
              this.form.patchValue(this.instrutor);
            },
            error: (erro: any) => {
              //this.toastr.error('Erro ao carregar o evento.', 'Erro!');
              console.error(erro);
            },
            complete: () => {

            }
          }
        );
    }

    public carregaFormInclusao(): void{
      this.id = 0;
      this.instrutor = this.getInstrutorVazio();
      this.form = this.getForm();
    }

    public Salvar(): void{
      if(this.form.valid){
        if( this.isInsercao ){
          this.InserirInstrutor();
        } else {
          this.AtualizarInstrutor();
        }
      }

    }

    public AtualizarInstrutor(): void{
      this.instrutor = {id: this.id, ... this.form.value}
      this.instrutorService.put( this.instrutor ).subscribe({
        next : () => {
          this.Mensagem('Instrutor atualizado.');
        },
        error : (error: any) => {
          this.erroAtualizacao(error);
        },
        complete : () => {

        }
      });
    }

    public InserirInstrutor(): void{
      this.instrutor = {id: this.id, ... this.form.value}
      this.instrutorService.post( this.instrutor ).subscribe({
        next : () => {
          this.Mensagem('Instrutor inserido.');
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
      this.Mensagem('Erro na atualização de instrutor.\n' + error.message );
    }

    public Mensagem(texto: string): void{
      this.snackBar.open(texto, 'Fechar');
    }
}

