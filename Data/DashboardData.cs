using MudBlazor;

namespace afya_admin.Data;

public class Kpi
{
    public string Titulo { get; set; } = "";
    public string Valor { get; set; } = "";
    public string Variacao { get; set; } = "";
    public string Tendencia { get; set; } = "";
    public bool IsPositivo { get; set; } = true;
    public bool Positivo { get => IsPositivo; set => IsPositivo = value; }
    public string Icone { get; set; } = Icons.Material.Filled.TrendingUp;
    public double[] SparklineData { get; set; } = Array.Empty<double>();
    public Color Cor { get; set; } = Color.Primary;
    public string CorHex { get; set; } = "#594AE2";
}

public class ProjetoPerformance
{
    public string Nome { get; set; } = "";
    public int Progresso { get; set; }
    public double Percentual { get => Progresso; set => Progresso = (int)value; }
    public string TarefasInfo { get; set; } = "";
    public int TarefasConcluidas { get; set; } = 30;
    public int TarefasTotal { get; set; } = 40;
    public string Icone { get; set; } = Icons.Material.Filled.Folder;
    public Color Cor { get; set; } = Color.Primary;
}

public class Atividade
{
    public string Iniciais { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Acao { get; set; } = "";
    public string Tempo { get; set; } = "";
    public Color CorAvatar { get; set; } = Color.Primary;
    public Color Cor { get => CorAvatar; set => CorAvatar = value; }
    public string Icone { get; set; } = Icons.Material.Filled.Notifications;
}

public class ProjetoRecente
{
    public string Nome { get; set; } = "";
    public string Cliente { get; set; } = "";
    public string Responsavel { get; set; } = "";
    public string IniciaisResponsavel { get; set; } = "";
    public string Status { get; set; } = "";
    public Color CorStatus { get; set; } = Color.Primary;
    public int Progresso { get; set; }
    public string Prazo { get; set; } = "";
}

public class SegmentoCliente
{
    public string Nome { get; set; } = "";
    public double Porcentagem { get; set; }
    public double Percentual { get => Porcentagem; set => Porcentagem = value; }
    public Color Cor { get; set; } = Color.Primary;
    public string CorHex { get; set; } = "#594AE2";
}

public static class DashboardData
{
    public static List<string> Periodos { get; } = new() { "Hoje", "Esta Semana", "Este Mês", "Este Ano" };
    public static string[] Meses { get; } = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
    public static double[] ReceitaMensal { get; } = new double[] { 12, 19, 15, 25, 22, 30, 28, 35, 40, 38, 45, 50 };
    public static double[] MetaMensal { get; } = new double[] { 15, 18, 20, 22, 25, 28, 30, 32, 35, 38, 40, 45 };
    public static int TotalClientes { get; } = 1284;

    public static List<Kpi> Kpis => ObterKpis();
    public static List<SegmentoCliente> SegmentosClientes => ObterSegmentosClientes();
    public static List<ProjetoPerformance> Performance => ObterPerformanceProjetos();
    public static List<Atividade> Atividades => ObterAtividadesRecentes();
    public static List<ProjetoRecente> ProjetosRecentes => ObterProjetosRecentes();

    public static List<Kpi> ObterKpis() => new()
    {
        new Kpi
        {
            Titulo = "Receita",
            Valor = "R$ 248.500",
            Variacao = "+12,5%",
            Tendencia = "+12,5%",
            IsPositivo = true,
            SparklineData = new double[] { 10, 15, 12, 18, 22, 25 },
            Cor = Color.Success,
            CorHex = "#00C853",
            Icone = Icons.Material.Filled.AttachMoney
        },
        new Kpi
        {
            Titulo = "Usuários Ativos",
            Valor = "12.842",
            Variacao = "+8,2%",
            Tendencia = "+8,2%",
            IsPositivo = true,
            SparklineData = new double[] { 8, 12, 10, 14, 16, 20 },
            Cor = Color.Secondary,
            CorHex = "#9C27B0",
            Icone = Icons.Material.Filled.People
        },
        new Kpi
        {
            Titulo = "Novos Clientes",
            Valor = "384",
            Variacao = "+16,6%",
            Tendencia = "+16,6%",
            IsPositivo = true,
            SparklineData = new double[] { 5, 8, 12, 10, 15, 18 },
            Cor = Color.Info,
            CorHex = "#2196F3",
            Icone = Icons.Material.Filled.PersonAdd
        },
        new Kpi
        {
            Titulo = "Projetos Ativos",
            Valor = "27",
            Variacao = "-2,4%",
            Tendencia = "-2,4%",
            IsPositivo = false,
            SparklineData = new double[] { 20, 18, 16, 15, 14, 12 },
            Cor = Color.Warning,
            CorHex = "#FF9800",
            Icone = Icons.Material.Filled.Assignment
        }
    };

