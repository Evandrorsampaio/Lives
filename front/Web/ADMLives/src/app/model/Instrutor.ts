import { Live } from "./Live";
import { Pessoa } from "./Pessoa";

export interface Instrutor {
  id: number;
  ativo: boolean;
  lives: Live[];
  pessoaId: number;
  pessoa: Pessoa;

}
