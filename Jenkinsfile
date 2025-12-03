		pipeline {
    agent any

stages {
        
	  stage('Checkout') {
            steps {
                echo "[${new Date().format('HH:mm:ss')}] Cleaning workspace..."
                deleteDir()
                checkout scm
            }
        }

	
	stage('Build') {
            steps {
                echo 'Building...'
            }
        }

stage('Test') {
            steps {
                echo 'Testing...'
            }
        }

stage('Deploy') {
            steps {
                echo 'Deploying...'
            }
        }
    }
}
