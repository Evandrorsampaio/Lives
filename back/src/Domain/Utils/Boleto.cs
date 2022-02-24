using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Utils.Constantes;

namespace Domain.Utils
{

    public class Boleto
    {
        private const int referenciaAno = 1997;
        private const int referenciaMes = 10;
        private const int referenciaDia = 7;

        public Boleto(decimal valor, DateTime vencimento)
        {
            this.banco = "000";
            this.moeda = "0";
            this.livre1 = "00000";
            this.dv1 = "0";
            this.livre2 = "0000000000";
            this.dv2 = "0";
            this.livre3 = "0000000000";
            this.dvGeral = "0";
            this.livre3 = "0000000000";
            this.dvGeral = "0";
            this.setFator(vencimento);
            this.setValorNominal(valor);
        }
        private string _banco;
        public string banco { get => _banco; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamBanco,'0');
                _banco = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamBanco,BoletoTamCampos.tamBanco);
            } 
        }

        private string _moeda;
        public string moeda { get => _moeda; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamMoeda,'0');
                _moeda = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamMoeda,BoletoTamCampos.tamMoeda);
            } 
        }

        private string _livre1;
        public string livre1 { get => _livre1; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamLivrePequeno,'0');
                _livre1 = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamLivrePequeno,BoletoTamCampos.tamLivrePequeno);
            } 
        }

        private string _dv1;
        public string dv1 { get => _dv1; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamDv,'0');
                _dv1 = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamDv,BoletoTamCampos.tamDv);
            } 
        }

        private string _dv2;
        public string dv2 { get => _dv2; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamDv,'0');
                _dv2 = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamDv,BoletoTamCampos.tamDv);
            } 
        }

        private string _dvGeral;
        public string dvGeral { get => _dvGeral; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamDv,'0');
                _dvGeral = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamDv,BoletoTamCampos.tamDv);
            } 
        }

        private string _livre2;
        public string livre2 { get => _livre2; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamLivreGrande,'0');
                _livre2 = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamLivreGrande,BoletoTamCampos.tamLivreGrande);
            } 
        }

        private string _livre3;
        public string livre3 { get => _livre3; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamLivreGrande,'0');
                _livre3 = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamLivreGrande,BoletoTamCampos.tamLivreGrande);
            } 
        }

        private string _fatorVencimento;
        public string fatorVencimento { get => _fatorVencimento; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamFatorVencimento,'0');
                _fatorVencimento = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamFatorVencimento,BoletoTamCampos.tamFatorVencimento);
            } 
        }

        private string _valorNominal;
        public string valorNominal { get => _valorNominal; 
            set{ 
                string valorZerosAEsquerda = value.PadLeft(BoletoTamCampos.tamValorNominal,'0');
                _valorNominal = valorZerosAEsquerda
                        .Substring(valorZerosAEsquerda.Length - BoletoTamCampos.tamValorNominal,BoletoTamCampos.tamValorNominal);
            } 
        }

        public void setValorNominal(decimal valor ){
            string strValor = valor.ToString("00000000.00");

            _valorNominal = strValor.Replace(",", "").Replace(".","");

        }

        public void setFator(DateTime vencimento ){
            DateTime referencia = new DateTime(referenciaAno, referenciaMes, referenciaDia);

            decimal fator = (vencimento - referencia).Days;

            _fatorVencimento = Math.Truncate(fator).ToString("0000");

        }

       public string getCodigoPagamento( ){

           return string.Concat(this.banco,
                                this.moeda,
                                this.livre1,
                                this.dv1,
                                this.livre2,
                                this.dv2,
                                this.livre3,
                                this.dvGeral,
                                this.fatorVencimento,
                                this.valorNominal);

        }
 
     }
}