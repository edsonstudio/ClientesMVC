# ClientesMVC

## How to Implement ROSLYN in Your Project

![Banner](https://www.idslogic.com/blog/wp-content/uploads/2019/02/How-to-add-ROSLYN-in-Your-Project.jpg)

Asp.net and Sitefinity use a runtime compilation to compile assets together.  But the problem is whenever a new Sitefinity page is requested after build or recycle, there is a long wait time to reload the site.  It is runtime compilation.

ROSLYN is Microsoft’s new compiler that is approx. 6 times faster than the default compiler.

It is available with Sitefinity 10.1 and above and reduce the reloading time drastically.

 

### These are the steps to implement the same in the local development server:

1-Open the Sitefinity project in visual studio

2-Right-Click web project, and select Manage Nuget Packages

3-Search for “Roslyn” and install CodeDom.Providers.DotNetCompilerPlatform 2.0.1

![Screen](https://www.idslogic.com/blog/wp-content/uploads/2019/02/ROSLYN.png)

4-Build the project (This step is important, after successful build, it will add a Roslyn folder to the bin folder

![Screen](https://www.idslogic.com/blog/wp-content/uploads/2019/02/ROSLYN-2.png)


Also few lines of code will be added at the bottom of the web.config file.

To enable the same on the live server, you need to follow the below two steps.

1. Copy all bin folder dlls (including roslyn sub folder inside bin folder) to live project’s bin folder.

2. Add the new node at the bottom of the web.config (system.codedom) in the live web.config as well

## Contributed By
### Biswajit Mishra
