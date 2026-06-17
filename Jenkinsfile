pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        stage('Deploy to Docker') {
            steps {
                script {
                    echo "Deploying only application containers..."
                    
                    // TARGET SPECIFIC SERVICES: This prevents Jenkins from trying to recreate itself!
                    sh "docker compose up -d --build backend frontend"
                }
            }
        }

        stage('Housekeeping') {
            steps {
                script {
                    echo "Cleaning up dangling images..."
                    sh "docker image prune -f"
                }
            }
        }
    }
}