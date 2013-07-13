#region © Copyright 2009, Roman Khramtsov / Major League - SqlRegularExpressions
// SqlRegularExpressions
// 
// © Copyright 2009, Roman Khramtsov / Major League
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution. 
//  * Neither the name of Rudy.net, XmlHelper, nor the names of its contributors 
//    may be used to endorse or promote products derived from this software
//    without specific prior written permission. 
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
// EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Data.SqlTypes;			//SqlChars
using System.Collections;			//IEnumerable
using System.Text.RegularExpressions;		//Match, Regex
using Microsoft.SqlServer.Server;				//SqlFunctionAttribute


/// <summary>
/// Class that allows to support regular expressions in MS SQL Server 2005/2008
/// </summary>
public partial class SqlRegularExpressions
{
	/// <summary>
	/// Checks string on match to regular expression
	/// </summary>
	/// <param name="text">string to check</param>
	/// <param name="pattern">regular expression</param>
	/// <returns>true - text consists match one at least, false - no matches</returns>
	[SqlFunction]
	public static bool Like(string text, string pattern)
	{
		Match match = Regex.Match(text, pattern);
		return (match.Value != String.Empty);
	}

	/// <summary>
	/// Gets matches from text using pattern
	/// </summary>
	/// <param name="text">text to parse</param>
	/// <param name="pattern">regular expression pattern</param>
	/// <returns>MatchCollection</returns>
	[SqlFunction(FillRowMethodName="FillMatch")]
	public static IEnumerable GetMatches(string text, string pattern)
	{
		return Regex.Matches(text, pattern
			//, RegexOptions.IgnoreCase       //uncomment this to ignore case when matching occurs
			);
	}

	/// <summary>
	/// Parses match-object and returns its parameters 
	/// </summary>
	/// <param name="obj">Match-object</param>
	/// <param name="index">TThe zero-based starting position in the original string where the captured
	///     substring was found</param>
	/// <param name="length">The length of the captured substring.</param>
	/// <param name="value">The actual substring that was captured by the match.</param>
	public static void FillMatch(object obj, out int index, out int length, out SqlChars value)
	{
		Match match = (Match)obj;
		index = match.Index;
		length = match.Length;
		value = new SqlChars(match.Value);
	}

}

