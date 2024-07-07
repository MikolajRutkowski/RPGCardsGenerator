using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace RPGCardsGenerator.Classes
{
    public static class TablePainter
    {
        public static void AddCellBorders(System.Windows.Controls.RichTextBox richTextBox, SolidColorBrush borderBrush, double borderThickness)
        {
            // Ensure the RichTextBox has a FlowDocument
            if (richTextBox.Document == null)
                return;

            // Loop through all blocks in the FlowDocument
            foreach (Block block in richTextBox.Document.Blocks)
            {
                // Only process Table elements
                if (block is Table table)
                {
                    foreach (TableRowGroup rowGroup in table.RowGroups)
                    {
                        foreach (TableRow row in rowGroup.Rows)
                        {
                            foreach (TableCell cell in row.Cells)
                            {
                                // Set the border properties for the cell
                                cell.BorderBrush = borderBrush;
                                cell.BorderThickness = new Thickness(borderThickness);
                            }
                        }
                    }
                }
            }
        }
        public static  void MakeCellColor(string badString, System.Windows.Controls.RichTextBox richTextBox, SolidColorBrush colorBrush)
        {
            // Ensure the RichTextBox has a FlowDocument
            if (richTextBox.Document == null)
                return;

            // Loop through all blocks in the FlowDocument
            foreach (Block block in richTextBox.Document.Blocks)
            {
                // Only process Table elements
                if (block is Table table)
                {
                    foreach (TableRowGroup rowGroup in table.RowGroups)
                    {
                        foreach (TableRow row in rowGroup.Rows)
                        {
                            foreach (TableCell cell in row.Cells)
                            {
                                // Get the text content of the cell
                                string cellText = new TextRange(cell.ContentStart, cell.ContentEnd).Text.Trim();

                                // Check if the cell text matches the badString exactly
                                if (cellText == badString)
                                {
                                    // Change the background color of the cell
                                    cell.Background = colorBrush;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
