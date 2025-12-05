		pipeline {
    agent any
environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
        SOLUTION_NAME = "Batch25JenkinsPipeline.sln"
        PROJECT_PATH = "Batch25JenkinsPipline\\Batch25JenkinsPipeline.csproj"
        NEXUS_URL = "http://localhost:8081/repository/nuget-hosted-Test/"
        PS_SCRIPT_PATH = "C:\\Tools\\commonbuild\\NugetPackagePublish.ps1"
        Project_Name = "Batch25JenkinsPipline"
        
    }

stages {
        
	  stage('Checkout') {
            steps {
                echo "[${new Date().format('HH:mm:ss')}] Cleaning workspace..."
                deleteDir()
                checkout scm
            }
        }
	
  stage('Restore Packages') {
            steps {
                echo "Restoring NuGet packages..."
                bat "dotnet restore ${env.SOLUTION_NAME}"
            }
        }

	
	stage('Build') {
            steps {
                   echo "⚙️ Building .NET project..."
                bat "dotnet build ${env.PROJECT_PATH} -c Release --no-restore"
            }
        }
  stage('SonarQube Analysis') {
    steps {
        script {
            def scannerHome = tool 'SonarScanner for MSBuild'

            withSonarQubeEnv('MySonarQube') {
                // Step 1: Sonar Begin
                bat """
                \"${scannerHome}\\SonarScanner.MSBuild.exe\" begin ^
                    /k:\"${env.Project_Name}_${env.BRANCH_NAME}\" ^
                    /n:\"${env.Project_Name} (${env.BRANCH_NAME})\" ^
                    /v:\"${env.BUILD_NUMBER}\" ^
                    /d:sonar.cs.opencover.reportsPaths=\"**/coverage.opencover.xml\" ^
                    /d:sonar.coverage.exclusions=\"**/*Migrations*/**\"
                """

                // Step 2: Build
                bat "dotnet build ${env.SOLUTION_NAME} -c Release"

				echo 'Testting...'
                // Step 3: Test with Coverage
               bat """
    dotnet test ${env.SOLUTION_NAME} ^
        --settings \"${WORKSPACE}\\coverlet.runsettings\" ^
        --logger \"trx;LogFileName=TestResults.trx\" ^
        /p:CollectCoverage=true ^
        /p:CoverletOutput=\"${WORKSPACE}\\TestResults\\coverage.opencover.xml\" ^
        /p:CoverletOutputFormat=opencover
    """

                // Step 4: Sonar End
                bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end"
            }
        }
    }
}


stage('Deploy') {
            steps {
                echo 'Deploying...'
            }
        }
    }
}
