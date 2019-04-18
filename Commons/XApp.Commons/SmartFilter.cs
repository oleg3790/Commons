using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace XApp.Commons
{
    public static class SmartFilter
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string BuildDataRowFilter(List<string> filterableColumns, string searchCriteria)
        {
            string filter = string.Empty;

            List<string> searchList = BuildSearchCriteriaList(searchCriteria);
            List<string> filterList = new List<string>();
            string queryConjunction = string.Empty;

            if (searchList.All(x => x.Contains("=")))
            {
                queryConjunction = "and";

                foreach (string searchItem in searchList)
                {
                    string field = Regex.Match(searchItem, "^(.+)=").Groups[1].Value;

                    if (filterableColumns.Any(x => x.ToLower().Equals(field.ToLower())))
                        filterList.Add(string.Format("{0} like '%{1}%'", Regex.Match(searchItem, "^(.+)=").Groups[1], Regex.Match(searchItem, "=(.+)$").Groups[1]));
                }                        
            }    
            else
            {
                queryConjunction = "or";

                foreach (string searchItem in searchList)
                    foreach (string column in filterableColumns)
                        filterList.Add(string.Format("{0} like '%{1}%'", column, searchItem));
            }
            
            if (filterList.Count != 0)    
                filter = filterList.Aggregate((x, y) => string.Format("{0} {1} {2}", x, queryConjunction, y));

            return filter;
        }

        private static List<string> BuildSearchCriteriaList(string searchCriteria)
        {
            searchCriteria = Regex.Replace(searchCriteria, @"[^A-Za-z0-9= ]", string.Empty); //Escape any characters that are used in rowfilter query
            List<string> searchCriteriaList = searchCriteria.Split(' ').ToList();
            log.Debug($"{searchCriteriaList.Count} search criteria items found");
            searchCriteriaList.RemoveAll(x => string.IsNullOrWhiteSpace(x));
            return searchCriteriaList;
        }
    }
}
