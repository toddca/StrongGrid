using StrongGrid.Utilities;
using System.Runtime.Serialization;

namespace StrongGrid.Models.Search
{
	/// <summary>
	/// Base class for search criteria classes on the value of a custom tracking argument.
	/// </summary>
	/// <remarks>
	/// UniqueArgs are only supported when searching for email activities.
	/// That's why this class derives from SearchCriteria&lt;EmailActivitiesFilterField&gt; instead of ISearchCriteria.
	/// </remarks>
	public abstract class SearchCriteriaUniqueArg : SearchCriteria<EmailActivitiesFilterField>
	{
		/// <summary>
		/// Gets or sets the name of the unique argument.
		/// </summary>
		public string UniqueArgName { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SearchCriteriaUniqueArg"/> class.
		/// </summary>
		/// <param name="uniqueArgName">The name of the unique arg.</param>
		/// <param name="filterOperator">The filtering operator.</param>
		/// <param name="filterValue">The filter value.</param>
		public SearchCriteriaUniqueArg(string uniqueArgName, SearchConditionOperator filterOperator, object filterValue)
		{
			UniqueArgName = uniqueArgName;
			FilterOperator = filterOperator;
			FilterValue = filterValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SearchCriteriaUniqueArg"/> class.
		/// </summary>
		protected SearchCriteriaUniqueArg()
		{
		}

		/// <summary>
		/// Converts the filter value into a string as expected by the SendGrid Email Activities API.
		/// Can be overridden in subclasses if the value needs special formatting.
		/// </summary>
		/// <returns>The string representation of the value.</returns>
		public override string ConvertValueToString()
		{
			return Utils.ConvertValueToStringForSearching(FilterValue);
		}

		/// <summary>
		/// Converts the filter operator into a string as expected by the SendGrid Email Activities API.
		/// Can be overridden in subclasses if the operator needs special formatting.
		/// </summary>
		/// <returns>The string representation of the operator.</returns>
		public override string ConvertOperatorToString()
		{
			return FilterOperator.GetAttributeOfType<EnumMemberAttribute>()?.Value ?? FilterOperator.ToString();
		}

		/// <summary>
		/// Returns a string representation of the search criteria.
		/// </summary>
		/// <returns>A <see cref="string"/> representation of the search criteria.</returns>
		public override string ToString()
		{
			var filterOperator = ConvertOperatorToString();
			var filterValue = ConvertValueToString();
			return $"(unique_args['{UniqueArgName}']{filterOperator}{filterValue})";
		}
	}
}
