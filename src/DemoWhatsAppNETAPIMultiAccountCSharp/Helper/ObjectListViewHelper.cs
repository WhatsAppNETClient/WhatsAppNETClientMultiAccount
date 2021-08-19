/**
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

using System.Drawing;
using System.Collections.Generic;

using BrightIdeasSoftware;

namespace DemoWhatsAppNETAPIMultiAccountCSharp
{
    public static class ObjectListViewHelper
    {
        public static void InitializeObjectListView(FastObjectListView olvFast, IList<ObjectListViewProperty> olvProperty, bool addRowNumber = true)
        {
            olvFast.HideSelection = false;
            olvFast.FullRowSelect = true;
            olvFast.UseAlternatingBackColors = true;
            olvFast.AlternateRowBackColor = Color.FromArgb(239, 239, 239);

            foreach (var item in olvProperty)
            {
                var olvColumn = new OLVColumn();
                olvColumn.CellPadding = null;
                olvColumn.Text = item.Header;
                olvColumn.Width = item.Width;
                olvColumn.IsEditable = item.IsEditable;
                olvColumn.FillsFreeSpace = item.IsFillsFreeSpace;
                olvColumn.TextAlign = item.TextAlign;
                olvColumn.Sortable = false;

                if (item.IsButton)
                {
                    olvColumn.IsButton = true;
                    olvColumn.ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds;
                }

                if (item.FieldName != null)
                    olvColumn.AspectName = item.FieldName;

                olvFast.AllColumns.Add(olvColumn);
            }

            olvFast.RebuildColumns();
            olvFast.RowHeight = 30;

            if (addRowNumber)
            {
                olvFast.FormatRow += delegate (object sender, BrightIdeasSoftware.FormatRowEventArgs e)
                {
                    var noUrut = e.DisplayIndex + 1;
                    e.Item.SubItems[0].Text = noUrut.ToString();                    
                };
            }
        }

        public static void AddObjects<T>(FastObjectListView olvFast, IList<T> record)
        {
            olvFast.ClearObjects();

            if (record.Count > 0)
            {
                var obj = record[0];

                if (obj != null)
                {
                    olvFast.SetObjects(record);
                    SelectObject(olvFast, obj);
                }
            }
        }

        public static void SelectObject(FastObjectListView olvFast, object obj)
        {
            olvFast.EnsureModelVisible(obj);
            olvFast.SelectObject(obj);
            olvFast.Focus();
        }
    }
}
