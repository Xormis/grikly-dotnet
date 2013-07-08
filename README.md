# Grikly Dot Net

## NuGet

Visual Studio users can install this directly into their .NET projects by executing the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

    PM> Install-Package Grikly


## Description

Grikly Dot Net is a library that wraps the [Grikly](http://grik.ly/) API. This is an Async Portable class library which has support for silverlight, windows phone 7.1 and WinRT.

## Usage



#### Sample Source:

Synchronous:



Asychronous:



#### Api methods Covered


	
## Necessary prerequisites



## Contributing

#### Building the source

The source can be built from the rake task `rake build` or using visual studio. If using rake, ensure `albacore`
and `version_bumper` gems are installed. Rename `rakefile.config.example.rb` to `rakefile.config.rb`. 

For running tests, ensure to rename `AppSettings.example.config` to `AppSettings.config` and 
set your own Api Key in the test project. Tests can be executed from rake: `rake test` or from any nunit test runner
tool.

#### Contributors


## Change Log

