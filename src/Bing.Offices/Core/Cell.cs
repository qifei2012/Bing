﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bing.Offices.Abstractions;
using Bing.Utils.Extensions;

namespace Bing.Offices.Core
{
    /// <summary>
    /// 单元格
    /// </summary>
    public class Cell:IExcelCell
    {
        #region 属性

        /// <summary>
        /// 列跨度
        /// </summary>
        private int _columnSpan;

        /// <summary>
        /// 行跨度
        /// </summary>
        private int _rowSpan;

        /// <summary>
        /// 单元行
        /// </summary>
        public IExcelRow Row { get; set; }

        /// <summary>
        /// 单元格值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 列跨度
        /// </summary>
        public int ColumnSpan
        {
            get { return _columnSpan; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _columnSpan = value;
            }
        }

        /// <summary>
        /// 行跨度
        /// </summary>
        public int RowSpan
        {
            get { return _rowSpan; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }

                _rowSpan = value;
            }
        }

        /// <summary>
        /// 是否需要合并单元格。true:是,false:否
        /// </summary>
        public bool NeedMerge => ColumnSpan > 1 || RowSpan > 1;

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get
            {
                Row.CheckNotNull("Row");
                return Row.RowIndex;
            }
        }

        /// <summary>
        /// 列索引
        /// </summary>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// 结束行索引
        /// </summary>
        public int EndRowIndex => RowIndex + RowSpan - 1;

        /// <summary>
        /// 结束列索引
        /// </summary>
        public int EndColumnIndex => ColumnIndex + ColumnSpan - 1;

        /// <summary>
        /// 空单元格
        /// </summary>
        public static IExcelCell Null => new NullCell();

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化一个<see cref="Cell"/>类型的实例
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="columnSpan">列跨度</param>
        /// <param name="rowSpan">行跨度</param>
        public Cell(object value, int columnSpan = 1, int rowSpan = 1)
        {
            Value = value;
            ColumnSpan = columnSpan;
            RowSpan = rowSpan;
        }

        #endregion

        #region SetValue(设置单元格值)

        /// <summary>
        /// 设置单元格值
        /// </summary>
        /// <param name="value">值</param>
        public void SetValue(object value)
        {
            this.Value = value;
        }

        #endregion

    }
}
