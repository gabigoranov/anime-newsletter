pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Deploy') {
            steps {
                // 1. Force a build of the new images inside the workspace
                sh "docker compose build --no-cache frontend backend"
                
                // 2. Tell compose to recreate and start ONLY those two apps
                sh "docker compose up -d --force-recreate frontend backend"
            }
        }
    }
}