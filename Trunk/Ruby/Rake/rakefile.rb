require 'dotnetvariables.rb'
SOLUTION = "RakeTest/RakeTest.sln"
OUTPUTDIRECTORY = "RakeTest/RakeTest.Domain/bin/Debug/"
PACKAGEDIRECTORY = "RakeTest/Package"
CONFIG = "Debug"

task :default => [:buildsolution]

task :buildsolution => [:compile, :copyfiles]

task :compile do 
	sh "#{DOT_NET_PATH}msbuild.exe /p:Configuration=#{CONFIG} #{SOLUTION}"
end 

task :copyfiles do
	mkpath PACKAGEDIRECTORY
	cp_r OUTPUTDIRECTORY, PACKAGEDIRECTORY
end

desc "This task should be run before test"
task :butFirstYouMustRunMe do 
	puts "Im first"
end

task :test => :butFirstYouMustRunMe do
	puts "This should work"
end

task :create_directories do
	two_directories = ['folder1', 'folder2']
	two_directories.each do |directory|
		puts directory
	end
end