using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace howto_listview_display_subitem_icons
{
    public static class ListViewExtensions
    {
#region "API Stuff"

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, ref LV_ITEM item_info);

        private struct LV_ITEM
        {
            public UInt32 uiMask;
            public Int32 iItem;
            public Int32 iSubItem;
            public UInt32 uiState;
            public UInt32 uiStateMask;
            public string pszText;
            public Int32 cchTextMax;
            public Int32 iImage;
            public IntPtr lParam;
        };

        public const Int32 LVM_FIRST = 0x1000;
        public const Int32 LVM_SETITEM = LVM_FIRST + 6;
        public const Int32 LVIF_IMAGE = 0x2;

        public const int LVW_FIRST = 0x1000;
        public const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVW_FIRST + 54;
        public const int LVM_GETEXTENDEDLISTVIEWSTYLE = LVW_FIRST + 55;

        public const int LVS_EX_SUBITEMIMAGES = 0x2;

#endregion "API Stuff"

        // Make the ListView's column headers.
        // The ParamArray entries should alternate between
        // strings and HorizontalAlignment values.
        public static void MakeColumnHeaders(
            this ListView lvw, params object[] header_info)
        {
            // Remove any existing headers.
            lvw.Columns.Clear();

            // Make the column headers.
            for (int i = header_info.GetLowerBound(0);
                     i <= header_info.GetUpperBound(0);
                     i += 3)
            {
                lvw.Columns.Add(
                    (string)header_info[i],
                    (int)header_info[i + 1],
                    (HorizontalAlignment)header_info[i + 2]);
            }
        }

        // Add a row to the ListView.
        public static void AddRow(this ListView lvw,
            string item_title, params string[] subitem_titles)
        {
            // Make the item.
            ListViewItem new_item = lvw.Items.Add(item_title, 1);

            // Make the sub-items.
            for (int i = subitem_titles.GetLowerBound(0);
                     i <= subitem_titles.GetUpperBound(0);
                     i++)
            {
                new_item.SubItems.Add(subitem_titles[i]);
            }
        }

        // Make the ListView display sub-item icons.
        public static void ShowSubItemIcons(this ListView lvw, bool show)
        {
            // Get the current style.
            int style = SendMessage(lvw.Handle,
                LVM_GETEXTENDEDLISTVIEWSTYLE, 0, 0);

            // Show or hide sub-item icons.
            if (show) style |= LVS_EX_SUBITEMIMAGES;
            else style &= (~LVS_EX_SUBITEMIMAGES);

            SendMessage(lvw.Handle,
                LVM_SETEXTENDEDLISTVIEWSTYLE, 0, style);
        }

        // Add an icon to a subitem.
        public static void AddIconToSubitem(this ListView lvw, int row, int col, int icon_num)
        {
            LV_ITEM lvi = new LV_ITEM();
            lvi.iItem = row;                        // Row.
            lvi.iSubItem = col;                     // Column.
            lvi.uiMask = LVIF_IMAGE;                // We're setting the image.
            lvi.iImage = icon_num;                  // The image index in the ImageList.

            // Send the LVM_SETITEM message.
            SendMessage(lvw.Handle, LVM_SETITEM, 0, ref lvi);
        }
    }
}
