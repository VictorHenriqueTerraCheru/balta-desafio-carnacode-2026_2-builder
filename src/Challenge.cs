// DESAFIO: Gerador de Relatórios Complexos
// PROBLEMA: Sistema precisa gerar diferentes tipos de relatórios (PDF, Excel, HTML)
// com múltiplas configurações opcionais (cabeçalho, rodapé, gráficos, tabelas, filtros)
// O código atual usa construtores enormes ou muitos setters, tornando difícil criar relatórios

using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de BI que gera relatórios customizados para diferentes departamentos
    // Cada relatório pode ter dezenas de configurações opcionais

    public class SalesReportBuilder
    {
        private SalesReport _report = new SalesReport();

        public SalesReportBuilder SetTitle(string title)
        {
            _report.Title = title;
            return this;
        }
        public SalesReportBuilder SetFormat(string format)
        {
            _report.Format = format;
            return this;
        }
        public SalesReportBuilder SetDateRange(DateTime start, DateTime end)
        {

            _report.StartDate = start;
            _report.EndDate = end;
            return this;
        }
        public SalesReportBuilder SetHeader(string text, bool show = true)
        {
            _report.HeaderText = text;
            _report.IncludeHeader = show;
            return this;
        }
        public SalesReportBuilder SetFooter(string text, bool show = true)
        {
            _report.FooterText = text;
            _report.IncludeFooter = show;
            return this;
        }
        public SalesReportBuilder SetChart(bool show, string type = "Bar")
        {
            _report.IncludeCharts = show;
            _report.ChartType = type;
            return this;
        }
        public SalesReportBuilder SetColumns(params string[] columns)
        {
            _report.Columns.AddRange(columns);
            return this;
        }
        public SalesReportBuilder SetFilters(params string[] filters)
        {
            _report.Filters.AddRange(filters);
            return this;
        }
        public SalesReportBuilder SetSummary(bool show = true)
        {
            _report.IncludeSummary = show;
            return this;
        }
        public SalesReportBuilder SetSortBy(string column)
        {
            _report.SortBy = column;
            return this;
        }
        public SalesReportBuilder SetGroupBy(string column)
        {
            _report.GroupBy = column;
            return this;
        }
        public SalesReportBuilder SetTotals(bool show = true)
        {
            _report.IncludeTotals = show;
            return this;
        }
        public SalesReportBuilder SetOrientation(string orientation)
        {
            _report.Orientation = orientation;
            return this;
        }
        public SalesReportBuilder SetPageSize(string size)
        {
            _report.PageSize = size;
            return this;
        }
        public SalesReportBuilder SetPageNumbers(bool show = true)
        {
            _report.IncludePageNumbers = show;
            return this;
        }
        public SalesReportBuilder SetCompanyLogo(string logoPath)
        {
            _report.CompanyLogo = logoPath;
            return this;
        }
        public SalesReportBuilder SetWaterMark(string text)
        {
            _report.WaterMark = text;
            return this;
        }
        public SalesReport Build()
        {
            if (string.IsNullOrEmpty(_report.Title))
                throw new InvalidOperationException("Title é obrigatório!");

            return _report;
        }
    }

    public class SalesReport
    {
        public string Title { get; set; }
        public string Format { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeHeader { get; set; }
        public bool IncludeFooter { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
        public bool IncludeCharts { get; set; }
        public string ChartType { get; set; }
        public bool IncludeSummary { get; set; }
        public List<string> Columns { get; set; }
        public List<string> Filters { get; set; }
        public string SortBy { get; set; }
        public string GroupBy { get; set; }
        public bool IncludeTotals { get; set; }
        public string Orientation { get; set; }
        public string PageSize { get; set; }
        public bool IncludePageNumbers { get; set; }
        public string CompanyLogo { get; set; }
        public string WaterMark { get; set; }

        // Problema: Construtor telescópico (muitos parâmetros)
        public SalesReport(
            string title,
            string format,
            DateTime startDate,
            DateTime endDate,
            bool includeHeader,
            bool includeFooter,
            string headerText,
            string footerText,
            bool includeCharts,
            string chartType,
            bool includeSummary,
            List<string> columns,
            List<string> filters,
            string sortBy,
            string groupBy,
            bool includeTotals,
            string orientation,
            string pageSize,
            bool includePageNumbers,
            string companyLogo,
            string waterMark)
        {
            Title = title;
            Format = format;
            StartDate = startDate;
            EndDate = endDate;
            IncludeHeader = includeHeader;
            IncludeFooter = includeFooter;
            HeaderText = headerText;
            FooterText = footerText;
            IncludeCharts = includeCharts;
            ChartType = chartType;
            IncludeSummary = includeSummary;
            Columns = columns;
            Filters = filters;
            SortBy = sortBy;
            GroupBy = groupBy;
            IncludeTotals = includeTotals;
            Orientation = orientation;
            PageSize = pageSize;
            IncludePageNumbers = includePageNumbers;
            CompanyLogo = companyLogo;
            WaterMark = waterMark;
        }

        // Alternativa problemática: Construtor vazio + setters
        public SalesReport()
        {
            Columns = new List<string>();
            Filters = new List<string>();
        }

        public void Generate()
        {
            Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
            Console.WriteLine($"Formato: {Format}");
            Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");
            
            if (IncludeHeader)
                Console.WriteLine($"Cabeçalho: {HeaderText}");
            
            if (IncludeCharts)
                Console.WriteLine($"Gráfico: {ChartType}");
            
            Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");
            
            if (Filters.Count > 0)
                Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");
            
            if (!string.IsNullOrEmpty(GroupBy))
                Console.WriteLine($"Agrupado por: {GroupBy}");
            
            if (IncludeFooter)
                Console.WriteLine($"Rodapé: {FooterText}");
            
            Console.WriteLine("Relatório gerado com sucesso!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Relatórios ===");

            var report1 = new SalesReportBuilder()
                .SetTitle("Vendas Mensais").SetFormat("PDF")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31))
                .SetHeader("Relatório de Vendas")
                .SetFooter("Confidencial")
                .SetChart(true, "Bar")
                .SetColumns("Produto", "Quantidade", "Valor")
                .SetFilters("Status=Ativo")
                .SetSummary(true)
                .SetSortBy("Valor")
                .SetGroupBy("Categoria")
                .SetTotals(true)
                .SetOrientation("Portrait")
                .SetPageSize("A4")
                .SetPageNumbers(true)
                .SetCompanyLogo("logo.png")
                .SetWaterMark("Confidencial")
                .Build();

            report1.Generate();

            var report2 = new SalesReportBuilder()
                .SetTitle("Relatório Trimestral")
                .SetFormat("Excel")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
                .SetColumns("Vendedor", "Região", "Total")
                .SetChart(true, "Line")
                .SetHeader("Relatório Trimestral")
                .SetGroupBy("Região")
                .SetTotals()
                .Build();

            report2.Generate();

            var report3 = new SalesReportBuilder()
                .SetTitle("Vendas Anuais")
                .SetFormat("PDF")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .SetHeader("Relatório de Vendas")
                .SetFooter("Confidencial")
                .SetColumns("Produto", "Quantidade", "Valor")
                .SetChart(true, "Pie")
                .SetTotals()
                .SetOrientation("Landscape")
                .SetPageSize("A4")
                .Build();

            report3.Generate();

            // Perguntas para reflexão:
            // - Como criar relatórios complexos sem construtores gigantes?
            // - Como garantir que configurações obrigatórias sejam definidas?
            // - Como reutilizar configurações comuns entre relatórios?
            // - Como tornar o processo de criação mais legível e fluente?
        }
    }
}
