// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

´╗┐namespace Nest
{
	/// <summary>
	/// A token filter of type uppercase that normalizes token text to upper case.
	/// </summary>
	public interface IUppercaseTokenFilter : ITokenFilter { }

	/// <inheritdoc />
	public class UppercaseTokenFilter : TokenFilterBase, IUppercaseTokenFilter
	{
		public UppercaseTokenFilter() : base("uppercase") { }
	}

	/// <inheritdoc />
	public class UppercaseTokenFilterDescriptor
		: TokenFilterDescriptorBase<UppercaseTokenFilterDescriptor, IUppercaseTokenFilter>, IUppercaseTokenFilter
	{
		protected override string Type => "uppercase";
	}
}
