# WPF Image Processing Application
An application made using WPF C# .NET framework. It provides gaussian blur and adaptive thresholding.
Application uses parallel processing and downsampling for performance purposes. One of the features are XML serializing and image file handling (loading and saving).
Program has been made as an recruitment task and one of requirements was not to use any external library or framework except WPF and .NET Core.

## Project Specification (translated from polish version)
**Project goal:** Develop application displaying results of image processing using two filters.

This version of specification is translated from polish version. Original document send by a recruiting company can be found here:  
https://drive.google.com/file/d/1gqFqtpU35ErJ3qySEy_opUGdH_hDRqgU/view?usp=sharing.

### 1. Bradley’s adaptive thresholding
Bradley’s adaptive thresholding is an algorithm generating binarized images. Details of it's implementation can be found here:  
http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.420.7883&rep=rep1&type=pdf.  

Requirements:
* Loading image from file.
* Abillity to adjust parameters of the algorithm.
* Preview of result image.
* Saving processed image.

### 2. Gaussian Blur
Gaussian Blur is - as the name suggests - algorithm generating blurred image. 
It works by averaging adjacent pixels. If image is represented by more than one channel (eg. RGB), then for each channel two-dimentional array is being generated, containing integers ranging from 0 to 255. Example of such array is presented below.

1 | 2 | 5 | 2 | 0 | 3
--|---|---|---|---|--
3 | 2 | 5 | 1 | 6 | 0
4 | 3 | 6 | 2 | 1 | 4
0 | 4 | 0 | 3 | 4 | 2
9 | 6 | 5 | 0 | 3 | 9

How to get pixel blurred? Simply average it's value with adjacent pixels. Following example shows calculations performed while pocessing highlighted pixel `6`.

1 | 2 | 5 | 2 | 0 | 3
--|---|---|---|---|--
3 | 2 | 5 | 1 | 6 | 0
4 | 3 | `6` | 2 | 1 | 4
0 | 4 | 0 | 3 | 4 | 2
9 | 6 | 5 | 0 | 3 | 9

*(2 + 5 + 1 + 3 + `6` + 2 + 4 +0 + 3) / 9 = 2,88*

Range of neighbouring pixels, which need to be averaged, is determined by a kernel (sometimes called mask or stencil). Kernel used in above example has been of size 3x3 and filled only with ones, what translates into following area and values.

1 | 2 | 5 | 2 | 0 | 3
--|---|---|---|---|--
3 | 2 * 1 | 5 * 1 | 1 * 1 | 6 | 0
4 | 3 * 1 | `6` * 1 | 2 * 1 | 1 | 4
0 | 4 * 1 | 0 * 1 | 3 * 1 | 4 | 2
9 | 6 | 5 | 0 | 3 | 9

This operation needs to be repeated for every pixel in every channel. Blur generated in this way is low quality. To improve the quality, other and more complex kernel have to be used. Next example also covers kernel of size 3x3 filled with following values.

0.0 | 0.2 | 0.0
----|-----|----
0.2 | 0.2 | 0.2
0.0 | 0.2 | 0.0

Again, highlighted `6` pixel will be used as example.  
*0.0 * 2 + 0.2 * 5 + 0.0 * 1 + 0.2 * 3 + 0.2 * 6 + 0.2 * 2 + 0.0 * 4 + 0.2 * 0 + 0.0 * 3 = 3.2*  
Sum of kernel values is equal to *0.0 + 0.2 + 0.0 + 0.2 + 0.2 + 0.2 + 0.0 + 0.2 + 0.0 = 1.0*  
Therefore final value of disscused pixel is equal to *3.2 / 1.0 = 3.2*  
Gaussian blur is also described in this video:
https://youtu.be/C_zFhWdM4ic

Requirements:
* Loading image from file.
* Abillity to define custom kernel, save and read it from file.
* Preview of result image.
* Saving processed image.
* Gaussian blur filter can be implemented using parallel processing. This feature is additional and will be appreciated.
