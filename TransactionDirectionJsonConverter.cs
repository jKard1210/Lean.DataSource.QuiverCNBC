/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using QuantConnect.Orders;
using QuantConnect.Util;
using System;

namespace QuantConnect.DataSource
{
    /// <summary>
    /// Converts Quiver Quantitative <see cref="TransactionDirection"/> to <see cref="OrderDirection"/>
    /// </summary>
    public class TransactionDirectionJsonConverter : TypeChangeJsonConverter<OrderDirection, string>
    {
        /// <summary>
        /// Convert OrderDirection to string
        /// </summary>
        /// <param name="value">OrderDirection to convert</param>
        /// <returns>Resulting string</returns>
        protected override string Convert(OrderDirection value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Convert string to OrderDirection
        /// </summary>
        /// <param name="value">string to convert</param>
        /// <returns>Resulting OrderDirection</returns>
        protected override OrderDirection Convert(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "Bearish":
                case "Bullish":
                case "purchase":
                case "Buy":
                    return OrderDirection.Buy;
                case "Short":
                case "sale":
                case "Sell":
                    return OrderDirection.Sell;
                default:
                    return OrderDirection.Hold;
            }
        }
    }
}