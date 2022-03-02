import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Inscricao } from '../model/Inscricao';
import { InscricaoService } from '../service/Inscricao/InscricaoService.service';
import { StrFunctions } from '../util/StrFunctions';

@Component({
  selector: 'app-Inscricao',
  templateUrl: './Inscricao.component.html',
  styleUrls: ['./Inscricao.component.css']
})
export class InscricaoComponent implements OnInit {

  private filtroListados = '';

  public inscricoes: Inscricao[] = [ ];
  public inscricoesFiltrados: Inscricao[] = [ ];


  constructor(
    private inscricaoService: InscricaoService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router
  ) { }

  public get filtroLista(): string{
    return this.filtroListados;
  }

  public set filtroLista(value: string){
    this.filtroListados = value;
    this.inscricoesFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.inscricoes;
  }

  public filtrarLista(filtrarPor: string): Inscricao[] {
    return this.inscricoes.filter(
      (inscricao: any) => StrFunctions.Contem(inscricao.inscrito.pessoa.nome, filtrarPor) ||
                          StrFunctions.Contem(inscricao.live.nome, filtrarPor) ||
                          StrFunctions.Contem(inscricao.live.descricao, filtrarPor) ||
                          StrFunctions.Contem(inscricao.instrutor.pessoa.nome, filtrarPor)
    ) ;
  }

  ngOnInit() {

    this.getinscricoes();

  }


  public getinscricoes(): void{
    this.inscricaoService.getAll().subscribe(
      {
        next: (v: Inscricao[]) => {
          this.inscricoes = v;
          this.inscricoesFiltrados = this.inscricoes;

        },
        error: (error: any) =>{
          this.snackBar.open('Erro ao carregar inscricoes.' + error.message, 'Fechar');
        },
        complete: () =>{

        }
      }
    );
  }


}
