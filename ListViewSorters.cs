using System;
using System.Collections;
using System.Windows.Forms;

namespace ImapClient
{
    public class ListViewItemDateSorter : IComparer
    {
        private readonly int _columnToSort;
        private readonly SortOrder _sortOrder;

        public ListViewItemDateSorter(int columnToSort, SortOrder sortOrder)
        {
            _columnToSort = columnToSort;
            _sortOrder = sortOrder;
        }

        public int Compare(object xobject, object yobject)
        {
            ListItemTagInfo x;
            ListItemTagInfo y;

            x = (ListItemTagInfo)((ListViewItem)xobject).Tag;
            y = (ListItemTagInfo)((ListViewItem)yobject).Tag;

            if (_sortOrder == SortOrder.Descending)
            {
                return y.DateTime.CompareTo(x.DateTime);
            }
            else
            {
                return x.DateTime.CompareTo(y.DateTime);
            }
        }
    }

    public class ListViewItemNameSorter : IComparer
    {
        private readonly int _columnToSort;
        private readonly SortOrder _sortOrder;

        public ListViewItemNameSorter(int columnToSort, SortOrder sortOrder)
        {
            _columnToSort = columnToSort;
            _sortOrder = sortOrder;
        }

        public int Compare(object xobject, object yobject)
        {
            ListViewItem x = (ListViewItem)xobject;
            ListViewItem y = (ListViewItem)yobject;
            string xname, yname;

            if (_columnToSort == 0)
            {
                xname = x.Text;
                yname = y.Text;
            }
            else
            {
                xname = x.SubItems[_columnToSort].Text;
                yname = y.SubItems[_columnToSort].Text;
            }

            int result = xname.CompareTo(yname);

            if (_sortOrder == SortOrder.Descending)
                result = -result;

            return result;
        }
    }

    public class ListViewItemSizeSorter : IComparer
    {
        private readonly int _columnToSort;
        private readonly SortOrder _sortOrder;

        public ListViewItemSizeSorter(int columnToSort, SortOrder sortOrder)
        {
            _columnToSort = columnToSort;
            _sortOrder = sortOrder;
        }

        public int Compare(object xobject, object yobject)
        {
            ListItemTagInfo x;
            ListItemTagInfo y;

            x = (ListItemTagInfo)((ListViewItem)xobject).Tag;
            y = (ListItemTagInfo)((ListViewItem)yobject).Tag;

            if (_sortOrder == SortOrder.Descending)
            {
                return y.Length.CompareTo(x.Length);
            }
            else
            {
                return x.Length.CompareTo(y.Length);
            }
        }
    }
}