﻿/**
 * Copyright (C) 2021 Kamarudin (http://wa-net.coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/WhatsAppNETClient/WhatsAppNETClientMultiSession
 */

using System.Windows.Forms;

namespace DemoWhatsAppNETAPIMultiAccountCSharp
{
    public sealed class ObjectListViewProperty
    {
        public string Header { get; set; }
        public string FieldName { get; set; }
        public int Width { get; set; }
        public bool IsEditable { get; set; }
        public bool IsFillsFreeSpace { get; set; }
        public bool IsButton { get; set; }
        public HorizontalAlignment TextAlign { get; set; }
    }
}
