using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SqlRegularExpressionsTest
{
	class Program
	{
		static void Main(string[] args)
		{
			String text = 
				"This is comprehensive compendium provides a broad and thorough investigation of all "
				+ "aspects of programming with ASP.Net. Entirely revised and updated for the 2.0 "
				+ "Release of .Net, this book will give you the information you need to master ASP.Net "
				+ "and build a dynamic, successful, enterprise Web application.";
			String pattern = @"\b(a\S+)";
			IEnumerable matches = SqlRegularExpressions.GetMatches(text, pattern);

			foreach (Match match in matches)
			{
				int index = match.Index;
			}

		}
	}
}
