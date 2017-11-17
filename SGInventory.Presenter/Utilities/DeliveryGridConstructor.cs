using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SGInventory.Model;
using System.Windows.Forms;
using SGInventory.Enums;
using SGInventory.Presenters.Model;
using SGInventory.Helpers;

namespace SGInventory.Presenters.Utilities
{
    internal class DeliveryGridConstructor
    {        
        internal const string ColumnColorName = "colDescriptionName",
                                ColumnTotal = "colTotal",
                                HeaderTag ="Header";
        const int COL_WIDTH = 50;
        internal DeliveryGridConstructor()
        {
        }

        internal void CreateDeliveries(List<SupplierDelivery> deliveries, DataGridView gvDeliveryDetails,string headerName)
        {
            var initialIndex = 0;
            if (gvDeliveryDetails.Columns.Count == 0)
            {
                gvDeliveryDetails.Columns.Add(ColumnColorName, "");                      
            }
            
            initialIndex = gvDeliveryDetails.Rows.Add(headerName);
            gvDeliveryDetails.Rows[initialIndex].Tag = HeaderTag;

            gvDeliveryDetails.Rows[initialIndex].DefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Yellow };

            var container = new Dictionary<string, List<Tuple<string, int>>>();
            var indexByProductName = new Dictionary<string, int>();
            var rowIndex =initialIndex+ 1;
            deliveries.ForEach((delivery) =>
            {

                var sizeName = delivery.SizeName;

                if (container.ContainsKey(delivery.ProductDescription))
                {
                    container[delivery.ProductDescription]
                    .Add(Tuple.Create<string, int>(sizeName, delivery.Quantity));

                }
                else
                {
                    indexByProductName.Add(delivery.ProductDescription, rowIndex);
                    container.Add(delivery.ProductDescription, new List<Tuple<string, int>> { Tuple.Create<string, int>(sizeName, delivery.Quantity) });
                    rowIndex += 1;
                }


            });

            var colTotal = 0;
            var rowTotal = 0;
            foreach (var key in container.Keys)
            {
                var productDetails = container[key];
                gvDeliveryDetails.Rows.Add(key);
                var currentRowIndex = indexByProductName[key];
                foreach (var productDetail in productDetails)
                {
                    var colSize = string.Concat("col", productDetail.Item1);
                    if (!gvDeliveryDetails.Columns.Contains(colSize))
                    {                        
                        CreateColumn(gvDeliveryDetails, colSize, productDetail.Item1);
                        gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value = productDetail.Item2;
                        colTotal += productDetail.Item2;
                    }
                    else
                    {
                        var previousValue = gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value == null ? 0 : (int)gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value;
                        var newValue = previousValue + productDetail.Item2;

                        gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value = newValue;
                        colTotal += newValue;

                    }
                }

                rowTotal += colTotal;
                colTotal = 0;
            }           
        }

        internal void CreateColumn(DataGridView gv, string colName, string headerText)
        {
            var colInt = gv.Columns.Add(colName, headerText);
            gv.Columns[colInt].Width = COL_WIDTH;
        }
       
