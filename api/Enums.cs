using System.ComponentModel;

namespace api
{
    public enum UF
    {
        [Description("Acre")]
        AC = 1,
        [Description("Alagoas")]
        AL,
        [Description("Amapá")]
        AP,
        [Description("Amazonas")]
        AM,
        [Description("Bahia")]
        BA,
        [Description("Ceará")]
        CE,
        [Description("Espírito Santo")]
        ES,
        [Description("Goiás")]
        GO,
        [Description("Maranhão")]
        MA,
        [Description("Mato Grosso")]
        MT,
        [Description("Mato Grosso do Sul")]
        MS,
        [Description("Minas Gerais")]
        MG,
        [Description("Pará")]
        PA,
        [Description("Paraíba")]
        PB,
        [Description("Paraná")]
        PR,
        [Description("Pernambuco")]
        PE,
        [Description("Piauí")]
        PI,
        [Description("Rio de Janeiro")]
        RJ,
        [Description("Rio Grande do Norte")]
        RN,
        [Description("Rio Grande do Sul")]
        RS,
        [Description("Rondônia")]
        RO,
        [Description("Roraima")]
        RR,
        [Description("Santa Catarina")]
        SC,
        [Description("São Paulo")]
        SP,
        [Description("Sergipe")]
        SE,
        [Description("Tocantins")]
        TO,
        [Description("Distrito Federal")]
        DF
    }

    public enum ErrorCodes
    {
        Unknown,
        [Description("Erro ao realizar o cálculo")]
        ErroNoCalculo,
        [Description("Tamanho máximo de arquivo ultrapassado")]
        TamanhoArquivoExcedido,
        [Description("Arquivo formato inválido")]
        ArquivoFormatoInvalido,
        [Description("Arquivo vazio")]
        ArquivoVazio,
        [Description("Planilha com formato incompatível")]
        PlanilhaFormatoIncompativel,
        [Description("Dados já inseridos")]
        DadosJaInseridos,
    }
    
    public enum Permissao
    {
        [Description("Calcular UPS de sinistros")]
        UpsCalcularSinistro = 5000,
            
        [Description("Caluclar UPS de escolas")]
        UpsCalcularEscola = 5001,
    
        [Description("Cadastrar rodovia")]
        RodoviaCadastrar = 5002,
    
        [Description("Cadastrar sinistro")]
        SinistroCadastrar = 5003,
    }

}
