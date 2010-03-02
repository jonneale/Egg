require 'rake'
require 'rake/tasklib'
require 'dotnetvariables'
require 'albacore'

SOURCE_DIR = File.expand_path('RakeTest')
SOLUTION = File.join(SOURCE_DIR, "RakeTest.sln")
OUTPUTDIRECTORY = File.join(SOURCE_DIR, "RakeTest.Domain/bin/Debug/")
TESTDLL = File.join(SOURCE_DIR, "RakeTest.UnitTests/bin/Debug/RakeTest.UnitTests.dll")
PACKAGEDIRECTORY = "RakeTest/Package"
CONFIG = "Debug"

task :default => [:buildsolution]

task :buildsolution => [:compile, :tests, :copyfiles]

msbuild :compile do |msb|
	msb.properties :configuration => :Debug
	msb.targets :Clean, :Build
	msb.solution = SOLUTION
end

nunit :tests do |nunit|
	nunit.path_to_command = "C:/Program Files/NUnit 2.5.2/bin/net-2.0/nunit-console.exe"
	nunit.assemblies TESTDLL
end


task :copyfiles do
	mkpath PACKAGEDIRECTORY
	cp_r OUTPUTDIRECTORY, PACKAGEDIRECTORY
end

task :create_directories do
	two_directories = ['folder1', 'folder2']
	two_directories.each do |directory|
		puts directory
	end
end

#task :compile do 
	#sh "#{DOT_NET_PATH}msbuild.exe /p:Configuration=#{CONFIG} #{SOLUTION}"
#end 