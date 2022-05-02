using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace StocksApplication.Models
{
	public class Repository : IRepository
	{
		private readonly AppDbContext _appDbContext;

		private List<Company> companies;

		public Repository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Company>> GetAllCompanies()
        {
			return await _appDbContext.Companies.ToListAsync();

		}

		public bool SaveCompanies(List<Company> companies)
		{
			bool anyNewRcordsInserted = false;
			var missingRecords = from cs in companies
								 join cd in _appDbContext.Companies
									 on cs.Symbol equals cd.Symbol into pp
								 from cd in pp.DefaultIfEmpty()
								 where cd == null
								 select cs;
			int count = missingRecords.ToList().Count;
			if (count != 0)
			{
				foreach (Company c in missingRecords)
				{
					_appDbContext.Companies.Add(c);
					anyNewRcordsInserted = true;
				}
				_appDbContext.SaveChanges();
			}

			return anyNewRcordsInserted;
		}

		public void SaveCompanyQuote(CompanyQuote companyQuote)
		{
			_appDbContext.CompaniesQuote.Add(companyQuote);
			_appDbContext.SaveChanges();
		}

		public void SaveCompanyDetails(CompanyDetails companyDetails)
		{
			CompanyDetails companyInfo = new CompanyDetails();

			//when the records is missing insert in database
			if (_appDbContext.CompanyDetails.Where(x => x.Symbol == companyDetails.Symbol).Count() == 0)
			{
				_appDbContext.CompanyDetails.Add(companyDetails);
			}

			//else
			//{
			//	// when the record is already present in database
			//	companyInfo = _appDbContext.CompanyDetails.Where(x => x.Symbol == companyDetails.Symbol).FirstOrDefault();

			//	// if record is found updating the column values with latest values obtained from API call.
			//	if (
			//		!companyInfo.CompanyName.Equals(companyDetails.CompanyName, StringComparison.OrdinalIgnoreCase) ||
			//		!companyInfo.CEO.Equals(companyDetails.CEO, StringComparison.OrdinalIgnoreCase) ||
			//		!companyInfo.Exchange.Equals(companyDetails.Exchange, StringComparison.OrdinalIgnoreCase)
			//		)
			//	{
			//		companyInfo.CompanyName = companyDetails.CompanyName.Trim();
			//		companyInfo.CEO = companyDetails.CEO.Trim();
			//		companyInfo.Exchange = companyDetails.Exchange.Trim();

			//	}
			//}
			_appDbContext.SaveChanges();
		}

		public void SaveCompanyLatestDividend(List<CompanyDividend> companyDividend)
		{
			if (companyDividend != null && companyDividend.Count != 0)
			{
				foreach (CompanyDividend c in companyDividend)
				{
					_appDbContext.CompanyDividend.Add(c);
				}
				_appDbContext.SaveChanges();
			}
		}
		public DataTable GetCompaniesCount()
		{
			var counts = _appDbContext.Companies.GroupBy(x => x.Type)
					  .Select(c => new { c.Key, Count = c.Count() });
			DataTable dt = new DataTable();
			dt.Columns.Add("Type", System.Type.GetType("System.String"));
			dt.Columns.Add("Count", System.Type.GetType("System.Int32"));


			foreach (var v in counts)
			{
				DataRow dr = dt.NewRow();
				dr["Type"] = v.Key;
				dr["Count"] = v.Count;
				dt.Rows.Add(dr);


			}
			return dt;
		}
		public bool SaveFeedback(Feedback feedback)
        {
            bool isFeedbackSaved = false;
            if (feedback != null)
            {
                _appDbContext.Feedback.Add(feedback);
                isFeedbackSaved = true;
            }
            return isFeedbackSaved;
        }
    }
}
