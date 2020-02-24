using System;
using System.Collections.Generic;

namespace StrongGrid.Models.Search
{
	/// <summary>
	/// Filter the result of a search for the value of a field to be a value.
	/// </summary>
	/// <typeparam name="TEnum">The type containing an enum of fields that can used for searching/segmenting.</typeparam>
	public class SearchCriteriaIs<TEnum> : SearchCriteria<TEnum>
		where TEnum : Enum
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SearchCriteriaIs{TEnum}"/> class.
		/// </summary>
		/// <param name="filterField">The filter field.</param>
		/// <param name="filterValues">The filter values.</param>
		public SearchCriteriaIs(TEnum filterField, IEnumerable<object> filterValues)
			: base(filterField, SearchConditionOperator.Is, filterValues)
		{
		}

		/// <summary>
		/// Converts the filter operator into a string as expected by the SendGrid Email Activities API.
		/// </summary>
		/// <returns>The string representation of the operator.</returns>
		public override string ConvertOperatorToString()
		{
			return $" {base.ConvertOperatorToString()} ";
		}
	}
}
