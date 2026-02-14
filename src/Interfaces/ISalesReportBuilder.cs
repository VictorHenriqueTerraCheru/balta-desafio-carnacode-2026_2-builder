using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Interfaces
{
    public interface ISalesReportBuilder
    {
        ISalesReportBuilder SetTitle(string title);
        ISalesReportBuilder SetFormat(string format);
        ISalesReportBuilder SetDateRange(DateTime start, DateTime end);
        ISalesReportBuilder SetHeader(string text, bool show = true);
        ISalesReportBuilder SetFooter(string text, bool show = true);
        ISalesReportBuilder SetChart(bool show, string type = "Bar");
        ISalesReportBuilder SetColumns(params string[] columns);
        ISalesReportBuilder SetFilters(params string[] filters);
        ISalesReportBuilder SetSummary(bool show = true);
        ISalesReportBuilder SetSortBy(string column);
        ISalesReportBuilder SetGroupBy(string column);
        ISalesReportBuilder SetTotals(bool show = true);
        ISalesReportBuilder SetOrientation(string orientation);
        ISalesReportBuilder SetPageSize(string size);
        ISalesReportBuilder SetPageNumbers(bool show = true);
        ISalesReportBuilder SetCompanyLogo(string logoPath);
        ISalesReportBuilder SetWaterMark(string text);
        SalesReport Build();
    }
}
