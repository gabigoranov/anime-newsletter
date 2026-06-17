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
                // Copy the fresh code directly into your production directory
                sh "cp -R \${WORKSPACE}/frontend/. /var/www/anime-newsletter/frontend/"
                sh "cp -R \${WORKSPACE}/backend/. /var/www/anime-newsletter/backend/"

                // Restart the apps without touching the network. Nginx stays perfectly connected.
                dir('/var/www/anime-newsletter') {
                    sh "docker compose restart frontend backend"
                }
            }
        }
    }
}