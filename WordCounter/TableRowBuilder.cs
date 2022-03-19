using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WordCounter {
    public class TableRowBuilder {
        public TableRow Build(int id, string word, int quantity) {

            var row = new TableRow();

            var idParagraph = new Paragraph(new Run(id.ToString()));
            idParagraph.TextAlignment = TextAlignment.Center;
            idParagraph.Foreground = Brushes.White;

            var idTableCell = new TableCell();
            idTableCell.BorderBrush = Brushes.White;
            idTableCell.BorderThickness = new Thickness(1, 1, 1 ,1);
            idTableCell.Padding = new Thickness(3, 2, 0, 2);
            idTableCell.Blocks.Add(idParagraph);

            var wordParagraph = new Paragraph(new Run(word));
            wordParagraph.Foreground = Brushes.White;
            var wordTableCell = new TableCell();
            wordTableCell.BorderBrush = Brushes.White;
            wordTableCell.BorderThickness = new Thickness(1, 1, 1 ,1);
            wordTableCell.Padding = new Thickness(3, 2, 0, 2);
            wordTableCell.Blocks.Add(wordParagraph);

            var quantityParagraph = new Paragraph(new Run(quantity.ToString()));
            quantityParagraph.TextAlignment = TextAlignment.Center;
            quantityParagraph.Foreground = Brushes.White;

            var quantityTableCell = new TableCell();
            quantityTableCell.BorderBrush = Brushes.White;
            quantityTableCell.BorderThickness = new Thickness(1, 1, 1 ,1);
            quantityTableCell.Padding = new Thickness(3, 2, 0, 2);
            quantityTableCell.Blocks.Add(quantityParagraph);

            row.Cells.Add(idTableCell);
            row.Cells.Add(wordTableCell);
            row.Cells.Add(quantityTableCell);

            return row;
        }
    }
}
