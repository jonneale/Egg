require 'rake'
require 'rake/tasklib'
require 'dotnetvariables'
require 'albacore'

SOURCE_DIR = File.expand_path('RakeTest')
SOLUTION = File.join(SOURCE_DIR, "RakeTest.sln")
OUTPUTDIRECTORY = File.join(SOURCE_DIR, "RakeTest.Domain/bin/Debug/")
TESTDLL = File.join(SOURCE_DIR, "RakeTest.UnitTests/bin/Debug/RakeTest.UnitTests.dll")
PACKAGEDIRECTORY = File.join(SOURCE_DIR, "/Package/")

task :default => [:buildsolution]

task :buildsolution => [:compile, :tests, :copyfiles, :replace_values]

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
	rm_r PACKAGEDIRECTORY
	mkpath PACKAGEDIRECTORY
	cp_r "#{OUTPUTDIRECTORY}.", PACKAGEDIRECTORY
	
	@app_config_file_name = File.join(PACKAGEDIRECTORY, "App.config")
	File.delete(@app_config_file_name)
	File.rename(File.join(PACKAGEDIRECTORY, "Master_App.config"), @app_config_file_name)
end

task :replace_values do
	File.open(@app_config_file_name, "r+") do |f|
		s = f.read.sub(/%%ReplaceMe%%/, "WithMe")
          f.rewind
          f.write s
	end
end

#task :compile do 
	#sh "#{DOT_NET_PATH}msbuild.exe /p:Configuration=#{CONFIG} #{SOLUTION}"
#end 