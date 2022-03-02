import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Inscrito } from '../model/Inscrito';
import { InscritoService } from '../service/Inscrito/InscritoService.service';
import { StrFunctions } from '../util/StrFunctions';

@Component({
  selector: 'app-Inscrito',
  templateUrl: './Inscrito.component.html',
  styleUrls: ['./Inscrito.component.css']
})
export class InscritoComponent implements OnInit {


  private filtroListados = '';
  public inscritos: Inscrito[] = [ ];
  public inscritosFiltrados: Inscrito[] = [ ];

  constructor(
    private inscritoService: InscritoService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router
  ) { }

  public get filtroLista(): string{
    return this.filtroListados;
  }

  public set filtroLista(value: string){
    this.filtroListados = value;
    this.inscritosFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.inscritos;
  }

  public filtrarLista(filtrarPor: string): Inscrito[] {
    return this.inscritos.filter(
      (inscrito: any) => StrFunctions.Contem(inscrito.pessoa.nome, filtrarPor) ||
                          StrFunctions.Contem(inscrito.pessoa.email, filtrarPor)
    ) ;
  }

  ngOnInit(): void{

    this.getInscritos();

  }


  public getInscritos(): void{
    this.inscritoService.getAll().subscribe(
      {
        next: (retorno: Inscrito[]) => {
          this.inscritos = retorno;
          this.inscritosFiltrados = this.inscritos;

        },
        error: (error: any) =>{
          this.Mensagem('Erro ao carregar os inscritos.' + error.message);
        },
        complete: () =>{

        }
      }
    );
  }

  public Mensagem(texto: string): void{
    this.snackBar.open(texto, 'Fechar');
  }

  public AbrirCadastro(id: number): void{
    this.router.navigate([`cadastro/${id}`]);
  }

}
