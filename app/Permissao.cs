using System.ComponentModel;

namespace app;

public enum Permissao
{
    [Description("Calcular UPS de sinistros")]
    UpsCalcularSinistro = 5000,
            
    [Description("Caluclar UPS de escolas")]
    UpsCalcularEscola = 5001,
            
    [Description("Visualizar sinistros")]
    SinistroVisualizar = 5002,
    
    [Description("Cadastrar rodovia")]
    RodoviaCadastrar = 5003,
    
    [Description("Cadastrar sinistro")]
    SinistroCadastrar = 5004,
}
