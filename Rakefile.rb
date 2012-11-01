include Rake::DSL
require 'albacore'
require 'version_bumper'

GRIKLY_CORE_DIR = 'src/GriklyApi.Portable/bin/release/GriklyApi.Portable.dll'

task :deploy,[:build] => [:zip, :nuget_push] do
end

zip :zip => :output do | zip |
	Dir.mkdir("build") unless Dir.exists?("build")
    zip.directories_to_zip "out"
    zip.output_file = "Grikly.v#{bumper_version.to_s}.zip"
    zip.output_path = "build"
end

output :output => :test do |out|
	out.from '.'
	out.to 'out'
	out.file GRIKLY_CORE_DIR, :as=>'GriklyApi.Portable.dll'
	out.file 'LICENSE.txt'
	out.file 'README.md'
	out.file 'VERSION'
end

desc "Test"
nunit :test => :build do |nunit|
	nunit.command = "tools/NUnit/nunit-console.exe"
	nunit.assemblies "tests/bin/Release/Grikly.Tests.dll"
end

desc "Build"
msbuild :build => :assemblyinfo do |msb|
  msb.properties :configuration => :Release
  msb.targets :Clean, :Build
  msb.solution = "Grikly.sln"
end

nugetpush :nuget_push => :nup do |nuget|
    nuget.command = "nuget.exe"
    nuget.package = "Grikly.#{bumper_version.to_s}.nupkg"
    nuget.apikey = "#{Configuration::Build.api_key}"
    nuget.create_only = true
end

##This does not work from albacore.
#nugetpack :nup => :nus do |nuget|
#   nuget.command     = "tools/NuGet/NuGet.exe"
#   nuget.nuspec      = "Grikly.nuspec"
#   nuget.base_folder = "out/"
#   nuget.output      = "build/"
#end

##use this until patched
task :nup => :nus do
	sh "tools/NuGet/NuGet.exe pack -BasePath out/ -Output build/ out/Grikly.nuspec"
end

nuspec :nus => :output do |nuspec|
   nuspec.id="Grikly"
   nuspec.version = bumper_version.to_s
   nuspec.authors = "Shawn Mclean"
   nuspec.description = "Grikly is an API wrapper to help developers getting started with the grikly api fast and easy."
   nuspec.title = "Grikly"
   nuspec.language = "en-US"
   nuspec.licenseUrl = "http://www.apache.org/licenses/LICENSE-2.0"
   nuspec.dependency "Newtonsoft.Json", "4.5.0.0"
   nuspec.projectUrl = "https://github.com/Xormis/grikly-dotnet"
   nuspec.working_directory = "out/"
   nuspec.output_file = "Grikly.nuspec"
   nuspec.file "GriklyApi.Portable.dll", "lib"
end


assemblyinfo :assemblyinfo do |asm|
  asm.version = bumper_version.to_s
  asm.file_version = bumper_version.to_s
  asm.company_name = "Self"
  asm.product_name = "Grikly"
  asm.copyright = "Shawn Mclean (c) 2012"
  asm.output_file = "AssemblyInfo.cs"
end