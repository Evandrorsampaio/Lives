import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Live } from '../model/Live';
import { LiveService } from '../service/Live/LiveService.service';
import { StrFunctions } from '../util/StrFunctions';

@Component({
  selector: 'app-Live',
  templateUrl: './Live.component.html',
  styleUrls: ['./Live.component.css']
})

export class LiveComponent implements OnInit {
  private filtroListados = '';

  public lives: Live[] = [ ];
  public livesFiltrados: Live[] = [ ];


  constructor(
    private liveService: LiveService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router
  ) { }

  public get filtroLista(): string{
    return this.filtroListados;
  }

  public set filtroLista(value: string){
    this.filtroListados = value;
    this.livesFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.lives;
  }

  public filtrarLista(filtrarPor: string): Live[] {
    return this.lives.filter(
      (live: any) => StrFunctions.Contem(live.nome, filtrarPor) ||
                          StrFunctions.Contem(live.descricao, filtrarPor) ||
                          StrFunctions.Contem(live.instrutor.pessoa.nome, filtrarPor)
    ) ;
  }

  ngOnInit() {

    this.getlives();

  }


  public getlives(): void{
    this.liveService.getAll().subscribe(
      {
        next: (v: Live[]) => {
          this.lives = v;
          this.livesFiltrados = this.lives;

        },
        error: (error: any) =>{
          this.snackBar.open('Erro ao carregar lives.' + error.message, 'Fechar');
        },
        complete: () =>{

        }
      }
    );
  }

}
