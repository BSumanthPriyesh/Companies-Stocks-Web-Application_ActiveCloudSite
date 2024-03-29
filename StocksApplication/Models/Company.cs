﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StocksApplication.Models
{
	public class Company
	{
		[Key]
		public string Symbol { get; set; }

		public string? Name { get; set; }

		public DateTime Date { get; set; }

		public string? Type { get; set; }

		public string? Iexid { get; set; }

		public bool IsEnabled { get; set; }
	}
}
