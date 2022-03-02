import { Inscricao } from "./Inscricao";
import { Pessoa } from "./Pessoa";

export interface Inscrito {
  id: number;
  ativo: boolean;
  inscricoes: Inscricao[];
  pessoaId: number;
  pessoa: Pessoa;
}
