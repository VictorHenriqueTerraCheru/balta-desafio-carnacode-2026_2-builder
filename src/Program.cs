using System;
using DesignPatternChallenge.Builders;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Relatórios ===");

            var report1 = new SalesReportBuilder()
                .SetTitle("Vendas Mensais")
                .SetFormat("PDF")
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
        }
    }
}
