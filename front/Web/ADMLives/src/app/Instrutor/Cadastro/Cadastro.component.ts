import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Instrutor } from 'src/app/model/Instrutor';
import { InstrutorService } from 'src/app/service/Instrutor/InstrutorService.service';
import { Constants } from '../../util/constants';
@Component({
  selector: 'app-Cadastro',
  templateUrl: './Cadastro.component.html',
  styleUrls: ['./Cadastro.component.css']
})

export class CadastroComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private instrutorService: InstrutorService

    ) { }

    public instrutor!: any;
    public id = 0;
    public idParameter = '';

    public form!: FormGroup;

    ngOnInit() {
      this.id = this.getIdParamenter();

      if(this.idParamIsValid()){
        this.carregaInstrutor(this.id);
      }else{
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

    }

