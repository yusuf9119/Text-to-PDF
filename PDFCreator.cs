import com.itextpdf.io.font.PdfEncodings;
import com.itextpdf.kernel.font.PdfFont;
import com.itextpdf.kernel.font.PdfFontFactory;
import com.itextpdf.kernel.pdf.PdfDocument;
import com.itextpdf.kernel.pdf.PdfWriter;
import com.itextpdf.layout.Document;
import com.itextpdf.layout.element.Paragraph;
import com.itextpdf.layout.property.TextAlignment;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class PDFCreator {

    public static void main(String[] args) {
        String inputFile = "C:\Users\yusuf\OneDrive\Documents\input.txt"; 
        String outputFile = "C:\Users\yusuf\OneDrive\Documents\output.pdf"; 

        try {
            PdfWriter writer = new PdfWriter(outputFile);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            PdfFont regularFont = PdfFontFactory.createFont(/* Path to regular font */, Arial.regularFont);
            PdfFont italicFont = PdfFontFactory.createFont(/* Path to italic font */, Arial.italicFont,);
            PdfFont boldFont = PdfFontFactory.createFont(/* Path to bold font */,Arial.boldFont);

            BufferedReader reader = new BufferedReader(new FileReader(inputFile));
            String line;
            Paragraph paragraph = new Paragraph();

            while ((line = reader.readLine()) != null) {
                String[] parts = line.split(" ");
                String command = parts[0].toLowerCase();

                switch (command) {
                    case ".large":
                        // Handle large font size
                       
                        break;
                    case ".normal":
                        // Handle normal font size
                      
                        break;
                    case ".paragraph":
                        document.add(paragraph);
                        paragraph = new Paragraph();
                        break;
                    case ".fill":
                        paragraph.setTextAlignment(TextAlignment.JUSTIFIED);
                        break;
                    case ".nofill":
                        paragraph.setTextAlignment(TextAlignment.LEFT);
                        break;
                    case ".regular":
                        paragraph.setFont(regularFont);
                        break;
                    case ".italic":
                        paragraph.setFont(italicFont);
                        break;
                    case ".bold":
                        paragraph.setFont(boldFont);
                        break;
                    case ".indent":
                        // Handle indentation
                      
                        break;
                    default:
                        paragraph.add(line);
                        break;
                }
            }

            document.add(paragraph);
            reader.close();

           
            document.close();
            pdf.close();
            System.out.println("PDF created successfully!");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
