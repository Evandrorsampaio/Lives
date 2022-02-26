import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Instrutor } from '../model/Instrutor';
import { InstrutorService } from '../service/Instrutor/InstrutorService.service';

@Component({
  selector: 'app-Instrutor',
  templateUrl: './Instrutor.component.html',
  styleUrls: ['./Instrutor.component.css']
})
export class InstrutorComponent implements OnInit {


  private filtroListados = '';

  public instrutores: Instrutor[] = [ ];
  public instrutoresFiltrados: Instrutor[] = [ ];


  constructor(
    private instrutorService: InstrutorService,

    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router
  ) { }

  public get filtroLista(): string{
    return this.filtroListados;
  }

  public set filtroLista(value: string){
    this.filtroListados = value;
    this.instrutoresFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.instrutores;
  }

  public filtrarLista(filtrarPor: string): Instrutor[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.instrutores.filter(
      (instrutor: any) => instrutor.pessoa.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        instrutor.pessoa.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    ) ;
  }

  ngOnInit() {

    this.getInstrutores();

  }


  public getInstrutores(): void{
    this.instrutorService.getAll().subscribe(
      {
        next: (v: Instrutor[]) => {
          this.instrutores = v;
          this.instrutoresFiltrados = this.instrutores;

        },
        error: (error: any) =>{
          this.snackBar.open('Erro ao carregar os Instrutors.' + error.message, 'Fechar');
        },
        complete: () =>{

        }
      }
    );
  }

  public DetalharInstrutor(id: number): void{
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