        internal void SummarizeGridDisplay(DataGridView gridView)
        {
            var colIndex = gridView.Columns.Add(ColumnTotal,"Total");
            gridView.Columns[colIndex].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Red };
            gridView.Columns[colIndex].Width = 75;

            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Tag == null)
                {
                    var totalCount = 0;
                    for (var i = 1; i < colIndex; i++)
                    {
                        var previousCount = row.Cells[i].Value == null ? 0 : (int)row.Cells[i].Value;
                        totalCount += previousCount;
                    }

                    row.Cells[colIndex].Value = totalCount;
                }
            }
        }
                
        internal void CreateGoodDeliveries(List<DeliveryDetail> goodDeliveries, DataGridView gvDeliveryDetails)
        {
            gvDeliveryDetails.Columns.Add(ColumnColorName, "");
            gvDeliveryDetails.Rows.Add("Good");
            gvDeliveryDetails.Rows[0].DefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Yellow };

            var container = new Dictionary<string,List<Tuple<string,int>>>();
            var indexByColorName = new Dictionary<string, int>();
            var rowIndex = 1;
            goodDeliveries.ForEach((delivery) => {  
               
                var sizeName = delivery.ProductDetail.Size.Name;

                if (container.ContainsKey(delivery.ProductDetail.Color.Name))
                {
                    container[delivery.ProductDetail.Color.Name]
                    .Add(Tuple.Create<string, int>(sizeName, delivery.Quantity));
                    
                }
                else
                {
                    indexByColorName.Add(delivery.ProductDetail.Color.Name, rowIndex);
                    container.Add(delivery.ProductDetail.Color.Name, new List<Tuple<string, int>> { Tuple.Create<string, int>(sizeName, delivery.Quantity) });
                    rowIndex += 1;
                }

               
            });

            var colTotal = 0;
            var rowTotal = 0;
            foreach (var key in container.Keys)
            {
                var productDetails = container[key];
                gvDeliveryDetails.Rows.Add(key);
                var currentRowIndex = indexByColorName[key];
                foreach (var productDetail in productDetails)
                {
                    var colSize = string.Concat("col",productDetail.Item1);
                    if (!gvDeliveryDetails.Columns.Contains(colSize))
                    {
                        var colInt = gvDeliveryDetails.Columns.Add(colSize, productDetail.Item1);
                        //gvDeliveryDetails.Columns[colInt].Width = COL_WIDTH;
                        gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value = productDetail.Item2;
                        colTotal += productDetail.Item2;
                    }
                    else
                    {
                        var previousValue = gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value==null?0: (int)gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value;
                        var newValue = previousValue + productDetail.Item2;

                        gvDeliveryDetails.Rows[currentRowIndex].Cells[colSize].Value = newValue;
                        colTotal += newValue;

                    }                                        
                }

                rowTotal += colTotal;
                colTotal = 0;
            }


            gvDeliveryDetails.Columns.Add(ColumnTotal, "");
            var lastColumnIndex = gvDeliveryDetails.Columns.Count-1;
            colTotal = 0;
            foreach(var color in indexByColorName.Keys)
            {
                var totalInColumn = 0;
                var index = indexByColorName[color];

                for (var i = 1; i <= lastColumnIndex; i++)
                {
                    if (i != lastColumnIndex)
                    {
                        if (gvDeliveryDetails.Rows[index].Cells[i].Value != null)
                        {
                            totalInColumn += (int)gvDeliveryDetails.Rows[index].Cells[i].Value;
                        }                      
                    }
                    else
                    {
                        gvDeliveryDetails.Rows[index].Cells[i].Value = totalInColumn;
                    }
                    
                }
            }
            var indexOfSumOfTheTotalGoodDeliveries = gvDeliveryDetails.Rows.Add();
            gvDeliveryDetails.Rows[indexOfSumOfTheTotalGoodDeliveries].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Red };
            gvDeliveryDetails.Rows[indexOfSumOfTheTotalGoodDeliveries].Cells[lastColumnIndex].Value = rowTotal;
                        
        }

        internal void CreateBadDeliveries(List<DeliveryDetail> badDeliveries, DataGridView gvDeliveryDetails)
        {
            if (gvDeliveryDetails.Columns.Count == 0)
            {
                gvDeliveryDetails.Columns.Add(ColumnColorName, "");
                gvDeliveryDetails.Columns.Add(ColumnTotal, "");
            }

            var currentRow = gvDeliveryDetails.Rows.Add("Damage");
            gvDeliveryDetails.Rows[currentRow].DefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.Yellow };

            var rowTotal = 0;
            var indexByDamageDescription = new Dictionary<string, int>();
            
            var columnName = gvDeliveryDetails.Columns[gvDeliveryDetails.ColumnCount-1].Name;

            badDeliveries.ForEach((badDelivery) => {
                var item = Enum.GetName(typeof(Damage), badDelivery.Damage.Value);

                if (!indexByDamageDescription.ContainsKey(item))
                {
                    currentRow = gvDeliveryDetails.Rows.Add(item);
                    indexByDamageDescription.Add(item, currentRow);
                    rowTotal += badDelivery.Quantity;
                    gvDeliveryDetails.Rows[currentRow].Cells[columnName].Value = badDelivery.Quantity;
                }
                else
                {
                    var index = indexByDamageDescription[item];
                    var previousValue = (int)gvDeliveryDetails.Rows[index].Cells[columnName].Value;
                    rowTotal = rowTotal = previousValue;
                    var newValue = previousValue + badDelivery.Quantity;
                    rowTotal+=newValue;
                }
                currentRow+=1;
            });

            var indexOfSumOfTheTotalBadDeliveries = gvDeliveryDetails.Rows.Add();
            gvDeliveryDetails.Rows[indexOfSumOfTheTotalBadDeliveries].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Red };
            gvDeliveryDetails.Rows[indexOfSumOfTheTotalBadDeliveries].Cells[columnName].Value = rowTotal;

        }
    }
}
