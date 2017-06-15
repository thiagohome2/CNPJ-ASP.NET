using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace ConsultaCNPJ
{
    
    public partial class frmConCNPJ : System.Web.UI.Page
    {
        private static  ConsultaCNPJReceita consulta;
        private static int c; 

        public void carregarCaptcha()
        {
            c++;
            //MessageBox.Text = c.ToString();
            consulta = new ConsultaCNPJReceita();
            //ttbLetras.Text = "";
            ttbLetras.Focus();
      
            string img = consulta.GetCaptcha();

            if (img != null)
                imgCaptcha.ImageUrl = img;
            else
                MessageBox.Text = "Não foi possível recuperar a imagem de validação do site da Receita Federal";

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ttbCNPJ.Value = Request.QueryString["cnpj"];
            
            if (ttbLetras.Text == "")
            {
                carregarCaptcha();
            }
        }


        protected void btnTrocarImagem_Click(object sender, EventArgs e)
        {
            carregarCaptcha();
        }

        private enum Coluna
        {
            RazaoSocial = 0,
            NomeFantasia,

            AtividadeEconomicaPrimaria,
            AtividadeEconomicaSecundaria,

            NumeroDaInscricao,
            MatrizFilial,
            NaturezaJuridica,

            SituacaoCadastral,
            DataSituacaoCadastral,
            MotivoSituacaoCadastral,

            EnderecoLogradouro,
            EnderecoNumero,
            EnderecoComplemento,
            EnderecoCEP,
            EnderecoBairro,
            EnderecoCidade,
            EnderecoEstado


        };

        private String RecuperaColunaValor(String pattern, Coluna col)
        {
            String S = pattern.Replace("\n", "").Replace("\t", "").Replace("\r", "");

            switch (col)
            {
                case Coluna.RazaoSocial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NOME EMPRESARIAL -->", "<!-- Fim Linha NOME EMPRESARIAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NomeFantasia:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ESTABELECIMENTO -->", "<!-- Fim Linha ESTABELECIMENTO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NaturezaJuridica:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NATUREZA JURÍDICA -->", "<!-- Fim Linha NATUREZA JURÍDICA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.AtividadeEconomicaPrimaria:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ATIVIDADE ECONOMICA -->", "<!-- Fim Linha ATIVIDADE ECONOMICA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.AtividadeEconomicaSecundaria:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ATIVIDADE ECONOMICA SECUNDARIA-->", "<!-- Fim Linha ATIVIDADE ECONOMICA SECUNDARIA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NumeroDaInscricao:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.MatrizFilial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoLogradouro:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoNumero:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoComplemento:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoCEP:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoBairro:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoCidade:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoEstado:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.SituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.DataSituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.MotivoSituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha MOTIVO DE SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha MOTIVO DE SITUAÇÃO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }

                default:
                    {
                        return S;
                    }
            }
        }

        private String StringEntreString(String Str, String StrInicio, String StrFinal)
        {
            int Ini;
            int Fim;
            int Diff;
            Ini = Str.IndexOf(StrInicio);
            Fim = Str.IndexOf(StrFinal);
            if (Ini > 0) Ini = Ini + StrInicio.Length;
            if (Fim > 0) Fim = Fim + StrFinal.Length;
            Diff = ((Fim - Ini) - StrFinal.Length);
            if ((Fim > Ini) && (Diff > 0))
                return Str.Substring(Ini, Diff);
            else
                return "";
        }

        private String StringSaltaString(String Str, String StrInicio)
        {
            int Ini;
            Ini = Str.IndexOf(StrInicio);
            if (Ini > 0)
            {
                Ini = Ini + StrInicio.Length;
                return Str.Substring(Ini);
            }
            else
                return Str;
        }

        public string StringPrimeiraLetraMaiuscula(String Str)
        {
            string StrResult = "";
            if (Str.Length > 0)
            {
                StrResult += Str.Substring(0, 1).ToUpper();
                StrResult += Str.Substring(1, Str.Length - 1).ToLower();
            }
            return StrResult;
        }
        
        public class Empresa
        {
            public string Cnpj { get; set; }
            public string Razaosocial { get; set; }
            public string NomeFantasia { get; set; }
            public string endereco { get; set; }
            public string Bairro { get; set; }
            public string Cep { get; set; }
            public string Cnae { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }

        }


        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //consulta = new ConsultaCNPJReceita();
            try
            {
                string tmp = consulta.Consulta(ttbCNPJ.Value, ttbLetras.Text);

                if (tmp.Length > 0)
                {
                    var empresa = new Empresa();
                
                    empresa.Cnpj = ttbCNPJ.Value;
                    empresa.Razaosocial = RecuperaColunaValor(tmp, Coluna.RazaoSocial);
                    empresa.NomeFantasia = RecuperaColunaValor(tmp, Coluna.NomeFantasia);
                    empresa.endereco = RecuperaColunaValor(tmp, Coluna.EnderecoLogradouro);
                    empresa.endereco += ", " + RecuperaColunaValor(tmp, Coluna.EnderecoNumero);
                    empresa.Bairro = RecuperaColunaValor(tmp, Coluna.EnderecoBairro);
                    empresa.Cep = RecuperaColunaValor(tmp, Coluna.EnderecoCEP);
                    empresa.Cnae = RecuperaColunaValor(tmp, Coluna.AtividadeEconomicaPrimaria);
                    empresa.Cidade = RecuperaColunaValor(tmp, Coluna.EnderecoCidade);
                    empresa.Estado = RecuperaColunaValor(tmp, Coluna.EnderecoEstado);

                    MessageBox.Text = "";

                    //Atribuição ao TextBox
                    lblCNPJ.Text = empresa.Cnpj;
                    txtRazao.Text = empresa.Razaosocial;
                    txtFantasia.Text = empresa.NomeFantasia;
                    txtEndereco.Text = empresa.endereco;
                    txtBairro.Text = empresa.Bairro;
                    txtCep.Text = empresa.Cep;
                    txtCnae.Text = empresa.Cnae;
                    txtCidade.Text = empresa.Cidade;
                    txtUF.Text = empresa.Estado;

                    string[] arr = new string[9];
                    arr[0] = empresa.Cnpj;
                    arr[1] = empresa.Razaosocial;
                    arr[2] = empresa.NomeFantasia;
                    arr[3] = empresa.endereco;
                    arr[4] = empresa.Bairro;
                    arr[5] = empresa.Cep;
                    arr[6] = empresa.Cnae;
                    arr[7] = empresa.Cidade;
                    arr[8] = empresa.Estado;

                    var json = new JavaScriptSerializer().Serialize(arr);
                    Response.Write("dados:" + json + "<br/>");


                }
            }
            catch(Exception ex)
            {
                MessageBox.Text = ex.ToString();
                MessageBox.Text = "Capcha Inválido!";
                carregarCaptcha();
            }


        }
    }
}
