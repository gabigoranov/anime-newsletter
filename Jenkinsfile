pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                // This pulls your latest Git commit onto the VPS workspace
                checkout scm
            }
        }

        stage('Deploy to Docker') {
            steps {
                script {
                    echo "Stopping old containers, rebuilding, and starting new ones..."
                    
                    // Jenkins leverages the mounted docker.sock to run this on your host VPS
                    sh "docker compose up -d --build"
                }
            }
        }

        stage('Housekeeping') {
            steps {
                script {
                    echo "Cleaning up dangling images to save space on Contabo..."
                    sh "docker image prune -f"
                }
            }
        }
    }
    
    post {
        success {
            echo "Pipeline completed successfully! Your site is updated."
        }
        failure {
            echo "Something went wrong during the build."
        }
    }
}