    public static List<ProjetoPerformance> ObterPerformanceProjetos() => new()
    {
        new ProjetoPerformance { Nome = "Website Corporativo", Progresso = 83, TarefasInfo = "34 de 41 tarefas", TarefasConcluidas = 34, TarefasTotal = 41, Cor = Color.Primary, Icone = Icons.Material.Filled.Web },
        new ProjetoPerformance { Nome = "App Mobile", Progresso = 68, TarefasInfo = "27 de 41 tarefas", TarefasConcluidas = 27, TarefasTotal = 41, Cor = Color.Secondary, Icone = Icons.Material.Filled.PhoneIphone },
        new ProjetoPerformance { Nome = "Migração Cloud", Progresso = 92, TarefasInfo = "46 de 50 tarefas", TarefasConcluidas = 46, TarefasTotal = 50, Cor = Color.Success, Icone = Icons.Material.Filled.CloudUpload },
        new ProjetoPerformance { Nome = "Sistema ERP", Progresso = 54, TarefasInfo = "27 de 50 tarefas", TarefasConcluidas = 27, TarefasTotal = 50, Cor = Color.Warning, Icone = Icons.Material.Filled.Storage }
    };

    public static List<Atividade> ObterAtividadesRecentes() => new()
    {
        new Atividade { Iniciais = "MS", Nome = "Mariana Souza", Acao = "adicionou um novo cliente", Tempo = "há 5 minutos", CorAvatar = Color.Primary, Icone = Icons.Material.Filled.PersonAdd },
        new Atividade { Iniciais = "CL", Nome = "Carlos Lima", Acao = "finalizou a revisão Website Corporativo", Tempo = "há 18 minutos", CorAvatar = Color.Success, Icone = Icons.Material.Filled.CheckCircle },
        new Atividade { Iniciais = "AM", Nome = "Ana Martins", Acao = "publicou um novo relatório", Tempo = "há 45 minutos", CorAvatar = Color.Secondary, Icone = Icons.Material.Filled.Assessment },
        new Atividade { Iniciais = "JS", Nome = "João Silva", Acao = "atualizou as permissões do sistema", Tempo = "há 1 hora", CorAvatar = Color.Warning, Icone = Icons.Material.Filled.Security }
    };

    public static List<ProjetoRecente> ObterProjetosRecentes() => new()
    {
        new ProjetoRecente { Nome = "Portal Institucional", Cliente = "TechCorp", Responsavel = "Mariana Souza", IniciaisResponsavel = "MS", Status = "Em andamento", CorStatus = Color.Info, Progresso = 72, Prazo = "25 Set" },
        new ProjetoRecente { Nome = "Aplicativo Mobile", Cliente = "Nova Digital", Responsavel = "Carlos Lima", IniciaisResponsavel = "CL", Status = "Em revisão", CorStatus = Color.Warning, Progresso = 80, Prazo = "28 Set" },
        new ProjetoRecente { Nome = "Migração Cloud", Cliente = "CloudSystems", Responsavel = "Ana Martins", IniciaisResponsavel = "AM", Status = "Concluído", CorStatus = Color.Success, Progresso = 100, Prazo = "20 Set" },
        new ProjetoRecente { Nome = "Sistema ERP", Cliente = "Alpha Group", Responsavel = "João Silva", IniciaisResponsavel = "JS", Status = "Em andamento", CorStatus = Color.Info, Progresso = 48, Prazo = "15 Out" }
    };

    public static List<SegmentoCliente> ObterSegmentosClientes() => new()
    {
        new SegmentoCliente { Nome = "Tecnologia", Porcentagem = 40, Cor = Color.Primary, CorHex = "#594AE2" },
        new SegmentoCliente { Nome = "Saúde", Porcentagem = 30, Cor = Color.Secondary, CorHex = "#FF4081" },
        new SegmentoCliente { Nome = "Educação", Porcentagem = 20, Cor = Color.Info, CorHex = "#2196F3" },
        new SegmentoCliente { Nome = "Outros", Porcentagem = 10, Cor = Color.Warning, CorHex = "#FF9800" }
    };
}