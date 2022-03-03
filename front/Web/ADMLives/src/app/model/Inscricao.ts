import { SituacaoInscricao } from "../Enum/SituacaoInscricao.enum";
import { Inscrito } from "./Inscrito";
import { Live } from "./Live";

export interface Inscricao {
  id: number;
  ativo: boolean;
  valor: number;
  vencimento: Date;
  situacao: SituacaoInscricao;
  idLive: number;
  live: Live;
  idInscrito: number;
  inscrito: Inscrito;
}
