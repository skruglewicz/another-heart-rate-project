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
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Result of a batch operation on a particular time series hierarchy.
    /// Hierarchy is set when operation is successful and error object is set
    /// when operation is unsuccessful.
    /// </summary>
    public partial class TimeSeriesHierarchyOrError
    {
        /// <summary>
        /// Initializes a new instance of the TimeSeriesHierarchyOrError class.
        /// </summary>
        public TimeSeriesHierarchyOrError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TimeSeriesHierarchyOrError class.
        /// </summary>
        /// <param name="hierarchy">Time series hierarchy object - set when the
        /// operation is successful.</param>
        /// <param name="error">Error object - set when the operation is
        /// unsuccessful.</param>
        public TimeSeriesHierarchyOrError(TimeSeriesHierarchy hierarchy = default(TimeSeriesHierarchy), TsiErrorBody error = default(TsiErrorBody))
        {
            Hierarchy = hierarchy;
            Error = error;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets time series hierarchy object - set when the operation is
        /// successful.
        /// </summary>
        [JsonProperty(PropertyName = "hierarchy")]
        public TimeSeriesHierarchy Hierarchy { get; private set; }

        /// <summary>
        /// Gets error object - set when the operation is unsuccessful.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public TsiErrorBody Error { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Hierarchy != null)
            {
                Hierarchy.Validate();
            }
        }
    }
}