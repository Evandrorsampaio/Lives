import { Inscricao } from "./Inscricao";
import { Instrutor } from "./Instrutor";

export interface Live {
  id: number;
  ativo: boolean;
  nome: string;
  descricao: string;
  dtHrInicio: Date;
  duracaoMin: number;
  valor: number;
  idInstrutor: number;
  instrutor: Instrutor;
  inscricoes: Inscricao[];
}
