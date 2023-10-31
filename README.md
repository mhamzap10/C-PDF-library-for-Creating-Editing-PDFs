# C# PDF library for Creating & Editing PDFs

IronPDF is a .NET library that allows developers to create, manipulate, and render PDF documents within their .NET applications. It provides a convenient way to work with PDF files in C# and VB.NET. This repository contains the example of a .NET Create PDF application to create PDF from URL and HTML Content using IronPDF Library.

PDF Format or Portable document format is a widely used format for sharing files across the globe.

## Steps to build a PDF Generator Application in .NET MVC

### Step 1: Download the project

Save this project to a directory on your computer, and then launch Visual Studio by opening the solution file.

### Step 2: Rebuild the solution

Rebuild the solution to install the required NuGet package.

### Step 3: Add UI Controls in Views:

In this example, we get URL and HTML Content from the Text Area. We will use the check box to define if a PDF needs to be created from URL or HTML Content.

#### Create PDF File Model Class:
```
 public class CreatePDFModel
 {
     [DataType(DataType.MultilineText)]
     public string Content { get; set; }
     [DisplayName("Create From URL")]
     public bool isURL { get; set; }
 }
```
This code defines a C# class called CreatePDFModel. It has two properties:

1. Content, which is a text field for input (with the attribute specifying it's for multiple lines of text). This will be used to take URL and HTML Content Input.

2. isURL, a boolean property used to determine if the content should be created from a URL. This will be used to bind the check box to decide if a PDF is to be created from the URL or HTML string.

Change the Code in the Index.cshtml file:

Add the following code to the Index.cshtml file.

```
@model CreatePDF.Models.CreatePDFModel

@{
    ViewData["Title"] = "CreatePDF";
}

<h1>Create PDF</h1>

<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="CreatePDF">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Content" class="control-label"></label>
                <textarea asp-for="Content" class="form-control"></textarea>
                <span asp-validation-for="Content" class="text-danger"></span>
            </div>
            <div class="form-group form-check">
                <label class="form-check-label">
                    <input class="form-check-input" asp-for="isURL" /> @Html.DisplayNameFor(model => model.isURL)
                </label>
            </div>
            <div class="form-group">
                <input type="submit" value="Create PDF" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>
```
It uses the CreatePDFModel class as the model and defines a form for creating a PDF. Users can input content in a text area, check a box to specify whether the content is a URL, and then click the "Create" button to submit the form.

This view provides a user interface for creating a PDF by entering content into a text area and specifying whether that content is a URL via the checkbox. When the user clicks the "Create File" button, the form data will be submitted to the "CreatePDF" action in the Home controller to generate a PDF file.

### Step 4: Add Action method:

Add the following action method in Home to Controller to create PDF files. The following method allows users to input content, and based on their choice (URL or HTML), it creates a PDF document and provides it for download as "myPDF.pdf."
```
[HttpPost]
public FileResult CreatePDF(CreatePDFModel model)
{
    var renderer = new ChromePdfRenderer();
    PdfDocument pdfDoc;
    if (model.isURL)
    {
        pdfDoc = renderer.RenderUrlAsPdf(model.Content);
    }
    else
    {
        pdfDoc = renderer.RenderHtmlAsPdf(model.Content);
    }
    byte[] fileBytes = pdfDoc.BinaryData;
    string fileName = "myPDF.pdf";
    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, fileName);
}
```
This C# method, tagged with the [HttpPost] attribute, is designed to handle HTTP POST requests in an ASP.NET Core application. It accepts a CreatePDFModel object called model as a parameter. This will be invoked when the User clicks on the Create PDF File Button. The IronPDF library help us to work with pdf by writing just a few lines of code.

It initializes a ChromePdfRenderer object of IronPDF, which is used to render PDF documents.

It checks the isURL property of the model to determine whether the PDF should be created from a URL or HTML content. If isURL is true, it utilizes the RenderUrlAsPdf method (provided by the Iron PDF library) to generate a PDF file from the content provided in the model. If isURL is false, it uses RenderHtmlAsPdf (provided by the Iron PDF library) to create a PDF document from the HTML content.

The binary data of the generated PDF is obtained from pdfDoc. The file name is set as "myPDF.pdf".

Finally, it returns the PDF as a File result, making it available for the user to download. The content type of the file is set to "application/pdf," and the file is named "myPDF.pdf," which the user can save to their device. In this way, It will generate a pdf file in C#.

### Step 5: Run the Program to Generate PDF Files:

Run the program by Pressing Ctrl + F5, or Pressing on Run Button from the Microsoft Visual Studio. The following UI will open. We have made the UI simple for the demonstration, you can design it as per choice.

![image](https://github.com/mhamzap10/C-PDF-library-for-Creating-Editing-PDFs/assets/48279611/47082359-8914-4137-9224-82e4ce40e4ff)

#### Create a PDF File from the URL:

Enter a URL in the text box, and check the Button "Create From URL" as shown below.

![image](https://github.com/mhamzap10/C-PDF-library-for-Creating-Editing-PDFs/assets/48279611/9c852f42-1c44-420b-941e-525f324a240a)

Click on the button for creating pdf file. The generated pdf document will be downloaded to your download folder. The PDF Page Design is the same as Wikipedia Design. This shows that IronPDF Preserves the design. The following is our first pdf document generated by IronPDF the .NET PDF library.

![image](https://github.com/mhamzap10/C-PDF-library-for-Creating-Editing-PDFs/assets/48279611/e9453443-b078-40b6-912d-758646494605)

#### Create a PDF Document from HTML Content:

Write the text in the text box. I have written "This is my Sample PDF File" as shown below. Uncheck the "Create from URL" Checkbox.'

![image](https://github.com/mhamzap10/C-PDF-library-for-Creating-Editing-PDFs/assets/48279611/dca72ffb-8bb2-48a7-a8c9-783ed0a04178)

Click on the Create PDF Button to create a new PDF document.

![image](https://github.com/mhamzap10/C-PDF-library-for-Creating-Editing-PDFs/assets/48279611/bf356639-dadc-4418-92f3-ced4a9ce019e)

We can create PDF documents programmatically, manipulate an existing PDF document, or Convert HTML File to a PDF.
