// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.TimeSeriesInsights.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Request to get the event schema of all events within a given search
    /// span.
    /// </summary>
    public partial class GetEventSchemaRequest
    {
        /// <summary>
        /// Initializes a new instance of the GetEventSchemaRequest class.
        /// </summary>
        public GetEventSchemaRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GetEventSchemaRequest class.
        /// </summary>
        /// <param name="searchSpan">The range of time on which the query is
        /// executed. Cannot be null.</param>
        public GetEventSchemaRequest(DateTimeRange searchSpan)
        {
            SearchSpan = searchSpan;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the range of time on which the query is executed.
        /// Cannot be null.
        /// </summary>
        [JsonProperty(PropertyName = "searchSpan")]
        public DateTimeRange SearchSpan { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (SearchSpan == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SearchSpan");
            }
            if (SearchSpan != null)
            {
                SearchSpan.Validate();
            }
        }
    }
}