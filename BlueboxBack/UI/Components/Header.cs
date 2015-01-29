using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI.Components
{
    class Header : DataGridView
    {
        private HeaderType headerType;
        private Core.DataHandler dataHandler;

        public enum HeaderType
        {
            Horizontal,
            Vertical
        }

        public Header(short width, short height, HeaderType headerType, DataHandler dataHandler)
        {
            InitializeComponent(width, height);
            FillData(headerType, dataHandler);
            this.headerType = headerType;
            this.dataHandler = dataHandler;
        }

        private void FillData(HeaderType type, DataHandler dataHandler)
        {
            DataTable table = new DataTable();
            short[][] arr = dataHandler.GetHeadersData(type);
            for (int i = 0; i < arr[0].Length; i++)
            {
                table.Columns.Add();
            }
            
            foreach (short[] line in arr)
            {
                object[] arrInt = new object[line.Length];
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if(line[i] != 0)
                    {
                        arrInt[i] = line[i];
                    }
                }
                table.Rows.Add(arrInt);
            }
            DataSource = table;
        }

        private void InitializeComponent(short width, short height)
        {
            ScrollBars = ScrollBars.None;
            RowCount = height;
            ColumnCount = width;
            Width = width * Constants.CELL_SIDE;
            Height = height * Constants.CELL_SIDE;

            RowHeadersVisible = false;
            ColumnHeadersVisible = false;
            EditMode = DataGridViewEditMode.EditProgrammatically;

            foreach(DataGridViewColumn column in Columns)
            {
                column.MinimumWidth = Constants.CELL_SIDE;
                column.Width = Constants.CELL_SIDE;
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in Rows)
            {
                row.MinimumHeight = Constants.CELL_SIDE;
                row.Height = Constants.CELL_SIDE;
                row.Resizable = DataGridViewTriState.False;
            }
            
            BackgroundColor = Color.LightGray;
        }
    }
}