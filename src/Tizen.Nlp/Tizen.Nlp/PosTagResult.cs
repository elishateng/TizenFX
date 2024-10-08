﻿/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Collections.Generic;
using System;

namespace Tizen.Nlp
{
    /// <summary>
    /// This class contains result of position tagged .
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [Obsolete("Deprecated since API11. Will be removed in API13.")]
    public class PosTagResult
    {
        /// <summary>
        /// The tokens of sentence.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Deprecated since API11. Will be removed in API13.")]
        public IList<string> Tokens { get; set; }

        /// <summary>
        /// The tags of sentence.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Deprecated since API11. Will be removed in API13.")]
        public IList<string> Tags { get; set; }
    }
}
