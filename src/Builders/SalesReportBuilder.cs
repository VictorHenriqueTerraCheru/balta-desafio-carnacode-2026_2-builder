using System;
using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Builders
{
    public class SalesReportBuilder : ISalesReportBuilder
    {
        private SalesReport _report = new SalesReport();

        public ISalesReportBuilder SetTitle(string title)
        {
            _report.Title = title;
            return this;
        }

        public ISalesReportBuilder SetFormat(string format)
        {
            _report.Format = format;
            return this;
        }

        public ISalesReportBuilder SetDateRange(DateTime start, DateTime end)
        {
            _report.StartDate = start;
            _report.EndDate = end;
            return this;
        }

        public ISalesReportBuilder SetHeader(string text, bool show = true)
        {
            _report.HeaderText = text;
            _report.IncludeHeader = show;
            return this;
        }

        public ISalesReportBuilder SetFooter(string text, bool show = true)
        {
            _report.FooterText = text;
            _report.IncludeFooter = show;
            return this;
        }

        public ISalesReportBuilder SetChart(bool show, string type = "Bar")
        {
            _report.IncludeCharts = show;
            _report.ChartType = type;
            return this;
        }

        public ISalesReportBuilder SetColumns(params string[] columns)
        {
            _report.Columns.AddRange(columns);
            return this;
        }

        public ISalesReportBuilder SetFilters(params string[] filters)
        {
            _report.Filters.AddRange(filters);
            return this;
        }

        public ISalesReportBuilder SetSummary(bool show = true)
        {
            _report.IncludeSummary = show;
            return this;
        }

        public ISalesReportBuilder SetSortBy(string column)
        {
            _report.SortBy = column;
            return this;
        }

        public ISalesReportBuilder SetGroupBy(string column)
        {
            _report.GroupBy = column;
            return this;
        }

        public ISalesReportBuilder SetTotals(bool show = true)
        {
            _report.IncludeTotals = show;
            return this;
        }

        public ISalesReportBuilder SetOrientation(string orientation)
        {
            _report.Orientation = orientation;
            return this;
        }

        public ISalesReportBuilder SetPageSize(string size)
        {
            _report.PageSize = size;
            return this;
        }

        public ISalesReportBuilder SetPageNumbers(bool show = true)
        {
            _report.IncludePageNumbers = show;
            return this;
        }

        public ISalesReportBuilder SetCompanyLogo(string logoPath)
        {
            _report.CompanyLogo = logoPath;
            return this;
        }

        public ISalesReportBuilder SetWaterMark(string text)
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
}
