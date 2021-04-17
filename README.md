# Zipper
Web file archiver using .Net 5


## How to use
To use this, you have two possibilities:

### Main way
Using the extension method below will return an IActionResult with your zipped file ready to download.

```ZippedFileResult(this Controller controller, IEnumerable<IFormFile> files, string fileName = "")```

[(see this example)](https://github.com/mtctr/Zipper/blob/main/Example/Zipper.Example/Controllers/ZipController.cs)

### Secondary way
Just call the method that actualy does the job and get a byte array with your zipped files, so you can do whatever you want with it.

```GetZippedFileAsByteArray(IEnumerable<IFormFile> files)```

[source](https://github.com/mtctr/Zipper/blob/main/Zipper/Zipper.Core/Zip.cs)

DISCLAIMER: 
This was made just for fun
